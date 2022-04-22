using CalistoStandards.Definitions.Interfaces.EdCore.Components;
using CalistoStandards.Definitions.Models.EdCore.Components.Factories;

namespace CalistoStandards.Definitions.Models.EdCore.Messages.MessageStructures;
public sealed class ModifyUserRequest : RequestStructure
{
    public ModifyUserRequest() : base(MessageSign.modificar_usuario)
    {
        (NodeSign node, MemberSign[] members) modifyUserNodeMembers =
            ComponentsFactory.ConstantsSigns.GetModifyUserNode;

        INode node = ComponentsFactory.CreateNode(modifyUserNodeMembers.node, modifyUserNodeMembers.members);

        RequestBody = ComponentsFactory.CreateBody(node);
    }
}