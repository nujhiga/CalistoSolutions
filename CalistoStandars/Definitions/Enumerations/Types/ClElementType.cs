namespace CalistoStandards.Definitions.Enumerations;

public enum ClElementType
{
    None,
    Serializable,
    MethodInfo,
    DefaultInfo,
    Member,
    MemberInfo,
    Node,
    NodeInfo,
    Body,
    EmptyBody,
    BodyInfo,
    MemberCollection,
    NodeCollection,
    BodyCollection,
    Message,
    Request,
    Response,
    Parameter,
    MapProvider,
    DisposableMapProvider,
    ReinstanteableMapProvider,
    DisposableMap,
    SignMap,
    ReinstanteableMap,
}
//ff



//foreach (PropertyInfo pinfo in this.GetPropertiesWith<ElementAttr>
//             (e => e.GetCustomAttribute<ElementAttr>()!.ClElementType is ClElementType.Disposable))
//{
//    if (pinfo is IDisposable disposablePinfo)
//        disposablePinfo.Dispose();
//}