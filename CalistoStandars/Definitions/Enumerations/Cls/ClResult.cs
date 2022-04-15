namespace CalistoStandards.Definitions.Enumerations;

[SignMapAttr(SignMapType.ClResultMap, typeof(ClResult))]

public enum ClResult
{
    None,
    Success,
    Warning,
    Failed,
    Error,
    Exception,
    Invalid,
    Valid
}