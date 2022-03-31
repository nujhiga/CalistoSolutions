namespace CalistoStandars.Definitions.Models;


public sealed class Member : Element<MemberSign>, IMember
{
    public object Value { get; set; }
    public bool InvalidValue { get; set; }
    public Member(MemberSign sign) : base(sign, Enumerations.ElementType.Member) { }
    public Member(MemberSign sign, object value) : base(sign, Enumerations.ElementType.Member) => Value = value;

    public override string ToString() => $"{Sign}:{Value}";

    public void Dispose() => Value = null!;

}