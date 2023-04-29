using MapboxMaui.Expressions;

namespace MapboxMaui.Styles;

public class Terrain
{
	public Terrain(string sourceId)
	{
		SourceId = sourceId;
	}

	public string SourceId { get; }
	public PropertyValue<double> Exaggeration { get; set; }
    public StyleTransition ExaggerationTransition { get; set; }
}

