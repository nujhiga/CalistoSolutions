using System.Reflection;

namespace CalistoStandars.Definitions.Interfaces;

public interface INode : IElement<NodeSign>, IDisposable
{
    [ElementAttr(Enumerations.ElementType.MemberCollection)]
    IEnumerable<IMember> Members { get; set; }
    PropertyInfo MembersProperty => GetType().GetProperty(nameof(Members))!;
}