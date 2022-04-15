using CalistoStandards.Definitions.Interfaces.EdCore.Components;
using CalistoStandards.Definitions.Structures.Cls;

namespace CalistoStandards.Definitions.Interfaces.EdCore.Messages;

public interface IMessage : IElement<MessageSign> //where T : Enum
{
    KeyReference? KeyID { get; set; }
    int MessageID { get; set; }
    bool IsInvalid { get; }
    string? StoredXml { get; set; }
    // BodyContentPattern Content { get; set; }
    ClResult ClResult { get; set; }
}
