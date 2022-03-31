using System.Collections.Concurrent;

using CalistoEdCore.Services.Handlers;

using CalistoStandars.Definitions.Enumerations;
using CalistoStandars.Definitions.Interfaces;

namespace CalistoEdCore.Services.Messages;

//todo: implement idisposable interface :: tdref:4-230322
//todo: Implement Pause - Cancel Services tdref:3-230322

public sealed class MessageQueueHandler : MessageHandler, IDisposable
{
    private readonly ConcurrentQueue<IRequest> _pendingRequests;
    private readonly ConcurrentQueue<IResponse> _pendingResponses;
    
    public MessageQueueHandler(in HttpClient wClient, ref (Action addCallback, Func<int> getCallback) callBacks) : base(in wClient, ref callBacks)
    {
        _pendingRequests = new ConcurrentQueue<IRequest>();
        _pendingResponses = new ConcurrentQueue<IResponse>();
    }

    public bool EnqueueRequest(in MessageSign sign, in object source)
    {
        IRequest request = MBuilder.GetMessage<IRequest>(in sign, in source);

        if (request.IsInvalid) return false;
        
        _pendingRequests.Enqueue(request);

        return true;
    }
    public bool RequestResponsesEnqueue(in MessageSign[] signs, in object[] sources)
    {
        if (signs.Length != sources.Length) return false;

        int count = signs.Length;
        int validCount = 0;

        for (int i = 0; i < count; i++)
        {
            MessageSign sign = signs[i];
            object source = sources[i];

            IRequest request = MBuilder.GetMessage<IRequest>(in sign, in source);

            if (request.IsInvalid) return false;
            
            validCount++;
            _pendingRequests.Enqueue(request);
        }

        return validCount == count;
    }
    public async Task<bool> RequestResponsesEnqueue()
    {
        int reqCount = _pendingRequests.Count;
        int successCount = 0;

        while (!_pendingRequests.IsEmpty)
            if (await RequestResponseEnqueue())
                successCount++;

        return successCount == reqCount;
    }
    public async Task<bool> RequestResponseEnqueue()
    {
        if (!_pendingRequests.TryDequeue(out IRequest request)) return false;

        IResponse response = await RequestResponse(request, UsingCampus.CampusUri);

        _pendingResponses.Enqueue(response);

        return !response.IsInvalid;
    }

    public bool TryDequeueResponse(out IResponse response)
    {
        bool success = _pendingResponses.TryDequeue(out response);

        return success;
    }

    public async Task<IResponse> RequestResponse(MessageSign sign, object source)
    {
        IRequest request = MBuilder.GetMessage<IRequest>(in sign, in source);

        if (request.IsInvalid) return MBuilder.GetMessage<IResponse>(sign, request);

        IResponse response = await RequestResponse(request, UsingCampus.CampusUri);

        return response;
    }



    public void Dispose()
    {
        _pendingRequests.Clear();

        _pendingResponses.Clear();

      //  _wsClient.Dispose();
    }
}


/*
public static async Task<string> PostSOAPRequestAsync(string url, string text)
{
    url = ClEdCore.Instance.UrlCampus;

    StringBuilder sb = new();

    SetStartLines(sb);
    SetConsultUser(sb, "", "A", "12019");
    SetEndLines(sb);

    text = sb.ToString();

    {}

    string methodsing = "consultar_usuarios";

    using HttpContent content = new StringContent(text, Encoding.UTF8, "text/xml"); 

    using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);

    request.Headers.Add(Header, $"{BaseLocation}#{methodsing}");

    request.MembersContent = content;

    using HttpResponseMessage response = await ClEdCore.HttpClient.SendAsync(request, HttpCompletionOption.ResponseContentRead);

    return await response.MembersContent.ReadAsStringAsync();

}
*/
