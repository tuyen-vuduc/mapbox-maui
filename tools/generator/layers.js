import fs from 'fs';
import * as path from 'path';
import * as helper from './helpers/index.js';

const swift2CsTypeMapping = {
    'Double': 'double',
    'Bool': 'bool',
    'String': 'string',
    'StyleColor': 'Color'
};

await generateLayers() ;

async function generateLayers() {
    const info = JSON.parse(fs.readFileSync('layers.json', 'utf8')); 
    const output = path.join(info.mauiRepo, info.output)
    if (!fs.existsSync(output)) {        
        fs.mkdirSync(output)
    }
    
    const input = path.join(info.mapboxRepo, info.input);
    await fs.readdirSync(input)
        // .filter(x => !info.ignored.some(y => x.endsWith(y + '.swift')))
        // .map(x => /(\w+)\.swift/.exec(x)[1])
        .forEach(x => generateCs(path.join(input, x), output));
}

async function generateCs(swiftFile, outputDir) {
    const content = fs.readFileSync(swiftFile, 'utf8');
    if (content.indexOf('@_spi(Experimental) public struct') > -1) {
        return;
    }
    const fileName = /(\w+).swift/.exec(swiftFile)[1];
    const layerName = /(\w+)Layer/.exec(fileName)[1];

    const hasSource = content.indexOf('public init(id: String, source: String)') > -1;
    let shouldSkip = false;

    const lines = content.split('\n')
        .filter(x => 
            !(/^@/.test(x.trim())) // Ignore swift directive
            && !(/^import /.test(x.trim())) // Ignore import directives
            && x != '// This file is generated.'
        );
    
    const layoutKeys = getKeys(lines, (x) => { return /enum LayoutCodingKeys:/.test(x) });
    const paintKeys = getKeys(lines, (x) => { return /enum PaintCodingKeys:/.test(x) });

    const result = lines.map(x => {
            // public struct BackgroundLayer: Layer, Equatable
            if (/public struct (\w+):/.test(x)) {
                const structName = /public struct (\w+):/.exec(x)[1];
                shouldSkip = true;
                return `public class ${structName} : MapboxLayer
{
    public ${structName}(string id${hasSource ? ', string source' : ''})
        : base(id)
    {
        Type = LayerType.${layerName};${hasSource ? '\n        Source = source;' : ''}
        Visibility = new PropertyValue<Visibility>(MapboxMaui.Visibility.Visible);
    }`;
            }

            // public var visibility: Value<Visibility>
            if (/public var visibility/.test(x)) {
                shouldSkip = false;
                return null;
            }

            if (/public init/.test(x)) {
                shouldSkip = true;
                return null;
            }
            
            if (shouldSkip) {
                // Ignore properties declared in base class
                return null;
            }

            // public var backgroundColor: Value<StyleColor>?
            if (/public var (\w+)/.test(x)) {
                const propertyParts = (/public var (\w+): (.+)/.exec(x)).slice(1, 3);
                const propertyName = helper.pascalCase(propertyParts[0]);
                let propertyType = propertyParts[1]
                    .replace('Value<', '')
                    .replace('>', '')
                    .replace('?', '');

                if (/\[/.test(propertyType)) {
                    const innerType = /\[(\w+)/.exec(propertyType)[1];
                    propertyType = `${swift2CsTypeMapping[innerType] || innerType}[]`;
                } else {
                    propertyType = swift2CsTypeMapping[propertyType] || propertyType;
                }
                
                const isPaint = paintKeys.filter(k => { return k[0] == propertyName }).length > 0;
                
                return `    public PropertyValue<${propertyType}> ${propertyName}
    {
        get => GetProperty<PropertyValue<${propertyType}>>(
            ${isPaint ? 'PaintCodingKeys' : 'LayoutCodingKeys' }.${propertyName},
            default,
            MapboxLayerKey.${isPaint ? 'paint' : 'layout' }
        );
        set => SetProperty(
            ${isPaint ? 'PaintCodingKeys' : 'LayoutCodingKeys' }.${propertyName},
            value,
            MapboxLayerKey.${isPaint ? 'paint' : 'layout' }
        );
    }`;
            }

            return x;
        }).filter(x => { return !!x });

    fs.writeFileSync(
        path.join(outputDir, fileName + '.cs'),
        `namespace MapboxMaui.Styles;

${result.join('\n')}

    public static class PaintCodingKeys {
${paintKeys
    .map(x => `        public const string ${x[0]} = ${x[1]};`).join('\n')}
    }

    public static class LayoutCodingKeys {
${layoutKeys
    .filter(x => x[0] != 'Visibility')
    .map(x => `        public const string ${x[0]} = ${x[1]};`).join('\n')}
    }
}`
    )
}

function getKeys(lines, filter) {
    let shouldSkip = true;
    return lines.map(x =>  {
        if (filter(x)) {
            shouldSkip = false;
            return null;
        }

        if (shouldSkip) {
            return null;
        }

        if (x.trim() == '}') {
            shouldSkip = true;
            return null;
        }

        const parts = (/case (\w+) = ("[^"]+")/.exec(x)).slice(1, 3);
        return [helper.pascalCase(parts[0]), parts[1]];
    }).filter(x => { return !!x });
}