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

            var propValues = ent.GetSourceValues(selectorSigns);
            TResult instance = GetInstanceParallel<TResult>(propValues);
            
            results.TryAdd(instance.EntityID, instance);
        });
        
        return results;
    }

    /*
    public static async Task<ConcurrentDictionary<object, TResult>> Convert2<TSource, TResult>(
        IQueryable<TSource> queryableSource, IEnumerable<EntityMemberSign> selectorSigns)
        where TSource : class where TResult : class, IEntity
    {
        IReadOnlyList<TSource> sourceEntities = await queryableSource.ToListAsync();

        ConcurrentDictionary<object, TResult> results = new ConcurrentDictionary<object, TResult>();

        sourceEntities.AsParallel().ForAll(ent =>
        {
            if (ent is null) return;

            var propValues = ent.GetSourceValues(selectorSigns);
            { }
            //IEnumerable<PropertyInfo> sProperties = 
            //    ent.GetSourceProperties(selectorSigns).AsParallel();

            TResult instance = GetInstanceParallel<TResult>(propValues);

            results.TryAdd(instance.EntityID, instance);
        });

        return results;
    }
    */


    /*
    public static async Task<IEnumerable<TResult>> GetResultInstancesAsync(IQueryable<TSource> queryableSource,
        IEnumerable<EntityMemberSign> selectorSigns, bool disposingSources = true)
    {
        IReadOnlyList<TSource> sourceEntities = await queryableSource.ToListAsync();

        Collection<TResult> results = new Collection<TResult>();

        foreach (TSource source in sourceEntities)
        {
            if (source is null) continue;

            IEnumerable<PropertyInfo> sProperties = source.GetSourceProperties(selectorSigns).AsParallel();

            if (sProperties.NullOrEmpty()) continue;

            TResult instance = GetResultInstanceParallel(in selectorSigns, in source, in sProperties);

            results.Add(instance);

           // sProperties = Enumerable.Empty<PropertyInfo>();
        }

        //if (disposingSources) queryableSource = Enumerable.Empty<TSource>().AsQueryable();

        return results;
    }
    */


    /*
    public static IEnumerable<TResult> GetResultInstances(IQueryable<TSource> queryableSource,
        IEnumerable<EntityMemberSign> selectorSigns, bool disposingSources = true)
    {
        foreach (TSource source in queryableSource)
        {
            if (source is null) continue;

            IEnumerable<PropertyInfo> sProperties =
                source.GetSourceProperties(selectorSigns);

            if (sProperties.NullOrEmpty()) continue;

            TResult instance = GetResultInstanceParallel(in selectorSigns, in source, in sProperties);

            yield return instance;

            sProperties = Enumerable.Empty<PropertyInfo>();
        }

        if (disposingSources)
            queryableSource = Enumerable.Empty<TSource>().AsQueryable();
    }
    */

    private static TResult GetInstanceParallel<TResult>(ConcurrentDictionary<EntityMemberSign, object> entityValues) where TResult : class, IEntity
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


        //


        /*
        rProperties.AsParallel().ForAll(rinfo =>
        {
            PropertyInfo sInfo = sProperties.AsParallel().Single(p => p.Name == rinfo.Name)!;
            if (sInfo is null) return;
            object sinfoValue = sInfo.GetValue(source)!;
            rinfo.SetValue(instance, sinfoValue);
        });
        */
        //foreach (PropertyInfo rPinfo in rProperties)
        //{
        //    PropertyInfo sInfo = sProperties.AsParallel().Single(p => p.Name == rPinfo.Name)!;

        //    if (sInfo is null) continue;

        //    object sinfoValue = sInfo.GetValue(source)!;

        //    rPinfo.SetValue(instance, sinfoValue);
        //}

        return instance;
    }

    /*
    private static TResult GetResultInstanceParallel<TSource, TResult>
        (in IEnumerable<EntityMemberSign> selectorSigns, in TSource source, in IEnumerable<PropertyInfo> sProperties)
        where TSource : class where TResult : class, IEntity
    {
        TResult instance = Activator.CreateInstance<TResult>();

        IEnumerable<PropertyInfo> rProperties = instance.GetResultProperties(selectorSigns).AsParallel();

        foreach (PropertyInfo rPinfo in rProperties)
        {
            PropertyInfo sInfo = sProperties.AsParallel().Single(p => p.Name == rPinfo.Name)!;

            if (sInfo is null) continue;

            object sinfoValue = sInfo.GetValue(source)!;

            rPinfo.SetValue(instance, sinfoValue);
        }

        return instance;
    */


}
