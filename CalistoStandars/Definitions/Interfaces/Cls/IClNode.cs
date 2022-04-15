using System.Reflection;
using CalistoStandards.Definitions.Interfaces.Cls;

namespace CalistoStandards.Definitions.Models;

public interface IClNode : IClSignedComponent<NodeSign>, IClComponent
{
    IEnumerable<IClMember>? Members { get; set; }
    PropertyInfo MembersProperty => GetType().GetProperty(nameof(Members))!;
}