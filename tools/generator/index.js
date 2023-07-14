import fs from 'fs';

var content = fs.readFileSync('input.txt', 'utf8');
var lines = content.split('\n');

var prefixedTypes = lines.map((item, index) => {
    if (item.trim().startsWith('public var')) {
        var name = /public var (\w+): ([\[]{0,2}\w+[\]]{0,2}\??)/.exec(item)[1];
        var type = /public var (\w+): ([\[]{0,2}\w+[\]]{0,2}\??)/.exec(item)[2];

        return [name, type.replace(/\[|\]|\?/img, ''), type.indexOf('?') > -1, type.indexOf('[') > -1];
    }

    return '';
});

const swift2CsTypeMapping = {
    'Double': 'double',
    'Bool': 'bool',
    'String': 'string',
    'StyleColor': 'Color'
};

// swiftProperties2CsInterfaceProperties();

// swiftProperties2CsClassProperties();

// annnotationManager_swiftProperties2JavaProperties()

// generateAndroidNamedString();

// swiftProperties2CsInterfaceProperties()

// generateLayerProperties('LineLayerKey');

var commonTypeToConversionNameMapping = {
    'bool': 'boolean',
};
generateSourcePropertiesObjc('GeoJSON');

function generateLayerPropertiesObjc(layerName) {
    var topLines = `// This file is generated.
import Foundation
import MapboxMaps

@objc open class TMB${layerName}Layer: TMBLayer {
    private var _self: ${layerName}Layer {
        get {
            return rawValue as! ${layerName}Layer
        }
        set {
            rawValue = newValue
        }
    }
    
    @objc public init(id: String = UUID().uuidString) {
        super.init(${layerName}Layer(id: id))
        
        self.visibility = TMBValue(constant: TMBVisibility.visible)
    }

    `

    var transformed = lines.map(item => {
        let isPropertyLine = /^\s+public/.test(item);
        if (!isPropertyLine) {
            return item;
        }
            
        var matches = /(\w+): Value<(\[?\w+\]?)>/.exec(item);
        
        if (!matches) {
            matches = /(\w+): (\[?\w+\]?)/.exec(item);
        }

        var propName = matches[1];        
        var propType = matches[2];
        var conversionName = propType.substring(0,1).toLowerCase() + propType.substring(1);
        if (commonTypeToConversionNameMapping[conversionName]) {
            conversionName = commonTypeToConversionNameMapping[conversionName];
        } else if (/^\[/.test(propType)) {
            conversionName = 'arrayOf' + propType.replace(/\[|\]/img, '');
        }

        if (propType == 'StyleTransition') {
            return `    @objc public var ${propName} : TMBStyleTransition? {
                get {
                    return _self.${propName}?.objcValue()
                }
                set {
                    _self.${propName} = newValue?.rawValue
                }
            }`;
        }
        
        return `    @objc public var ${propName} : TMBValue? {
        get {
            return TMBValue.fromSwiftValue(_self.${propName})
        }
        set {
            _self.${propName} = newValue?.${conversionName}()
        }
    }`;
    });
    
    fs.writeFileSync('output.txt', topLines + transformed.join('\n') + '\n}');
}

function generateSourcePropertiesObjc(srcName) {
    var nsnumberTypes = {
        'Bool': 'boolValue',
        'Double': 'doubleValue',
    }
    var nsnumberConversions = {
        'Bool': 'asNumber()',
        'Int': 'asNumber()',
        'Double': 'NSNumber',
    }
    var nsvalueTypes = {

    }
    var topLines = `// This file is generated.
import Foundation
import MapboxMaps

@objc open class TMB${srcName}Source: TMBSource {
    private var _self: ${srcName}Source {
        get {
            return rawValue as! ${srcName}Source
        }
        set {
            rawValue = newValue
        }
    }
    
    @objc public init() {
        super.init(${srcName}Source())
    }

    `;

    var transformed = lines.map(item => {
        let isPropertyLine = /^\s+public/.test(item);
        if (!isPropertyLine) {
            return item;
        }
            
        var matches = /(\w+): ([\[]{0,2}\w+[\]]{0,2})(\??)/.exec(item);

        var propName = matches[1];        
        var propType = matches[2];
        let nullable = matches[3];
        var conversionName = propType.trim('?')
        if (nsnumberTypes[conversionName]) {
            return `    @objc public var ${propName} : NSNumber${nullable} {
        get {
            return _self.${propName}${nullable}.${nsnumberConversions[propType]}
        }
        set {
            _self.${propName} = newValue${nullable}.${nsnumberTypes[conversionName]}
        }
    }`;
        }

        return `    @objc public var ${propName} : ${conversionName}? {
        get {
            return _self.${propName}
        }
        set {
            _self.${propName} = newValue
        }
    }`;
    });
    
    fs.writeFileSync('output.txt', topLines + transformed.join('\n') + '\n}');
}


function generateAndroidNamedString() {
    var transformed = lines
        .filter(x => /enum/.test(x))
        .map(item => {
            var match = /enum (\w+)/.exec(item);
            return `public static Enums.${match[1]} ToPlatform(this ${match[1]} xvalue) {
                return Enums.${match[1]}.ValueOf(xvalue);
            }`
        });
    
    fs.writeFileSync('output.txt', transformed.join('\n'));
}

function generateIOSNamedString() {
    var transformed = lines
        .filter(x => /enum/.test(x))
        .map(item => {
            var match = /enum (\w+)/.exec(item);
            return `public static TMB${match[1]} ToPlatform(this ${match[1]} xvalue) {
                return new TMB${match[1]}(xvalue);
            }`
        });
    
    fs.writeFileSync('output.txt', transformed.join('\n'));
}

function generateSourceProperties(keyClassName) {
    var transformed = lines.map(item => {
        if (/^\s+public/.test(item)) {
            
            var matches = /(\w+): Value<(\[?\w+\]?\??)>/.exec(item);
            
            if (!matches) {
                matches = /(\w+): (\[?\w+\]?\??)/.exec(item);
            }

            var propName = matches[1];
            var csname = propName.substring(0,1).toUpperCase() + propName.substring(1);
            
            let propType = matches[2];
            console.log(propType);
            let nullable = /\?/.test(propType) ? '?' : '';
            let array = /\[/.test(propType) ? '[]' : '';
            propType = propType.replace(/\[|\]|\?/img, '')

            if (swift2CsTypeMapping[propType]) {
                propType = swift2CsTypeMapping[propType];
            }
            let cstype = `${propType}${nullable}${array}`;

            return `public ${cstype} ${csname}
            {
                get => GetProperty<${cstype}>(
                    ${keyClassName}.${propName},
                    default
                );
                set => SetProperty(
                    ${keyClassName}.${propName},
                    value
                );
            }`;
        }
        return item;
    });
    
    fs.writeFileSync('output.txt', transformed.join('\n'));
}

function generateLayerProperties(keyClassName) {
    var transformed = lines.map(item => {
        if (/^\s+public/.test(item)) {
            
        var matches = /(\w+): Value<(\[?\w+\]?)>/.exec(item);
        
        if (!matches) {
            matches = /(\w+): (\[?\w+\]?)/.exec(item);
        }

        var propName = matches[1];
        var csname = propName.substring(0,1).toUpperCase() + propName.substring(1);
        
        let propType = matches[2];
        let array = /\[/.test(propType) ? '[]' : '';
        propType = propType.replace(/\[|\]|\?/img, '')

        if (swift2CsTypeMapping[propType]) {
            propType = swift2CsTypeMapping[propType];
        }
        let cstype = `${propType}${array}`;

    return `public PropertyValue<${cstype}> ${csname}
    {
        get => GetProperty<PropertyValue<${cstype}>>(
            ${keyClassName}.${propName},
            default,
            MapboxLayerKey.paint
        );
        set => SetProperty(
            ${keyClassName}.${propName},
            value,
            MapboxLayerKey.paint
        );
    }`;
        }
        return item;
    });
    
    fs.writeFileSync('output.txt', transformed.join('\n'));
}

function annnotationManager_swiftProperties2JavaProperties() {
    var transformed = prefixedTypes
        .filter(x => !!x)
        .map((item) => {
            let propName = item[0];
            let propType = item[1];

            if (swift2CsTypeMapping[propType]) {
                propType = swift2CsTypeMapping[propType];
            }

            let nullable = item[2] && !item[3] ? '?' : '';
            let array = item[3] ? '[]' : '';
            let cstype = `${propType}${nullable}${array}`;
            let csname = `${propName.substring(0,1).toUpperCase() + propName.substring(1)}`;
            return `    public ${cstype} ${csname} 
        {
            get => nativeManager.${csname};
            set => nativeManager.${csname} = value;
        }`;
        });
    
    fs.writeFileSync('output.txt', transformed.join('\n'));
}

function swiftProperties2CsInterfaceProperties() {
    var transformed = prefixedTypes
        .filter(x => !!x)
        .map((item) => {
            let propName = item[0];
            let propType = item[1];

            if (swift2CsTypeMapping[propType]) {
                propType = swift2CsTypeMapping[propType];
            }

            let nullable = item[2] && !item[3] ? '?' : '';
            let array = item[3] ? '[]' : '';
            let cstype = `${propType}${nullable}${array}`;
            let csname = `${propName.substring(0,1).toUpperCase() + propName.substring(1)}`;
            return `${cstype} ${csname} { get; set; }`;
        });
    
    fs.writeFileSync('output.txt', transformed.join('\n'));
}

function swiftProperties2CsClassProperties() {
    var transformed = lines.map((item, index) => {
        let infoIndex = -1;
        if (/^\s+public var/.test(item)) {
            infoIndex = 0;
        }
        else if (/^\s+return/.test(item)) { 
            infoIndex = 2;
        } 
        else if (/^\s+layerProperties/.test(item)) { 
            infoIndex = 5;
        }
        let propType;
        let propName;
        let nullable;
        let array;
        let cstype;
        let csname;

        if (infoIndex > -1) {
            let info = prefixedTypes[index-infoIndex];
            propName = info[0];
            propType = info[1];

            if (swift2CsTypeMapping[propType]) {
                propType = swift2CsTypeMapping[propType];
            }

            nullable = info[2] && !info[3] ? '?' : '';
            array = info[3] ? '[]' : '';
            cstype = `${propType}${nullable}${array}`;
            csname = `${propName.substring(0,1).toUpperCase() + propName.substring(1)}`;
        }

        if (/^\s+public var/.test(item)) {
            return `    public ${cstype} ${csname}
        {`;
        }
        
        if (/^\s+return/.test(item)) {
            return `            return GetProperty<${cstype}>("${/"([^"]+)"/.exec(item)[1]}", default);`;
        }

        if (/^\s+layerProperties/.test(item)) {
            return `            SetProperty("${/"([^"]+)"/.exec(item)[1]}", value);`;
        }
        
        return item;
    })
    
    fs.writeFileSync('output.txt', transformed.join('\n'));
}