using CalistoStandards.Definitions.Interfaces.EdCore.Components;

namespace CalistoStandards.Definitions.Interfaces.EdCore.Messages;

public interface IRequestStructure
{
    MessageSign? RequestSign { get; }
    IBody? RequestBody { get; }
}