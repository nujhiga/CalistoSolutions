﻿namespace CalistoStandars.Definitions.Models;

[AttributeUsage(AttributeTargets.Property)]
public class MemberAttr : ElementAttr
{

    public readonly bool IsNullable;
    
    public readonly MemberSign? MemberSign;

    public readonly object? DefaultValue;

    
    public MemberAttr(MemberSign memberSigns, bool isNullable = true, object? defaultValue = null) : base(ElementType.Member, memberSigns)
    {
        MemberSign = memberSigns;
        IsNullable = isNullable;
        DefaultValue = defaultValue;
    }

}
