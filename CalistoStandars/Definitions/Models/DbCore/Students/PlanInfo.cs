using CalistoStandards.Definitions.Interfaces.DbCore.Students;

namespace CalistoStandards.Definitions.Models.DbCore.Students;

public sealed class PlanInfo : IPlanInfo
{
    public int? PlanID { get; set; }
    public int? PlanYear { get; set; }
    public int? PlanAct { get; set; }
    public int? PlanPeriod { get; set; }
}