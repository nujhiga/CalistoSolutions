namespace CalistoStandars.Definitions.Interfaces;

public interface IPlanInfo
{
    int? PlanID { get; set; }
    int? PlanYear { get; set; }
    int? PlanAct { get; set; }
    int? PlanPeriod { get; set; }
}