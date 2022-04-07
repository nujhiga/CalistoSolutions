using System.Linq.Expressions;

using CalistoDbCore.Expressions.BuildingOptions.OptionsModels;
using CalistoDbCore.Expressions.Enumerations;

using CalistoStandars.Definitions.Enumerations;
using CalistoStandars.Definitions.Models.DbCore.Entities.Constants;
using CalistoStandars.Definitions.Structures;

namespace CalistoDbCore.Expressions.BuildingOptions.Factory;
public static class OptionFactory
{
    public static ExpressionOption<TValue> WithOption<TValue, TSign>(TSign signField, TValue constValue, ExpressionType expType = ExpressionType.Equal)
    {
        return new ExpressionOption<TValue>($"{signField}", constValue, expType);
    }

    public static ExpressionOption<TValue> WithOption<TValue>(Enum signEnum, TValue constValue, ExpressionType expType = ExpressionType.Equal)
    {
        return new ExpressionOption<TValue>($"{signEnum}", constValue, expType);
    }

    public static ExpressionOption<TValue[]> WithOptions<TValue, TSign>(TSign signField, TValue[] constValue)
    {
        return new ExpressionOption<TValue[]>($"{signField}", constValue, ExpressionType.OnesComplement);
    }

    public static ExpressionOption<TValue[]> WithOptions<TValue>(Enum signEnum, TValue[] constValue)
    {
        return new ExpressionOption<TValue[]>($"{signEnum}", constValue, ExpressionType.OnesComplement);
    }

    public static ExpressionOption<string> WithPeriod(DbPeriod periodField, Period constValue)
    {
        string period = periodField is DbPeriod.AnoIngreso
            ? constValue.Year
            : constValue.StrValue;

        return new ExpressionOption<string>($"{periodField}", period, ExpressionType.Equal);
    }

    public static ExpressionOption<string[]> WithPeriods(DbPeriod periodField, Period[] constValue)
    {
        string[] periods = periodField is DbPeriod.AnoIngreso
            ? constValue.Select(p => p.Year).ToArray()
            : constValue.Select(p => p.StrValue).ToArray();

        return new ExpressionOption<string[]>($"{periodField}", periods, ExpressionType.OnesComplement);
    }

    public static ExpressionOption<ClCampus> WithCampus(ClCampus constValue)
    {
        return new ExpressionOption<ClCampus>(EntitiesConstants.Academic.Campus, constValue, ExpressionType.Equal);
    }

    public static ExpressionOption<int?> WithConvCod(ClCampus campus)
    {
        int? constValue = 119;

        const string fieldName = EntitiesConstants.Academic.ConvCod;

        ExpressionType expType = campus == ClCampus.U3F ? ExpressionType.NotEqual : ExpressionType.Equal;

        ExpressionOption<int?> option = new ExpressionOption<int?>(fieldName, constValue, expType, true);

        return option;
    }
}
