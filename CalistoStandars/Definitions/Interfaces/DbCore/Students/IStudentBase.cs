using CalistoStandars.Definitions.Interfaces.DbCore.Persons;

namespace CalistoStandars.Definitions.Interfaces;

[ElementAttr(ElementType.Serializable)]
public interface IStudentBase : IPersonBase, IEquatable<IStudentBase>
{
    IList<ICareerInfo>? CareersInfo { get; set; }
    IList<ICommissionInfo>? CommissionsInfo { get; set; }

    public ICareerInfo GetCareerInfo(int? careerid);
    public IEnumerable<ICareerInfo> GetCareersInfo(params int?[] careerids);
    public ICommissionInfo GetCommissionInfo(int? commissionid);
    public IEnumerable<ICommissionInfo> GetCommissionsInfo(params int?[] commissionids);
}
