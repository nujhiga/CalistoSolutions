using System.Reflection;

namespace CalistoStandards.Definitions.Interfaces.Cls;

public interface IClGenericComponent<TValue>
{
    bool? Nullation { get; set; }
    TValue? Value { get; set; }
    PropertyInfo NullationProperty => GetType().GetProperty(nameof(Nullation))!;
    PropertyInfo ValueProperty => GetType().GetProperty(nameof(Value))!;
}
