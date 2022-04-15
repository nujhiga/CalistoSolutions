namespace CalistoStandards.Definitions.Models;

public sealed class ClNodesBody : ClBody, IClNodesBody
{
    public IEnumerable<IClNode> Nodes { get; set; }

    public ClNodesBody()
    {
        
    }
    public ClNodesBody(BodySign sign, IEnumerable<IClNode> nodes) : base(sign, ClMessagePattern.Nodes)
    {
        Nodes = nodes;
    }
    public ClNodesBody(IEnumerable<IClNode> nodes) : base(ClMessagePattern.Nodes)
    {
        Nodes = nodes;
    }
}