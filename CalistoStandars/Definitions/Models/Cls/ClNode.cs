using CalistoStandards.Definitions.Factories.Cls;

namespace CalistoStandards.Definitions.Models;

public sealed class ClNode : IClNode
{
    public NodeSign Sign { get; set; }

    public IEnumerable<IClMember>? Members { get; set; }

    public ClNode()
    {
        
    }

    public ClNode(NodeSign sign, IEnumerable<MemberSign> membersSigns)
    {
        Sign = sign;
        Members = from mSign in membersSigns
            select new ClMember(mSign);
    }
    public ClNode(NodeSign sign, IEnumerable<IClMember> members)
    {
        Sign = sign;
        Members = members;
    }

    public object? Value { get; set; }
    public Enum? ComponentType { get; set; }
    //public ClPattern? MessagePattern { get; set; }
}