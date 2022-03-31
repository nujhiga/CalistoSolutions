namespace CalistoStandars.Definitions.Models;

public class BodyMembers : Body, IBodyMembers
{
    public BodyMembers(BodySign sign, IEnumerable<IMember> members) : base(sign, BodyContentPattern.Members) => Members = members;

    public BodyMembers(BodySign sign, params IMember[] members) : base(sign, BodyContentPattern.Members) => Members = members;


    public BodyMembers(IEnumerable<IMember> members) : base(BodyContentPattern.Members) => Members = members;

    public BodyMembers(params IMember[] members) : base(BodyContentPattern.Members) => Members = members;

    public IEnumerable<IMember> Members { get; private set; }

    public override void Dispose()
    {
        if (Members.NullOrEmpty()) return;
        
        foreach (var member in Members)
            member.Dispose();

        Members = Enumerable.Empty<IMember>();
        Members = null!;
    }
}