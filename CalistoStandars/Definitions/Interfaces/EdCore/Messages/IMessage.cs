namespace CalistoStandars.Definitions.Interfaces;

public interface IMessage : IElement<MessageSign> //where T : Enum
{
    KeyReference? KeyID { get; set; }
    int MessageID { get; set; }
    bool IsInvalid { get; }
    string? StoredXml { get; set; }
   // BodyContentPattern Content { get; set; }
    ClResult ClResult { get; set; }
}
