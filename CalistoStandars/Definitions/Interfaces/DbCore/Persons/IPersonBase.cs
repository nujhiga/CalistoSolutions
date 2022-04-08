using CalistoStandars.Definitions.Interfaces.DbCore.Users;

namespace CalistoStandars.Definitions.Interfaces.DbCore.Persons;


[ElementAttr(ElementType.Serializable)]
public interface IPersonBase : IEquatable<IPersonBase>, IComparable<IPersonBase>, IReferenceable
{
    object? PersonID { get; }
    PersonEntitySign? PersonEntity { get; set; }

    [ElementAttr(ElementType.Serializable)]
    ICampusUser? CampusUser { get; set; }
}
