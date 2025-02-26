﻿using CalistoStandards.Definitions.Interfaces.EdCore.Components;
using CalistoStandards.Definitions.Models.EdCore.Components.Factories;

namespace CalistoStandards.Definitions.Models.EdCore.Messages.MessageStructures;
public class AuthUserRequest : RequestStructure
{
    public AuthUserRequest(bool usingTrust) :
        base(usingTrust ? MessageSign.autenticar_usuario_confiable
                        : MessageSign.autenticar_usuario)
    {
        var memberSigns = usingTrust
            ? new[] { MemberSign.id_usuario, MemberSign.clave, MemberSign.id_grupo }
            : new[] { MemberSign.id_usuario, MemberSign.clave };

        IMember[] members = ComponentsFactory.CreateMembers(memberSigns);

        RequestBody = ComponentsFactory.CreateBody(members);
    }
}