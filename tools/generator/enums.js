import fs from 'fs';
import * as path from 'path';
import * as helper from './helpers/index.js';

const nameMapping = {
    'ToString': 'ToStringX'
};
const javaNameNamping = {
    'StyleProjectionName': 'ProjectionName'
}

generateEnums() ;

function generateEnums() {
    var info = JSON.parse(fs.readFileSync('enums.json', 'utf8'));   
    
    info.enums.map(x => generateEnum(info, x));
}

async function generateEnum(repoInfo, enumInfo) {
    var output = path.join(repoInfo.mauiRepo, enumInfo.output);
    if (!fs.existsSync(output)) {        
        fs.mkdirSync(output);
    }

    var input = path.join(repoInfo.mapboxRepo, enumInfo.input, enumInfo.name);
    var content = fs.readFileSync(input, 'utf8');
    var objcName = '';
    var csName = '';
    var javaName = '';
    var cases = {};
    var skipped = false;
    var scopedName = '';
    var lines = content.split('\n')
        .map(line => {
            if (/public extension (\w+)/.test(line.trim())) {
                scopedName = /public extension (\w+)/.exec(line.trim())[1];
                return '__NA__';
            }

            if (/^import/.test(line)) {
                return "__NA__";
            }

            if (/^public struct/.test(line.trim())) {
                skipped = true;
                let matches = /struct (\w+)/.exec(line.trim())
                objcName = matches[1];
                csName = scopedName + objcName;
                javaName = javaNameNamping[objcName] ?? objcName;
                
                objcName =!!scopedName
                    ? `TMB${scopedName}${objcName}`
                    : `TMB${objcName}`;
                scopedName = '';

                return `public readonly struct ${csName} : INamedString
{
    public string Value { get; }

    private ${csName}(string value) => Value = value;
    public override string ToString() =>  Value;    

    public static implicit operator string(${csName} value) => value.Value;
    public static implicit operator ${csName}(string value) => new (value);
`
            }

            if (/public init/.test(line)
                 || /rawValue/.test(line)) {
                skipped = true;
            }

            if (/^public static let/.test(line.trim())) {
                skipped = false;
                let matches = /public static let (\w+).+("[^"]+")/.exec(line.trim())
                let caseKey = helper.pascalCase(matches[1]);
                let caseValue = matches[2] ?? `"${matches[1]}"`;
                cases[caseKey] = caseValue;
                let staticFieldName = nameMapping[caseKey] || caseKey;

                return `    public static readonly ${csName} ${staticFieldName} = new (${caseValue});`;
            }

            if (skipped) {
                return '__NA__';
            }

            if (/^@/.test(line.trim())) {
                return line.replace('@', '// @')
            }

            return line;
        }).filter(x => x != '__NA__');
    
    fs.writeFileSync(
        path.join(output, enumInfo.name.replace('.swift', '.cs')), 
        [
            `namespace MapboxMaui;
`
        ]
        .concat(lines)
        .join('\n') + '\n}');
}

function generateIOSMapping(csName, objcName, cases) {
    var objcQualifiedName = `MapboxMapsObjC.${objcName}`;
    return `#if IOS    
partial class ${csName}Extensions
{
    public static ${objcQualifiedName} ToPlatform(this ${csName} value)
    {
        return value.Value switch 
        {
${Object.entries(cases).map(x => `            ${x[1]} => ${objcQualifiedName}.${x[0]}`).join(',\n')}
        };
    }

    public static ${csName} ToPlatform(this ${objcQualifiedName} value)
    {
        return value switch 
        {
${Object.entries(cases).map(x => `            ${objcQualifiedName}.${x[0]} => ${x[1]}`).join(',\n')}
        };
    }

    public static ${csName} ${csName}X(this Foundation.NSNumber value)
    {
        return value.${csName}().ToPlatform();
    }

    public static Foundation.NSNumber AsNumber(this ${csName} value)
    {
        return Foundation.NSNumber.FromInt32((int)ToPlatform(value));
    }
}
#endif`;
}

function generateAndroidMapping(csName, javaName, cases, enumInfo) {
    var javaQualifiedName = `${(enumInfo.javaNs ?? '')}${javaName}`;
    return `#if ANDROID    
partial class ${csName}Extensions
{
    public static ${javaQualifiedName} ToPlatform(this ${csName} value)
    {
        return ${javaQualifiedName}.ValueOf(
            value.Value.ToUpper(new System.Globalization.CultureInfo("en-US"))
        );
    }
}
#endif`;
}