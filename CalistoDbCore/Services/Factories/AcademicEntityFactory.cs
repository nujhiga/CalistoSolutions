using CalistoStandars.Definitions.Interfaces;

namespace CalistoDbCore.Services.Factories;
public static class AcademicEntityFactory
{


    public static UserGroup GetStudentGroup(short? groupid)
    {
        UserGroup group = UserGroup.Student;
        group.GroupID = groupid;

        return group;
    }
    public static UserGroup GetStudentGroup(short? groupid, bool? enabled)
    {
        UserGroup group = UserGroup.Student;

        group.GroupID = groupid;
        group.Enabled = enabled;

        return group;
    }



}
