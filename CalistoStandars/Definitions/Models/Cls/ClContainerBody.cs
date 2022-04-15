namespace CalistoStandards.Definitions.Models;

public sealed class ClContainerBody : ClBody, IClContainerBody
{
    public IClMember? Member { get; set; }
    public IEnumerable<IClNode>? Nodes { get; set; }

    public ClContainerBody()
    {
        
    }
    public ClContainerBody(BodySign sign, IEnumerable<IClNode> nodes) : base(sign, ClMessagePattern.Container)
    {
        Nodes = nodes;
    }

}