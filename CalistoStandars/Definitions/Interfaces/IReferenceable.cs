namespace CalistoStandars.Definitions.Interfaces;

public interface IReferenceable : IEquatable<KeyReference?>
{
    KeyReference? Reference { get; set; }
}