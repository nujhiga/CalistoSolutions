using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Reflection;

using CalistoDbCore.Expressions.Factories.Helpers;

using CalistoStandards.Definitions.Interfaces.DbCore.Entities;

using Microsoft.EntityFrameworkCore;

namespace CalistoDbCore.Expressions.Builders;



public static class EntityConverter
{

    public static async Task<ConcurrentDictionary<object, IEntity>> ConvertDct2<TSource, TResult>
        (IQueryable<TSource> query, IEnumerable<EntityMemberSign> selectFields, CancellationToken cancelToken)
        where TSource : class where TResult : class, IEntity
    {
        IReadOnlyList<TSource> sourceEntities = await query.ToListAsync(cancelToken);

        ConcurrentDictionary<object, IEntity> results =
            new ConcurrentDictionary<object, IEntity>();

        sourceEntities.AsParallel().WithCancellation(cancelToken).ForAll(ent =>
        {
            var propValues = GetSourceValues(in ent, in selectFields, in cancelToken);
            TResult instance = GetInstanceParallel<TResult>(in propValues, in cancelToken);

            results.TryAdd(instance.EntityID, instance);
        });

        return results;
    }

    public static async Task<ConcurrentDictionary<object, TResult>> ConvertDct<TSource, TResult>
        (IQueryable<TSource> query, IEnumerable<EntityMemberSign> selectFields, CancellationToken cancelToken)
        where TSource : class where TResult : class, IEntity
    {
        IReadOnlyList<TSource> sourceEntities = await query.ToListAsync(cancelToken);

        ConcurrentDictionary<object, TResult> results =
            new ConcurrentDictionary<object, TResult>();

        sourceEntities.AsParallel().WithCancellation(cancelToken).ForAll(ent =>
        {
            var propValues = GetSourceValues(in ent, in selectFields, in cancelToken);
            TResult instance = GetInstanceParallel<TResult>(in propValues, in cancelToken);

            results.TryAdd(instance.EntityID, instance);
        });
        
        return results;
    }

    public static async Task<IEnumerable<TResult>> ConvertColl<TSource, TResult>
        (IQueryable<TSource> query, IEnumerable<EntityMemberSign> selectFields,  CancellationToken cancelToken) 
        where TSource : class where TResult : class, IEntity
    {
        IReadOnlyList<TSource> sourceEntities = await query.ToListAsync(cancelToken);

        Collection<TResult> results = new Collection<TResult>();
        
        sourceEntities.AsParallel().WithCancellation(cancelToken).ForAll(ent =>
        {
            var propValues = GetSourceValues(in ent, in selectFields, in cancelToken);
            TResult instance = GetInstanceParallel<TResult>(in propValues, in cancelToken);

            lock (results) results.Add(instance);
        });

        return results;
    }

    private static TResult GetInstanceParallel<TResult>(in ConcurrentDictionary<EntityMemberSign, object> entityValues, in CancellationToken cancelToken)
        where TResult : class, IEntity
    {
        TResult instance = Activator.CreateInstance<TResult>();

        IEnumerable<PropertyInfo> rProperties =
            instance.GetResultProperties(entityValues.Keys).AsParallel();

        entityValues.AsParallel().WithCancellation(cancelToken).ForAll(ekp =>
        {
            (EntityMemberSign sign, object value) = ekp;

            string signName = $"{sign}"; //to mapped 

            PropertyInfo? pinfo = rProperties.SingleOrDefault(p => p.Name == signName);

            if (pinfo is null) return;

            pinfo.SetValue(instance, value);
        });

        return instance;
    }

    private static ConcurrentDictionary<EntityMemberSign, object> GetSourceValues<TEntity>(
        in TEntity source, in IEnumerable<EntityMemberSign> signs, in CancellationToken cancelToken) where TEntity : class
    {
        ConcurrentDictionary<EntityMemberSign, object>
            propValues = new ConcurrentDictionary<EntityMemberSign, object>();

        IEnumerable<PropertyInfo> properties = source.GetSourceProperties(signs);

        var lSource = source; //todo:7422#1 - verify if its a good practice

        properties.AsParallel().WithCancellation(cancelToken).ForAll(prop =>
        {
            EntityMemberSign mSign = Enum.Parse<EntityMemberSign>(prop.Name);

            object pValue = prop.GetValue(lSource)!;

            propValues.TryAdd(mSign, pValue);
        });

        return propValues;
    }
}