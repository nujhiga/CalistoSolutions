using CalistoStandards.Definitions.Interfaces.EdCore.Components;
using CalistoStandards.Definitions.Models.EdCore.Components.Factories;

namespace CalistoStandards.Definitions.Models.EdCore.Messages.MessageStructures;
public sealed class CreateUsersRequest : RequestStructure
{
    public CreateUsersRequest(bool massiveVersion)
        : base(massiveVersion 
            ? MessageSign.registrar_usuarios 
            : MessageSign.registrar_usuario)
    {
        BodySign bodySign = massiveVersion ? BodySign.registro_usuario_grupo : default;

        (NodeSign node, MemberSign[] members) userNodeMembers = 
            ComponentsFactory.ConstantsSigns.GetUsersNode;

        INode userNode = ComponentsFactory.CreateNode
            (userNodeMembers.node, userNodeMembers.members);

        (NodeSign node, MemberSign[] members) userGroupNodeMembers = 
            ComponentsFactory.ConstantsSigns.GetUserGroupNode;

        INode userGroupNode = ComponentsFactory.CreateNode
            (userGroupNodeMembers.node, userGroupNodeMembers.members);

        RequestBody = ComponentsFactory.CreateBody(bodySign, userNode, userGroupNode);
    }
}