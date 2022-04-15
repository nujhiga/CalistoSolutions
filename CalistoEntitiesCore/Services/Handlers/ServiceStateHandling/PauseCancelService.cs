namespace CalistoEnvironment.Services.Handlers.ServiceStateHandling;

public sealed class PauseCancelService : IDisposable
{
    public readonly Cancellation.CancelService CancelService;
    public readonly Pause.PauseService PauseService;

    public CancellationToken CancelToken => CancelService.Token;
    public Pause.PauseToken PauseToken => PauseService.Token;

    public PauseCancelService(Action pauseCallbackDelegate)
    {
        CancelService = new Cancellation.CancelService();
        PauseService = new Pause.PauseService(pauseCallbackDelegate);
    }

    public PauseCancelService()
    {
        CancelService = new Cancellation.CancelService();
        PauseService = new Pause.PauseService();
    }

    public void SetPauseCallback(Action delegateAction) => PauseService.Callback = delegateAction;

    public void Dispose()
    {
        CancelService.Dispose();
    }
}
