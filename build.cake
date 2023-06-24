#addin nuget:?package=Cake.FileHelpers&version=6.0.0

var target = Argument("target", "example");
var name = Argument("name", "Awesome");
var index = Argument("index", 0);
var group = Argument("group", "None");
var title = Argument("title", "Awesome");
var subtitle = Argument("subtitle", "Awesome");
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
    public string Subtitle => ""{subtitle ?? "No subtitle"}"";
    public string PageRoute => typeof({name}Example).FullName;
}}");

    Information($"\n>> Generate >> {name}ExamplePage.cs");
    FileWriteText($"{exampleFolderPath}/{name}Example.cs", $@"namespace MapboxMauiQs;

public class {name}Example : ContentPage, IExamplePage, IQueryAttributable
{{
    MapboxView map;
    IExampleInfo info;

    public {name}Example()
	{{
        iOSPage.SetUseSafeArea(this, false);
		Content = map = new MapboxView();

        map.MapReady += Map_MapReady;
        map.MapLoaded += Map_MapLoaded;
	}}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {{
        info = query[""example""] as IExampleInfo;

        Title = info?.Title;
    }}

    private void Map_MapReady(object sender, EventArgs e)
    {{
        var centerLocation = new Point(21.0278, 105.8342);
        var cameraOptions = new CameraOptions
        {{
            Center = centerLocation,
            Zoom = 14,
        }};

        map.CameraOptions = cameraOptions;
        map.MapboxStyle = MapboxStyle.MAPBOX_STREETS;
    }}

    private void Map_MapLoaded(object sender, EventArgs e)
    {{
        // Setup Styles, Annotations, etc here
    }}
}}");
});

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
