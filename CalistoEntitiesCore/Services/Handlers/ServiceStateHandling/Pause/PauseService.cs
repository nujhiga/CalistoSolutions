namespace CalistoEnvironment.Services.Handlers.ServiceStateHandling.Pause;
public class PauseService
{
    public Action Callback { get; set; }
    private TaskCompletionSource<bool> _mPaused;
    internal static readonly Task SCompletedTask = Task.FromResult(true);

    public bool IsPaused => _mPaused is not null;

    public void Execute(bool value = true)
    {
        if (value)
        {
            Interlocked.CompareExchange(
                ref _mPaused, new TaskCompletionSource<bool>(), null);
        }
        else
        {
            while (true)
            {
                var tcs = _mPaused;
                if (tcs == null) return;
                if (Interlocked.CompareExchange(ref _mPaused, null, tcs) != tcs) continue;
                tcs.SetResult(true);
                break;
            }
        }
    }

    public PauseToken Token => new PauseToken(this);

    public PauseService(Action callback) => Callback = callback;

    public PauseService ( )
    {
        
    }

    internal Task WaitWhilePausedAsync()
    {
        var cur = _mPaused;

        Callback.Invoke();

        return cur?.Task ?? SCompletedTask;
    }
    public async Task AwaitRequestAsync()
    {
        await WaitWhilePausedAsync();
        await Task.Delay(250);
    }
    public void Continue() => Execute(false);

}
