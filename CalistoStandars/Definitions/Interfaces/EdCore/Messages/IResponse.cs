using System.Net;

namespace CalistoStandards.Definitions.Interfaces.EdCore.Messages;

public interface IResponse : IMessage //where T : Enum
{
    string ContentFilter { get; }
    HttpStatusCode StatusCode { get; }
    IRequest? InvalidRequest { get; }
}