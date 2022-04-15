namespace CalistoStandards.Definitions.Attributes;


[AttributeUsage(AttributeTargets.Property | AttributeTargets.Interface)]
public sealed class NodeAttr : ElementAttr
{
    public readonly NodeSign? NodeSign;

    public NodeAttr(NodeSign nodeSign) : base(ClElementType.Node, nodeSign) => NodeSign = nodeSign;

}