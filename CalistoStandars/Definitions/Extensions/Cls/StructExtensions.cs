using CalistoStandards.Definitions.Structures.Cls;

namespace CalistoStandards.Definitions.Extensions;

public static class StructExtensions
{

    public static string[] PeriodsToStringArray(this IEnumerable<Period> periods)
    {
        if (periods is not { }) return null!;

        if (!periods.TryGetNonEnumeratedCount(out int pCount)) return null!;

        string[] strPeriods = new string[pCount];

        int iaux = 0;

        foreach (Period period in periods)
        {
            strPeriods[iaux] = period.StrValue;
            iaux++;
        }

        return strPeriods;
    }

    public static bool NullOrEmpty(this KeyReference? keyRef) => keyRef is { } key && !key.Source.NullOrEmpty();
}