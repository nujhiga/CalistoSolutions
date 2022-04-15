using System.Reflection;
using CalistoStandards.Definitions.Interfaces.Cls;

namespace CalistoStandards.Definitions.Models;

public interface IClContainerBody : IClSignedComponent<BodySign>
{
    IEnumerable<IClNode>? Nodes { get; set; }
    PropertyInfo NodesProperty => GetType().GetProperty(nameof(Nodes))!;
}