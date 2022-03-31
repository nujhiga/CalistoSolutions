namespace CalistoDbCore.U3FEntities
{
    public partial class UtfAluxRen
    {
        public int? Legajo { get; set; }
        public string? Apellido { get; set; }
        public string? Nombres { get; set; }
        public double? Documento { get; set; }
        public double? Aprobadas { get; set; }
        public double? Sumanota { get; set; }
        public double? Rendidas { get; set; }
        public int? CarreraId { get; set; }
        public string? Plaest { get; set; }
        public int? Ciclo1 { get; set; }
        public int? Ciclo2 { get; set; }
        public string? Regular { get; set; }
        public string? AnoIngreso { get; set; }
        public string Sexo { get; set; } = null!;
        public string? Estdes { get; set; }
        public string? Convenio { get; set; }
        public int? Nota { get; set; }
        public int? ConvCod { get; set; }
    }
}
