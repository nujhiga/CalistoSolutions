namespace CalistoStandards.Definitions.Enumerations;

[SignMapAttr(SignMapType.NodeSignMap, typeof(NodeSign))]

public enum NodeSign
{
    None,
    fault,
    error,
    grupos,
    usuario_grupo,
    modificar_usuario,
    asignar_usuario_grupo,
    eliminar_usuarios_grupos,
    usuario,
    usuarios,
    valor_da
}