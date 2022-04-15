using System.Reflection;

namespace CalistoStandards.Definitions.Interfaces.EdCore.Components;

public interface IMember : IElement<MemberSign>, IDisposable
{
    [ElementAttr(ClElementType.Member, nameof(Value))]
    object Value { get; set; }
    
    bool InvalidValue { get; set; }

    PropertyInfo ValueProperty => GetType().GetProperty(nameof(Value))!;
    PropertyInfo InvalidValueProperty => GetType().GetProperty(nameof(InvalidValue))!;
}