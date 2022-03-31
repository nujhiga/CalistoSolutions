namespace CalistoStandars.Definitions.Models;


[AttributeUsage(AttributeTargets.Property | AttributeTargets.Interface)]
public sealed class NodeAttr : ElementAttr
{
    public readonly NodeSign? NodeSign;

    public NodeAttr(NodeSign nodeSign) : base(ElementType.Node, nodeSign) => NodeSign = nodeSign;

}