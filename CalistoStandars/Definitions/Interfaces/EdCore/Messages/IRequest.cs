namespace CalistoStandars.Definitions.Interfaces;

public interface IRequest : IMessage //where T : Enum
{
    EdRequestEndpoint RequestEndpoint { get; set; }
}