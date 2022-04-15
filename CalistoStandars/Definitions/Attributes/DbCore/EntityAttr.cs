namespace CalistoStandards.Definitions.Attributes;

[Obsolete("Review its usefulness")]

[AttributeUsage(AttributeTargets.Interface, AllowMultiple = false)]
public sealed class EntityClrAttr : Attribute
{
    public readonly Type ClrType;
    public EntityClrAttr(Type clrType) => ClrType = clrType;
}


[AttributeUsage(AttributeTargets.Property | AttributeTargets.Interface)]
public sealed class EntityAttr : Attribute
{
    [Obsolete("Review")]
    public readonly Enum Depth;
    public readonly EntityMemberSign Sign;

    public EntityAttr(EntityMemberSign sign)
    {
        Sign = sign;
    }


    public EntityAttr(EntityMemberSign sign, Enum depth)
    {
        Sign = sign;
        Depth = depth;
    }

}
