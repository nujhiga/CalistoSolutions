using System.Net;
using CalistoStandards.Definitions.Interfaces.EdCore.Messages;

namespace CalistoStandards.Definitions.Models.EdCore.Messages;

public sealed class Response : Message, IResponse //> where T : Enum
{
    public IRequest? InvalidRequest { get; }

    public Response(IRequest invalidRequest) : base(invalidRequest.Sign, true, ClElementType.Response)
    {
        InvalidRequest = invalidRequest;
    }

    public Response(MessageSign sign, HttpStatusCode statusCode, bool isInvalid) : base(sign, isInvalid, ClElementType.Response)
    {
        StatusCode = statusCode;
    }

    public string ContentFilter { get; }
    public HttpStatusCode StatusCode { get; }
}