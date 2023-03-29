#addin nuget:?package=Cake.FileHelpers&version=6.0.0

var target = Argument("target", "example");
var name = Argument("name", "Awesome");
var index = Argument("index", 0);
var group = Argument("group", "None");
var title = Argument("title", "Awesome");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

const string CONTROL_FODLER_PATH_TEMPLATE="./src/qs/MapboxMauiQs/Examples/{0}.{1}";

Task("example")
    .Does(() =>
{
    var exampleFolderPath = string.Format(CONTROL_FODLER_PATH_TEMPLATE, index, name);
    Information("Example folder path: " + exampleFolderPath);
    
    if (DirectoryExists(exampleFolderPath)) {
        Warning("Example folder path exists:" + exampleFolderPath);
        return;
    }

    CreateDirectory(exampleFolderPath);

    Information($"\n>> Generate >> {name}ExampleInfo.cs");
    FileWriteText($@"{exampleFolderPath}/{name}ExampleInfo.cs", $@"namespace MapboxMauiQs;
class {name}ExampleInfo : IExampleInfo
{{
    public string Group => ""{group ?? "None"}"";
    public string Title => ""{title ?? "No title"}"";
    public string Subtitle => ""No subtitle"";
    public string PageRoute => typeof({name}ExamplePage).FullName;
}}");

    Information($"\n>> Generate >> {name}ExamplePage.cs");
    FileWriteText($"{exampleFolderPath}/{name}ExamplePage.cs", $@"{"using"} System;
{"using"} Mapbox.Maui;
namespace MapboxMauiQs;

public class {name}ExamplePage : ContentPage, IExamplePage
{{
    MapboxView map;

    public CustomStyleURLExample()
	{{
		Content = map = new MapboxView();

        map.MapReady += Map_MapReady;
	}}

    private void Map_MapReady(object sender, EventArgs e)
    {{
        // Setup Map here
    }}
}}");
});

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
