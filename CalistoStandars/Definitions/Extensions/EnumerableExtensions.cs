using System.Text;

namespace CalistoStandars.Definitions.Extensions;

public static class EnumerableExtensions
{
    public enum ContentEvaluiationOption
    {
        None,
        Any,
        All
    }

    public enum EnumerableConvertOption
    {
        None,
        Array,
        List,
        Collection,
        Dictionary
    }

    public static bool NullOrEmpty<T>(this IEnumerable<T> source) => source is null || !source.Any();

    public static bool NullOrEmptyWhen<T>(this IEnumerable<T> source, Func<T, bool> contentEvaluation,
        ContentEvaluiationOption option)
    {
        if (source.NullOrEmpty()) return true;
        if (contentEvaluation is null) return false;

        var result = option switch
        {
            ContentEvaluiationOption.All when source.All(contentEvaluation) => true,
            ContentEvaluiationOption.Any when source.Any(contentEvaluation) => true,
            _ => false
        };

        return result;
    }

    public static string ToCsvString<T>(this IEnumerable<T> source, char comma = ',', char? afterComma = null,
        bool nullEmptyValidation = true)
    {
        if (source is null || !source.Any()) return string.Empty;

        var arraySrc = source as T[] ?? source.ToArray();

        if (arraySrc.NullOrEmpty()) return null!;

        StringBuilder sb = new();

        var lenth = arraySrc.Length;

        for (var i = 0; i < lenth - 1; i++)
        {
            sb.Append($"{arraySrc[i]}{comma}");

            if (afterComma is { })
                sb.Append(afterComma);
        }

        sb.Append(arraySrc[^1]);

        var sbData = sb.ToString();

        Array.Clear(arraySrc, 0, arraySrc.Length);
        arraySrc = null!;

        return sbData;
    }
}