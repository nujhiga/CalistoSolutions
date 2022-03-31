namespace CalistoDbCore.U3FEntities
{
    public partial class UvVisapag
    {
        public int Id { get; set; }
        public double? Legajo { get; set; }
        public double? Carrera { get; set; }
        public DateTime? Fechaproc { get; set; }
        public DateTime? Fechapago { get; set; }
        public decimal? Importe { get; set; }
        public int? Pagopor { get; set; }
        public string? Pagcta { get; set; }
        public int? Pagdeb { get; set; }
        public string? Tarjeta { get; set; }
        public string? Tartipo { get; set; }
        public DateTime? Fechaori { get; set; }
        public string? Estado { get; set; }
        public string? Rechazo { get; set; }
        public string? Cuenta { get; set; }
    }
}
