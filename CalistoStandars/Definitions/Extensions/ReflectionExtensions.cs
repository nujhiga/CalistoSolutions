using System.Reflection;

namespace CalistoStandars.Definitions.Extensions;
public static class ReflectionExtensions
{

    public static Type GetInterfaceType(this Type baseType)
    {
        string interfaceName = $"I{baseType.Name}";

        Type interfaceType = baseType.GetInterface(interfaceName)!;

        return interfaceType;
    }

    [Obsolete]
    public static Type GetInterfaceType(this object? source)
    {
        Type baseType = source!.GetType();

        if (baseType.IsInterface) return baseType;

        string interfaceName = $"I{baseType.Name}";

        Type interfaceType = baseType.GetInterface(interfaceName)!;

        return interfaceType;
    }

    [Obsolete]
    public static Type GetInterfaceType<TType>()
    {
        Type baseType = typeof(TType);

        if (baseType.IsInterface) return baseType;

        string interfaceName = $"I{baseType.Name}";

        Type interfaceType = baseType.GetInterface(interfaceName)!;

        return interfaceType;
    }

    [Obsolete]
    public static IEnumerable<PropertyInfo> GetInterfaceProperties(this object? source)
    {
        Type interType = source.GetInterfaceType();

        return interType is null ? null! : interType.GetProperties()!;
    }
   
    [Obsolete]
    public static IEnumerable<PropertyInfo> GetInterfacePropertiesParallel<TAttr>(this object? source) where TAttr : Attribute
    {
        Type interType = source.GetInterfaceType();

        return interType is null ? null! : interType.GetProperties().
            Where(p => Attribute.IsDefined(p, typeof(TAttr))).AsParallel()!;
    }

    [Obsolete]
    public static IEnumerable<PropertyInfo> GetInterfaceProperties<TAttr>(this object? source) where TAttr : Attribute
    {
        Type interType = source.GetInterfaceType();

        return interType is null ? null! : interType.GetProperties().
            Where(p => Attribute.IsDefined(p, typeof(TAttr)))!;
    }

    [Obsolete]
    public static IEnumerable<PropertyInfo> GetInterfaceProperties<TAttr>(this Type baseType) where TAttr : Attribute
    {
        Type interType = baseType.GetInterfaceType();

        return interType is null ? null! : interType.GetProperties().
            Where(p => Attribute.IsDefined(p, typeof(TAttr)))!;
    }

    [Obsolete]
    public static IEnumerable<PropertyInfo> GetInstanceProperties<TResult, TAttr>(this TResult instance)
        where TAttr : Attribute where TResult : class
    {
        Type type = instance.GetType();

        return type is null ? null! : type.GetProperties().
            Where(p => Attribute.IsDefined(p, typeof(TAttr)))!;
    }

    

    private static IEnumerable<PropertyInfo> GetPropertiesWith<TAttr>(this Type type) where TAttr : Attribute 
    {
        return type.GetProperties().Where(p => 
            Attribute.IsDefined(p, typeof(TAttr))).AsParallel()!;
    }


    public static IEnumerable<PropertyInfo> GetPropertiesWith<TAttr, TType>(Func<PropertyInfo, bool> where = null!) where TAttr : Attribute
    {
        var (type, _) = typeof(TType).GetTypeDetails();

        IEnumerable<PropertyInfo> properties =
            type.GetPropertiesWith<TAttr>();

        return where is null ? properties : properties.Where(where);
    }

    public static IEnumerable<PropertyInfo> GetPropertiesWith<TAttr>
        (this object source, Func<PropertyInfo, bool> where = null!) where TAttr : Attribute
    {
        var (type, _) = source.GetTypeDetails();

        IEnumerable<PropertyInfo> properties = 
            type.GetPropertiesWith<TAttr>();

        return where is null ? properties : properties.Where(where);
    }

    public static IEnumerable<TAttr> GetAttributesWith<TAttr>(this object source, Func<TAttr, bool> where = null!) where TAttr : Attribute
    {
        var (type, _) = source.GetTypeDetails();
        
        IEnumerable<TAttr> attributes = from pinfo in type.GetPropertiesWith<TAttr>() 
            select pinfo.GetCustomAttribute<TAttr>();

        return where is null ? attributes : attributes.Where(where);
    }

    private static (Type type, bool isInterface) GetTypeDetails(this object source)
    {
        Type srcType = source.GetType();
        bool isInterface = srcType.IsInterface;

        Type type = isInterface ? srcType.GetInterfaceType() : srcType;

        return (type, isInterface);
    }
}
