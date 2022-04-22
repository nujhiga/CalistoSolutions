using CalistoStandards.Definitions.Interfaces.Cls;
using CalistoStandards.Definitions.Interfaces.DbCore.Persons;
using CalistoStandards.Definitions.Interfaces.DbCore.Users;
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

public sealed class ClRequestSerializer
{
    private readonly Dictionary<MessageSign, IClComponent> _structures;

    public ClRequestSerializer(Dictionary<MessageSign, IClComponent> structures)
    {
        _structures = structures;
    }

  
}

public interface IClRequest : IClMessage
{

}