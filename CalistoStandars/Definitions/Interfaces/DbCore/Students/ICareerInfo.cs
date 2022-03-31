namespace CalistoStandars.Definitions.Interfaces;

public interface ICareerInfo : IGenericAcademicInfo
{
    public int? CareerID { get; set; }
    int? ConvID { get; set; }
    int? IngressYear { get; set; }
    char? Curing { get; set; }
    char? Regularity { get; set; }
    char? DownID { get; set; }
    DateTime? DownDate { get; set; }
    IPlanInfo? PlanInfo { get; set; }
}