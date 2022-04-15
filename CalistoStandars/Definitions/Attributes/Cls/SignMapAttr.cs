namespace CalistoStandards.Definitions.Attributes;

[AttributeUsage(AttributeTargets.Enum)]
public sealed class SignMapAttr : Attribute
{
    public readonly SignMapType MapSignType;
    public readonly Type MapType;
    
    public SignMapAttr(SignMapType mapSignType, Type mapType)
    {
        MapSignType = mapSignType;
        MapType = mapType;
    }
}