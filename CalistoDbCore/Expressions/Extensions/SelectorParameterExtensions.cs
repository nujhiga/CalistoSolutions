
using CalistoDbCore.Expressions.Builders;

namespace CalistoDbCore.Expressions.Extensions;
internal static class SelectorParameterExtensions
{

    internal static IEnumerable<string> GetPropertiesNames(this Selector parameters)
      => parameters.Select(pinfo => pinfo.Name);

    internal static IEnumerable<Type> GetPropertiesTypes(this Selector parameters)
       => parameters.Select(pinfo => pinfo.PropertyType);

    internal static IEnumerable<object> GetPropertiesValues(this Selector parameters)
       => parameters.Select(pinfo => pinfo.GetValue(parameters.SourceObj))!;

    internal static IEnumerable<(string, Type, object)> GetPropertiesStruct(this Selector parameters)
       => parameters.Select(pinfo => (pinfo.Name, pinfo.PropertyType, pinfo.GetValue(parameters.SourceObj)))!;

    internal static Type GetPropertyType<TEntity>(this Selector parameters, in string paramName)
        => parameters[paramName].PropertyType;

    internal static object GetPropertyValue<TEntity>(this Selector parameters, in string paramName)
        => parameters[paramName].GetValue(parameters.SourceObj)!;

    internal static (Type, object) GetPropertyStruct<TEntity>(this Selector parameters, string paramName)
        => (parameters[paramName].PropertyType, parameters[paramName].GetValue(parameters.SourceObj))!;



}
