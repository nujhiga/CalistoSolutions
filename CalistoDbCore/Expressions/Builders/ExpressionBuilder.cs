using System.Linq.Expressions;
using System.Reflection;
using CalistoDbCore.Expressions.BuildingOptions;
using CalistoDbCore.Expressions.BuildingOptions.OptionsModels;
using CalistoDbCore.Expressions.Enumerations;
using CalistoDbCore.Expressions.Extensions;
using CalistoDbCore.U3FEntities;
using CalistoStandars.Definitions.Enumerations;
using CalistoStandars.Definitions.Records.DbCore;
using Microsoft.EntityFrameworkCore;

namespace CalistoDbCore.Expressions.Builders;

public abstract class ExpressionsBase<TEntity> where TEntity : class
{
    protected record ExpressionPackage(ConstantExpression Constant, ParameterExpression Param, MemberExpression Value);
    private const string ParamMarker = "p";
    protected virtual MethodInfo? GetContainsMethod<TValue>() => typeof(ICollection<TValue>).GetMethod(nameof(Enumerable.Contains), new[] { typeof(TValue) });
    protected virtual MethodInfo? GetNullableContainsMethod<TValue>() => typeof(ICollection<TValue>).GetMethod(nameof(Enumerable.Contains), new[] { typeof(TValue?) });
    protected static MemberExpression GetProperty(Expression param, string target) => Expression.PropertyOrField(param, target);
    protected static ParameterExpression GetParameter() => Expression.Parameter(typeof(TEntity), ParamMarker);
    protected static ConstantExpression GetConstant(object source) => Expression.Constant(source);
    protected static ConstantExpression GetNullableConstant<TValue>(object source) => Expression.Constant(source, typeof(TValue?));
    protected static ExpressionPackage GetPackage(object constSource, string target)
    {
        var constant = GetConstant(constSource);

        var param = GetParameter();
        { }
        var property = GetProperty(param, target);
        { }
        return new ExpressionPackage(constant, param, property);
    }
    protected static ExpressionPackage GetNullablePackage<TValue>(object constSource, string target)
    {
        var constant = GetNullableConstant<TValue>(constSource);
        { }
        var param = GetParameter();
        { }
        var property = GetProperty(param, target);
        { }
        return new ExpressionPackage(constant, param, property);
    }
}
public abstract class ExpressionsBinary<TEntity> : ExpressionsBase<TEntity> where TEntity : class
{
    protected virtual Expression<Func<TEntity, bool>> Contains<TValue>(string target, params TValue[] values)
    {
        MethodInfo method = GetContainsMethod<TValue>()!;
        { }
        var (constant, param, value) = GetPackage(values, target);
        { }
        var expBody = Expression.Call(constant, method, value);
        { }
        return Expression.Lambda<Func<TEntity, bool>>(expBody, param);
    }
    protected virtual Expression<Func<TEntity, bool>> NullableContains<TValue>(string target, params TValue[] values)
    {
        MethodInfo method = GetNullableContainsMethod<TValue>()!;
        { }
        var (constant, param, value) = GetNullablePackage<TValue>(values, target);
        { }
        var expBody = Expression.Call(constant, method!, value);
        { }
        return Expression.Lambda<Func<TEntity, bool>>(expBody, param);
    }
    protected virtual Expression<Func<TEntity, bool>> Equal<TValue>(string target, TValue value)
    {
        var (constant, param, evalue) = GetPackage(value!, target);

        var equal = Expression.Equal(evalue, constant);

        return Expression.Lambda<Func<TEntity, bool>>(equal, param);
    }
    protected virtual Expression<Func<TEntity, bool>> NullableEqual<TValue>(string target, TValue? value)
    {
        var (constant, param, evalue) = GetNullablePackage<TValue?>(value, target);
        { }
        var equal = Expression.Equal(evalue, constant);

        return Expression.Lambda<Func<TEntity, bool>>(equal, param);
    }
    protected virtual Expression<Func<TEntity, bool>> NotEqual<TValue>(string target, TValue value)
    {
        var (constant, param, evalue) = GetPackage(value!, target);

        var nequal = Expression.NotEqual(evalue, constant);

        return Expression.Lambda<Func<TEntity, bool>>(nequal, param);
    }
    protected virtual Expression<Func<TEntity, bool>> NullableNotEqual<TValue>(string target, TValue? value)
    {
        var (constant, param, evalue) = GetNullablePackage<TValue?>(value, target);
        { }
        var nequal = Expression.NotEqual(evalue, constant);
        { }
        return Expression.Lambda<Func<TEntity, bool>>(nequal, param);
    }

