namespace CalistoEnvironment.Services.Handlers.ServiceStateHandling.Pause;
public struct PauseToken
{
    private readonly PauseService _mSource;
    internal PauseToken(PauseService source) { _mSource = source; }
    public bool IsPaused => _mSource is { IsPaused: true };
    public Task WaitWhilePausedAsync() => IsPaused ? _mSource.WaitWhilePausedAsync() : PauseService.SCompletedTask;
}
