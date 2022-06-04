using CalistoStandards.Definitions.Interfaces.DbCore.Entities;
// ReSharper disable ClassNeverInstantiated.Global

namespace CalistoStandards.Definitions.Models;
public class NominalEntity : INominalEntity
{
    public object EntityID => Legajo;
    public double Legajo { get; set; }
    public string? Apellido { get; set; }
    public string? Nombres { get; set; }
    public double? Documento { get; set; }
    public DateTime? FecNac { get; set; }
    public string? Mail { get; set; }
    public int? SexoId { get; set; }
}
