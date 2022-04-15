using System.Reflection;

using CalistoStandards.Definitions.Interfaces.EdCore.Components;

namespace CalistoStandards.Definitions.Extensions;

//todo: 7422#2 - review reflection methods

public static class MessagesExtensions
{
    public static bool IsMassiveRequest(this MessageSign messageSign) =>
        messageSign is MessageSign.asignar_usuarios_grupos or MessageSign.desactivar_usuarios
            or MessageSign.eliminar_usuarios_grupos or MessageSign.registrar_usuarios;


    public static void SetMemberValue(this IMember member, in object source)
    {
        if (member is null) return;

        PropertyInfo valueMemberPinfo = member.ValueProperty;
        
        object? sourceValue = GetSourceValue(source, member.Sign);

        if (sourceValue is null)
        {
            var attr = source.GetMemberAttribute(member.Sign);
         
            if (!attr!.IsNullable && attr!.DefaultValue is null)
            {
                PropertyInfo invalidValueProperty = member.InvalidValueProperty;
                invalidValueProperty.SetValue(member, true);
                return;
            }

            if (!attr!.IsNullable && attr!.DefaultValue is not null)
                sourceValue = attr!.DefaultValue;
        }

        valueMemberPinfo.SetValue(member, sourceValue);
    }
    

    public static object? GetSourceValue<TSign>(this object source, TSign sign) where TSign : Enum
    {
        var properties = ReflectionExtensions.GetInterfaceProperties <ElementAttr>( source );

        var nameProp = properties!.Single(p => p.GetCustomAttribute<ElementAttr>()!.SignEnum.Equals(sign));
        
        var value = nameProp.GetValue(source);

        return value;
    }




    private static MemberAttr GetMemberAttribute<TSign>(this object source, TSign sign) where TSign : Enum
    {
        var interProperties = ReflectionExtensions.GetInterfaceProperties <MemberAttr>( source );

        var signedProperty = interProperties.Single(p => p.GetCustomAttribute<MemberAttr>()!.MemberSign.Equals(sign));

        return signedProperty.GetCustomAttribute<MemberAttr>()!;
    }




    public static void SetSingleNodeMembersValues(this object source, in INode node)
    {
        //// Base Properties of the source object marked up as Node
        var properties = ReflectionExtensions.GetInterfaceProperties <NodeAttr>( source ).First();

            //source.GetType().GetProperties().First(p => Attribute.IsDefined(p, typeof(NodeAttr)));
            //// Validates if exists or have at least an element
        if (properties.GetValue(source) is not (object[] { Length: > 0 } innerArray)) return;
        {}
        foreach (var element in innerArray.Take(1))
        {
            ////Getting the properties marked up as Members on the interface of the source object
            var interfaceProperties = ReflectionExtensions.GetInterfaceProperties <MemberAttr>( element );

            if (interfaceProperties is null) continue;

            foreach (var prop in interfaceProperties)
            {
                ////Getting the attribute itself who contains the Sign id reference of a Member
                var attr = prop.GetCustomAttribute<MemberAttr>();

                if (attr is null) continue;
                ////Getting the corresponding member 
                IMember member = node.Members.SingleOrDefault(m => m.Sign == attr.MemberSign)!;

                if (member is null) continue;
                ////Getting the source value
                object? value = prop.GetValue(element);
                ////Setting it on the empty member

                if (value is null && !attr.IsNullable && attr.DefaultValue is null)
                {

                    PropertyInfo invalidValueProperty = member.InvalidValueProperty;
                    invalidValueProperty.SetValue(member, true);
                    break;

                }

                if (value is null && !attr.IsNullable && attr.DefaultValue is not null)
                    value = attr.DefaultValue;

                member.ValueProperty.SetValue(member, value);
                
            }

        }
        

    }

    public static bool TryConvertBodyContent<TBody>(this IBody body, out TBody result) where TBody : class
    {
        result = null!;

        if (body is not ({ } and TBody outBody))
            return false;

        result = outBody;
        return true;
    }
    public static IMember GetMember(this IBodyMemberNode body) => body.SingleMemberSingleNode.member;
    public static INode GetNode(this IBodyMemberNode body) => body.SingleMemberSingleNode.node;
    public static IEnumerable<IMember> GetNodeMembers(this IBodyMemberNode body, Func<IMember, bool> where = null!) => @where is null ? body.SingleMemberSingleNode.node.Members : body.SingleMemberSingleNode.node.Members.Where(@where);
    public static IEnumerable<IMember> GetNodeMembers(this IBodyMembers body, Func<IMember, bool> where = null!) => @where is null ? body.Members : body.Members.Where(@where);
    public static IEnumerable<IMember> GetNodeMembers(this IBodyNodesMembers body, NodeSign nodeSign) => body.Nodes.SingleOrDefault(n => n.Sign == nodeSign)!.Members;






}