using CalistoStandards.Definitions.Interfaces.EdCore.Components;
using CalistoStandards.Definitions.Interfaces.EdCore.Messages;

namespace CalistoStandards.Definitions.Models.EdCore.Messages.MessageStructures;
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