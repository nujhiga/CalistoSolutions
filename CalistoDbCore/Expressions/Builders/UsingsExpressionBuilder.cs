using System.Collections;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.ComTypes;

using CalistoDbCore.Expressions.BuildingOptions;
using CalistoDbCore.Expressions.BuildingOptions.Factory;
using CalistoDbCore.Expressions.BuildingOptions.OptionsModels;
using CalistoDbCore.Expressions.Enumerations;
using CalistoDbCore.Expressions.Extensions;
using CalistoDbCore.Services.Repositories;

using CalistoStandars.Definitions.Enumerations;
using CalistoStandars.Definitions.Extensions;
using CalistoStandars.Definitions.Records.DbCore;
using CalistoStandars.Definitions.Structures;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;

namespace CalistoDbCore.Expressions.Builders;

internal sealed class ExpressionBuilder<TEntity> : BinaryExpressionBuilder<TEntity> where TEntity : class
{
    public DbRequestParameter<DbRequestSign> Parameter { get; set; }

    public ExpressionBuilder() { }
    public ExpressionBuilder(DbRequestParameter<DbRequestSign> parameter) => Parameter = parameter;

    internal IEnumerable<Expression> TryBuild()
    {
        Expression pExpression = GetPeriodExpression();

        if (pExpression is not null)
            yield return pExpression;

        Expression cExpression = GetCampusExpression();

        if (cExpression is not null)
            yield return cExpression;




    }


    private Expression GetAcademicExpression()
    {
        Expression aExpression = null!;

        if (Parameter.WithAcademicID is not {Length: > 0} academics) return aExpression;

        Enum dbEnumSign = Parameter.RequestSign.GetEnumSign();

        if (academics.Length == 1)
        {
            BuilderOption<int?> option = OptionFactory.WithOption(dbEnumSign, academics[0]);
            _ = TryBuild(option, out aExpression);
        }
        else
        {
            BuilderOption<int?[]> option = OptionFactory.WithOptions(dbEnumSign, academics);
            _ = TryBuild(option, out aExpression);
        }

        return aExpression;
    }

    private Expression GetCampusExpression()
    {
        Expression cExpression = null!;

        if (Parameter.FromCampus is not { } campus) return cExpression;

        DbCampus dbCampus = Parameter.RequestSign.GetDbCampus();

        if (dbCampus is DbCampus.ConvCod)
        {
            BuilderOption<int?> option = OptionFactory.WithConvCod(campus);
            _ = TryBuild(option, out cExpression);
        }
        else
        {
            BuilderOption<ClCampus> option = OptionFactory.WithCampus(campus);
            _ = TryBuild(option, out cExpression);
        }

        return cExpression;
    }
    private Expression GetPeriodExpression()
    {
        Expression pExpression = null!;

        if (Parameter.OnPeriods is not { Length: > 0 } periods) return pExpression;

        DbPeriod dbPeriod = Parameter.RequestSign.GetDbPeriod();

        if (periods.Length == 1)
        {
            BuilderOption<Period> option = OptionFactory.WithPeriod(dbPeriod, periods[0]);
            _ = TryBuild(option, out pExpression);
        }
        else
        {
            BuilderOption<Period[]> option = OptionFactory.WithPeriods(dbPeriod, periods);
            _ = TryBuild(option, out pExpression);
        }

        return pExpression;
    }




    private bool TryBuild<TValue>(in BuilderOption<TValue> buildOpt, out Expression expression)
    {
        expression = null!;

        if (!buildOpt.IsValid) return false;

        (string fieldName, TValue constVal, bool nullable) =
            (buildOpt.FieldName, buildOpt.ConstValue, buildOpt.Nullable);

        expression = buildOpt.ExpressionType switch
        {
            ExpressionType.Equal when !nullable => Equal(fieldName, constVal),
            ExpressionType.Equal when nullable => NullableEqual(fieldName, constVal),

            ExpressionType.NotEqual when !nullable => NotEqual(fieldName, constVal),
            ExpressionType.NotEqual when nullable => NullableNotEqual(fieldName, constVal),

            ExpressionType.OnesComplement when !buildOpt.AsArray().NullOrEmpty() =>
                Contains(fieldName, buildOpt.AsArray().NullOrEmpty()),

            _ => null!
        };

        return expression != null;
    }
    private bool TryBuild<TValue>(in BuilderOption<TValue> xbuildOpt, in BuilderOption<TValue> ybuildOpt, out Expression expression)
    {
        expression = And(xbuildOpt.FieldName, xbuildOpt.ConstValue,
            ybuildOpt.FieldName, ybuildOpt.ConstValue);

        return expression != null;
    }




