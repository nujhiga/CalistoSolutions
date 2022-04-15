using CalistoStandards.Definitions.Structures.Cls;

namespace CalistoStandards.Definitions.Interfaces.Cls;

public interface IReferenceable : IEquatable<KeyReference?>
{
    KeyReference? Reference { get; set; }
}