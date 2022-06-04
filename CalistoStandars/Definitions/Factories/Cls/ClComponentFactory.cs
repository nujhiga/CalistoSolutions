using System.Reflection;
using System.Text.Json.Nodes;

using CalistoStandards.Definitions.Interfaces.Cls;
using CalistoStandards.Definitions.Models;
using CalistoStandards.Definitions.Models.EdCore.Messages;

namespace CalistoStandards.Definitions.Factories.Cls;
public static class ClComponentFactory
{
    public static IClMember GetMember(MemberSign sign) => new ClMember(sign);
    public static IClMember GetMember(MemberSign sign, object? value) => new ClMember(sign, value);
    public static IEnumerable<IClMember> GetMembers(params MemberSign[] memberSigns) => from mSign in memberSigns select GetMember(mSign);

    public static IClNode GetNode(NodeSign sign, IEnumerable<IClMember> members) => new ClNode(sign, members);

    public static IClBody GetBody(IEnumerable<IClMember> members, bool isContainer = false) => new ClMembersBody(members, isContainer);
    public static IClBody GetBody(IEnumerable<IClNode> nodes, bool isContainer = false) => new ClNodesBody(nodes, isContainer);
    public static IClBody GetBody(IClMember member, IClNode node, bool isContainer = false) => new ClMemberNodeBody(member, node, isContainer);

    public static IEnumerable<IClMember> GetMembers(MemberSign[] memberSigns, object[] values) => from mSign in memberSigns let sg = mSign from mVal in values select GetMember(sg, mVal);

    public static IClNode GetNode(NodeSign sign, params IClMember[] members) => new ClNode(sign, members);
    public static IClBody GetBody(BodySign sign, IClNode node) => new ClNodeBody(sign, node);
    public static IClBody GetBody(BodySign sign, IEnumerable<IClNode> nodes) => new ClNodesBody(sign, nodes);
    public static IClBody GetBody(BodySign sign, IClMember member, IClNode node) => new ClMemberNodeBody(sign, member, node);
    public static IClBody GetBody(BodySign sign, IClMember member) => new ClMemberBody(sign, member);
    public static IClBody GetBody(BodySign sign, IEnumerable<IClMember> members) => new ClMembersBody(sign, members);

}

public static class ClJsonExtensions
{
    public static JsonNode?[] GetStructHeaderNodes(this JsonNode root, bool fromRecursiveArray = false)
    {
        JsonNode?[] headerNodes =
        {
            root[ClConsts.ClJsonReader.Sign],
            root[ClConsts.ClJsonReader.Pattern]
        };

        return headerNodes;
    }
    public static JsonNode GetJObjClSign(this JsonNode node) => node[ClConsts.ClJsonReader.Sign]!;
    public static JsonNode GetJObjClMember(this JsonNode node) => node[ClConsts.ClJsonReader.Member]!;
    public static JsonNode GetJObjClNode(this JsonNode node) => node[ClConsts.ClJsonReader.Node]!;
    public static JsonArray GetJArrayClMembers(this JsonNode node) => node[ClConsts.ClJsonReader.Members]!.AsArray();
    public static JsonArray GetJArrayClNodes(this JsonNode node) => node[ClConsts.ClJsonReader.Nodes]!.AsArray();
    public static JsonNode GetJObjClContainer(this JsonNode node) => node[ClConsts.ClJsonReader.Container]!;

    public static TSign AsTSign<TSign>(this JsonNode jnode) where TSign : struct, Enum => Enum.TryParse(jnode.GetValue<string>(), true, out TSign value) ? value : default;

    public static (MessageSign sign, ClMessagePattern pattern) GetStructHeader(this JsonNode?[] headerNodes)
    {
        if (headerNodes[0] is null || headerNodes[1] is null) return (default, default);

        MessageSign sign = headerNodes[0]!.AsTSign<MessageSign>();
        ClMessagePattern pattern = headerNodes[1]!.AsTSign<ClMessagePattern>();

        return (sign, pattern);
    }

    public static IClMember GetClMember(this JsonNode node, bool isNested = false)
    {
        MemberSign mSign;

        if (isNested)
        {
            mSign = node.GetJObjClSign().AsTSign<MemberSign>();
        }
        else
        {
            JsonNode jClMember = node.GetJObjClMember();
            mSign = jClMember.GetJObjClSign().AsTSign<MemberSign>();
        }

        return ClComponentFactory.GetMember(mSign);
    }

    public static IEnumerable<IClMember> GetClMembers(this JsonNode node)
    {
        JsonArray array = node.GetJArrayClMembers();

        foreach (JsonNode? nd in array)
            yield return nd?.GetClMember(true)!;
    }

    public static IEnumerable<IClNode> GetClNodes(this JsonNode node)
    {
        JsonArray array = node.GetJArrayClNodes();

        foreach (JsonNode? nd in array)
            yield return nd?.GetClNode(true)!;
    }
    public static (IClMember, IClNode) GetClMemberNode(this JsonNode node)
    {
        IClMember clmember = node.GetClMember();
        IClNode clnode = node.GetClNode();

        return (clmember, clnode);
    }

