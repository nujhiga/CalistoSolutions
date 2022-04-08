using CalistoStandars.Definitions.Enumerations.DbCore;

namespace CalistoStandars.Definitions.Models;

[AttributeUsage(AttributeTargets.Property)]
public sealed class DbParamAttr : ElementAttr
{
    public readonly DbParameterType ParamType;
    public DbParamAttr(DbParameterType paramType) : 
        base(ElementType.Parameter) => ParamType = paramType;
}