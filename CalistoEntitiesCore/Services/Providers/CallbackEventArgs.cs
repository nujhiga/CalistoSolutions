namespace CalistoEnvironment.Services.Providers;

/*
public class CallbackEventArgs : EventArgs
{
    private readonly Action _callback;
    private readonly Action<object> _callbackArgs;

    private readonly Func<Task> _asyncCallback;

    private readonly Func<Task<object>> _asyncCallbackResult;
    private readonly Func<object, Task<object>> _asyncCallbackArgsResult;

    public CallbackEventArgs(in Action callback)
    {
        _callback = callback;
    }
    public CallbackEventArgs(in Action<object> callbackArgs)
    {
        _callbackArgs = callbackArgs;
    }
    public CallbackEventArgs(in Func<Task> asyncCallback)
    {
        _asyncCallback = asyncCallback;
    }
    public CallbackEventArgs(in Func<Task<object>> asyncCallbackResult)
    {
        _asyncCallbackResult = asyncCallbackResult;
    }
    public CallbackEventArgs(in Func<object, Task<object>> asyncCallbackArgsResult)
    {
        _asyncCallbackArgsResult = asyncCallbackArgsResult;
    }

    public void Call() => _callback();
    public void Call(object args) => _callbackArgs(args);
    public async ValueTask CallAsync() => await _asyncCallback();
    public async ValueTask<object> CallResultAsync() => await _asyncCallbackResult();
    public async ValueTask<object> CallResultAsync(object args) => await _asyncCallbackArgsResult(args);

}
*/