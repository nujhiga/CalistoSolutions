using System.Reflection;

namespace CalistoStandards.Definitions.Interfaces.Cls;

public interface IClSignedComponent<TSign> where TSign : struct, Enum
{
    TSign Sign { get; set; }
    PropertyInfo SignProperty => GetType().GetProperty(nameof(Sign))!;
}
//PropertyInfo SignProperty => GetType().GetProperty(nameof(Sign))!;
