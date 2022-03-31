using System.Net;
using System.Text;

using CalistoEdCore.Services.Factories;

using CalistoStandars.Definitions.Enumerations;
using CalistoStandars.Definitions.Interfaces;
using CalistoStandars.Definitions.Structures;

namespace CalistoEdCore.Services.Handlers;
public abstract class MessageHandler
{
    protected const string BaseLocation = "urn:Educativa/Aula";
    protected const string Header = "SOAPAction";
    
    protected readonly Func<int> GetMessageCountCallback;

    protected readonly HttpClient WClient;
    internal readonly MessageBuilder MBuilder;

    public CampusTarget UsingCampus { get; set; }

    public MessageHandler()
    {
        
    }

    protected MessageHandler(in HttpClient wClient, ref (Action addCallback, Func<int> getCallback) addGetCallbacks)
    {
        WClient = wClient;

        GetMessageCountCallback = addGetCallbacks.getCallback;

        MBuilder = new MessageBuilder(ref addGetCallbacks);
    }

   // protected MessageHandler(in HttpClient wClient) => WClient = wClient;

    public async Task<IResponse> RequestResponse(MessageSign sign, object source)
    {
        IRequest request = MBuilder.GetMessage<IRequest>(in sign, in source);

        if (request.IsInvalid) return MBuilder.GetMessage<IResponse>(sign, request);

        IResponse response = await RequestResponse(request, UsingCampus.CampusUri);

        return response;
    }

    protected async Task<IResponse> RequestResponse(IRequest request, Uri campusUri)
    {
        using HttpContent content = new StringContent(request.StoredXml, Encoding.UTF8, "text/xml");

        using HttpRequestMessage httpReqMsg = new HttpRequestMessage(HttpMethod.Post, campusUri);

        httpReqMsg.Headers.Add(Header, $"{BaseLocation}#{request.Sign}");

        httpReqMsg.Content = content;

        using HttpResponseMessage httpResp = await WClient.SendAsync
            (httpReqMsg, HttpCompletionOption.ResponseContentRead);

        string xmlResponse = await httpResp.Content.ReadAsStringAsync();
        HttpStatusCode statusCode = httpResp.StatusCode;

        IResponse response = MBuilder.GetMessage<IResponse>
            (request.Sign, new object[] { xmlResponse, statusCode });

        return response;
    }
}
