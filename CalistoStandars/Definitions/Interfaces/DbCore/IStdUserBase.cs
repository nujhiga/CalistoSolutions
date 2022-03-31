namespace CalistoStandars.Definitions.Interfaces;

public interface IStdUserBase : IPerson, IEquatable<IStdUserBase>
{
    IList<ICareerInfo> CarsInfo { get; set; }
    IList<ICommissionInfo> CommsInfo { get; set; }
}