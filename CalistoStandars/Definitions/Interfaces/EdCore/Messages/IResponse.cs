using System.Net;

namespace CalistoStandars.Definitions.Interfaces;

public interface IResponse : IMessage //where T : Enum
{
    string ContentFilter { get; }
    HttpStatusCode StatusCode { get; }
    IRequest? InvalidRequest { get; }
}