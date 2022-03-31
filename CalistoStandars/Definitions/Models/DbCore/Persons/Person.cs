using CalistoStandars.Definitions.Interfaces.DbCore.Users;
using CalistoStandars.Definitions.Models.DbCore.Persons;

namespace CalistoStandars.Definitions.Models;

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

    public Person(object? personID, PersonEntity? personEntity) : base(personID, personEntity)
    {
    }

    public Person(object? personID, PersonEntity? personEntity, ICampusUser? campusUser) : base(personID, personEntity, campusUser)
    {
    }
}