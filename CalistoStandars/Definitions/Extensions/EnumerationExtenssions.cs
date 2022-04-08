namespace CalistoStandars.Definitions.Extensions;
public static class EnumerationExtenssions
{
    //todo: 8422#1: review if its a good/performance practice
    public static string AsString<TEnum>(this TEnum enm) where TEnum : struct, Enum => $"{enm}";
    public static string AsString(this Enum enm) => $"{enm}";
}
