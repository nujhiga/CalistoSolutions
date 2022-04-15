using CalistoStandards.Definitions.Interfaces.EdCore.Messages;
using CalistoStandards.Definitions.Structures.EdCore;

namespace CalistoStandards.Definitions.Models.EdCore.Messages;

public sealed class Request : Message, IRequest //where T : Enum
{
    public Request(MessageSign sign, bool isInvalid) : base(sign, isInvalid, ClElementType.Request)
    {
    } //=> InvalidRequest = invalidRequest;

    public EdRequestEndpoint RequestEndpoint { get; set; }
    public bool InvalidRequest { get; }
}



public interface IClRequest : IClMessage
{

}