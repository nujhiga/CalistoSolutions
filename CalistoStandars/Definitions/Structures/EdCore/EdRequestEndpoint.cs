using System.Diagnostics.CodeAnalysis;

namespace CalistoStandards.Definitions.Structures.EdCore;

public readonly struct EdRequestEndpoint : IEquatable<EdRequestEndpoint>
{
    public readonly MessageSign MessageSign;
    public readonly Uri UriPoint;

    public (string, string) Endpoint => (UriStr, SignStr);
    public string SignStr => $"{MessageSign}";
    public string UriStr => $"{UriPoint}";

    public EdRequestEndpoint(in Uri uriPoint, in MessageSign messageSign)
    {
        UriPoint = uriPoint;
        MessageSign = messageSign;
    }

    public EdRequestEndpoint(in string uriPoint, in MessageSign messageSign)
    {
        UriPoint = new Uri(uriPoint);
        MessageSign = messageSign;
    }

    public override string ToString() => UriStr;

    public override bool Equals([NotNullWhen(true)] object? obj) => base.Equals(obj);

    public override int GetHashCode() => HashCode.Combine((int)MessageSign, UriPoint);

    public static bool operator ==(EdRequestEndpoint left, EdRequestEndpoint right) => left.Equals(right);

    public static bool operator !=(EdRequestEndpoint left, EdRequestEndpoint right) => !(left == right);

    public bool Equals(EdRequestEndpoint other) => MessageSign == other.MessageSign && UriPoint.Equals(other.UriPoint);
}