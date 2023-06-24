namespace MapboxMauiQs;

public class DebugMapExample : ContentPage, IExamplePage, IQueryAttributable
{
    MapboxView map;
    IExampleInfo info;
    bool mapReady;
    DebugOptionItem[] debugOptionItems = new[]
    {
        new DebugOptionItem
        {
           DebugOption = DebugOption.Collision,
           Title = "Debug collision",
        },
        new DebugOptionItem
        {
           DebugOption = DebugOption.DepthBuffer,
           Title = "Show depth buffer",
        },
        new DebugOptionItem
        {
           DebugOption = DebugOption.Overdraw,
           Title = "Debug overdraw",
        },
        new DebugOptionItem
        {
           DebugOption = DebugOption.ParseStatus,
           Title = "Show tile coordinate",
        },
        new DebugOptionItem
        {
           DebugOption = DebugOption.RenderCache,
           Title = "Render Cache",
        },
        new DebugOptionItem
        {
           DebugOption = DebugOption.StencilClip,
           Title = "Show stencil buffer",
        },
        new DebugOptionItem
        {
           DebugOption = DebugOption.TileBorders,
           Title = "Debug tile clipping",
        },
        new DebugOptionItem
        {
           DebugOption = DebugOption.Timestamps,
           Title = "Show tile loaded time",
        },
    };

    public DebugMapExample()
	{
        iOSPage.SetUseSafeArea(this, false);

		Content = map = new MapboxView();
       
        ToolbarItems.Add(new ToolbarItem
        {
            Text = "Edit",
            Command = new Command(() => Shell.Current.GoToAsync(
                typeof(DebugOptionsPage).FullName,
                new Dictionary<string, object> {
                    { "options", debugOptionItems }
                }
            )),
        });
        map.MapReady += Map_MapReady;
	}

    private void Map_MapReady(object sender, EventArgs e)
    {
        mapReady = true;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (mapReady) {
            var debugOptions = this.debugOptionItems
                .Select(x => x.DebugOption)
                .ToArray();
            map.DebugOptions = debugOptions;
        }
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        info = query["example"] as IExampleInfo;

        if (info != null)
        {
            Title = info.Title;
        }

        if (query.TryGetValue("options", out var value) &&
            value is DebugOptionItem[] debugOptions)
        {
            this.debugOptionItems = debugOptions;
        }
    }
}