    public static IClComponent AsClComponent(this IEnumerable<IClMember> members, bool isContainer)
        => ClComponentFactory.GetBody(members, isContainer);
    public static IClComponent AsClComponent(this IEnumerable<IClNode> nodes, bool isContainer)
        => ClComponentFactory.GetBody(nodes, isContainer);
    public static IClComponent AsClComponent(this (IClMember member, IClNode node) memberNode, bool isContainer)
        => ClComponentFactory.GetBody(memberNode.member, memberNode.node, isContainer);

    public static IClNode GetClNode(this JsonNode node, bool isNested = false)
    {
        NodeSign nSign;
        IEnumerable<IClMember> nodeMembers;

        if (isNested)
        {
            nSign = node.GetJObjClSign().AsTSign<NodeSign>();
            nodeMembers = node.GetClMembers();
        }
        else
        {
            JsonNode jClNode = node.GetJObjClNode();

            nSign = jClNode.GetJObjClSign().AsTSign<NodeSign>();
            nodeMembers = jClNode.GetClMembers();
        }

        return ClComponentFactory.GetNode(nSign, nodeMembers);
    }

    public static ClPattern GetClPattern(this JsonNode node)
    {
        JsonNode?[] hNodes = node.GetStructHeaderNodes();

        (MessageSign sign, ClMessagePattern pattern) = hNodes.GetStructHeader();

        return new ClPattern(sign, pattern);
    }
}



public static class ClMessageStructFactory
{


    private static IClComponent GetCommonClComponent(in JsonNode node, in ClPattern pattern, bool isContainer = false)
    {
        IClComponent component = null!;

        if (pattern.Equals(ClMessagePattern.Member))
        {
            component = node.GetClMember();
        }
        else if (pattern.Equals(ClMessagePattern.Members))
        {
            component = node.GetClMembers().AsClComponent(isContainer);
        }
        else if (pattern.Equals(ClMessagePattern.Node))
        {
            component = node.GetClNode();
        }
        else if (pattern.Equals(ClMessagePattern.Nodes))
        {
            component = node.GetClNodes().AsClComponent(isContainer);
        }
        else if (pattern.Equals(ClMessagePattern.MemberNode))
        {
            component = node.GetClMemberNode().AsClComponent(isContainer);
        }

       // component.MessagePattern = pattern;

        return component;
    }

    public static Dictionary<MessageSign, IClComponent> GetMessagesStructs<TMessage>() where TMessage : IClMessage
    {
        JsonArray nodeArray = GetStructsArray<TMessage>();

        Dictionary<MessageSign, IClComponent> messagesStruct =
            new Dictionary<MessageSign, IClComponent>(nodeArray.Count);

        foreach (JsonNode? node in nodeArray)
        {
            if (node is null) continue;

            ClPattern pattern = node.GetClPattern();
            IClComponent component;

            if (pattern.Equals(ClMessagePattern.Container))
            {
                JsonNode contNode = node.GetJObjClContainer();
                ClPattern contPattern = contNode.GetClPattern();

                component = GetCommonClComponent(in contNode, in contPattern, true);
            }
            else
            {
                component = GetCommonClComponent(in node, in pattern);
            }

            messagesStruct.Add(pattern.Sign, component);
        }

        return messagesStruct;
    }




    private static JsonArray GetStructsArray<TMessage>() where TMessage : IClMessage
    {
        string source = GetJsonResourcePath();
        JsonNode jsonSource = JsonNode.Parse(source)!;

        string structRef = typeof(TMessage) == typeof(IClRequest)
            ? ClConsts.ClJsonReader.Requests
            : ClConsts.ClJsonReader.Responses;

        return jsonSource.Root[structRef]?.AsArray()!;
    }


    private static string GetJsonResourcePath()
    {
        Assembly assbly = Assembly.GetExecutingAssembly();

        using Stream rStream = assbly.GetManifestResourceStream(ClConsts.ClJsonReader.ResourcePath)!;
        using StreamReader rStreamReader = new StreamReader(rStream);

        return rStreamReader.ReadToEnd();
    }


}
public sealed class ClPattern : IEquatable<ClMessagePattern>
{
    public MessageSign Sign { get; }
    public ClMessagePattern Pattern { get; }

    public ClPattern(MessageSign sign, ClMessagePattern pattern)
    {
        Sign = sign;
        Pattern = pattern;
    }

    private bool Equals(ClPattern other) => Sign == other.Sign && Pattern == other.Pattern;
    public bool Equals(ClMessagePattern other) => other.Equals(Pattern);
    public override bool Equals(object? obj) => ReferenceEquals(this, obj) || obj is ClPattern other && Equals(other);
    public override int GetHashCode() => HashCode.Combine((int)Sign, (int)Pattern);
}