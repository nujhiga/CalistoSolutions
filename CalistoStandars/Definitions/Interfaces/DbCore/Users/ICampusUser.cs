namespace CalistoStandards.Definitions.Interfaces.DbCore.Users;

public interface ICampusUser
{
    object? PersonID { get; }

    
    [MemberAttr(MemberSign.id_usuario, isNullable: false)]
    object? UserID { get; set; }
    
    
    [MemberAttr(MemberSign.clave, isNullable: false)]
    string? Password { get; set; }

    
    [NodeAttr(NodeSign.usuario_grupo)]
    IEnumerable<IUserGroup> GroupsInfo { get; set; }

    
    [MemberAttr(MemberSign.administrador_usuario, defaultValue: 0)]
    bool? IsWebmasterAdmin { get; set; }
}
