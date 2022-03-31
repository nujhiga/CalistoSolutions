namespace CalistoStandars.Definitions.Interfaces;

public sealed class CareerInfo : ICareerInfo
{
    public int? CareerID { get; set; }
    public int? ConvID { get; set; }
    public int? IngressYear { get; set; }
    public char? Curing { get; set; }
    public char? Regularity { get; set; }
    public int? Period { get; set; }
    public char? DownID { get; set; }
    public bool? Disabled { get; }
    public IPlanInfo? PlanInfo { get; set; }
    public DateTime? DownDate { get; set; }
    public DateTime? InscriptionDate { get; set; }
}