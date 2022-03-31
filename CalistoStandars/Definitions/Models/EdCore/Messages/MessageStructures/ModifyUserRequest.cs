namespace CalistoStandars.Definitions.Models;
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