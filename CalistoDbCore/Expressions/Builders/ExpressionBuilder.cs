using System.Linq.Expressions;
using System.Reflection;
using CalistoDbCore.Expressions.BuildingOptions.Factory;
using CalistoDbCore.Expressions.BuildingOptions.OptionsModels;
using CalistoDbCore.Expressions.Enumerations;
using CalistoDbCore.Expressions.Extensions;
using CalistoDbCore.Services.Repositories;

using CalistoStandars.Definitions.Enumerations;
using CalistoStandars.Definitions.Enumerations.DbCore;
using CalistoStandars.Definitions.Extensions;
using CalistoStandars.Definitions.Interfaces.DbCore.Entities;
using CalistoStandars.Definitions.Models;
using CalistoStandars.Definitions.Structures;

namespace CalistoDbCore.Expressions.Builders;

internal abstract class ExpressionBuilder<TEntity> : BinaryExpressionBuilder<TEntity> where TEntity : class, IEntity
{
    public DbRequestParameter Parameter { get; set; }
    
    [Obsolete]
    protected IEnumerable<Expression> GetSyncExpressions()
    {
        Expression pExpression = GetPeriodExpression();
        if (pExpression is not null)
            yield return pExpression;

        Expression cExpression = GetCampusExpression();
        if (cExpression is not null)
            yield return cExpression;

        Expression aExpression = GetAcademicExpression();
        if (aExpression is not null)
            yield return aExpression;

        Expression uExpression = GetUserExpression();
        if (uExpression is not null)
            yield return uExpression;

        Expression rExpression = GetRegularityExpression();
        if (rExpression is not null)
            yield return rExpression;
    }
    
    protected IEnumerable<Expression> GetExpressions()
    {
        IEnumerable<DbParamAttr> attributes =
            Parameter.GetAttributesWith<DbParamAttr>();

        foreach (DbParamAttr attr in attributes)
        {
            if (attr.ParamValueType == typeof(Period[]))
                yield return GetPeriodExpression();

            if (attr.ParamValueType == typeof(ClCampus?))
                yield return GetCampusExpression();

            if (attr.ParamValueType == typeof(int?[]))
                yield return GetAcademicExpression();

            if (attr.ParamValueType == typeof(double[]))
                yield return GetUserExpression();

            if (attr.ParamValueType == typeof(DbRegularity?))
                yield return GetRegularityExpression();
        }
    }

    protected Expression GetExpression<TValue>(EntityMemberSign sign, TValue constValue, ExpressionType expType, bool isNullable = true)
    {
        ExpressionOption<TValue> buildOpt = new ExpressionOption<TValue>($"{sign}", constValue, expType, isNullable);
        _ = TryBuild(buildOpt, out Expression expression);

        return expression;
    }
    
    
    
    
    
    
    private bool TryBuild<TValue>(in ExpressionOption<TValue> buildOpt, out Expression expression)
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
    private bool TryBuild<TValue>(in ExpressionOption<TValue> xbuildOpt, in ExpressionOption<TValue> ybuildOpt, out Expression expression)
    {
        expression = And(xbuildOpt.FieldName, xbuildOpt.ConstValue,
            ybuildOpt.FieldName, ybuildOpt.ConstValue);

        return expression != null;
    }
    protected Expression GetRegularityExpression()
    {
        Expression rExpression = null!;

        if (!Parameter.UseRegularity) return null!;

        ExpressionOption<string> optionx;

        if (Parameter.Regularity is DbRegularity.Regular)
        {
            optionx = OptionFactory.WithOption(DbRegularity.Regular, nameof(ConsoleKey.R));
            _ = TryBuild(optionx, out rExpression);
        }
        else if (Parameter.Regularity is DbRegularity.Ingress)
        {
            optionx = OptionFactory.WithOption(DbRegularity.Regular, nameof(ConsoleKey.I));
            ExpressionOption<string> optiony = OptionFactory.WithOption(DbRegularity.Ingress, nameof(ConsoleKey.T));
            _ = TryBuild(optionx, optiony, out rExpression);
        }

        return rExpression;
    }
    protected Expression GetUserExpression()
    {
        Expression uExpression;

        if (!Parameter.UseUsersIDs) return null!;

        if (Parameter.UsersIDs!.Length == 1)
        {
            ExpressionOption<double> option = OptionFactory.
                WithOption(DbUsers.Legajo, Parameter.UsersIDs[0]);

            _ = TryBuild(option, out uExpression);
        }
        else
        {
            ExpressionOption<double[]> option = OptionFactory.
                WithOptions(DbUsers.Legajo, Parameter.UsersIDs);

            _ = TryBuild(option, out uExpression);
        }

        return uExpression;
    }
    protected Expression GetAcademicExpression()
    {
        Expression aExpression;

        if (!Parameter.UseAcademicIDs) return null!;

        Enum dbEnumSign = Parameter.RequestSign.GetEnumSign();

        if (Parameter.AcademicIDs!.Length == 1)
        {
            ExpressionOption<int?> option = OptionFactory.
                WithOption(dbEnumSign, Parameter.AcademicIDs[0]);

            _ = TryBuild(option, out aExpression);
        }
        else
        {
            ExpressionOption<int?[]> option = OptionFactory.
                WithOptions(dbEnumSign, Parameter.AcademicIDs);

            _ = TryBuild(option, out aExpression);
        }

        return aExpression;
    }
    protected Expression GetCampusExpression()
    {
        Expression cExpression;

        if (!Parameter.UseCampus) return null!;

        DbCampus dbCampus = Parameter.RequestSign.GetDbCampus();

        if (dbCampus is DbCampus.ConvCod)
        {
            ExpressionOption<int?> option = OptionFactory.
                WithConvCod(Parameter.Campus!.Value);

            _ = TryBuild(option, out cExpression);
        }
        else
        {
            ExpressionOption<ClCampus> option = OptionFactory.
                WithCampus(Parameter.Campus!.Value);

            _ = TryBuild(option, out cExpression);
        }

        return cExpression;
    }
    protected Expression GetPeriodExpression()
    {
        Expression pExpression;

        if (!Parameter.UsePeriods) return null!;

        DbPeriod dbPeriod = Parameter.RequestSign.GetDbPeriod();

        if (Parameter.Periods!.Length == 1)
        {
            ExpressionOption<string> option = OptionFactory.
                WithPeriod(dbPeriod, Parameter.Periods![0]);

            _ = TryBuild(option, out pExpression);
        }
        else
        {
            ExpressionOption<string[]> option = OptionFactory.
                WithPeriods(dbPeriod, Parameter.Periods!);

            _ = TryBuild(option, out pExpression);
        }

        return pExpression;
    }
}




