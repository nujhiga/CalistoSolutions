using CalistoStandards.Definitions.Interfaces.DbCore.Users;

namespace CalistoStandards.Definitions.Models.DbCore.Users;

public sealed class UserGroup : IUserGroup
{
    public bool? Enabled { get; set; }
    public char? Profile { get; set; }
    public short? GroupID { get; set; }
    public bool? IsAdmingGroup { get; set; }

    public EdGroupType? GroupType { get; set; }

    public static UserGroup Student => new UserGroup(null, 'A', false);
    public static UserGroup Teacher => new UserGroup(null, 'P', true);
    public static UserGroup Tutor => new UserGroup(null, 'M', true);
    public static UserGroup Guest => new UserGroup(null, 'I', false);
    public static UserGroup Coordinator => new UserGroup(null, 'X', false);


    public UserGroup(short? groupid, char? profile, bool? isAdminGroup, bool? enabled = true)
    {
        GroupID = groupid;
        Profile = profile;
        Enabled = enabled;
        IsAdmingGroup = isAdminGroup;
    }
    
    public bool Equals(IUserGroup? other)
    {
        if (other is not { } oGrp) return false;

        if (oGrp.GroupID is not { } oGrpID ||
            GroupID is not { } grpID) return false;

        return oGrpID == grpID;
    }
}