namespace CalistoDbCore.U3FEntities;


public sealed class PersonaBase
{
    public double Legajo { get; set; }
    public string? Apellido { get; set; }
    public string? Nombres { get; set; }
    public double? Documento { get; set; }
    public string? Mail { get; set; }
    public string? Regular { get; set; }
    public string? Curing { get; set; }
    public string? AnoIngreso { get; set; }
    public int? CarreraId { get; set; }
    public int? ConvCod { get; set; }
    public string? CuatrIngreso { get; set; }
    public string? Usucla { get; set; }
}


public partial class VisAlu
{
    public double Legajo { get; set; }
    public string? Apellido { get; set; }
    public string? Nombres { get; set; }
    public double? Documento { get; set; }
    public int? TipoDoc { get; set; }
    public string? Nacio { get; set; }
    public DateTime? FecNac { get; set; }
    public string? Direccion { get; set; }
    public string? Cp { get; set; }
    public string? Telefono { get; set; }
    public string? AnoIngreso { get; set; }
    public DateTime? FecIns { get; set; }
    public int? SexoId { get; set; }
    public int? LocalidadId { get; set; }
    public string? Mail { get; set; }
    public int? CarreraId { get; set; }
    public int? Presento { get; set; }
    public DateTime? FinDes { get; set; }
    public DateTime? FinHas { get; set; }
    public string? Regular { get; set; }
    public string? ReguAnt { get; set; }
    public string? Convenio { get; set; }
    public int? ConvCod { get; set; }
    public int? CuoIns { get; set; }
    public string? Orienta { get; set; }
    public int? PlanId { get; set; }
    public string? MotBaja { get; set; }
    public double? ResNro { get; set; }
    public string? ResAno { get; set; }
    public DateTime? ResFec { get; set; }
    public string? Tipo { get; set; }
    public DateTime? Feclib { get; set; }
    public string? CuatrIngreso { get; set; }
    public int? IdSede { get; set; }
    public int? IdTarifa { get; set; }
    public int? IdMedioPago { get; set; }
    public string? Curing { get; set; }
    public string? Documenta { get; set; }
    public string? CuotaIngreso { get; set; }
    public string? Usucla { get; set; }
    public string? Suspendido { get; set; }
    public DateTime? Suspfecha { get; set; }
    public string? Suspcuatri { get; set; }
    public bool? Suspproce { get; set; }
    public string? Guacuit { get; set; }
    public int? Guapnac { get; set; }
    public int? Gualoca { get; set; }
    public int? Guatrab { get; set; }
    public int? Guainpa { get; set; }
    public int? Guainma { get; set; }
    public int? Guabeca { get; set; }
    public string? Guadate { get; set; }
    public int? Guapres { get; set; }
    public DateTime? Recifecha { get; set; }
    public string? Debedni { get; set; }
    public string? Debetit { get; set; }
}

