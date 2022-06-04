using CalistoStandards.Definitions.Interfaces.Cls;
using CalistoStandards.Definitions.Interfaces.EdCore.Messages;
using CalistoStandards.Definitions.Models.EdCore.Components;
using CalistoStandards.Definitions.Structures.Cls;

namespace CalistoStandards.Definitions.Models.EdCore.Messages;


public interface IClMessage : IClSignedComponent<MessageSign>
{
    public int Id { get; set; }
    bool IsValid { get; set; }
    string? StoredXml { get; set; }
    IClBody? Body { get; set; }
    ClResult Result { get; }
    ClStatus Status { get; set; }
}

public abstract class ClMessage : IClMessage
{
    public MessageSign Sign { get; set; }
    public int Id { get; set; }
    public bool IsValid { get; set; }
    public string? StoredXml { get; set; }
    public IClBody? Body { get; set; }
    public ClResult Result { get; }
    public ClStatus Status { get; set; }

    protected ClMessage(MessageSign sign) => Sign = sign;
    protected ClMessage(MessageSign sign, ClResult result) : this(sign) => Result = result;
}




public abstract class Message : Element<MessageSign>, IMessage, IDisposable //where T : Enum
{
    private bool _disposed;

    protected Message(MessageSign sign, bool isInvalid, ClElementType type) : base(sign, type)
    {
        IsInvalid = isInvalid;
    }

    public ClResult ClResult { get; set; }
    public KeyReference? KeyID { get; set; }
    public int MessageID { get; set; }
    public bool IsInvalid { get; }
    public string? StoredXml { get; set; }


    public override string ToString() => $"{base.ToString()}{ClResult}";


    #region IDisposable Pattern

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;

        if (disposing)
        {
        }

        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    #endregion
}