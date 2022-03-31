namespace CalistoStandars.Definitions.Models;

public class Person : Serializable, IPerson
{
    public double? Document { get; set; }
    public char? Gender { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PostalCode { get; set; }
    public string? Location { get; set; }
    public object? UserID { get; set; }
    public string? Password { get; set; }
    public bool? IsWebmasterAdmin { get; set; }
    public IEnumerable<IUserGroup> UserGroups { get; set; }

    public KeyReference? Reference { get; set; }

    public bool Equals(IPerson? other)
    {
        if (other?.Reference is null && Reference is null)
            return Document == other?.Document;

        if (other?.Reference is not null && Reference is not null)
            return other is not null && other.Reference.Equals(Reference);

        return false;
    }

    public override int GetHashCode() => Reference is { } ? Reference.GetHashCode() : Document.GetHashCode();
}