namespace CalistoStandards.Definitions.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public sealed class DbParamAttr : ElementAttr
{
    public readonly ClParameterType ParamType;
    public DbParamAttr(ClParameterType paramType) : 
        base(ClElementType.Parameter) => ParamType = paramType;
}