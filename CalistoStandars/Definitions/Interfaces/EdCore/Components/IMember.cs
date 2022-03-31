using System.Reflection;

namespace CalistoStandars.Definitions.Interfaces;

public interface IMember : IElement<MemberSign>, IDisposable
{
    [ElementAttr(Enumerations.ElementType.Member, nameof(Value))]
    object Value { get; set; }
    
    bool InvalidValue { get; set; }

    PropertyInfo ValueProperty => GetType().GetProperty(nameof(Value))!;
    PropertyInfo InvalidValueProperty => GetType().GetProperty(nameof(InvalidValue))!;
}