namespace CalistoStandars.Definitions.Interfaces;

/// <summary>
///     Common Interface for Body result of ISerializable object that will be the content of an Message
///     It's properties should be used as this description indicates.
/// </summary>
public interface IBody : IElement<BodySign>, IDisposable
{
    BodyContentPattern ContentPattern { get; }

    bool IsInvalidBody { get; set; }
}