using System.Reflection;

namespace CalistoStandards.Definitions.Interfaces.EdCore.Components;

public interface INode : IElement<NodeSign>, IDisposable
{
    [ElementAttr(ClElementType.MemberCollection)]
    IEnumerable<IMember> Members { get; set; }
    PropertyInfo MembersProperty => GetType().GetProperty(nameof(Members))!;
}

