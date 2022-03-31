using System.Linq.Expressions;
using System.Reflection;

namespace CalistoDbCore.Expressions.Builders;

public abstract class BaseExpressionsBuilder<TEntity> where TEntity : class
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




