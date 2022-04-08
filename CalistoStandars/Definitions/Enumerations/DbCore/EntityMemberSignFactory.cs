namespace CalistoStandars.Definitions.Enumerations.DbCore;

[Obsolete("Review its usefulness")]

public static class EntityMemberSignFactory
{
    [Obsolete]
    public static EntityMemberSign[] GetCompleteNominal => new[]
    {
        EntityMemberSign.Legajo, EntityMemberSign.Documento,
        EntityMemberSign.Apellido, EntityMemberSign.Nombres,
        EntityMemberSign.Mail, EntityMemberSign.FecNac,
        EntityMemberSign.SexoId
    };


}
