using System.Collections;
using System.Net;
using CalistoStandars.Definitions.Interfaces;
using CalistoStandars.Definitions.Enumerations;
using CalistoStandars.Definitions.Extensions;

namespace CalistoEdCore.Services.Factories;

internal sealed class MessageBuilder
{
    private readonly Action _addMessageCountCallback;
    private readonly Func<int> _getMessageCountCallback;

    internal MessageBuilder(ref (Action addCallback, Func<int> getCallback) addGetCallBacks)
    {
        _addMessageCountCallback = addGetCallBacks.addCallback;
        _getMessageCountCallback = addGetCallBacks.getCallback;
    }

    internal TMessage GetMessage<TMessage>(in MessageSign sign, in object source) where TMessage : IMessage
    {
        TMessage message = default;

        int currentMessageID = _getMessageCountCallback();

        if (typeof(TMessage) == typeof(IRequest))
            message = (TMessage)GetRequest(in sign, in source, in currentMessageID);
        else if (typeof(TMessage) == typeof(IResponse))
            message = (TMessage)GetResponse(in sign, in source, in currentMessageID);

        _addMessageCountCallback();

        return message;
    }


    private static IResponse GetResponse(in MessageSign sign, in object source, in int currentMessageID)
    {
        if (source is IRequest request)
            return MessageFactory.CreateResponse(request, currentMessageID);

        if (source is not object[] responseData) return null!;

        string xmlResponse = (string)responseData[0];
        HttpStatusCode statusCode = (HttpStatusCode)responseData[1];

        ClResult responseResult = statusCode is HttpStatusCode.OK ? 
            ClResult.Valid : ClResult.Invalid;

        return MessageFactory.CreateResponse(sign, xmlResponse, statusCode, responseResult, currentMessageID);
    }

    private static IRequest GetRequest(in MessageSign sign, in object source, in int currentMessageID)
    {
        IRequestStructure rStruct = MessageStructProvider.GetRequestStruct(sign);
        
        ClResult contentResult = ClResult.Invalid;
        
        using MessageSerializer serializer = new MessageSerializer(sign);

        string serializedXml = null;

        if (!IsMassiveRequest(in source, sign))
        {
            IBody body = MessageFactory.GetBodyContent(in source, in rStruct);
            serializedXml = serializer.Serialize(in body);
            
            contentResult = body.IsInvalidBody ? ClResult.Invalid : ClResult.Valid;
        }
        else
        {
            if (source is IEnumerable<object> sourceObjs)
            {
                IEnumerable<IBody> bodies = MessageFactory.GetBodyContent(sourceObjs, rStruct);

                serializedXml = serializer.Serialize(in bodies);

                contentResult = bodies.Any(b => b.IsInvalidBody) ? ClResult.Invalid : ClResult.Valid;
            }
        }

        return MessageFactory.CreateRequest(sign, serializedXml, contentResult, currentMessageID);
    }




    private static bool IsMassiveRequest<TSign>(in object source, in TSign sign) => IsEnumerableSource(in source) && IsMassiveSign(in sign);
    private static bool IsEnumerableSource(in object source) => source.GetType().GetInterface(nameof(IEnumerable)) is not null || source.GetType().IsArray;
    private static bool IsMassiveSign<TSign>(in TSign sign) => sign is MessageSign mSing && mSing.IsMassiveRequest();
    
}




