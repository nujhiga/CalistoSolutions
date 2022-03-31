namespace CalistoStandars.Definitions.Interfaces;

public interface IBodyMembers : IBody
{
    IEnumerable<IMember> Members { get; }
    public bool IsInvalid => Members.Any(m => m.InvalidValue);
}