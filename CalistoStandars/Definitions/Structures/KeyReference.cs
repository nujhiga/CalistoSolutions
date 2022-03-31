namespace CalistoStandars.Definitions.Structures;


public readonly struct MessageReference
{
    public readonly MessageSign Sign;

}

public readonly struct KeyReference : IEquatable<KeyReference>
{
    public IEnumerable<IConvertible?> Source { get; }

    public KeyReference(params IConvertible?[] source) => Source = source;

    public bool Equals(KeyReference other)
    {
        if (Source.Any(s => s is null) || other.Source.Any(s => s is null))
            return false;

        var reqHits = Source.Count();
        var hits = 0;

        for (var i = 0; i < reqHits; i++)
        {
            if (!Source.ElementAt(i)!.Equals(other.Source.ElementAt(i)))
                continue;

            hits++;
        }

        return hits == reqHits;
    }

    public override bool Equals(object? obj) => obj is KeyReference @ref && Equals(@ref);

    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;

            foreach (var obj in Source)
            {
                if (obj is null) continue;

                hash *= 23 + obj.GetHashCode();
            }

            return hash;
        }
    }

    public static bool operator ==(KeyReference left, KeyReference right) => left.Equals(right);

    public static bool operator !=(KeyReference left, KeyReference right) => !(left == right);

    public override string ToString() => Source.ToCsvString('-');
}