    //public ExpressionBuilder() => Options = new BuilderOptions();public ExpressionBuilder(BuilderOptions options) => Options = options;


    /*
        private Expression UsingRegularity()
    {
        OptRegular option = Options.Regular;

        if (!option.IsValid()) return null!;

        var value = option.ConstValue;

        return value is IngressCond
            ? And(nameof(value.Regular), value.Regular,
                nameof(value.Curing), value.Curing)
            : Equal(nameof(value.Regular), value.Regular);
    }




    private Expression UsingOption(OptionType optionType) => optionType switch
    {
        OptionType.Name => UsignName(),
        OptionType.Document => UsingDocument(),
        OptionType.Campus => UsingCampus(),
        OptionType.ConvCod => UsingConvCod(),
        OptionType.Regular => UsingRegularity(),
        OptionType.Period => UsingPeriods(),
        OptionType.Career => UsingCareers(),
        OptionType.Commission => UsingCommissions(),
        OptionType.User => UsingUsers()!,
        _ => null!
    };
    private Expression UsingPeriods()
    {
        OptPeriod option = Options.Period;

        if (!option.IsValid()) return null!;

        if (option.ConstValue is not { Length: > 0 }) return null!;

        return option.ConstValue.Length == 1
            ? Equal(option.FieldName, option.ConstValue[0].StrValue)
            : Contains(option.FieldName, option.ConstValue.Select(p => p.ToString()).ToArray());
    }
    private Expression UsingConvCod()
    {
        OptCampus option = Options.Campus;

        if (!option.IsValid()) return null!;

        return ClCampus.U3F == option.ConstValue ?
            NullableNotEqual(option.FieldName, ULPConvCodRef) :
            NullableEqual(option.FieldName, ULPConvCodRef);
    }
    private Expression UsingCampus()
    {
        OptCampus option = Options.Campus;

        return !option.IsValid() ? null! :
            Equal(option.FieldName, option.ConstValue.ToString());
    }
    private Expression UsingCampus()
    {
        OptCampus option = Options.Campus;

        return !option.IsValid() ? null! :
            Equal(option.FieldName, option.ConstValue.ToString());
    }

    private Expression UsingCareers()
    {
        OptCareers option = Options.Careers;

        if (!option.IsValid()) return null!;

        if (option.ConstValue is not { Length: > 0 }) return null!;

        return option.ConstValue.Length == 1 ?
            NullableEqual(option.FieldName, option.ConstValue[0]) :
            Contains(option.FieldName, option.ConstValue);
    }
    private Expression UsingCommissions()
    {
        OptCommissions option = Options.Commissions;

        if (!option.IsValid()) return null!;

        if (option.ConstValue is not { Length: > 0 }) return null!;

        return option.ConstValue.Length == 1 ?
            NullableEqual(option.FieldName, option.ConstValue[0]) :
            Contains(option.FieldName, option.ConstValue);
    }
    private Expression UsingUsers()
    {
        OptUsers option = Options.Users;

        if (!option.IsValid()) return null!;

        if (option.ConstValue is not { Length: > 0 }) return null!;

        return option.ConstValue.Length == 1 ?
            NullableEqual(option.FieldName, option.ConstValue[0]) :
            Contains(option.FieldName, option.ConstValue);
    }
    */

    /*
    protected IEnumerable<Expression> GetExpressionsOptions(params OptionType[] options) 
        => options.Select(UsingOption).Where(e => e is not null);*/
}




