
using CalistoStandars.Definitions.Interfaces.DbCore.Entities;

namespace CalistoStandars.Definitions.Models.DbCore.Entities;
public class NominalEntity : INominalEntity
{
    public object EntityID => Legajo;
    public double Legajo { get; set; }
    public string? Apellido { get; set; }
    public string? Nombres { get; set; }
    public double? Documento { get; set; }
    public DateTime? FecNac { get; set; }
    public string? Mail { get; set; }
    public char? SexoId { get; set; }
}
