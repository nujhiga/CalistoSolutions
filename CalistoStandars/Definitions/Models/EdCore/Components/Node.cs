using System.Collections.ObjectModel;

namespace CalistoStandars.Definitions.Models;


public sealed class Node : Element<NodeSign>, INode
{
    public Node(NodeSign sign, IEnumerable<MemberSign> memberSigns) : base(sign,  Enumerations.ElementType.Node)
    {
        var auxMembers = new Collection<IMember>();

        foreach (var memberSign in memberSigns)
            auxMembers.Add(new Member(memberSign));

        Members = auxMembers;
    }

    public Node(NodeSign sign, IEnumerable<IMember> members) :
        base(sign, Enumerations.ElementType.Node) => Members = members;

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