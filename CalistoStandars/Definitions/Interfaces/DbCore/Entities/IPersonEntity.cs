namespace CalistoStandards.Definitions.Interfaces.DbCore.Entities;




public interface IPersonEntitys : INominalEntity
{
    

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
