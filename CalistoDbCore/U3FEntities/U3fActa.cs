namespace CalistoDbCore.U3FEntities
{
    public partial class U3fActa
    {
        public string? Actanro { get; set; }
        public int? Materia { get; set; }
        public DateTime? Fecha { get; set; }
        public int? Turno { get; set; }
        public int? Docente { get; set; }
        public string? Reglib { get; set; }
        public int? Libro { get; set; }
        public int? Folio { get; set; }
        public int? Tipolibro { get; set; }
        public int? KIns { get; set; }
        public string Esta { get; set; } = null!;
        public int Id { get; set; }
        public string? Cerrada { get; set; }
        public string? Observa { get; set; }
        public int? Semide { get; set; }
        public int? Sede { get; set; }
        public string? Aula { get; set; }
        public string? Campus { get; set; }
    }
}
