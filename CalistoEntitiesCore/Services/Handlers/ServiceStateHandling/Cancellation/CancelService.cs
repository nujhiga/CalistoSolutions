namespace CalistoEnvironment.Services.Handlers.ServiceStateHandling.Cancellation;
public class CancelService : CancellationTokenSource
{
    public bool CancelSuccess { get; private set; }
    public CancelService() { }

    public async ValueTask<bool> AwaitRequestAsync()
    {
        await Task.Delay(250);
        return IsCancellationRequested;
    }

    public async Task ExecuteAsync()
    {
        try
        {
            await Task.Run(Cancel);
            CancelSuccess = true;
        }
        catch { CancelSuccess = false; }
    }

    public async Task ExecuteAfterAsync(int miliSeconds)
    {
        try
        {
            await Task.Run(() => CancelAfter(miliSeconds));
            CancelSuccess = true;
        }
        catch { CancelSuccess = false; }
    }
}
