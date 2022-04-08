using System.Text;
using CalistoEdCore.Services.Providers;
using CalistoStandars.Definitions.Enumerations;
using CalistoStandars.Definitions.Extensions;
using CalistoStandars.Definitions.Interfaces;
using CalistoStandars.Definitions.Models;

namespace CalistoEdCore.Services.Factories;

public sealed class MessageSerializer : IDisposable
{
    private StringBuilder _builder;
    private string _methodHeader;
    private string _methodFooter;

    private readonly MessageSign? _messageSign;

    public MessageSerializer(MessageSign? messageSign)
    {
        _messageSign = messageSign;
       
        Initialize();
    }

    private void Initialize()
    {
        (_builder, _methodHeader, _methodFooter) = SerializerProvider.GetHeaderFooter();
        
        CleanBuilder();
    }

    private void CleanBuilder() 
    {
        _builder.Length = 0;
        _builder.Capacity = 0;
        _builder.Clear();
    }




    public void Dispose() => CleanBuilder();

    #region Serialization
    public string Serialize(in IBody body)
    {
        string builderResult = SimpleSerialize(in body);

        CleanBuilder();

        body.Dispose();

        return builderResult;
    }
    public string Serialize(in IEnumerable<IBody> bodies)
    {
        string builderResult = CompleSerialize(in bodies);

        CleanBuilder();

        foreach (var body in bodies)
            body.Dispose();

        return builderResult;
    }
    private string SimpleSerialize(in IBody body)
    {
        SerializeHeader(_messageSign);

        SerializeContent(in body);

        SerializeFooter(_messageSign);

        return _builder.ToString();

    }
    private string CompleSerialize(in IEnumerable<IBody> bodies)
    {
        SerializeHeader(_messageSign);

        foreach (var body in bodies)
            SerializeContent(body);

        SerializeFooter(_messageSign);

        return _builder.ToString();
    }
    private void SerializeHeader(in MessageSign? sign)
    {
        _builder.Append(_methodHeader);
        _builder.AppendLine(SerializerProvider.GetStatamen(sign));
    }
    private void SerializeFooter(in MessageSign? sign)
    {
        _builder.AppendLine(SerializerProvider.GetCloseStatamen(sign));
        _builder.Append(_methodFooter);
    }
    private void SerializeContent(in IBody body)
    {
        if (body.Sign is not BodySign.None)
            _builder.AppendLine(SerializerProvider.GetStatamen(body.Sign));

        if (body.ContentPattern is BodyContentPattern.Members)
        {
            _ = body.TryConvertBodyContent(out BodyMembers bodyContent);
            AppendMembers(bodyContent.Members);
        }
        else if (body.ContentPattern is BodyContentPattern.NodesMembers)
        {
            _ = body.TryConvertBodyContent(out BodyNodesMembers bodyContent);

            foreach (INode node in bodyContent.Nodes)
                AppendNode(in node);
        }
        else if (body.ContentPattern is BodyContentPattern.MemberNode)
        {
            _ = body.TryConvertBodyContent(out BodyMemberNode bodyContent);

            (IMember member, INode node) = bodyContent.SingleMemberSingleNode;

            AppendMember(in member);
            AppendNode(in node);
        }

        if (body.Sign is not BodySign.None) _builder.AppendLine
            (SerializerProvider.GetCloseStatamen(body.Sign));

        ValidateBody(body);
    }
    private void AppendMembers(in IEnumerable<IMember> members)
    {
        foreach (IMember member in members)
            _builder.AppendLine(SerializerProvider.
                GetStatamen(member.Sign, member.Value));
    }
    private void AppendMember(in IMember member) => _builder.AppendLine(
        SerializerProvider.GetStatamen(member.Sign, member.Value));
    private void AppendNode(in INode node, bool appendNodeMembers = true)
    {
        _builder.AppendLine(SerializerProvider.GetStatamen(node.Sign));

        if (appendNodeMembers) AppendMembers(node.Members);

        _builder.AppendLine(SerializerProvider.GetCloseStatamen(node.Sign));
    }
    private static void ValidateBody(IBody body)
    {
        if (body.IsInvalidBody) return;

        if (body is IBodyMemberNode a)
        {
            body.IsInvalidBody = a.IsInvalid;
            return;
        }

        if (body is IBodyMembers b)
        {
            body.IsInvalidBody = b.IsInvalid;
            return;
        }

        if (body is not IBodyNodesMembers c) return;

        body.IsInvalidBody = c.IsInvalid;
    }
    #endregion
}
