using System.Net;

namespace CalistoStandars.Definitions.Models;

public sealed class Response : Message, IResponse //> where T : Enum
{
    public IRequest? InvalidRequest { get; }

    public Response(IRequest invalidRequest) : base(invalidRequest.Sign, true, Enumerations.ElementType.Response)
    {
        InvalidRequest = invalidRequest;
    }

    public Response(MessageSign sign, HttpStatusCode statusCode, bool isInvalid) : base(sign, isInvalid, Enumerations.ElementType.Response)
    {
        StatusCode = statusCode;
    }

    public string ContentFilter { get; }
    public HttpStatusCode StatusCode { get; }
}