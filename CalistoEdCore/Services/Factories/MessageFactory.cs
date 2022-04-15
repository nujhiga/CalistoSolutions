using System.Collections.ObjectModel;
using System.Net;
using CalistoStandards.Definitions.Interfaces.EdCore.Components;
using CalistoStandards.Definitions.Interfaces.EdCore.Messages;
using CalistoStandards.Definitions.Models.EdCore.Components;
using CalistoStandards.Definitions.Models.EdCore.Messages;

namespace CalistoEdCore.Services.Factories;

public static class MessageFactory
{
    public static IRequest CreateRequest(in MessageSign sign, string xmlGeneration, ClResult clResult, int currentCount) //where  TSign : Enum
    {
        bool isInvalid = clResult is ClResult.Invalid;
        
        Request request = new Request(sign, isInvalid)
        {
            StoredXml = xmlGeneration,
            ClResult = clResult,
        };

        return request;
    }

    public static IResponse CreateResponse(in IRequest invalidRequest, int currentCount) //where  TSign : Enum
    {
        Response request = new Response(invalidRequest);

        return request;
    }

    public static IResponse CreateResponse(in MessageSign sign, string xmlResponse, HttpStatusCode statusCode, ClResult clResult, int currentCount) //where  TSign : Enum
    {
        bool isInvalid = clResult is ClResult.Invalid;

        Response request = new Response(sign, statusCode, isInvalid)
        {
            StoredXml = xmlResponse,
            ClResult = clResult,
        };

        return request;
    }
    


    /// <summary>
    /// Calls the corresponding method builder from a raw no nodes / members / body structure
    /// </summary>
    /// <typeparam name="TObj">Generic type of the object that will provide the references.</typeparam>
    /// <param name="source">Object as reference provider.</param>
    /// <param name="rStruct">Object as raw empty message structure provider.</param>
    /// <returns>A complete request message with the reference data.</returns>
    public static IBody GetBodyContent(in object source, in IRequestStructure rStruct)
    {
        //IBody bodyContent = null!;

        if (rStruct.RequestBody!.ContentPattern is ClMessagePattern.MemberNode)
        {
            if (MessagesExtensions.TryConvertBodyContent( rStruct.RequestBody , out BodyMemberNode memberNode))
                 return GetMemberNodeBody(in source, ref memberNode);

            // bodyContent = GetMemberNodeBody(in source, ref memberNode);
        }
        else if (rStruct.RequestBody!.ContentPattern is ClMessagePattern.Nodes)
        {
            if (MessagesExtensions.TryConvertBodyContent( rStruct.RequestBody , out BodyNodesMembers nodesMembers))
                return GetNodesMembersBody(in source, ref nodesMembers);
            //bodyContent = GetNodesMembersBody(in source, ref nodesMembers);
        }
        else if (rStruct.RequestBody!.ContentPattern is ClMessagePattern.Members)
        {
            if (MessagesExtensions.TryConvertBodyContent( rStruct.RequestBody , out BodyMembers bodyMembers))
                return GetMembersBody(in source, ref bodyMembers);
            

            //  bodyContent = GetMembersBody(in source, ref bodyMembers);
        }
        {}
        return null!;
    }

    public static IEnumerable<IBody> GetBodyContent(IEnumerable<object> source, IRequestStructure rStruct)
    {
        Collection<IBody> bodies = new Collection<IBody>();

        foreach (object body in source)
            bodies.Add(GetBodyContent(body, rStruct));

        return bodies;
    }
    



    /// <summary>
    /// Build a request message structured as Unique Member - Unique Node.
    /// </summary>
    /// <typeparam name="TObj">Generic type of the object that will provide the message members - nodes references and values.</typeparam>
    /// <param name="source">Object as reference provider.</param>
    /// <param name="memberNode">The empty structure according to message sign provided</param>
    /// <returns>A complete request message with the reference data.</returns>
    private static IBody GetMemberNodeBody(in object source, ref BodyMemberNode memberNode)
    {
        MessagesExtensions.SetMemberValue( MessagesExtensions.GetMember( memberNode ) , in source);

        INode node = MessagesExtensions.GetNode( memberNode );

        MessagesExtensions.SetSingleNodeMembersValues( source , in node);

        return memberNode;
    }

    /// <summary>
    /// Build a message structured as Multiple Nodes.
    /// </summary>
    /// <typeparam name="TObj">Generic type of the object that will provide the message members - nodes references and values.</typeparam>
    /// <param name="source">Object as reference provider.</param>
    /// <param name="nodesMembers">The empty structure according to message sign provided</param>
    /// <returns>A complete request message with the reference data.</returns>
    private static IBody GetNodesMembersBody(in object source, ref BodyNodesMembers nodesMembers)
    {
        foreach (INode node in nodesMembers.Nodes)
        {
            if (node.Sign is NodeSign.usuario_grupo)
                MessagesExtensions.SetSingleNodeMembersValues( source , in node);
            else
            {
                foreach (IMember member in node.Members)
                    MessagesExtensions.SetMemberValue( member , in source);
            }
        }

        return nodesMembers;
    }

    /// <summary>
    /// Build a message structure Multiple Members.
    /// </summary>
    /// <typeparam name="TObj">Generic type of the object that will provide the message members - nodes references and values.</typeparam>
    /// <param name="source">Object as reference provider.</param>
    /// <param name="bodyMembers">The empty structure according to message sign provided</param>
    /// <returns>A complete request message with the reference data.</returns>
    private static IBody GetMembersBody(in object source, ref BodyMembers bodyMembers)
    {
        foreach (IMember member in bodyMembers.Members)
            MessagesExtensions.SetMemberValue( member , in source);

        return bodyMembers;
    }
}
