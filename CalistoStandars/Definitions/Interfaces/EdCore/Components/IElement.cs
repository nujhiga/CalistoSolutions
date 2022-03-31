using System.Reflection;

namespace CalistoStandars.Definitions.Interfaces;

/// <summary>
///     Common Interface of Element.
/// </summary>
/// <typeparam name="TSign">Generic argument that represents an enumeration like method/argument/parameter sign</typeparam>
/// <typeparam name="ElementType">Markup to identify the type of this eventual implementor</typeparam>
public interface IElement<TSign> where TSign : Enum
{
    TSign? Sign { get; }
    ElementType? ElementType { get; }
    public PropertyInfo SignProperty => GetType().GetProperty(nameof(Sign))!;

}