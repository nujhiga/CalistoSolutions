﻿using CalistoStandards.Definitions.Interfaces.EdCore.Messages;
using CalistoStandards.Definitions.Models.EdCore.Messages.MessageStructures;

namespace CalistoEdCore.Services.Providers;

public static class MessageStructProvider
{
    public static IRequestStructure GetRequestStruct<TRequest>(TRequest requestSign)
    {
        IRequestStructure rqtStruct = requestSign switch
        {
            MessageSign.autenticar_usuario => new AuthUserRequest(false),

            MessageSign.autenticar_usuario_confiable => new AuthUserRequest(true),

            MessageSign.registrar_usuario => new CreateUsersRequest(false),

            MessageSign.registrar_usuarios => new CreateUsersRequest(true),

            MessageSign.modificar_usuario => new ModifyUserRequest(),

            MessageSign.asignar_usuario_grupo => new AssignGroupRequest(false),

            MessageSign.asignar_usuarios_grupos => new AssignGroupRequest(true),

            MessageSign.modificar_usuario_grupo => new ModifyGroupRequest(),

            _ => null!
        };

        return rqtStruct;
    }
}
