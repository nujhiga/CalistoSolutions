namespace CalistoStandards.Definitions.Interfaces.DbCore.Persons;

[ElementAttr(ClElementType.Serializable)]
public interface IPerson : IPersonBase
{
    [MemberAttr(MemberSign.dato_adicional_1)]
    int? Document { get; set; }


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
}