namespace CalistoDbCore.U3FEntities
{
    public partial class WebAprobaronCiclo
    {
        public double Legajo { get; set; }
        public string? Apellido { get; set; }
        public string? Nombres { get; set; }
        public string? Carrera { get; set; }
        public string? Tipo { get; set; }
        public string? Plaest { get; set; }
        public string? Regular { get; set; }
        public int? SexoId { get; set; }
        public string Recibido { get; set; } = null!;
        public int? Placi1 { get; set; }
        public int? Placi1idio { get; set; }
        public int? Placi1semi { get; set; }
        public int? Placi1opta { get; set; }
        public int? Placi2 { get; set; }
        public int? Placi2idio { get; set; }
        public int? Placi2semi { get; set; }
        public int? Placi2opta { get; set; }
        public int? Expr1 { get; set; }
        public int? CarreraId { get; set; }
        public int? PlanId { get; set; }
        public int C1C { get; set; }
        public int C1I { get; set; }
        public int C1S { get; set; }
        public int C1O { get; set; }
        public int C2C { get; set; }
        public int C2I { get; set; }
        public int C2S { get; set; }
        public int C2O { get; set; }
        public string? Sexo { get; set; }
        public string? Estdes { get; set; }
    }
}
