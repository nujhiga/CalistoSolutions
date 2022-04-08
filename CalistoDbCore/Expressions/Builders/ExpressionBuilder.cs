using System.Linq.Expressions;

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

internal abstract class ExpressionBuilder<TEntity> where TEntity : class, IEntity //: BinaryExpressionBuilder<TEntity> where TEntity : class, IEntity
{
    public ClDbParameter Parameter { get; set; }

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
            if (attr.ParamType is DbParameterType.Period)
                yield return GetPeriodExpression();

            if (attr.ParamType is DbParameterType.Campus)
                yield return GetCampusExpression();

            if (attr.ParamType is DbParameterType.Academics)
                yield return GetAcademicExpression();

            if (attr.ParamType is DbParameterType.Users)
                yield return GetUserExpression();

            if (attr.ParamType is DbParameterType.Regularity)
                yield return GetRegularityExpression();
        }
    }


    //protected Expression BuildExpression<TValue>(EntityMemberSign sign, TValue constValue, ExpressionType expType, bool isNullable = true)
    //{
    //    ExpressionOption<TValue> buildOpt = new ExpressionOption<TValue>($"{sign}", constValue, expType, isNullable);
    //    _ = TryBuild(buildOpt, out Expression expression);

    //    return expression;
    //}



    private static bool TryBuild<TSign, TValue>(in ExpressionOption<TSign, TValue> buildOpt, out Expression expression) where TSign : struct, Enum
    {
        expression = null!;

        if (!buildOpt.IsValid) return false;

        (TSign sign, TValue value, ExpressionType xType, bool nullable) =
            (buildOpt.FieldSign, buildOpt.ConstValue,
                buildOpt.ExpressionType, buildOpt.Nullable);

        expression = xType switch
        {
            ExpressionType.Equal or ExpressionType.NotEqual =>
                value!.AsEqualityExpression<TEntity, TSign>(sign, xType, nullable),

            ExpressionType.OnesComplement =>
                value!.AsContainsExpression<TEntity, TSign>(sign),

            _ => null!
        };

        return expression is not null;
    }

    /*
    private bool TryBuild<TSign, TValue>(in ExpressionOption<TSign, TValue> buildOpt, out Expression expression) 
        where TSign : struct, Enum
    {
        expression = null!;

        if (!buildOpt.IsValid) return false;

        (string fieldName, TValue constVal, bool nullable) =
            (buildOpt.FieldName, buildOpt.ConstValue, buildOpt.Nullable);

        expression = buildOpt.ExpressionType switch
        {
            ExpressionType.Equal when !nullable => constVal.AsEqualsExpression<TEntity>(), //EqualExp2(fieldName, constVal),
            ExpressionType.Equal when nullable => NullableEqualExp(fieldName, constVal),

            ExpressionType.NotEqual when !nullable => NotEqualExp(fieldName, constVal),
            ExpressionType.NotEqual when nullable => NullableNotEqualExp(fieldName, constVal),

            ExpressionType.OnesComplement when !buildOpt.AsArray().NullOrEmpty() =>
                ContainsExp(fieldName, buildOpt.AsArray().NullOrEmpty()),

            _ => null!
        };

        return expression != null;
    }
    */

    private static bool TryBuild<TSign, TValue>(
        in ExpressionOption<TSign, TValue> buildOptx,
        in ExpressionOption<TSign, TValue> buildOpty,
        out Expression expression) where TSign : struct, Enum
    {
        object[] xValues = { buildOptx.ConstValue!, buildOpty.ConstValue! };

        expression = xValues.AsAndAlsoExpression<TEntity, TSign, TSign>
            (buildOptx.FieldSign, buildOpty.FieldSign);

        return expression is not null;
    }

    /*
    private bool TryBuild<TValue>(in ExpressionOption<TValue> xbuildOpt, in ExpressionOption<TValue> ybuildOpt, out Expression expression)
    {
        expression = And(xbuildOpt.FieldName, xbuildOpt.ConstValue,
            ybuildOpt.FieldName, ybuildOpt.ConstValue);

        return expression != null;
    }
    */
    protected Expression GetRegularityExpression()
    {
        Expression rExpression;

        if (!Parameter.UsingRegularity) return null!;

        DbRegularity regularity = Parameter.Regularity!.Member;
        string regularityValue = regularity.GetRegularityValue();

        if (regularity is DbRegularity.Ingress)
        {
            string regular = regularityValue[..1];
            string curing = regularityValue[1..1];

            ExpressionOption<DbRegularity, string> optionx =
                OptionFactory.WithOption(DbRegularity.Regular, regular);

            ExpressionOption<DbRegularity, string> optiony =
                OptionFactory.WithOption(DbRegularity.Curing, curing);

            _ = TryBuild(optionx, optiony, out rExpression);
        }
        else
        {
            ExpressionOption<DbRegularity, string> option =
                OptionFactory.WithOption(DbRegularity.Regular, regularityValue);

            _ = TryBuild(option, out rExpression);
        }


        /*
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
        */

        return rExpression;
    }
    protected Expression GetUserExpression()
    {
        Expression uExpression;

        if (!Parameter.UsingUsers) return null!;

        if (!Parameter.UsersIDs!.IsArray)
        {
            ExpressionOption<DbAcademics, double> option = OptionFactory.
                WithOption(DbAcademics.Legajo, Parameter.UsersIDs.Member![0]);

            _ = TryBuild(option, out uExpression);
        }
        else
        {
            ExpressionOption<DbAcademics, double[]> option = OptionFactory.
                WithOption(DbAcademics.Legajo, Parameter.UsersIDs.Member!,
                    ExpressionType.OnesComplement);

            _ = TryBuild(option, out uExpression);
        }

        /*
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
        */

        return uExpression;
    }
    protected Expression GetAcademicExpression()
    {
        Expression aExpression;

        if (!Parameter.UsingAcademics) return null!;

        DbAcademics dbAcademics = Parameter.RequestSign.GetDbAcademic();

        if (!Parameter.AcademicsIDs!.IsArray)
        {
            ExpressionOption<DbAcademics, int?> option = OptionFactory.
                WithOption(dbAcademics, Parameter.AcademicsIDs.Member![0]);

            _ = TryBuild(option, out aExpression);

        }
        else
        {
            ExpressionOption<DbAcademics, int?[]> option = OptionFactory.
                WithOption(dbAcademics, Parameter.AcademicsIDs.Member!,
                    ExpressionType.OnesComplement);

            _ = TryBuild(option, out aExpression);
        }

        /*
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
        */


        return aExpression;
    }
    protected Expression GetCampusExpression()
    {
        Expression cExpression;

        if (!Parameter.UsingCampus) return null!;

        DbCampus dbCampus = Parameter.RequestSign.GetDbCampus();

        if (dbCampus is DbCampus.ConvCod)
        {
            int? aux = 119;

            ExpressionOption<DbCampus, int?> option = OptionFactory.
                WithOption(dbCampus, aux);

            _ = TryBuild(option, out cExpression);
        }
        else
        {
            ExpressionOption<DbCampus, ClCampus> option = OptionFactory.
                WithOption(dbCampus, Parameter.Campus!.Member);

            _ = TryBuild(option, out cExpression);
        }

        /*
        if (!Parameter.Campus2.UsingThis) return null!;

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
        }*/


        return cExpression;
    }
    protected Expression GetPeriodExpression()
    {
        Expression pExpression;

        if (!Parameter.UsingPeriods) return null!;

        DbPeriod dbPeriod = Parameter.RequestSign.GetDbPeriod();

        if (!Parameter.Periods!.IsArray)
        {
            ExpressionOption<DbPeriod, Period> option = OptionFactory.
                WithOption(dbPeriod, Parameter.Periods.Member![0]);

            _ = TryBuild(option, out pExpression);
        }
        else
        {
            ExpressionOption<DbPeriod, Period[]> option = OptionFactory.
                WithOption(dbPeriod, Parameter.Periods.Member!,
                    ExpressionType.OnesComplement);

            _ = TryBuild(option, out pExpression);
        }

        return pExpression;
    }

    //protected Expression GetClParamExpression(DbParameterType paramType)
    //{
    //    var whereParam = new Func<PropertyInfo, bool>(p =>
    //        p.GetCustomAttribute<DbParamAttr>()!.ParamType == paramType);

    //    var paramInfoMember = Parameter.GetPropertiesWith<DbParamAttr>(whereParam).Single();


    //}


}




