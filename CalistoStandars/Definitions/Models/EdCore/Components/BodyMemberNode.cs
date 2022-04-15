using CalistoStandards.Definitions.Interfaces.EdCore.Components;

namespace CalistoStandards.Definitions.Models.EdCore.Components;

public sealed class BodyMemberNode : Body, IBodyMemberNode
{
    public (IMember, INode) SingleMemberSingleNode { get; private set; }

    public BodyMemberNode(BodySign sign, (IMember, INode) memberNode) : base(sign, ClMessagePattern.MemberNode) => SingleMemberSingleNode = memberNode;

    public BodyMemberNode(BodySign sign, IMember member, INode node) : base(sign, ClMessagePattern.MemberNode) => SingleMemberSingleNode = (member, node);

    public override void Dispose()
    {
        (IMember member, INode node) = SingleMemberSingleNode;

        member?.Dispose();

        node?.Dispose();
    }
}