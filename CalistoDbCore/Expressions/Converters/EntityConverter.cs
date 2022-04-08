using System.Collections.Concurrent;
using System.Reflection;

using CalistoDbCore.Expressions.Builders;

using CalistoStandars.Definitions.Enumerations.DbCore;
using CalistoStandars.Definitions.Interfaces.DbCore.Entities;

using Microsoft.EntityFrameworkCore;


namespace CalistoDbCore.Expressions.Converters;

public static class EntityConverter
{

    public static async Task<ConcurrentDictionary<object, TResult>> Convert<TSource, TResult>(
        IQueryable<TSource> queryableSource, IEnumerable<EntityMemberSign> selectorSigns)
        where TSource : class where TResult : class, IEntity
    {
        IReadOnlyList<TSource> sourceEntities = await queryableSource.ToListAsync();

        ConcurrentDictionary<object, TResult> results =
            new ConcurrentDictionary<object, TResult>();

        sourceEntities.AsParallel().ForAll(ent =>
        {
            if (ent is null) return;

            var propValues = GetSourceValues(in ent, in selectorSigns);
            TResult instance = GetInstanceParallel<TResult>(in propValues);

            results.TryAdd(instance.EntityID, instance);
        });

        return results;
    }
    
    private static TResult GetInstanceParallel<TResult>(in ConcurrentDictionary<EntityMemberSign, object> entityValues) where TResult : class, IEntity
    {
        TResult instance = Activator.CreateInstance<TResult>();

        IEnumerable<PropertyInfo> rProperties =
            instance.GetResultProperties(entityValues.Keys).AsParallel();

        entityValues.AsParallel().ForAll(ekp =>
        {
            (EntityMemberSign sign, object value) = ekp;

            string signName = $"{sign}";

            PropertyInfo pinfo = rProperties.Single(p => p.Name == signName);

            if (pinfo is null) return;

            pinfo.SetValue(instance, value);
        });
        
        return instance;
    }

    private static ConcurrentDictionary<EntityMemberSign, object> GetSourceValues<TEntity>(in TEntity source, in IEnumerable<EntityMemberSign> signs) where TEntity : class
    {
        ConcurrentDictionary<EntityMemberSign, object>
            propValues = new ConcurrentDictionary<EntityMemberSign, object>();

        IEnumerable<PropertyInfo> properties = source.GetSourceProperties(signs);

        var lSource = source; //todo:7422#1 - verify if its a good practice
        
        properties.AsParallel().ForAll(prop =>
        {
            EntityMemberSign mSign =
                Enum.Parse<EntityMemberSign>(prop.Name);

            object pValue = prop.GetValue(lSource)!;
            
            propValues.TryAdd(mSign, pValue);
        });

        return propValues;
    }
}