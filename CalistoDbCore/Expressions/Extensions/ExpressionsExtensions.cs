using System.Linq.Expressions;
using System.Reflection;

using CalistoDbCore.Expressions.Builders;

using CalistoStandars.Definitions.Enumerations.DbCore;
using CalistoStandars.Definitions.Extensions;
using CalistoStandars.Definitions.Interfaces.DbCore.Entities;


namespace CalistoDbCore.Expressions.Extensions;

internal static class ExpressionsExtensions
{
    #region Base Factory

    private const string ParamMarker = "p";


    internal static MethodInfo? GetContainsMethod(this Type type) =>
        type.GetMethod(nameof(Enumerable.Contains), new[] { type });


    internal static ExpressionPackage AsPackagedExpressions(this object source, Enum fieldSign, bool nullable = false)
    {
        ConstantExpression constant = source.AsConstantExpression(nullable);

        ParameterExpression parameter = source.GetType().AsParameterExpression();

        MemberExpression propertyOrField =
            parameter.AsPropertyOrFieldExpression(fieldSign.AsString());

        return new ExpressionPackage(constant, parameter, propertyOrField);
    }

    internal static MemberExpression AsPropertyOrFieldExpression(this Expression param, string target) =>
        Expression.PropertyOrField(param, target);

    internal static MemberExpression AsPropertyExpression(this Expression param, PropertyInfo pinfo) =>
        Expression.Property(param, pinfo);

    internal static MemberAssignment AsBindExpression(this MemberInfo minfo, Expression expression) =>
        Expression.Bind(minfo, expression);

    internal static MemberInitExpression AsInitExpression(this NewExpression nExpression,
        IEnumerable<MemberAssignment> members) => Expression.MemberInit(nExpression, members);

    internal static NewExpression AsNewExpression(this Type newInstanceType) => Expression.New(newInstanceType);

    internal static ParameterExpression AsParameterExpression(this Type parameterType) =>
        Expression.Parameter(parameterType, ParamMarker);

    internal static ConstantExpression AsConstantExpression(this object value, bool asNullable = false) =>
        !asNullable ? Expression.Constant(value) : Expression.Constant(value, value.GetType());


    #endregion

    #region Binary Factory



    internal static Expression<Func<TEntity, bool>> AsEqualityExpression<TEntity, TSign>
        (this object value, TSign fieldSign, ExpressionType expType, bool nullable = false) 
        where TSign : struct, Enum 
        where TEntity : class, IEntity
    {
        LambdaExpressionPackage package = value.
            AsEqualityLambdaPackage(fieldSign, expType, nullable);

        return package.AsLambdaExpression<TEntity>();
    }
    
    internal static Expression<Func<TEntity, bool>> AsAndAlsoExpression<TEntity, TxSign, TySign>
        (this object[] values, TxSign xSign, TySign ySign) 
        where TxSign : struct, Enum 
        where TySign : struct, Enum 
        where TEntity : class, IEntity
    {
        var xtuple = (values[0], xSign);
        var ytuple = (values[1], ySign);

        LambdaExpressionPackage[] lambdaPacks = xtuple.
            AsAndAlsoLambdaExpressionsPackage(ytuple);

        return lambdaPacks.AsAndAlsoVisitors<TEntity>();
    }

    internal static Expression<Func<TEntity, bool>> AsContainsExpression<TEntity, TSign>
        (this object values, TSign fielSign)
        where TSign : struct, Enum
    {

        MethodInfo methodInfo = values.GetType().GetContainsMethod()!;
        var (constant, param, value) = values.AsPackagedExpressions(fielSign);
        
        MethodCallExpression callExpression = Expression.Call(constant, methodInfo, value);
        
        return Expression.Lambda<Func<TEntity, bool>>(callExpression, param);

    }

    public static Expression<Func<TEntity, TEntity>> AsSelectExpression<TEntity>(this EntityMemberSign[] selectSigns)
    {
        var type = typeof(TEntity);

        ParameterExpression xParameter = type.AsParameterExpression();

        NewExpression xNew = type.AsNewExpression();

        var bindings = selectSigns.Select(sgName =>
        {
            PropertyInfo pinfo = type.GetProperty(sgName.AsString())!;

            MemberExpression xMember = xParameter.AsPropertyExpression(pinfo);

            return pinfo.AsBindExpression(xMember);
        });

        MemberInitExpression xInit = xNew.AsInitExpression(bindings);

        Expression<Func<TEntity, TEntity>> expression =
            Expression.Lambda<Func<TEntity, TEntity>>(xInit, xParameter);

        return expression;
    }

    #endregion

    #region Lambdas Factory

    private static LambdaExpressionPackage[] AsAndAlsoLambdaExpressionsPackage<TxValue, TxSign, TyValue, TySign>
        (this (TxValue xvalue, TxSign xsign) xValue, 
              (TyValue yvalue, TySign ysign) yValue) 
        where TySign : struct, Enum 
        where TxSign : struct, Enum
    {
        LambdaExpressionPackage xlambda = xValue.xvalue.AsEqualityLambdaPackage(xValue.xsign, ExpressionType.Equal);
        LambdaExpressionPackage ylambda = yValue.yvalue.AsEqualityLambdaPackage(yValue.ysign, ExpressionType.Equal);

        return new[] { xlambda, ylambda };
    }

    private static Expression<Func<TEntity, bool>> AsAndAlsoVisitors<TEntity>
        (this LambdaExpressionPackage[] lambdasPackages) 
        where TEntity : class, IEntity
    {
        var parameter = Expression.Parameter(typeof(TEntity));

        var xlambda = lambdasPackages[0].AsLambdaExpression<TEntity>();
        var ylambda = lambdasPackages[1].AsLambdaExpression<TEntity>();
        
        var leftVisitor = new ReplaceExpressionVisitor(xlambda.Parameters[0], parameter);
        var left = leftVisitor.Visit(xlambda.Body);

        var rightVisitor = new ReplaceExpressionVisitor(ylambda.Parameters[0], parameter);
        var right = rightVisitor.Visit(ylambda.Body);

        return Expression.Lambda<Func<TEntity, bool>>(
            Expression.AndAlso(left, right), parameter);
    }
    
    private static LambdaExpressionPackage AsEqualityLambdaPackage<TValue, TSign>
        (this TValue value, TSign fieldSign, ExpressionType expType, bool nullable = false) 
        where TSign : struct, Enum
    {
        var (constant, parameter, property) = value!.AsPackagedExpressions(fieldSign, nullable);

        BinaryExpression equality = expType == ExpressionType.Equal
            ? Expression.Equal(property, constant)
            : Expression.NotEqual(property, constant);

        return new LambdaExpressionPackage(equality, parameter);
    }

    private static Expression<Func<TEntity, bool>> AsLambdaExpression<TEntity>
        (this LambdaExpressionPackage package) 
        where TEntity : class, IEntity
    {
        var (expression, parameter) = package;
        return Expression.Lambda<Func<TEntity, bool>>(expression, parameter);
    }

    #endregion



}


