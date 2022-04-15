namespace CalistoDbCore.U3FEntities
{
    public partial class Docente
    {
        public int     Id         { get; set; }
        public string? Docente1   { get; set; }
        public string? DocApe     { get; set; }
        public string? DocNom     { get; set; }
        public string? DocTit     { get; set; }
        public string? DocCar     { get; set; }
        public string? DocDom     { get; set; }
        public int?    DocLoc     { get; set; }
        public string? DocPos     { get; set; }
        public string? DocPar     { get; set; }
        public int?    DocPro     { get; set; }
        public int?    DocDni     { get; set; }
        public string? DocTel     { get; set; }
        public string? DocMai     { get; set; }
        public string? DocObs     { get; set; }
        public int?    Doccarrera { get; set; }
        public int?    Docdepto   { get; set; }
        public string? Docsitu    { get; set; }
        public string? Precv      { get; set; }
        public string? Predni     { get; set; }
        public string? Pretit     { get; set; }
        public int?    Reemplazo  { get; set; }
        public string? Docusuario { get; set; }
        public int?    Segusu     { get; set; }
    }
}