using CalistoStandards.Definitions.Interfaces.DbCore.Students;

namespace CalistoStandards.Definitions.Models.DbCore.Students;

public sealed class CommissionInfo : ICommissionInfo
{
    public int? CommissionID { get; set; }
    public int? CareerRef { get; set; }
    public int? AssignatureID { get; set; }
    public int? Period { get; set; }
    public bool? Disabled { get; set; }
    public DateTime? InscriptionDate { get; set; }
}