    protected virtual Expression<Func<T, bool>> AndAlsos<T>(
        Expression<Func<T, bool>> expr1,
        Expression<Func<T, bool>> expr2)
    {
        // need to detect whether they use the same
        // parameter instance; if not, they need fixing
        ParameterExpression param = expr1.Parameters[0];
        if (ReferenceEquals(param, expr2.Parameters[0]))
        {
            // simple version
            return Expression.Lambda<Func<T, bool>>(
                Expression.AndAlso(expr1.Body, expr2.Body), param);
        }
        // otherwise, keep expr1 "as is" and invoke expr2
        return Expression.Lambda<Func<T, bool>>(
            Expression.AndAlso(
                expr1.Body,
                Expression.Invoke(expr2, param)), param);
    }

    protected virtual Expression<Func<T, bool>> AndAlso<T>(
        Expression<Func<T, bool>> expr1,
        Expression<Func<T, bool>> expr2)
    {
        var parameter = Expression.Parameter(typeof(T));

        var leftVisitor = new ReplaceExpressionVisitor(expr1.Parameters[0], parameter);
        var left = leftVisitor.Visit(expr1.Body);

        var rightVisitor = new ReplaceExpressionVisitor(expr2.Parameters[0], parameter);
        var right = rightVisitor.Visit(expr2.Body);

        return Expression.Lambda<Func<T, bool>>(
            Expression.AndAlso(left, right), parameter);
    }
    
    private class ReplaceExpressionVisitor
        : ExpressionVisitor
    {
        private readonly Expression _oldValue;
        private readonly Expression _newValue;

        public ReplaceExpressionVisitor(Expression oldValue, Expression newValue)
        {
            _oldValue = oldValue;
            _newValue = newValue;
        }

        public override Expression Visit(Expression node)
        {
            if (node == _oldValue)
                return _newValue;
            return base.Visit(node);
        }
    }

    protected virtual Expression<Func<TEntity, bool>> And<TxValue, TyValue>
        (string xtarget, TxValue xvalue, string ytarget, TyValue yvalue)
    {
        var (xconstant, xparam, xevalue) = GetPackage(xvalue!, xtarget);
        var xequal = Expression.Equal(xevalue, xconstant);
        var xexp = Expression.Lambda<Func<TEntity, bool>>(xequal, xparam);

        var (yconstant, yparam, yevalue) = GetPackage(yvalue!, ytarget);
        var yequal = Expression.Equal(yevalue, yconstant);
        var yexp = Expression.Lambda<Func<TEntity, bool>>(yequal, yparam);

        return AndAlso(xexp, yexp);
    }

