namespace CalistoStandards.Definitions.Attributes;

[AttributeUsage(AttributeTargets.Interface | AttributeTargets.Property |
                AttributeTargets.Class | AttributeTargets.Field, AllowMultiple = true)]
public class ElementAttr : Attribute
{
    public readonly ClElementType ElementType;

    public readonly Enum SignEnum;

    public readonly string MarkerRef;

    public ElementAttr(ClElementType elementType) => ElementType = elementType;

    public ElementAttr(ClElementType elementType, Enum signEnum)
    {
        ElementType = elementType;
        SignEnum = signEnum;
    }

    public ElementAttr(ClElementType elementType, string marketRef)
    {
        ElementType = elementType;
        MarkerRef = marketRef;
    }

}


