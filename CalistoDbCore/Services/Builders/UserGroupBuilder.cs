using CalistoDbCore.Services.Factories;

using CalistoStandards.Definitions.Interfaces.DbCore.Persons;
using CalistoStandards.Definitions.Interfaces.DbCore.Users;
using CalistoStandards.Definitions.Models.DbCore.Users;

namespace CalistoDbCore.Services.Builders;
public abstract class UserGroupFullBuilder : AcademicEntityBuilder<IUserGroup, (short? groupid, char? profile, bool? isAdmin, bool? enabled), IPerson>
{
    protected UserGroupFullBuilder((short? groupid, char? profile, bool? isAdmin, bool? enabled) groupData) : base(groupData)
    {
    }
}

public abstract class UserGroupBuilder : AcademicEntityBuilder<IUserGroup, (short? groupid, bool? enabled), IPerson>
{
    protected UserGroupBuilder((short? groupid, bool? enabled) groupData) : base(groupData)
    {

    }
}

public sealed class StudentGroupBuilder : UserGroupBuilder
{
    public StudentGroupBuilder((short? groupid, bool? enabled) groupData) : base(groupData)
    {
    }

    public override IEnumerable<IUserGroup> Build(in IEnumerable<IPerson> source)
    {
        UserGroup ugroup = AcademicEntityFactory.
            GetStudentGroup(CommonValue.groupid, CommonValue.enabled);

        return from person in source 
            where person?.PersonID is not null select ugroup;
    }
    
}
