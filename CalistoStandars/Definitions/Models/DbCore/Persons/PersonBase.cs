using CalistoStandards.Definitions.Interfaces.DbCore.Persons;

using CalistoStandards.Definitions.Interfaces.DbCore.Users;
using CalistoStandards.Definitions.Structures.Cls;

namespace CalistoStandards.Definitions.Models.DbCore.Persons;
public abstract class PersonBase : IPersonBase
{
    public KeyReference? Reference { get; set; }
    public object? PersonID { get; }
   // public PersonEntitySign? PersonEntity { get; set; }
    public ICampusUser? CampusUser { get; set; }

    protected PersonBase(object? personID) => PersonID = personID;
    //protected PersonBase(object? personID, PersonEntitySign? personEntity) : this(personID) => PersonEntity = personEntity;
    //protected PersonBase(object? personID, PersonEntitySign? personEntity, ICampusUser? campusUser) : this(personID, personEntity) => CampusUser = campusUser;
    
    public bool Equals(IPersonBase? other)
    {
        if (other?.PersonID is null || PersonID is null) return false;

        if (other.PersonID.GetType() != PersonID.GetType()) return false;

        return other.PersonID == PersonID;
    }
    public bool Equals(KeyReference? other)
    {
        if (other is null || Reference is null) return false;

        if (other is {} oref && Reference is {} rref )
            return oref.Equals(rref);

        return false;
    }
    
    public int CompareTo(IPersonBase? other)
    {
        if (other is not {} opers || opers.PersonID is null) return -1;

        return other.PersonID switch
        {
            string stroid when PersonID is string strid 
                => string.Compare(stroid, strid, StringComparison.Ordinal),

            int ioid when PersonID is int iid 
                => ioid.CompareTo(iid),

            _ => 0
        };
    }
}
