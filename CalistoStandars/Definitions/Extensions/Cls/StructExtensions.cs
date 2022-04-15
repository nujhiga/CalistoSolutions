using CalistoStandards.Definitions.Structures.Cls;

namespace CalistoStandards.Definitions.Extensions;

public static class StructExtensions
{
    public static bool NullOrEmpty(this KeyReference? keyRef) => keyRef is { } key && !key.Source.NullOrEmpty();
}