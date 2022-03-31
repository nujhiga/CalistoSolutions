namespace CalistoStandars.Definitions.Models;

public class AssignGroupRequest : RequestStructure 
{
    public AssignGroupRequest(bool massiveVersion, bool isModifyGroup = false) : 
        base(isModifyGroup ? MessageSign.modificar_usuario_grupo : massiveVersion 
                           ? MessageSign.asignar_usuarios_grupos : MessageSign.asignar_usuario_grupo)
    {
        BodySign bodySign = massiveVersion ? BodySign.asignar_usuarios_grupos : default;
        
        const MemberSign memberSign = MemberSign.id_usuario;
        const NodeSign nodeSign = NodeSign.usuario_grupo;
        
        IMember member = ComponentsFactory.CreateMember(memberSign);
        
        MemberSign[] nodeMemberSigns = ComponentsFactory.ConstantsSigns.GetUserGroupMember;
        
        INode node = ComponentsFactory.CreateNode(nodeSign, nodeMemberSigns);
        
        RequestBody = ComponentsFactory.CreateBody(bodySign, member, node);
    }
}