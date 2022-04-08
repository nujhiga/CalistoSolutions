namespace CalistoStandars.Definitions.Models;

[AttributeUsage(AttributeTargets.Interface | AttributeTargets.Property)]
public class ElementAttr : Attribute
{
    public readonly ElementType ElementType;

    public readonly Enum SignEnum;

    public readonly string MarkerRef;
    
    public ElementAttr(ElementType elementType) => ElementType = elementType;

    public ElementAttr(ElementType elementType, Enum signEnum)
    {
        ElementType = elementType;
        SignEnum = signEnum;
    }

    public ElementAttr(ElementType elementType, string marketRef)
    {
        ElementType = elementType;
        MarkerRef = marketRef;
    }
}
