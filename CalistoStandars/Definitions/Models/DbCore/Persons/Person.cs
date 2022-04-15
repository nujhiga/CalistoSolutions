using CalistoStandards.Definitions.Interfaces.DbCore.Persons;

namespace CalistoStandards.Definitions.Models.DbCore.Persons;

public class Person : PersonBase, IPerson
{
    public int? Document { get; set; }
    public char? Gender { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PostalCode { get; set; }
    public string? Location { get; set; }
    
    public Person(object? personID) : base(personID)
    {
    }

    //public Person(object? personID, PersonEntitySign? personEntity) : base(personID, personEntity)
    //{
    //}

    //public Person(object? personID, PersonEntitySign? personEntity, ICampusUser? campusUser) : base(personID, personEntity, campusUser)
    //{
    //}
}