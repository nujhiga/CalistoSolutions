namespace CalistoStandards.Definitions.Interfaces.EdCore.Components;

public interface IBodyMemberNode : IBody
{
    (IMember member, INode node) SingleMemberSingleNode { get; }

    public bool IsInvalid
    {
        get
        {
            (IMember member, INode node) = SingleMemberSingleNode;

            bool invalid = member.InvalidValue || node.Members.Any(m => m.InvalidValue);
            return invalid;
        }
    }


}