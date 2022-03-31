namespace CalistoDbCore.U3FEntities
{
    public partial class Convenio
    {
        public int Id { get; set; }
        public string Convenio1 { get; set; } = null!;
        public bool CurIng { get; set; }
        public bool RegExa { get; set; }
        public string? Observa { get; set; }
        public string? ConPag { get; set; }
        public string? Habicar { get; set; }
        public string? Habimat { get; set; }
        public string? Habiexa { get; set; }
        public string? Nombre { get; set; }
        public string? Derexa { get; set; }
        public string? Habipre { get; set; }
    }
}
