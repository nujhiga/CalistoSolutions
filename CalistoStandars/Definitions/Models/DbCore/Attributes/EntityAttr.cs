using CalistoStandars.Definitions.Enumerations.DbCore;

namespace CalistoStandars.Definitions.Models.DbCore.Attributes;

[AttributeUsage(AttributeTargets.Interface, AllowMultiple = false)]
public sealed class EntityClrAttr : Attribute
{
    public readonly Type ClrType;
    public EntityClrAttr(Type clrType) => ClrType = clrType;
}


[AttributeUsage(AttributeTargets.Property | AttributeTargets.Interface)]
public sealed class EntityAttr : Attribute
{
    public readonly SelectionDepth Depth;
    public readonly EntityMemberSign Sign;

    public EntityAttr(EntityMemberSign sign)
    {
        Sign = sign;
    }


    public EntityAttr(EntityMemberSign sign, SelectionDepth depth)
    {
        Sign = sign;
        Depth = depth;
    }

}
