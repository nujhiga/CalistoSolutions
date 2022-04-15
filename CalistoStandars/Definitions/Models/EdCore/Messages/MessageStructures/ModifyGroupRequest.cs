namespace CalistoStandards.Definitions.Models.EdCore.Messages.MessageStructures;

public sealed class ModifyGroupRequest : AssignGroupRequest
{
    public ModifyGroupRequest() : base(false, true)
    {
    }
}