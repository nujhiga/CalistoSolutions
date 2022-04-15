namespace CalistoStandards.Definitions.Models;

public sealed class ClMembersBody : ClBody, IClMembersBody
{
    public IEnumerable<IClMember>? Members { get; set; }

    public ClMembersBody()
    {
        
    }
    public ClMembersBody(IEnumerable<IClMember> members)
        : base(ClMessagePattern.Members)
    {
        Members = members;
    }
    public ClMembersBody(BodySign sign, IEnumerable<IClMember> members)
        : base(sign, ClMessagePattern.Members)
    {
        Members = members;
    }
}