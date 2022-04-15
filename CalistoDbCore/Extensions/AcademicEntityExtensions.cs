using CalistoStandards.Definitions.Models.DbCore.Users;

namespace CalistoDbCore.Extensions;

public static class AcademicEntityExtensions
{
    public static void AlterGroup(this UserGroup inGroup,             bool?        enabled = null, char? profile = null,
                                  bool?          isAdminGroup = null, EdGroupType? groupType = null)
    {
        if (enabled is { }) inGroup.Enabled = enabled;

        if (profile is { }) inGroup.Profile = profile;

        if (isAdminGroup is { }) inGroup.IsAdmingGroup = isAdminGroup;

        if (groupType is { }) inGroup.GroupType = groupType;
    }

    public static UserGroup GetAlterated(this UserGroup inGroup,             bool? enabled = null, char? profile = null,
                                         bool?          isAdminGroup = null, EdGroupType? groupType = null)
    {
        if (enabled is { }) inGroup.Enabled = enabled;

        if (profile is { }) inGroup.Profile = profile;

        if (isAdminGroup is { }) inGroup.IsAdmingGroup = isAdminGroup;

        if (groupType is { }) inGroup.GroupType = groupType;

        return inGroup;
    }
}