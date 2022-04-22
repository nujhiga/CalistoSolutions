namespace CalistoStandards.Definitions.Attributes;

[Obsolete("Review its usefulness")]

[AttributeUsage(AttributeTargets.Interface, AllowMultiple = false)]
public sealed class EntityClrAttr : Attribute
{
    public readonly Type ClrType;
    public EntityClrAttr(Type clrType) => ClrType = clrType;
}
public enum FieldConvertion
{
    None,
    SexId,
}

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Interface)]
public sealed class EntityAttr : Attribute
{
    [Obsolete("Review")]
    public readonly Enum Depth;

    public readonly EntityMemberSign Sign;

    public readonly TypeCode FromType;
    public readonly TypeCode ToType;

    public readonly FieldConvertion Convertion;

    public EntityAttr(EntityMemberSign sign, FieldConvertion convertion)
    {
        Sign = sign;
        Convertion = convertion;
    }

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
