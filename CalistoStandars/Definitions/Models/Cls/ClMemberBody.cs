namespace CalistoStandards.Definitions.Models;

public sealed class ClMemberBody : ClBody, IClMemberBody
{
    public IClMember? Member { get; set; }

    public ClMemberBody()
    {
        
    }
    public ClMemberBody(BodySign sign, IClMember member)
        : base(sign, ClMessagePattern.Member)
    {
        Member = member;
    }
}