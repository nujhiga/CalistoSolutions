using System.Reflection;

namespace CalistoStandards.Definitions.Models;

public interface IClNodesBody : IClBody
{
    IEnumerable<IClNode> Nodes { get; set; }
    PropertyInfo NodeProperty => GetType().GetProperty(nameof(Nodes))!;
}