using System.Reflection;

namespace CalistoStandars.Definitions.Extensions;
public static class ReflectiveExtensions
{
    public static Type GetInterfaceType(this object? source)
    {
        Type baseType = source!.GetType();

        if (baseType.IsInterface) return baseType;

        string interfaceName = $"I{baseType.Name}";

        Type interfaceType = baseType.GetInterface(interfaceName)!;

        return interfaceType;
    }

    public static IEnumerable<PropertyInfo> GetInterfaceProperties(this object? source) 
    {
        Type interType = source.GetInterfaceType();

        return interType is null ? null! : interType.GetProperties()!;
    }

    public static IEnumerable<PropertyInfo> GetInterfaceProperties<TAttr>(this object? source) where TAttr : Attribute
    {
        Type interType = source.GetInterfaceType();

        return interType is null ? null! : interType.GetProperties().
            Where(p => Attribute.IsDefined(p, typeof(TAttr)))!;
    }

    
}
