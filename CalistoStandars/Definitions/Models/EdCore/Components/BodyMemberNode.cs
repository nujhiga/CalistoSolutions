namespace CalistoStandars.Definitions.Models;

public sealed class BodyMemberNode : Body, IBodyMemberNode
{
    public (IMember, INode) SingleMemberSingleNode { get; private set; }

    public BodyMemberNode(BodySign sign, (IMember, INode) memberNode) : base(sign, BodyContentPattern.MemberNode) => SingleMemberSingleNode = memberNode;

    public BodyMemberNode(BodySign sign, IMember member, INode node) : base(sign, BodyContentPattern.MemberNode) => SingleMemberSingleNode = (member, node);

    public override void Dispose()
    {
        (IMember member, INode node) = SingleMemberSingleNode;

        member?.Dispose();

        node?.Dispose();
    }
}