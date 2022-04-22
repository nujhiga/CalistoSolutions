using System.Reflection;
using CalistoStandards.Definitions.Interfaces.Cls;

namespace CalistoStandards.Definitions.Models;

public interface IClBody : IClSignedComponent<BodySign>, IClComponent
{
    ClMessagePattern ClMessagePattern { get; set; }
    bool IsValidBody { get; set; }
    public bool IsContainer { get; set; }

    bool IsMassive { get; set; }
    PropertyInfo IsValidBodyProperty => GetType().GetProperty(nameof(IsValidBody))!;
}