using System.Net.Http.Headers;
using System.Text;

using CalistoDbCore;

using CalistoEdCore;

using CalistoEnvironment.Services.Providers;

using CalistoStandars.Definitions.Structures;

namespace CalistoEnvironment;

// todo: Implement Pause - Cancel Services :: tdref:3-230322
public sealed class ClEnvironment : IDisposable
{
    #region ThreadSafe Singleton Pattern

    private static ClEnvironment _instance;
    private bool disposedValue;
    private static readonly object _padlock = new();

    private ClEnvironment()
    {
        _addGetCallbacks = (AddMessageCount, GetMessageCount);
    }

    public static ClEnvironment Instance
    {
        get
        {
            lock (_padlock)
            {
                if (_instance is null)
                    _instance = new ClEnvironment();

                return _instance;
            }
        }
    }
    #endregion
    
    public readonly GatewayProvider Gateway = new();

    public static readonly HttpClient _wsClient = new();
    public ClDbCore DbCore { get; private set; }
    public ClEdCore EdCore { get; private set; }

    private int _messagesCount = 0;

    public void AddMessageCount() => _messagesCount++;
    public int GetMessageCount() => _messagesCount;

    private (Action add, Func<int> get) _addGetCallbacks;

    #region Calisto DbCore

    private void InitDbCore() => DbCore = new ClDbCore();

    public async Task ResetDbCore()
    {
        if (DbCore is null) return;

        //todo: implement idisposable interface :: tdref:230322-2

        InitEdCore();
    }

    #endregion

    #region Calisto EdCore

    public void SetClientCredentials(in CampusTarget? campus = null)
    {
        if (EdCore is null) return;

        const string Basic = "Basic";

        string auxAuthString = campus is { } cmpInstance
            ? $"{Gateway.GetUsAccess(cmpInstance.Source)}:{Gateway.GetPwAccess(cmpInstance.Source)}"
            : $"{Gateway.GetUsAccess()}:{Gateway.GetPwAccess()}";
       
        string authString = Convert.ToBase64String(Encoding.Default.GetBytes(auxAuthString));
        
        _wsClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(Basic, authString);

        EdCore?.CampusChanged(campus.Value);
    }
    public void InitEdCore() => EdCore = new ClEdCore(in _wsClient, ref _addGetCallbacks);
    public async Task ResetEdCore()
    {
        if (EdCore is null) return;

        await Task.Run(() => EdCore.Dispose());

        InitEdCore();
    }

    #endregion
    
    #region IDisposable Pattern
    private void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                EdCore.Dispose();
                // TODO: dispose managed state (managed objects)
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            disposedValue = true;
        }
    }

    // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
    ~ClEnvironment()
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