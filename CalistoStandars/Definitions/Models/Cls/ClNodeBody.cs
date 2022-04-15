namespace CalistoStandards.Definitions.Models;

public sealed class ClNodeBody : ClBody, IClNodeBody
{
    public IClNode Node { get; set; }

    public ClNodeBody()
    {
        
    }
    public ClNodeBody(BodySign sign, IClNode node) : base(sign, ClMessagePattern.Node)
    {
        Node = node;
    }
}