using CalistoStandards.Definitions.Interfaces.DbCore.Entities;

namespace CalistoStandards.Definitions.Models;
public sealed class PersonEntity : NominalEntity, IPersonEntitys
{

    public string? Regular { get; set; }
    public string? ReguAnt { get; set; }
    public DateTime? Feclib { get; set; }
    public string? CuotaIngreso { get; set; }
    public string? Curing { get; set; }
    public string? Usucla { get; set; }
    public string? AnoIngreso { get; set; }
    public string? Suspendido { get; set; }
    public DateTime? Suspfecha { get; set; }
    public int? CarreraId { get; set; }
    public string? Suspcuatri { get; set; }
    public string? MotBaja { get; set; }

}
