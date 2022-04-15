using CalistoStandards.Definitions.Interfaces.DbCore.Persons;

namespace CalistoStandards.Definitions.Interfaces.DbCore.Students;

[ElementAttr(ClElementType.Serializable)]
public interface IStudentBase : IPersonBase, IEquatable<IStudentBase>
{
    IList<ICareerInfo>? CareersInfo { get; set; }
    IList<ICommissionInfo>? CommissionsInfo { get; set; }

    public ICareerInfo GetCareerInfo(int? careerid);
    public IEnumerable<ICareerInfo> GetCareersInfo(params int?[] careerids);

    public ICommissionInfo GetCommissionInfo(int? commissionid);
    public IEnumerable<ICommissionInfo> GetCommissionsInfo(params int?[] commissionids);
}
