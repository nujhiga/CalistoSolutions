namespace CalistoStandars.Definitions.Models;
public abstract class RequestStructure : IRequestStructure
{
    public MessageSign? RequestSign { get; }
    public IBody? RequestBody { get; protected set; }
    protected RequestStructure(MessageSign requestSign, IBody? body = null)
    {
        RequestSign = requestSign;

        if (body is not null)
            RequestBody = body;
    }
}