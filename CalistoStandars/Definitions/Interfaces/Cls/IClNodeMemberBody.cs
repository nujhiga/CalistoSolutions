using System.Reflection;

namespace CalistoStandards.Definitions.Models;

public interface IClNodeMemberBody : IClBody
{
    IClMember? Member { get; set; }
    IClNode? Node { get; set; }
    PropertyInfo MemberProperty => GetType().GetProperty(nameof(Member))!;
    PropertyInfo NodeProperty => GetType().GetProperty(nameof(Node))!;
}