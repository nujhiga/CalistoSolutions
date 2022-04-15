namespace CalistoStandards.Definitions.Interfaces.EdCore.Components;

public interface IBodyNodesMembers : IBody
{
IEnumerable<INode> Nodes { get; }
public bool IsInvalid => Nodes.Any(m => m.Members.Any(m => m.InvalidValue));

}