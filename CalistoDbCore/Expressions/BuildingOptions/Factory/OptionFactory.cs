namespace CalistoDbCore.Expressions.Builders;

public static class OptionFactory
{
    public static ExpressionOption<TSign, TValue> WithOption<TSign, TValue>(TSign fieldSign, TValue constValue,
                                                                            ExpressionType expType =
                                                                                ExpressionType.Equal)
        where TSign : struct, Enum
    {
        return new ExpressionOption<TSign, TValue>(fieldSign, constValue, expType);
    }


    //public static ExpressionOption<TValue, TSign> WithOption<TValue, TSign>(TSign fieldSign, TValue constValue, 
    //    ExpressionType expType = ExpressionType.Equal) where TSign : struct, Enum
    //{
    //    return new ExpressionOption<TValue, TSign>(fieldSign, constValue, expType);
    //}

    //public static ExpressionOption<TValue> WithOption<TValue>(Enum signEnum, TValue constValue, ExpressionType expType = ExpressionType.Equal)
    //{
    //    return new ExpressionOption<TValue>($"{signEnum}", constValue, expType);
    //}

    //public static ExpressionOption<TValue[], TSign> WithOptions<TValue, TSign>(TSign fieldSign, TValue[] constValue) where TSign : struct, Enum
    //{
    //    return new ExpressionOption<TValue[], TSign>(fieldSign, constValue, ExpressionType.OnesComplement);
    //}

    /*
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

    */
}