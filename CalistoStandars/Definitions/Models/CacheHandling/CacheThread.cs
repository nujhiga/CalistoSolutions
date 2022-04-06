namespace CalistoStandars.Definitions.Models;

public sealed class CacheThread
{
    public readonly int ThreadRef;
    public readonly Thread Thread;
    public int LifeTime { get; set; }
    public CacheThread(in int threadRef, int lifeTime, ThreadStart method)
    {
        Thread = new Thread(method);
        ThreadRef = threadRef;
        LifeTime = lifeTime;
    }
    public void Start() => Thread.Start();
}
