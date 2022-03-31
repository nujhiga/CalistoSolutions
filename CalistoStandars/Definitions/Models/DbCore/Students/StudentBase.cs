using CalistoStandars.Definitions.Interfaces.DbCore.Users;
using CalistoStandars.Definitions.Models.DbCore.Persons;

namespace CalistoStandars.Definitions.Models.DbCore.Students;
public abstract class StudentBase : PersonBase, IStudentBase
{
    public bool SingleCareer => CareersInfo?.Count == 1;
    public ICareerInfo? Career => SingleCareer ? CareersInfo?[0] : null;
    
    public IList<ICareerInfo>? CareersInfo { get; set; }
    public IList<ICommissionInfo>? CommissionsInfo { get; set; }
    
    protected StudentBase(object? personID) : base(personID)
    {
    }
    protected StudentBase(object? personID, PersonEntity? personEntity) : base(personID, personEntity)
    {
        
    }
    protected StudentBase(object? personID, PersonEntity? personEntity, ICampusUser? campusUser) : base(personID, personEntity, campusUser)
    {
    }
    
    public ICareerInfo GetCareerInfo(int? careerid)
    {
        if (careerid is null) return Career!;

        ICareerInfo careerinfo = null!;

        if (CareersInfo is {Count: > 0})
            careerinfo = CareersInfo.FirstOrDefault(c => c.CareerID == careerid)!;

        return careerinfo;
    }
    public IEnumerable<ICareerInfo> GetCareersInfo(params int?[] careerids)
    {
        if (CareersInfo is not { Count: > 0 }) yield break;

        foreach (int? careerid in careerids)
            yield return GetCareerInfo(careerid);
    }

    public ICommissionInfo GetCommissionInfo(int? commissionid)
    {
        ICommissionInfo commissioninfo = null!;

        if (CommissionsInfo is { Count: > 0 })
            commissioninfo = CommissionsInfo.FirstOrDefault(c => c.CommissionID == commissionid)!;

        return commissioninfo;
    }
    public IEnumerable<ICommissionInfo> GetCommissionsInfo(params int?[] commissionids)
    {
        if (CommissionsInfo is not { Count: > 0 }) yield break;

        foreach (int? commissionid in commissionids)
            yield return GetCommissionInfo(commissionid);
    }

    public bool Equals(IStudentBase? other)
    {
        throw new NotImplementedException();
    }
}
