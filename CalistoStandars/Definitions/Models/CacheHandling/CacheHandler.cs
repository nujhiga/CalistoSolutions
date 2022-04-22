using System.Collections.Concurrent;

namespace CalistoStandards.Definitions.Models.CacheHandling;

public readonly struct ClRequestKey : IEquatable<ClRequestKey>
{
    public int Key { get; }
    public DbRequestSign Sign { get; }

    public ClRequestKey(DbRequestSign sign, in int currentDbRequestCount)
    {
        Sign = sign;
        Key = currentDbRequestCount;
    }

    public bool Equals(ClRequestKey other) => Key == other.Key && Sign == other.Sign;

    public override bool Equals(object? obj) => obj is ClRequestKey other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(Key, (int)Sign);

    public static bool operator ==(ClRequestKey left, ClRequestKey right) => left.Equals(right);

    public static bool operator !=(ClRequestKey left, ClRequestKey right) => !(left == right);
}

public sealed class CacheHandler<TCache> where TCache : struct
{
    private readonly Action<TCache> _cleanupCallback;
    private readonly ConcurrentDictionary<int, CacheThread> _threads;

    private readonly Queue<TCache> _queue;

    private int _threadid = 0;

    public CacheHandler(Action<TCache> cleanupCallback)
    {
        _cleanupCallback = cleanupCallback;
        _queue = new Queue<TCache>();
        _threads = new ConcurrentDictionary<int, CacheThread>();
    }

    private async void WhileRunning(int threadid)
    {
        CacheThread thisThread = _threads[threadid];

        do
        {
            await Task.Delay(60000);

            thisThread.LifeTime--;

        } while (thisThread.LifeTime > 0);

        Finish(thisThread);
    }

    public void AddStart(TCache rtype, int lifeTime = 1)
    {
        _queue.Enqueue(rtype);

        if (_threads.ContainsKey(_threadid)) _threadid++;

        CacheThread cThread = new CacheThread(_threadid,
            lifeTime, () => WhileRunning(_threadid));

        _threads.TryAdd(_threadid, cThread);

        cThread.Start();
    }

    private void Finish(CacheThread thread)
    {
        TCache rtype = _queue.Dequeue();

        _cleanupCallback.Invoke(rtype);

        thread.Thread.Join(1000);
        thread.Thread.Interrupt();

        _threads.TryRemove(thread.ThreadRef, out _);
    }
}