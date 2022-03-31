using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Xml;

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
