namespace CalistoDbCore.U3FEntities
{
    public partial class WebCubo01
    {
        public double Legajo { get; set; }
        public string? Nombre { get; set; }
        public double? Documento { get; set; }
        public string? Provincia { get; set; }
        public string? Sexo { get; set; }
        public string? Carrera { get; set; }
        public string? Orientacion { get; set; }
        public string Convenio { get; set; } = null!;
        public string? AñoIngreso { get; set; }
        public DateTime? FechaInscripto { get; set; }
        public string? CuatrimestreIngeso { get; set; }
        public string CursoIngreso { get; set; } = null!;
        public string? Extranjero { get; set; }
        public string? Residente { get; set; }
        public string? Intercambio { get; set; }
        public string? Sede { get; set; }
        public string? MedioDePago { get; set; }
        public string? TipoTarjeta { get; set; }
        public string? Recibido { get; set; }
        public string? PlanEstudio { get; set; }
        public string Suspendido { get; set; } = null!;
        public DateTime? FechaSuspendido { get; set; }
        public string? CuatriSuspendido { get; set; }
        public string? PagóMatricula { get; set; }
        public string? PresentóDocumentación { get; set; }
        public string? TitSecundario { get; set; }
        public DateTime? FechaTitSec { get; set; }
        public int? PresentóTitSec { get; set; }
        public double? PromedioSec { get; set; }
        public string? EgresóSec { get; set; }
        public string? TitTerciario { get; set; }
        public string? TitUniversitario { get; set; }
        public DateTime? FechaTitUniv { get; set; }
        public int? PresentóTitUniv { get; set; }
        public string? EgresóUniv { get; set; }
        public string? Libreta { get; set; }
        public DateTime? FecLibreta { get; set; }
        public DateTime? FechaNac { get; set; }
        public string? Nacionalidad { get; set; }
        public string? Direccion { get; set; }
        public string? CodPostal { get; set; }
        public string? Localidad { get; set; }
        public string? Partido { get; set; }
        public string? Telefono { get; set; }
        public string? Mail { get; set; }
        public string? Pais { get; set; }
        public string? LugMundo { get; set; }
        public string? Estado { get; set; }
        public string? EstadoAmpliado { get; set; }
        public int Contar { get; set; }
        public int? XIdMedioPago { get; set; }
        public int? XIdCarrera { get; set; }
        public int? XIdPlan { get; set; }
        public int? XIdConv { get; set; }
        public int? XIdPais { get; set; }
        public int? XIdLocalidad { get; set; }
    }
}
