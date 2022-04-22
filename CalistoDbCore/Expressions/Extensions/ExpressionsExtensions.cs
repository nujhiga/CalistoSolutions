
using System.Reflection.Metadata;
using System.Windows.Markup;

using CalistoDbCore.Services.Repositories;

using CalistoStandards.Definitions.Structures.Cls;

internal static class ExpressionExtensions
{
    internal static ExpressionType ToExpressionType(this ClParamValueAssert paramValueAssert)
    {
        ExpressionType exType = paramValueAssert switch
        {
            ClParamValueAssert.Equal => ExpressionType.Equal,
            ClParamValueAssert.NotEqual => ExpressionType.NotEqual,
            ClParamValueAssert.Contains => ExpressionType.OnesComplement,
            _ => ExpressionType.Default
        };

        return exType;
    }
    internal static Expression ToExpression<TEntity>(this ClParamValue paramValue, bool nullableValue = false)
    {
        if (paramValue.AsValueCode is not { } valueCode) return null!;
        if (paramValue.ValueAssert is not { } valueAssert) return null!;

        if (paramValue.Value is null) return null!;

        ExpressionType exType = valueAssert.ToExpressionType();
        string targetName = paramValue.StrValueSign;  //valueSign.ToString(); //use mapping provider

        { }

        Expression expression = exType is ExpressionType.Equal or ExpressionType.NotEqual
            ? ToEqualityExpression<TEntity>(valueCode, paramValue.Value, targetName, exType, nullableValue)
            : ToContainsExpression<TEntity>(valueCode, paramValue.Value, targetName, nullableValue);

        return expression;
    }
    internal static Expression ToEqualityExpression<TEntity>(TypeCode asValueCode, object value, string targetName, ExpressionType exType, bool nullable)
    {
        Expression expression = asValueCode switch
        {
            TypeCode.String => ExpressionFactory.GetEqualityEx<TEntity, string>
                (targetName, exType, value.AsTypedValue<string>(), nullable),

            TypeCode.Char => ExpressionFactory.GetEqualityEx<TEntity, char>
                (targetName, exType, value.AsTypedValue<char>(), nullable),

            TypeCode.Int32 when nullable => ExpressionFactory.GetEqualityEx<TEntity, int?>
                (targetName, exType, value.AsTypedValue<int?>(), true),

            TypeCode.Int32 when !nullable => ExpressionFactory.GetEqualityEx<TEntity, int>
                (targetName, exType, value.AsTypedValue<int>()),

            TypeCode.Double => ExpressionFactory.GetEqualityEx<TEntity, double>
                (targetName, exType, value.AsTypedValue<double>(), nullable),

            TypeCode.DateTime => ExpressionFactory.GetEqualityEx<TEntity, DateTime>
                (targetName, exType, value.AsTypedValue<DateTime>(), nullable),

            _ => null!
        };

        return expression;
    }

    internal static Expression ToContainsExpression<TEntity>(TypeCode asValueCode, object values, string targetName, bool nullable)
    {
        Expression expression = asValueCode switch
        {
            TypeCode.String => ExpressionFactory.GetContainsEx<TEntity, string>
                (targetName, nullable, values.AsTypedArray<string>()),

            TypeCode.Char => ExpressionFactory.GetContainsEx<TEntity, char>
                (targetName, nullable, values.AsTypedArray<char>()),

            TypeCode.Int32 when nullable => ExpressionFactory.GetContainsEx<TEntity, int?>
                (targetName, nullable, values.AsTypedArray<int?>()),

            TypeCode.Int32 when !nullable => ExpressionFactory.GetContainsEx<TEntity, int>
                (targetName, nullable, values.AsTypedArray<int>()),

            TypeCode.Double => ExpressionFactory.GetContainsEx<TEntity, double>
                (targetName, nullable, values.AsTypedArray<double>()),

            TypeCode.DateTime => ExpressionFactory.GetContainsEx<TEntity, DateTime>
                (targetName, nullable, values.AsTypedArray<DateTime>()),

            _ => null!
        };

        return expression;
    }

