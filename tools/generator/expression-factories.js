import fs from 'fs';
import * as path from 'path';
import * as helper from './helpers/index.js';

const nameMapping = {
    'ToString': 'ToStringX'
};
generateFactories() ;

function generateFactories() {
    var info = JSON.parse(fs.readFileSync('expression-factories.json', 'utf8'));   
    
    var output = path.join(info.mauiRepo, info.output);
    if (!fs.existsSync(output)) {        
        fs.mkdirSync(output);
    }

    var input = path.join(info.mapboxRepo, info.input, info.name);
    var content = fs.readFileSync(input, 'utf8');
    var factories = content.split('\n')
        .filter(x => /^case (\w+)/.test(x.trim()))
        .map(x => /^case (\w+)/.exec(x.trim())[1])
        .map(x => helper.pascalCase(x))
        .map(x => nameMapping[x] ?? x)
        .map(x => `    public static DslExpression ${x}(params object[] arguments) => new(ExpressionOperator.${x}, arguments);`);

    fs.writeFileSync(
            path.join(output, 'DslExpression.Factories.cs'), 
            [
                `namespace MapboxMaui.Expressions;

partial class DslExpression
{`
            ]
            .concat(factories)
            .concat(['}'])
            .join('\n'));
}