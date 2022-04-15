using System.Reflection;

namespace CalistoDbCore.Expressions.Factories.Helpers;

internal static class SelectorHelper
{
    [Obsolete("Review its usefulness")]
    internal static IEnumerable<PropertyInfo> GetSourcePropertiesParallel<TEntity>(
        this TEntity source, IEnumerable<EntityMemberSign> propertiesSignsFilter)
    {
        IEnumerable<PropertyInfo> properties = source!.GetType().GetProperties().AsParallel();

        foreach (string signName in propertiesSignsFilter.Select(p => $"{p}").AsParallel())
            yield return properties.AsParallel().Single(p => p.Name == signName);
    }


    internal static IEnumerable<PropertyInfo> GetSourceProperties<TEntity>(
        this TEntity source, IEnumerable<EntityMemberSign> propertiesSignsFilter)
    {
        IEnumerable<PropertyInfo> properties = source!.GetType().GetProperties();

        foreach (string signName in propertiesSignsFilter.Select(p => $"{p}"))
            yield return properties.Single(p => p.Name == signName);
    }


    internal static IEnumerable<PropertyInfo> GetResultProperties<TResult>(
        this TResult result, IEnumerable<EntityMemberSign> propertiesSignsFilter)
    {
        //IEnumerable<string> signsStrings = propertiesSignsFilter.SelectExp(s => s.ToString());

        IEnumerable<PropertyInfo> properties = result.GetInterfaceProperties<EntityAttr>();

        foreach (string signName in propertiesSignsFilter.Select(p => $"{p}"))
            yield return properties.Single(p => p.Name == signName);
    }

    [Obsolete("Review its usefulness")]
    internal static IEnumerable<PropertyInfo> GetResultPropertiesParallel<TResult>(
        this TResult result, IEnumerable<EntityMemberSign> propertiesSignsFilter)
    {
        //IEnumerable<string> signsStrings = propertiesSignsFilter.SelectExp(s => s.ToString());

        IEnumerable<PropertyInfo> properties = result.GetInterfacePropertiesParallel<EntityAttr>();

        foreach (string signName in propertiesSignsFilter.Select(p => $"{p}").AsParallel())
            yield return properties.Single(p => p.Name == signName);
    }


    [Obsolete("Review its usefulness")]
    internal static IEnumerable<PropertyInfo> GetSelectionProperties<TSource>(params EntityMemberSign[] selectSigns)
    {
        IEnumerable<PropertyInfo> properties =
            typeof(TSource).GetInterfaceProperties<EntityAttr>();

        foreach (PropertyInfo pinfo in properties)
        {
            EntityAttr attr = pinfo.GetCustomAttribute<EntityAttr>()!;

            if (!selectSigns.Contains(attr.Sign)) continue;

            //if (attr?.Depth is SelectionDepth.Avoid) continue;

            yield return pinfo;
        }
    }

    [Obsolete("Review commented line")]
    internal static IEnumerable<EntityMemberSign> GetEntitySigns<TEntity>() where TEntity : class
    {
        IEnumerable<PropertyInfo> properties = typeof(TEntity).GetPropertiesWith<EntityAttr>();

        if (properties.NullOrEmpty()) yield break;

        foreach (PropertyInfo pinfo in properties)
        {
            EntityAttr attr = pinfo.GetCustomAttribute<EntityAttr>()!;

            if (attr is null) continue;

            //if (attr?.Depth is SelectionDepth.Avoid) continue;

            yield return attr!.Sign;
        }
    }
}