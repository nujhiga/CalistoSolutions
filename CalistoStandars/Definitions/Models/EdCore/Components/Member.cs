using CalistoStandards.Definitions.Interfaces.EdCore.Components;

namespace CalistoStandards.Definitions.Models.EdCore.Components;


public sealed class Member : Element<MemberSign>, IMember
{
    public object Value { get; set; }
    public bool InvalidValue { get; set; }
    public Member(MemberSign sign) : base(sign, ClElementType.Member) { }
    public Member(MemberSign sign, object value) : base(sign, ClElementType.Member) => Value = value;
    public override string ToString() => $"{Sign}:{Value}";
    public void Dispose() => Value = null!;
}