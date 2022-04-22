using CalistoStandards.Definitions.Interfaces.DbCore.Users;

namespace CalistoStandards.Definitions.Models.DbCore.Users;
public sealed class CampusUser : ICampusUser
{
    public object? PersonID { get; }
    public object? UserID { get; set; }
    public string? Password { get; set; }
    public IEnumerable<IUserGroup> GroupsInfo { get; set; }
    public bool? IsWebmasterAdmin { get; set; }
}
