using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalistoStandars.Definitions.Enumerations.DbCore;
public static class EntityMemberSignFactory
{

    public static EntityMemberSign[] GetCompleteNominal => new[]
    {
        EntityMemberSign.Legajo, EntityMemberSign.Documento,
        EntityMemberSign.Apellido, EntityMemberSign.Nombres,
        EntityMemberSign.Mail, EntityMemberSign.FecNac,
        EntityMemberSign.SexoId
    };


}
