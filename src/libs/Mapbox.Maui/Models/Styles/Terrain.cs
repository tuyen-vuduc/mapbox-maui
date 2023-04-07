using Mapbox.Maui.Expressions;

namespace Mapbox.Maui.Styles;

public class Terrain
{
	public Terrain(string sourceId)
	{
		SourceId = sourceId;
	}

	public string SourceId { get; }
	public object Exaggeration { get; private set; }
    public StyleTransition ExaggerationTransition { get; set; }

    public void SetExaggeration(double value) => Exaggeration = value;
    public void SetExaggeration(DslExpression value) => Exaggeration = value;
}

