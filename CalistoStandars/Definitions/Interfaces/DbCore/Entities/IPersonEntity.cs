using CalistoStandars.Definitions.Enumerations.DbCore;
using CalistoStandars.Definitions.Models.DbCore.Attributes;
using CalistoStandars.Definitions.Models.DbCore.Entities.Constants;

namespace CalistoStandars.Definitions.Interfaces.DbCore.Entities;




public interface IPersonEntitys : IEntity
{
    [EntityAttr(EntityMemberSign.Legajo)]
    double Legajo { get; set; }

    [EntityAttr(EntityMemberSign.Apellido)]
    string? Apellido { get; set; }

    [EntityAttr(EntityMemberSign.Nombres)]
    string? Nombres { get; set; }

    [EntityAttr(EntityMemberSign.Documento)]
    double? Documento { get; set; }

    [EntityAttr(EntityMemberSign.FecNac)]
    DateTime? FecNac { get; set; }

    [EntityAttr(EntityMemberSign.Regular)]
    string? Regular { get; set; }

    [EntityAttr(EntityMemberSign.ReguAnt)]
    string? ReguAnt { get; set; }

    [EntityAttr(EntityMemberSign.Feclib)]
    DateTime? Feclib { get; set; }

    [EntityAttr(EntityMemberSign.CuotaIngreso)]
    string? CuotaIngreso { get; set; }

    [EntityAttr(EntityMemberSign.Curing)]
    string? Curing { get; set; }

    [EntityAttr(EntityMemberSign.Usucla)]
    string? Usucla { get; set; }

    [EntityAttr(EntityMemberSign.AnoIngreso)]
    string? AnoIngreso { get; set; }

    [EntityAttr(EntityMemberSign.Suspendido)]
    string? Suspendido { get; set; }

    [EntityAttr(EntityMemberSign.Suspfecha)]
    DateTime? Suspfecha { get; set; }

    [EntityAttr(EntityMemberSign.CarreraId)]
    int? CarreraId { get; set; }

    [EntityAttr(EntityMemberSign.Suspcuatri)]
    string? Suspcuatri { get; set; }

    [EntityAttr(EntityMemberSign.MotBaja)]
    string? MotBaja { get; set; }
}
