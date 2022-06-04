using System.Collections.Concurrent;
using CalistoStandards.Definitions;
using CalistoStandards.Definitions.Interfaces.DbCore.Entities;
using CalistoStandards.Definitions.Models.CacheHandling;
using CalistoStandards.Definitions.Structures.Cls;
using CalistoStandards.Providers;

namespace CalistoDbCore.Services.Repositories;



public sealed class DbRepository
{

    public ConcurrentDictionary<ClRequestKey, IEnumerable<IEntity>> EnumeratedResults { get; private set; }
    public ConcurrentDictionary<ClRequestKey, ConcurrentDictionary<object, IEntity>> DictionaryResults { get; private set; }

    public CancellationToken Cancellation { get; }

    private readonly CacheHandler<ClRequestKey> _cacheControl;

    private readonly KeyedDelegator _kyDelegator = KeyedDelegator.Instance;

    public DbRepository()
    {
        Cancellation = new CancellationToken();
        _cacheControl = new CacheHandler<ClRequestKey>(CleanCacheRequest);

        EnumeratedResults =
            new ConcurrentDictionary<ClRequestKey, IEnumerable<IEntity>>(Environment.ProcessorCount, 75);

        DictionaryResults =
            new ConcurrentDictionary<ClRequestKey, ConcurrentDictionary<object, IEntity>>(Environment.ProcessorCount, 75);
    }

    private int RequestsCount => _kyDelegator.Invoke<int>(ClConsts.ClEnviroment.GetCurrentDbRequestCount);
    private void IncreaseRequestsCount() => _kyDelegator.Invoke(ClConsts.ClEnviroment.SetCurrentDbRequestCount);

    public async Task<IEnumerable<TOutEntity>> RequestCollAsync<TEntity, TOutEntity>(ClParameter parameter)
        where TEntity : class, IEntity where TOutEntity : class, IEntity
    {
        using MrQueryBuilder<TEntity> builder = new MrQueryBuilder<TEntity>();
        IQueryable<TEntity> query = builder.GetQuery(parameter);

        IEnumerable<TOutEntity> result = await EntityConverter.
            ConvertColl<TEntity, TOutEntity>(query, parameter.SelectFields, Cancellation);

        return result;
    }

    public async Task<ConcurrentDictionary<object, TOutEntity>> RequestDictAsync<TEntity, TOutEntity>(ClParameter parameter)
        where TEntity : class, IEntity where TOutEntity : class, IEntity
    {
        using MrQueryBuilder<TEntity> builder = new MrQueryBuilder<TEntity>();
        IQueryable<TEntity> query = builder.GetQuery(parameter);

        ConcurrentDictionary<object, TOutEntity> result = await EntityConverter.
            ConvertDct<TEntity, TOutEntity>(query, parameter.SelectFields, Cancellation);

        return result;
    }

    public async Task CacheCollAsync<TEntity, TOutEntity>(ClParameter parameter, ClCacheOptions cOptions)
        where TEntity : class, IEntity where TOutEntity : class, IEntity
    {
        using MrQueryBuilder<TEntity> builder = new MrQueryBuilder<TEntity>();
        IQueryable<TEntity> query = builder.GetQuery(parameter);

        IEnumerable<TOutEntity> result = await EntityConverter.
            ConvertColl<TEntity, TOutEntity>(query, parameter.SelectFields, Cancellation);



        StoreCollCache(parameter.RequestSign, result, ref cOptions);
    }

    public async Task CacheDictAsync<TEntity, TOutEntity>(ClParameter parameter, ClCacheOptions cOptions)
        where TEntity : class, IEntity where TOutEntity : class, IEntity
    {
        using MrQueryBuilder<TEntity> builder = new MrQueryBuilder<TEntity>();
        IQueryable<TEntity> query = builder.GetQuery(parameter);

        ConcurrentDictionary<object, IEntity> result = await EntityConverter.
            ConvertDct2<TEntity, TOutEntity>(query, parameter.SelectFields, Cancellation);



        StoreDictCache(parameter.RequestSign, result, ref cOptions);
    }

    private void StoreCollCache<TEntity>(in DbRequestSign requestSign,
        in IEnumerable<TEntity> entities, ref ClCacheOptions options) where TEntity : class, IEntity
    {
        ClRequestKey key = new ClRequestKey(requestSign, RequestsCount);

        if (EnumeratedResults.TryAdd(key, entities))
            IncreaseRequestsCount();

        if (options.CacheLifeTime is { } lifeTime)
            _cacheControl.AddStart(key, lifeTime);
    }

    private void StoreDictCache(in DbRequestSign requestSign,
        in ConcurrentDictionary<object, IEntity> entities, ref ClCacheOptions options)
    {
        ClRequestKey key = new ClRequestKey(requestSign, RequestsCount);
        
        if (DictionaryResults.TryAdd(key, entities))
            IncreaseRequestsCount();

        if (options.CacheLifeTime is { } lifeTime)
            _cacheControl.AddStart(key, lifeTime);
    }

    private void CleanCacheRequest(ClRequestKey rtype)
    {
        //TryRemove(rtype, out IEnumerable<TEntity> entities);
        //entities = Enumerable.Empty<TEntity>();
    }
}

