namespace CalistoDbCore.U3FEntities
{
    public partial class ComisCar
    {
        public int     Id           { get; set; }
        public int?    Comision     { get; set; }
        public int?    Carrera      { get; set; }
        public string? AnoIng       { get; set; }
        public string? Cuatrimestre { get; set; }
        public string? Vale         { get; set; }
    }
}