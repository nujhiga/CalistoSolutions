namespace CalistoStandards.Definitions.Extensions;
public static class EnumerationExtenssions
{
    //todo: 8422#1: review if its a good/performance practice
    public static string AsString<TEnum>(this TEnum enm) where TEnum : struct, Enum => $"{enm}";
    public static string AsString(this Enum enm) => $"{enm}";


    public static string Translate(this ClStatus clStatus) => clStatus switch
    {
        ClStatus.Cancelled => ClConsts.ClStatusTranslations.Cancelled,
        ClStatus.Finished => ClConsts.ClStatusTranslations.Finished,
        ClStatus.Paused => ClConsts.ClStatusTranslations.Paused,
        ClStatus.Working => ClConsts.ClStatusTranslations.Working,
        ClStatus.Initializing => ClConsts.ClStatusTranslations.Initializing,
        ClStatus.Cancelling => ClConsts.ClStatusTranslations.Cancelling,
        ClStatus.Pausing => ClConsts.ClStatusTranslations.Pausing,


        _ => string.Empty
    };


    public static string Translate(this ClResult clStatus) => clStatus switch
    {
        ClResult.Success => ClConsts.ClResultTranslations.Success,
        ClResult.Warning => ClConsts.ClResultTranslations.Warning,
        ClResult.Failed => ClConsts.ClResultTranslations.Failed,
        ClResult.Error => ClConsts.ClResultTranslations.Error,
        ClResult.Exception => ClConsts.ClResultTranslations.Exception,
        ClResult.Invalid => ClConsts.ClResultTranslations.Invalid,
        ClResult.Valid => ClConsts.ClResultTranslations.Valid,

        _ => string.Empty
    };


}
