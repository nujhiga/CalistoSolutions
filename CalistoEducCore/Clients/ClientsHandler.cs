using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Description;
using Microsoft.IdentityModel.Protocols.WsAddressing;
using U3FEduServices;


namespace CalistoEducCore.Clients;



public partial class U3FClient
{
    
    public U3FClient()
    {
        
    }

}















public sealed class ClientHandler : KeyedCollection<ClientKey, ICommunicationObject>
{
    private static ClientHandler _handler;

    private static readonly object _padlock = new();
    private ClientHandler()
    {
        Add(new U3FEduServices.AulaSoapClient());
        Add(new ULPEduServices.AulaSoapClient());
        Add(new U3PEduServices.AulaSoapClient());
    }
    public static ClientHandler Handler
    {
        get
        {
            lock (_padlock)
            {
                return _handler ??= new ClientHandler();
            }
        }
    }
    protected override ClientKey GetKeyForItem(ICommunicationObject item)
    {
        if (item is U3FEduServices.AulaSoapClient)
            return ClientKey.U3F;

        if (item is ULPEduServices.AulaSoapClient)
            return ClientKey.ULP;

        if (item is U3PEduServices.AulaSoapClient)
            return ClientKey.U3P;

        return default;
    }
    
    public TClient GetClient<TClient>(ClientKey key) where TClient : class
    {
        var client = this[key];

        if (typeof(TClient) == client.GetType())
            return client as TClient;

        return null;
    }
}
