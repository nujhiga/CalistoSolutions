namespace CalistoStandars.Definitions.Interfaces;

public interface IPerson : IEquatable<IPerson>, IReferenceable, ISerializable
{
    [MemberAttr(MemberSign.dato_adicional_1)]
    double? Document { get; set; }


    [MemberAttr(MemberSign.dato_adicional_2)]
    char? Gender { get; set; }


    [MemberAttr(MemberSign.telefono)] 
    string? PhoneNumber { get; set; }


    [MemberAttr(MemberSign.direccion)] 
    string? Address { get; set; }


    [MemberAttr(MemberSign.nombre, isNullable: false)] 
    string? Name { get; set; }


    [MemberAttr(MemberSign.apellido, isNullable: false)] 
    string? LastName { get; set; }


    [MemberAttr(MemberSign.email, isNullable: false)] 
    string? Email { get; set; }


    [MemberAttr(MemberSign.codigo_postal)] 
    string? PostalCode { get; set; }


    [MemberAttr(MemberSign.localidad)] 
    string? Location { get; set; }


    [MemberAttr(MemberSign.id_usuario, isNullable: false)] 
    object? UserID { get; set; }


    [MemberAttr(MemberSign.clave, isNullable: false)] 
    string? Password { get; set; }


    [MemberAttr(MemberSign.administrador_usuario, defaultValue: 0)]
    bool? IsWebmasterAdmin { get; set; }

   
    [NodeAttr(NodeSign.usuario_grupo)] 
    IEnumerable<IUserGroup> UserGroups { get; set; }

    //IUserGroup[]? UserGroups { get; set; }
}