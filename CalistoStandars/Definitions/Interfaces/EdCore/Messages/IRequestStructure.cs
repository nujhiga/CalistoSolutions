namespace CalistoStandars.Definitions.Interfaces;

public interface IRequestStructure
{
    MessageSign? RequestSign { get; }
    IBody? RequestBody { get; }
}