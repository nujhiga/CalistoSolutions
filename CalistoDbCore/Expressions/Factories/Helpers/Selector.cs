using System.Collections.ObjectModel;
using System.Reflection;

using CalistoStandars.Definitions.Enumerations;
using CalistoStandars.Definitions.Enumerations.DbCore;
using CalistoStandars.Definitions.Extensions;
using CalistoStandars.Definitions.Models.DbCore.Attributes;

namespace CalistoDbCore.Expressions.Builders;

internal sealed class Selector : Collection<PropertyInfo> //where TEntity : class
{
    internal readonly bool Initialized = false;
    internal readonly object SourceObj;

    public IEnumerable<EntityMemberSign>? RequestingSigns { get; set; }


    internal Selector(object sourceObj, EntityMemberSign[] requestingSigns) : this(sourceObj) => RequestingSigns = requestingSigns;


    internal Selector(object sourceObj, Func<SelectionDepth, bool> when = null!)
    {
        SourceObj = sourceObj;

        IEnumerable<PropertyInfo> properties = sourceObj?.GetInterfaceProperties<EntityAttr>()!;

        if (properties is not { }) return;

        foreach (PropertyInfo pinfo in properties)
        {
            if (pinfo is null) continue;

            EntityAttr attr = pinfo.GetCustomAttribute<EntityAttr>()!;

            if (attr is null) continue;

            if (RequestingSigns is { } && !RequestingSigns.Contains(attr.Sign)) continue;
            
            SelectionDepth depthAttr = attr.Depth;

            if (depthAttr is SelectionDepth.Avoid) continue;

            if (depthAttr is SelectionDepth.When)
            {
                if (when is { } wwhen && wwhen(depthAttr)) Add(pinfo);
            }
            else
            {
                Add(pinfo);
            }
        }

        Initialized = Count > 0;
    }

    public PropertyInfo this[string pinfoName]
    {
        get
        {
            return this.SingleOrDefault(p => p.Name.
                Equals(pinfoName, StringComparison.Ordinal))!;
        }
    }
    internal IEnumerable<PropertyInfo> GetAndRemove(bool clear = true)
    {
        foreach (PropertyInfo pinfo in this)
        {
            yield return pinfo;
            Remove(pinfo);
        }

        if (clear) Clear();
    }
    internal PropertyInfo GetAndRemove(string pinfoname) => this[pinfoname];
}

//public static class Helpers
//{
//    public static Func<T, T> DynamicSelectGenerator<T>
// (string Fields = "")
//    {
//        string[] EntityFields;



//        if (Fields == "")
//            // get Properties of the T
//            EntityFields = typeof(T).GetProperties().
// Select(propertyInfo => propertyInfo.FieldName).ToArray();
//        else
//            EntityFields = Fields.Split(',');




//        // input parameter "o"
//        var xParameter = Expression.Parameter(typeof(T), "o");

//        // new statement "new Data()"
//        var xNew = Expression.New(typeof(T));

//        // create initializers
//        var bindings = EntityFields.Select(o => o.Trim())
//            .Select(o =>
//                {

//                    // property "Field1"
//                    var mi = typeof(T).GetProperty(o);

//                    // original value "o.Field1"
//                    var xOriginal = Expression.Property(xParameter, mi);

//                    // set value "Field1 = o.Field1"
//                    return Expression.Bind(mi, xOriginal);
//                }
//            );

//        // initialization "new Data { Field1 = o.Field1, Field2 = o.Field2 }"
//        var xInit = Expression.MemberInit(xNew, bindings);

//        // expression "o => new Data { Field1 = o.Field1, Field2 = o.Field2 }"
//        var lambda = Expression.Lambda<Func<T, T>>(xInit, xParameter);

//        // compile to Func<Data, Data>
//        return lambda.Compile();
//    }