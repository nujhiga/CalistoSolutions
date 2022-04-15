namespace CalistoDbCore.U3FEntities
{
    public partial class Convcar
    {
        public int      Id           { get; set; }
        public int?     IdCar        { get; set; }
        public int?     IdConv       { get; set; }
        public string?  Cuatrimestre { get; set; }
        public string?  CurIng       { get; set; }
        public string?  IngCuotas    { get; set; }
        public decimal? IngMonto     { get; set; }
        public string?  Activa       { get; set; }
    }
}