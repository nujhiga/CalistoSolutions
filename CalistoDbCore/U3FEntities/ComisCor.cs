namespace CalistoDbCore.U3FEntities
{
    public partial class ComisCor
    {
        public int     Id           { get; set; }
        public int?    Comision     { get; set; }
        public string? Cuatrimestre { get; set; }
        public int?    IdMateria    { get; set; }
        public int?    IdDocente    { get; set; }
        public int?    IdCargo      { get; set; }
        public string? Titular      { get; set; }
    }
}