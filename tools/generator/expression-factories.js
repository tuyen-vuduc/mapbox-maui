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
        .filter(x => /^public static let (\w+)/.test(x.trim()))
        .map(x => /^public static let (\w+)/.exec(x.trim())[1])
        .map(x => helper.pascalCase(x))
        .map(x => nameMapping[x] ?? x)
        .map(x => `    public static DslExpression ${x}(params object[] arguments) => new(DslOperator.${x}, arguments);`);

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
    
        var operators = content.split('\n')
            .filter(x => /^public static let (\w+)/.test(x.trim()))
            .map(x => /^public static let (\w+).+("[^"]+")/.exec(x.trim()).slice(1, 3))
            .map(x => [helper.pascalCase(x[0]), x[1]])
            .map(x => [nameMapping[x[0]] ?? x[0], x[1]])
            .map(x => `    public static readonly DslOperator ${x[0]} = new(${x[1]});`);
    
        fs.writeFileSync(
                path.join(output, 'DslOperator.cs'), 
                [
                    `namespace MapboxMaui.Expressions;

public struct DslOperator : INamedString
{
    public string Value { get; }

    private DslOperator(string op)
    {
        Value = op;
    }

    public override string ToString() => Value;

    public static implicit operator string(DslOperator value) => value.Value;
    public static implicit operator DslOperator(string value) => new (value);
`
                ]
                .concat(operators)
                .concat(['}'])
                .join('\n'));
        
}