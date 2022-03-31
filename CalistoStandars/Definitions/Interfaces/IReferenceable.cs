namespace CalistoStandars.Definitions.Interfaces;

public interface IReferenceable
{
    KeyReference? Reference { get; set; }
    //public void SetReference(params IConvertible[]? values);
}