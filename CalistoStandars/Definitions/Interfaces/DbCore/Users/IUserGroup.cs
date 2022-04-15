namespace CalistoStandards.Definitions.Interfaces.DbCore.Users;

public interface IUserGroup : IEquatable<IUserGroup>
{

    [MemberAttr(MemberSign.estado, isNullable: false)] 
    bool? Enabled { get; set; }


    [MemberAttr(MemberSign.perfil, isNullable: false)] 
    char? Profile { get; set; }


    [MemberAttr(MemberSign.id_grupo, isNullable: false)] 
    short? GroupID { get; set; }


    [MemberAttr(MemberSign.administrador_grupo, defaultValue: 0)]
    bool? IsAdmingGroup { get; set; }

    EdGroupType? GroupType { get; set; }
}
