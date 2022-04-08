namespace CalistoStandars.Definitions.Models;

public abstract class Message : Element<MessageSign>, IMessage, IDisposable //where T : Enum
{
    private bool _disposed;
    
    protected Message(MessageSign sign, bool isInvalid, ElementType type) : base(sign, type)
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