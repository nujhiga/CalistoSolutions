namespace CalistoStandards.Definitions.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class MemberAttr : ElementAttr
{

    public readonly bool IsNullable;
    
    public readonly MemberSign? MemberSign;

    public readonly object? DefaultValue;

    
    public MemberAttr(MemberSign memberSigns, bool isNullable = true, object? defaultValue = null) : base(ClElementType.Member, memberSigns)
    {
        MemberSign = memberSigns;
        IsNullable = isNullable;
        DefaultValue = defaultValue;
    }

}
