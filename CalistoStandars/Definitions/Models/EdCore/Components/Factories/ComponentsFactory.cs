using CalistoStandards.Definitions.Interfaces.EdCore.Components;

namespace CalistoStandards.Definitions.Models.EdCore.Components.Factories;


/// <summary>
///     Static Factory for all Interfaces / Instances Of EdMessages Elements, Components and Models.
/// </summary>
public static class ComponentsFactory
{
    public static IMember[] CreateMembers(MemberSign[] memberSigns)
    {
        int length = memberSigns.Length;
        IMember[] members = new IMember[length];

        for (int i = 0; i < length; i++)
            members[i] = CreateMember(memberSigns[i]);

        return members;
    }
    public static IMember CreateMember(MemberSign memberSign) => new Member(memberSign);

    public static INode CreateNode(NodeSign nodeSign, IEnumerable<MemberSign> memberSigns) => new Node(nodeSign, memberSigns);
    public static INode CreateNode(NodeSign nodeSign, IEnumerable<IMember> members) => new Node(nodeSign, members);

    public static IBody CreateBody(BodySign bodySign, IMember member, INode node) => new BodyMemberNode(bodySign, member, node);
    public static IBody CreateBody(BodySign bodySign, (IMember member, INode node) memberNode) => new BodyMemberNode(bodySign, memberNode);

    public static IBody CreateBody(BodySign bodySign, IEnumerable<INode> nodes) => new BodyNodesMembers(bodySign, nodes);
    public static IBody CreateBody(BodySign bodySign, params INode[] nodes) => new BodyNodesMembers(bodySign, nodes);

    public static IBody CreateBody(IEnumerable<INode> nodes) => new BodyNodesMembers(nodes);
    public static IBody CreateBody(params INode[] nodes) => new BodyNodesMembers(nodes);

    public static IBody CreateBody(BodySign bodySign, IEnumerable<IMember> members) => new BodyMembers(bodySign, members);
    public static IBody CreateBody(BodySign bodySign, params IMember[] members) => new BodyMembers(bodySign, members);

    public static IBody CreateBody(IEnumerable<IMember> members) => new BodyMembers(members);
    public static IBody CreateBody(params IMember[] members) => new BodyMembers(members);
    
    public static class ConstantsSigns
    {
        public static MemberSign[] GetUserGroupMember => new[] { MemberSign.administrador_grupo, MemberSign.estado, MemberSign.id_grupo, MemberSign.perfil };
        public static MemberSign[] GetModifyUserMember => new[] { MemberSign.id_usuario, MemberSign.nombre, MemberSign.apellido, MemberSign.clave, MemberSign.email, MemberSign.codigo_postal, MemberSign.dato_adicional_1, MemberSign.dato_adicional_2, MemberSign.dato_adicional_3, MemberSign.direccion, MemberSign.localidad, MemberSign.telefono };
        public static (NodeSign, MemberSign[]) GetUsersNode => (NodeSign.usuario, new[] { MemberSign.id_usuario, MemberSign.nombre, MemberSign.apellido, MemberSign.clave, MemberSign.email });
        public static (NodeSign, MemberSign[]) GetUserGroupNode => (NodeSign.usuario_grupo, GetUserGroupMember);
        public static (NodeSign, MemberSign[]) GetModifyUserNode => (NodeSign.usuario, GetModifyUserMember);
    }
}