using System.Reflection;

namespace CalistoStandards.Definitions.Models;

public interface IClMemberBody : IClBody
{
    public IClMember? Member { get; set; }
    PropertyInfo MembersProperty => GetType().GetProperty(nameof(Member))!;
}