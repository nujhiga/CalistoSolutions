using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalistoStandars.Definitions.Structures;
public readonly struct ExecutionOptions
{
    public readonly bool CacheResults;
    public readonly int? CacheLifeTime;

    private ExecutionOptions(bool cacheResults, int? cacheLifeTime = null)
    {
        CacheResults = cacheResults;
        CacheLifeTime = cacheLifeTime;
    }

    public static ExecutionOptions Default => new(true, 5);
    public static ExecutionOptions Min => new(true, 1);
    public static ExecutionOptions Med => new(true, 7);
    public static ExecutionOptions Max => new(true, 15);
    public static ExecutionOptions NoCache => new(false);
    public static ExecutionOptions CacheNoClean => new(true);
}
