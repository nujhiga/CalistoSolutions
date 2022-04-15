using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

using CalistoStandards.Definitions.Interfaces.Cls;
using CalistoStandards.Definitions.Models;
using CalistoStandards.Definitions.Models.EdCore.Messages;

using Microsoft.VisualBasic;

namespace CalistoStandards.Definitions.Factories.Cls;
public static class ClComponentFactory
{
    public static IClMember GetMember(MemberSign sign) => new ClMember(sign);
    public static IClMember GetMember(MemberSign sign, object? value) => new ClMember(sign, value);
    public static IEnumerable<IClMember> GetMembers(params MemberSign[] memberSigns) => from mSign in memberSigns select GetMember(mSign);
    public static IEnumerable<IClMember> GetMembers(MemberSign[] memberSigns, object[] values) => from mSign in memberSigns let sg = mSign from mVal in values select GetMember(sg, mVal);

    public static IClNode GetNode(NodeSign sign, IEnumerable<IClMember> members) => new ClNode(sign, members);
    public static IClNode GetNode(NodeSign sign, params IClMember[] members) => new ClNode(sign, members);
    // public static IClNode GetNode(NodeSign sign, IEnumerable<MemberSign> membersSigns) => new ClNode(sign, membersSigns);

    public static IClBody GetBody(BodySign sign, IClMember member) => new ClMemberBody(sign, member);
    public static IClBody GetBody(BodySign sign, IEnumerable<IClMember> members) => new ClMembersBody(sign, members);
    public static IClBody GetBody(IEnumerable<IClMember> members) => new ClMembersBody(members);
    public static IClBody GetBody(BodySign sign, IClNode node) => new ClNodeBody(sign, node);
    public static IClBody GetBody(IEnumerable<IClNode> nodes) => new ClNodesBody(nodes);
    public static IClBody GetBody(BodySign sign, IEnumerable<IClNode> nodes) => new ClNodesBody(sign, nodes);
    public static IClBody GetBody(BodySign sign, IClMember member, IClNode node) => new ClMemberNodeBody(sign, member, node);



}

public static class ClJsonExtensions
{
    public static JsonNode?[] GetStructHeaderNodes(this JsonNode root)
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

    public static JsonArray ContainerToArray(this JsonNode node)
    {
        JsonNode objClContainer = node.GetJObjClContainer();
        JsonNode?[] containerNodes = objClContainer.GetJsonNodesNotNull().ToArray();
        return new JsonArray(containerNodes);
    }

    public static IEnumerable<JsonNode> GetJsonNodesNotNull(this JsonNode node)
    {
        foreach (string cmpStr in ClConsts.ClJsonReader.Components)
        {
            JsonNode? cNode = node[cmpStr];
            if (cNode is not null)
                yield return cNode;
        }
    }



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

    public static IClComponent AsClComponent(this IEnumerable<IClMember> members) => ClComponentFactory.GetBody(members);
    public static IClComponent AsClComponent(this IEnumerable<IClNode> nodes) => ClComponentFactory.GetBody(nodes);


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

    //JsonNode?[] hNodes = node.GetStructHeaderNodes();
    //(MessageSign sign, ClMessagePattern pattern) sHeader = hNodes.GetStructHeader();
    //var nodess = node.GetJArrayClNodes();

    //IClNode clNode = node.GetClNode(false);
    //var members = node.GetClMembers();
    /*
if (sHeader.pattern is ClMessagePattern.Nodes)
{

    var nodes = node.GetClNodes();



    { }
}
*/


    public static IClBody GetMessageStruct<TMessage>() where TMessage : IClMessage
    {
        JsonArray array = GetStructsArray<TMessage>();

        foreach (JsonNode? node in array)
        {
            if (node is null) continue;

            IClComponent component;

            ClPattern hPattern = node.GetClPattern();

            if (hPattern.Equals(ClMessagePattern.Member))
            {
                component = node.GetClMember();
            }
            else if (hPattern.Equals(ClMessagePattern.Members))
            {
                component = node.GetClMembers().AsClComponent();
            }
            else if (hPattern.Equals(ClMessagePattern.Node))
            {
                component = node.GetClNode();
            }
            else if (hPattern.Equals(ClMessagePattern.Nodes))
            {
                component = node.GetClNodes().AsClComponent();
            }
            else if (hPattern.Equals(ClMessagePattern.Container))
            {
                var a = node.ContainerToArray();
                {}
            }




        }

        return null;
    }


    //public static IClBody GetBody()
    //{
    //    var jarray = GetStructsArray<IClRequest>();

    //    foreach (JsonNode? node in jarray)
    //    {
    //        if (node is null) continue;

    //        ClPattern hPattern = node.GetClPattern();




    //    }

    //    return null!;
    //}

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

    private bool Equals(ClPattern other)
    {
        return Sign == other.Sign && Pattern == other.Pattern;
    }

    public bool Equals(ClMessagePattern other) => other.Equals(Pattern);


    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj) || obj is ClPattern other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine((int)Sign, (int)Pattern);
    }
}