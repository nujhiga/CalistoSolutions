using System.Reflection;
using CalistoStandards.Definitions.Interfaces.Cls;
using CalistoStandards.Definitions.Interfaces.DbCore.Users;

namespace CalistoStandards.Definitions.Interfaces.DbCore.Persons;


[ElementAttr(ClElementType.Serializable)]
public interface IPersonBase : IEquatable<IPersonBase>, IComparable<IPersonBase>, IReferenceable
{
    object? PersonID { get; }
    // PersonEntitySign? PersonEntity { get; set; }

    [ElementAttr(ClElementType.Serializable)]
    ICampusUser? CampusUser { get; set; }

}
