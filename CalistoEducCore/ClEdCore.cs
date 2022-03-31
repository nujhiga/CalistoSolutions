using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.ServiceModel;
using System.ServiceModel.Description;

using CalistoEducCore;

using Microsoft.IdentityModel.Protocols.WsAddressing;

using U3FEduServices;

namespace CalistoEducCore;



public interface IEducativaClient
{

}

public interface IEducativaClient<TClient> : IEducativaClient where TClient : class
{
   // ClientBase<TClient> ClientBase { get; }
}

public abstract class EducativaClient<TClient, TIClient> : IEducativaClient<TClient> where TClient : class
{
  //  public abstract ClientBase<TClient> ClientBase { get; protected set; }

}

public sealed class U3FClient : EducativaClient<U3FEduServices.AulaSoapClient, U3FEduServices.AulaSoap>
{
    //public override ClientBase<U3FEduServices.AulaSoapClient> ClientBase { get; set; }

    public U3FClient()
    {
        var x = new U3FEduServices.AulaSoapClient().OpenAsync();
        {}
    }

}


public class ClEdCore
{

    public async void foo()
    {
        U3FClient clientl = new U3FClient();

        
        AulaSoapClient client = new AulaSoapClient(AulaSoapClient.EndpointConfiguration.AulaSoap);

        await client.OpenAsync();

        {}


        EndpointReference refe = new EndpointReference("https://campus.untrefvirtual.edu.ar/soap/");

        EndpointAddress add = new EndpointAddress("https://campus.untrefvirtual.edu.ar/soap/");

    }

}
