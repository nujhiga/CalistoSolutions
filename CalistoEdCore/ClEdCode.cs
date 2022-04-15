using CalistoEdCore.Services.Handlers;

using CalistoStandards.Definitions.Structures.Cls;

namespace CalistoEdCore;

public sealed class ClEdCore : IDisposable
{
    private bool _disposed;

    public readonly MessageQueueHandler MessageQueueHandler;
   
    public ClEdCore(in HttpClient wsClient)
    {
        MessageQueueHandler = new MessageQueueHandler(in wsClient);
    }


    //public ClEdCore(KeyedDelegator)
    //{
    //    MessageQueueHandler = new MessageQueueHandler(in wsClient);
    //}

    //public ClEdCore(in HttpClient wsClient)
    //{
    //    MessageQueueHandler = new MessageQueueHandler(in wsClient);
    //}

    public void CampusChanged(CampusTarget campus) => MessageQueueHandler.UsingCampus = campus;

    #region IDisposable Pattern
    private void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                //_wsClient?.CancelPendingRequests();
                
            }

            //_wsClient?.Dispose(); todo: Verify: should be disposed at this context ?????

            _disposed = true;
        }
    }
    
    ~ClEdCore()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: false);
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    #endregion
}
