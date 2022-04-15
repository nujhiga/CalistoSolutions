using System.Collections.ObjectModel;
using CalistoStandards.Definitions.Interfaces.EdCore.Components;

namespace CalistoStandards.Definitions.Models.EdCore.Components;


public sealed class Node : Element<NodeSign>, INode
{
    public Node(NodeSign sign, IEnumerable<MemberSign> memberSigns) : base(sign, ClElementType.Node)
    {
        var auxMembers = new Collection<IMember>();

        foreach (var memberSign in memberSigns)
            auxMembers.Add(new Member(memberSign));

        Members = auxMembers;
    }

    public Node(NodeSign sign, IEnumerable<IMember> members) :
        base(sign, ClElementType.Node) => Members = members;

    public IEnumerable<IMember> Members { get; set; }
    public override string ToString() => $"Node: {Sign}";

    public void Dispose()
    {
        if (Members.NullOrEmpty()) return;
        
        foreach (var member in Members)
            member.Dispose();

        Members = Enumerable.Empty<IMember>();
        Members = null!;
    }

}