    //private static T AsTypedValue<T>(this object value)
    //{
    //    if (value is null) return default!;
    //    { }
    //    return (T) Convert.ChangeType(value, typeof(T));
    //}
    private static T AsTypedValue<T>(this object value)
    {
        var t = typeof(T);

        if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
        {
            if (value == null)
            {
                return default(T);
            }

            t = Nullable.GetUnderlyingType(t);
        }

        return (T)Convert.ChangeType(value, t);
    }





    private static T?[] AsTypedArray<T>(this object values)
    {
        {}
        if (values is IEnumerable<Period> periods)
            return (periods.PeriodsToStringArray() as T[])!;
        {}
        if (values is not IEnumerable<T?> enumeratedValues) return null!;
        {}
        if (!enumeratedValues.TryGetNonEnumeratedCount(out int _)) return null!;
        { }
        return enumeratedValues.ToArray()!;
    }

}

internal static class ClDbParameterExtensions
{
    internal static Expression[] ToExpressions<TEntity>(this ClParameter parameter)
    {
        IEnumerable<Expression> expressions = parameter.RequestSign switch
        {
            DbRequestSign.GetSyncCareers => parameter.ToSyncCareerExpressions<TEntity>(),



            _ => Enumerable.Empty<Expression>()
        };

        return expressions.WithOutNulls().ToArray();
    }

    private static IEnumerable<Expression> ToSyncCareerExpressions<TEntity>(this ClParameter parameter)
    {
        yield return parameter.ToExpression<TEntity>(ClParamValueType.Regularity);
        yield return parameter.ToExpression<TEntity>(ClParamValueType.StudentCareer);
        yield return parameter.ToExpression<TEntity>(ClParamValueType.StudentPeriod);
        yield return parameter.ToExpression<TEntity>(ClParamValueType.StudentCampus);
    }

    internal static Expression<Func<TEntity, TEntity>> ToSelectExpression<TEntity>(this ClParameter parameter) =>
        ExpressionFactory.GetSelectEx<TEntity>(parameter.SelectFields.ToArray());


    internal static Expression ToExpression<TEntity>(this ClParameter parameter, ClParamValueType valType)
    {
        Expression ex = valType switch
        {
            ClParamValueType.Regularity => parameter.GetRegularityEx<TEntity>(),

            ClParamValueType.StudentCareer => parameter.GetValueOrValuesEx<TEntity>
                (ClParamValueType.Career, ClParamValueType.Careers, true),

            ClParamValueType.StudentPeriod => parameter.GetValueOrValuesEx<TEntity>
                (ClParamValueType.Period, ClParamValueType.Periods),

            ClParamValueType.StudentCampus => parameter.GetValueOrValuesEx<TEntity>
                (ClParamValueType.ConvCod, nullableValue: true),

            _ => null!
        };

        return ex;
    }


    private static Expression GetRegularityEx<TEntity>(this ClParameter parameter)
    {
        if (!parameter.ContainsValues) return null!;

        ClParamValue? regPmValue = parameter[ClParamValueType.Regularity];
        ClParamValue? curPmValue = parameter[ClParamValueType.Ingress];

        if (curPmValue is null)
            return regPmValue!.ToExpression<TEntity>();

        string regValue = regPmValue!.GetValue<string>();
        string regTarget = regPmValue!.StrValueSign;
        { }
        string curValue = curPmValue.GetValue<string>();
        string curTarget = curPmValue.StrValueSign;
        { }
        Expression regCurEx = ExpressionFactory.
            GetAndAlsoEx<TEntity, string, string>(regTarget, regValue, curTarget, curValue);

        return regCurEx;
    }

    internal static Expression GetValueOrValuesEx<TEntity>(this ClParameter parameter,
        ClParamValueType xValType, ClParamValueType? yValType = null, bool nullableValue = false)
    {
        if (!parameter.ContainsValues) return null!;

        ClParamValue? paramValue = parameter[xValType];
        { }
        if (paramValue is not null)
            return paramValue.ToExpression<TEntity>(nullableValue);

        if (yValType is not { } yyValType) return null!;

        paramValue = parameter[yyValType];

        return paramValue?.ToExpression<TEntity>(nullableValue)!;
    }

}



