using CalistoStandards.Definitions.Interfaces.EdCore.Components;

namespace CalistoStandards.Definitions.Models.EdCore.Components;

/// <summary>
///     Body result of ISerializable object that will be the content of an Message
///     It's properties should be used as this description indicates.
/// </summary>
public abstract class Body : Element<BodySign>, IBody
{
    protected Body(BodySign sign, ClMessagePattern contentPattern) : base(sign, ClElementType.Body) => ContentPattern = contentPattern;

    protected Body(ClMessagePattern contentPattern) : base(ClElementType.Body) => ContentPattern = contentPattern;

    public ClMessagePattern ContentPattern { get; }

    public bool IsInvalidBody { get; set; }

    public abstract void Dispose();
}

