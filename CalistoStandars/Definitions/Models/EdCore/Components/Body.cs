namespace CalistoStandars.Definitions.Models;

/// <summary>
///     Body result of ISerializable object that will be the content of an Message
///     It's properties should be used as this description indicates.
/// </summary>
public abstract class Body : Element<BodySign>, IBody 
{
    protected Body(BodySign sign, BodyContentPattern contentPattern) : base(sign, Enumerations.ElementType.Body) => ContentPattern = contentPattern;

    protected Body(BodyContentPattern contentPattern) : base(Enumerations.ElementType.Body) => ContentPattern = contentPattern;

    public BodyContentPattern ContentPattern { get; }

    public bool IsInvalidBody { get; set;}

    public abstract void Dispose();
}

