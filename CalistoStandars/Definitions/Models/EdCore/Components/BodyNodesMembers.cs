using CalistoStandards.Definitions.Interfaces.EdCore.Components;

namespace CalistoStandards.Definitions.Models.EdCore.Components;


public class BodyNodesMembers : Body, IBodyNodesMembers
{
    public BodyNodesMembers(BodySign sign, IEnumerable<INode> nodes) : base(sign, ClMessagePattern.Nodes) => Nodes = nodes;

    public BodyNodesMembers(IEnumerable<INode> nodes) : base(ClMessagePattern.Nodes) => Nodes = nodes;

    public BodyNodesMembers(BodySign sign, params INode[] nodes) : base(sign, ClMessagePattern.Nodes) => Nodes = nodes;
    public BodyNodesMembers(params INode[] nodes) : base(ClMessagePattern.Nodes) => Nodes = nodes;
    public IEnumerable<INode> Nodes { get; private set; }
    public override void Dispose()
    {
        if (Nodes.NullOrEmpty()) return;

        foreach (INode node in Nodes)
            node.Dispose();

        Nodes = Enumerable.Empty<INode>();
        Nodes = null!;
    }
}