    protected virtual Expression<Func<TEntity, bool>> AndAlso<TValue>(string target, TValue value, params Expression[] alsoBinaries)
    {
        var (constant, param, evalue) = GetPackage(value!, target);
        var equalSource = Expression.Equal(evalue, constant);

        var alsoSource = alsoBinaries[0];
        BinaryExpression andAlso = Expression.AndAlso(equalSource, alsoSource);

        for (int i = 1; i < alsoBinaries.Length; i++)
            andAlso = Expression.AndAlso(andAlso, alsoBinaries[i]);

        return Expression.Lambda<Func<TEntity, bool>>(andAlso, param);
    }
    protected virtual Expression<Func<TEntity, bool>> NullableAndAlso<TValue>(string target, TValue? value, params Expression[] alsoBinaries)
    {
        var (constant, param, evalue) = GetPackage(value!, target);
        var equalSource = Expression.Equal(evalue, constant);

        var alsoSource = alsoBinaries[0];
        BinaryExpression andAlso = Expression.AndAlso(equalSource, alsoSource);
        
        for (int i = 1; i < alsoBinaries.Length; i++)
            andAlso = Expression.AndAlso(andAlso, alsoBinaries[i]);

        return Expression.Lambda<Func<TEntity, bool>>(andAlso, param);
    }
}
public abstract class ExpressionBuilder<TEntity> : ExpressionsBinary<TEntity> where TEntity : class
{
    private readonly int? ULPConvCodRef = 119;
    public BuilderOptions Options { get; set; }

    protected ExpressionBuilder() => Options = new BuilderOptions();
    protected ExpressionBuilder(BuilderOptions options) => Options = options;

    private Expression UsingOption(OptionType optionType) => optionType switch
    {
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

        if (option.Value is not { Length: > 0 }) return null!;

        return option.Value.Length == 1
            ? Equal(option.Name, option.Value[0].StrValue)
            : Contains(option.Name, option.Value.Select(p => p.ToString()).ToArray());
    }

    private Expression UsingConvCod()
    {
        OptCampus option = Options.Campus;

        if (!option.IsValid()) return null!;

        return ClCampus.U3F == option.Value ?
            NullableNotEqual(option.Name, ULPConvCodRef) :
            NullableEqual(option.Name, ULPConvCodRef);
    }
    private Expression UsingCampus()
    {
        OptCampus option = Options.Campus;

        return !option.IsValid() ? null! :
            Equal(option.Name, option.Value.SourceStr);
    }
    private Expression UsingRegularity()
    {
        OptRegular option = Options.Regular;

        if (!option.IsValid()) return null!;

        var value = option.Value;

        return value is IngressCond
            ? And(nameof(value.Regular), value.Regular,
                nameof(value.Curing), value.Curing)
            : Equal(nameof(value.Regular), value.Regular);
    }
    private Expression UsingCareers()
    {
        OptCareers option = Options.Careers;

        if (!option.IsValid()) return null!;

        if (option.Value is not { Length: > 0 }) return null!;

        return option.Value.Length == 1 ?
            NullableEqual(option.Name, option.Value[0]) :
            Contains(option.Name, option.Value);
    }
    private Expression UsingCommissions()
    {
        OptCommissions option = Options.Commissions;

        if (!option.IsValid()) return null!;

        if (option.Value is not { Length: > 0 }) return null!;

        return option.Value.Length == 1 ?
            NullableEqual(option.Name, option.Value[0]) :
            Contains(option.Name, option.Value);
    }
    private Expression UsingUsers()
    {
        OptUsers option = Options.Users;

        if (!option.IsValid()) return null!;

        if (option.Value is not { Length: > 0 }) return null!;

        return option.Value.Length == 1 ?
            NullableEqual(option.Name, option.Value[0]) :
            Contains(option.Name, option.Value);
    }
    protected IEnumerable<Expression> GetExpressionsOptions(params OptionType[] options) 
        => options.Select(UsingOption).Where(e => e is not null);
}


public sealed class StudentsQueries : ExpressionBuilder<VisAlu>
{
    public StudentsQueries() { }
    public StudentsQueries(BuilderOptions options) : base(options) { }

    public IQueryable<VisAlu>? GetSyncCareerQuery(IQueryable<VisAlu> query)
    {
        Expression[] expressions = GetExpressionsOptions(OptionType.Period, 
            OptionType.Regular, OptionType.ConvCod, OptionType.Career).ToArray()!;
        
        {}

        return expressions.Length == 0 ? null :
            query.WithExpressions(expressions).AsNoTracking();
    }
}




