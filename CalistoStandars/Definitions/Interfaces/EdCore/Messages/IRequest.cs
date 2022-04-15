using CalistoStandards.Definitions.Structures.EdCore;

namespace CalistoStandards.Definitions.Interfaces.EdCore.Messages;

public interface IRequest : IMessage //where T : Enum
{
    EdRequestEndpoint RequestEndpoint { get; set; }
}