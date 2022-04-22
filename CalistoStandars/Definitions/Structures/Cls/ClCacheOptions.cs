namespace CalistoStandards.Definitions.Structures.Cls;
public readonly struct ClCacheOptions
{
    public readonly bool CacheResults;
    public readonly int? CacheLifeTime;

    private ClCacheOptions(bool cacheResults, int? cacheLifeTime = null)
    {
        CacheResults = cacheResults;
        CacheLifeTime = cacheLifeTime;
    }

    public static ClCacheOptions Default => new(true, 5);
    public static ClCacheOptions Min => new(true, 1);
    public static ClCacheOptions Med => new(true, 7);
    public static ClCacheOptions Max => new(true, 15);
    public static ClCacheOptions NoCache => new(false);
    public static ClCacheOptions CacheNoClean => new(true);
}
