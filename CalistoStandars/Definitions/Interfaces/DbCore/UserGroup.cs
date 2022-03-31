namespace CalistoStandars.Definitions.Interfaces;

public class UserGroup : Serializable, IUserGroup
{
    public bool? Enabled { get; set; }
    public char? Profile { get; set; }
    public short? GroupID { get; set; }
    public bool? IsAdmingGroup { get; set; }
    public EdGroupType? GroupType { get; set; }

    public bool Equals(IUserGroup? other)
    {
        if (other is not { } oGrp) return false;

        if (oGrp.GroupID is not { } oGrpID ||
            GroupID is not { } grpID) return false;

        return oGrpID == grpID;
    }
}