namespace CalistoStandards.Definitions.Models;

public sealed class ClMemberNodeBody : ClBody, IClNodeMemberBody
{
    public IClMember? Member { get; set; }
    public IClNode? Node { get; set; }

    public ClMemberNodeBody()
    {

    }
    public ClMemberNodeBody(IClMember member, IClNode node)
        : base(ClMessagePattern.MemberNode)
    {
        Member = member;
        Node = node;
    }
    public ClMemberNodeBody(IClMember member, IClNode node, bool isContainer)
        : base(ClMessagePattern.MemberNode)
    {
        Member = member;
        Node = node;
        IsContainer = isContainer;
    }
    public ClMemberNodeBody(BodySign sign, IClMember member, IClNode node)
        : base(sign, ClMessagePattern.MemberNode)
    {
        Member = member;
        Node = node;
    }
}