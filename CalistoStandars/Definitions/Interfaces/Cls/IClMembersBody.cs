using System.Reflection;

namespace CalistoStandards.Definitions.Models;

public interface IClMembersBody : IClBody
{
    public IEnumerable<IClMember>? Members { get; set; }
    PropertyInfo MembersProperty => GetType().GetProperty(nameof(Members))!;
}