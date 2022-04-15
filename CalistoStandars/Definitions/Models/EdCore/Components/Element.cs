using CalistoStandards.Definitions.Interfaces.EdCore.Components;

namespace CalistoStandards.Definitions.Models.EdCore.Components;

/// <summary>
///     Common Element from Serialize ISerializable objects on to raw xml elements.
/// </summary>
/// <typeparam name="TSign">Generic argument that represents an enumeration like method/argument/parameter sign</typeparam>
public abstract class Element<TSign> : IElement<TSign> where TSign : Enum
{
    public TSign? Sign { get; }
    public ClElementType? ElementType { get; }
    protected Element(TSign? elementSign) => Sign = elementSign;
    protected Element(ClElementType elementType) => ElementType = elementType;
    protected Element(TSign? sign, ClElementType type) : this(sign) => ElementType = type;

    public override string ToString() => $"{ElementType} - ";

}