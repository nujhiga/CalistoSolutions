using System.Net.Http.Headers;
using System.Text;

using CalistoDbCore;

using CalistoEdCore;

using CalistoStandards.Definitions.Structures.Cls;
using CalistoStandards.Providers;
using CalistoEnvironment.Services.Providers.Gateways;

namespace CalistoEnvironment;

// todo: Implement Pause - Cancel Services :: tdref:3-230322
public sealed class ClEnvironment : IDisposable, IKeyedDelegation
{
    #region ThreadSafe Singleton Pattern

    private static ClEnvironment _instance;
    private bool disposedValue;
    private static readonly object _padlock = new();

    private ClEnvironment()
    {
        SetupDelegations();
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

    internal readonly KeyedDelegator KyDelegator = KeyedDelegator.Instance;

    public readonly GatewayProvider Gateway = new();

    public static readonly HttpClient WsClient = new();




    public ClDbCore? DbCore { get; private set; }
    public ClEdCore? EdCore { get; private set; }

    public int MessagesCount = 0;
    public int RequestsCount = 0;
    public int ResponsesCount = 0;

    public void SetupDelegations()
    {
        KyDelegator.SetupDelegate(SetHttpClientCredentials);
        KyDelegator.SetupDelegate(GetClient);
        KyDelegator.SetupDelegate(GetCampusTarget);
        KyDelegator.SetupDelegate(GetSelectedPeriod);
        KyDelegator.SetupDelegate(GetSelectedPeriods);
    }

    private static HttpClient GetClient() => WsClient;
    private CampusTarget GetCampusTarget() => Gateway.SelectedCampus;
    private Period GetSelectedPeriod() => Gateway.SelectedPeriod;
    private Period[] GetSelectedPeriods() => Gateway.SelectedPeriods;


    //  private (Action add, Func<int> get) _addGetCallbacks;

    #region Calisto DbCore

    public void InitDbCore() => DbCore = new ClDbCore();

    public async Task ResetDbCore()
    {
        if (DbCore is null) return;

        //todo: implement idisposable interface :: tdref:230322-2

        InitEdCore();
    }

    #endregion

    #region Calisto EdCore


    internal void SetHttpClientCredentials()
    {
        const string Basic = "Basic";

        GatewayProvider gate = Gateway;
        CampusTarget campus = gate.SelectedCampus;

        string preAuthString = GetPreAuthString(in gate);
        string authString = Convert.ToBase64String(Encoding.Default.GetBytes(preAuthString));

        WsClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(Basic, authString);
    }

    private static string GetPreAuthString(in GatewayProvider gate)
    {
        CampusTarget campus = gate.SelectedCampus;

        StringBuilder sb = new();
        sb.Append(gate.GetUsAccess(campus.Source));
        sb.Append(":");
        sb.Append(gate.GetPwAccess(campus.Source));
        string preAuthString = sb.ToString();
        sb.Clear();
        sb.Capacity = 0;
        sb.Length = 0;

        return preAuthString;
    }

    /*
    private void SetClientCredentials(in CampusTarget? campus = null)
    {
        if (EdCore is null) return;

        const string Basic = "Basic";

        string auxAuthString = campus is { } cmpInstance
            ? $"{Gateway.GetUsAccess(cmpInstance.Source)}:{Gateway.GetPwAccess(cmpInstance.Source)}"
            : $"{Gateway.GetUsAccess()}:{Gateway.GetPwAccess()}";

        string authString = Convert.ToBase64String(Encoding.Default.GetBytes(auxAuthString));

        WsClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(Basic, authString);

        EdCore?.CampusChanged(campus.Value);
    }
    */

    public void InitEdCore() => EdCore = new ClEdCore(in WsClient);

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