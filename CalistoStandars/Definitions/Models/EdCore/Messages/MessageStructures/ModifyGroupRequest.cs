namespace CalistoStandars.Definitions.Models;

public sealed class ModifyGroupRequest : AssignGroupRequest
{
    public ModifyGroupRequest() : base(false, true)
    {
    }
}