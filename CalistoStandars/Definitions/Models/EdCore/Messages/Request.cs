namespace CalistoStandars.Definitions.Models;

public sealed class Request : Message, IRequest //where T : Enum
{
    public Request(MessageSign sign, bool isInvalid) : base(sign, isInvalid, Enumerations.ElementType.Request)
    {
    } //=> InvalidRequest = invalidRequest;

    public EdRequestEndpoint RequestEndpoint { get; set; }
    public bool InvalidRequest { get; }
}