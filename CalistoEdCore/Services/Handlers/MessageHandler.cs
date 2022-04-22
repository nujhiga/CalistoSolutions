using System.Net;
using System.Text;

using CalistoEdCore.Services.Factories;
using CalistoStandards.Definitions;
using CalistoStandards.Definitions.Interfaces.EdCore.Messages;
using CalistoStandards.Definitions.Structures.Cls;
using CalistoStandards.Providers;

namespace CalistoEdCore.Services.Handlers;
public abstract class MessageHandler
{
    protected const string BaseLocation = "urn:Educativa/Aula";
    protected const string Header = "SOAPAction";

    //protected readonly Func<int> GetMessageCountCallback;

    protected readonly HttpClient WClient;
    internal readonly MessageBuilder MBuilder;

    private readonly KeyedDelegator _delegator = KeyedDelegator.Instance;

    public CampusTarget UsingCampus { get; set; }

    protected MessageHandler()
    {
        
        MBuilder = new MessageBuilder();
    }

    protected MessageHandler(in HttpClient wClient)
    {
        WClient = wClient;
        MBuilder = new MessageBuilder();
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

        HttpClient client = _delegator.Invoke<HttpClient>(ClConsts.ClEnviroment.GetClient);

        using HttpResponseMessage httpResp = await client.SendAsync
            (httpReqMsg, HttpCompletionOption.ResponseContentRead);

        string xmlResponse = await httpResp.Content.ReadAsStringAsync();
        HttpStatusCode statusCode = httpResp.StatusCode;

        IResponse response = MBuilder.GetMessage<IResponse>
            (request.Sign, new object[] { xmlResponse, statusCode });

        return response;
    }
}
