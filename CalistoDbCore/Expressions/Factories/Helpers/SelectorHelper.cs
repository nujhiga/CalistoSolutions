using System.Collections.Concurrent;
using System.Reflection;

using CalistoStandars.Definitions.Enumerations;
using CalistoStandars.Definitions.Enumerations.DbCore;
using CalistoStandars.Definitions.Extensions;
using CalistoStandars.Definitions.Models.DbCore.Attributes;

namespace CalistoDbCore.Expressions.Builders;


internal static class SelectorHelper
{

    internal static IEnumerable<PropertyInfo> GetSourcePropertiesParallel<TEntity>(this TEntity source, IEnumerable<EntityMemberSign> propertiesSignsFilter)
    {
        IEnumerable<PropertyInfo> properties = source!.GetType().GetProperties().AsParallel();

        foreach (string signName in propertiesSignsFilter.Select(p => $"{p}").AsParallel())
            yield return properties.AsParallel().Single(p => p.Name == signName);
    }

    internal static IEnumerable<PropertyInfo> GetSourceProperties<TEntity>(this TEntity source, IEnumerable<EntityMemberSign> propertiesSignsFilter)
    {
        IEnumerable<PropertyInfo> properties = source!.GetType().GetProperties();

        foreach (string signName in propertiesSignsFilter.Select(p => $"{p}"))
            yield return properties.Single(p => p.Name == signName);
    }

    internal static ConcurrentDictionary<EntityMemberSign, object> GetSourceValues<TEntity>(this TEntity source, in IEnumerable<EntityMemberSign> signs) where TEntity : class
    {
        ConcurrentDictionary<EntityMemberSign, object>
            propValues = new ConcurrentDictionary<EntityMemberSign, object>();

        IEnumerable<PropertyInfo> properties = source.GetSourceProperties(signs);
       
        properties.AsParallel().ForAll(prop =>
        {
            EntityMemberSign mSign = 
                Enum.Parse<EntityMemberSign>(prop.Name);

            object pValue = prop.GetValue(source)!;

            propValues.TryAdd(mSign, pValue);
        });

        return propValues;
    }




    internal static IEnumerable<PropertyInfo> GetResultProperties<TResult>(this TResult result, IEnumerable<EntityMemberSign> propertiesSignsFilter)
    {
        //IEnumerable<string> signsStrings = propertiesSignsFilter.Select(s => s.ToString());

        IEnumerable<PropertyInfo> properties = result.GetInterfaceProperties<EntityAttr>();

        foreach (string signName in propertiesSignsFilter.Select(p => $"{p}"))
            yield return properties.Single(p => p.Name == signName);


    }

    internal static IEnumerable<PropertyInfo> GetResultPropertiesParallel<TResult>(this TResult result, IEnumerable<EntityMemberSign> propertiesSignsFilter)
    {
        //IEnumerable<string> signsStrings = propertiesSignsFilter.Select(s => s.ToString());

        IEnumerable<PropertyInfo> properties = result.GetInterfacePropertiesParallel<EntityAttr>();

        foreach (string signName in propertiesSignsFilter.Select(p => $"{p}").AsParallel())
            yield return properties.Single(p => p.Name == signName);


    }

    //internal static IEnumerable<PropertyInfo> GetResultProperties<TResult>(this TResult result, IEnumerable<EntityMemberSign> propertiesSignsFilter)
    //{
    //    IEnumerable<string> signsStrings = propertiesSignsFilter.Select(s => s.ToString());

    //    IEnumerable<PropertyInfo> properties = result.GetInterfaceProperties<EntityAttr>()
    //        .Where(p => propertiesSignsFilter.Contains(p.GetCustomAttribute<EntityAttr>().Sign));

    //    return properties;
    //}

    internal static IEnumerable<PropertyInfo> GetSelectionProperties<TSource>(params EntityMemberSign[] selectSigns)
    {
        IEnumerable<PropertyInfo> properties =
            typeof(TSource).GetInterfaceProperties<EntityAttr>();

        foreach (PropertyInfo pinfo in properties)
        {
            EntityAttr attr = pinfo.GetCustomAttribute<EntityAttr>()!;

            if (!selectSigns.Contains(attr.Sign)) continue;

            if (attr?.Depth is SelectionDepth.Avoid) continue;

            yield return pinfo;
        }
    }


    internal static IEnumerable<EntityMemberSign> GetSelectionSigns<TEntity>() where TEntity : class
    {
        IEnumerable<PropertyInfo> properties = typeof(TEntity).GetInterfaceProperties<EntityAttr>();

        if (properties.NullOrEmpty()) yield break;

        foreach (PropertyInfo pinfo in properties)
        {
            EntityAttr attr = pinfo.GetCustomAttribute<EntityAttr>()!;

            if (attr is null) continue;

            if (attr?.Depth is SelectionDepth.Avoid) continue;

            yield return attr!.Sign;
        }
    }

}
