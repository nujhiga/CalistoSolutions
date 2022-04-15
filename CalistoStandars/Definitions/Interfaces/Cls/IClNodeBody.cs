using System.Reflection;

namespace CalistoStandards.Definitions.Models;

public interface IClNodeBody : IClBody
{
    IClNode Node { get; set; }
    PropertyInfo NodeProperty => GetType().GetProperty(nameof(Node))!;
}