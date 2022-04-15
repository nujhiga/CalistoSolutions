using System.Reflection;
using CalistoDbCore.Expressions.Factories;
using CalistoDbCore.Expressions.Factories.Helpers;
using CalistoStandards.Definitions.Interfaces.DbCore.Entities;

//using static CalistoDbCore.Expressions.Builders.ExpressionFactory<TEntity>;

namespace CalistoDbCore.Expressions.Builders;

public abstract class BinaryExpressionBuilder<TEntity>
    where TEntity : class, IEntity //: BaseExpressionBuilder<TEntity> where TEntity : class
{
    public static Expression<Func<TEntity, TEntity>> SelectExp(params EntityMemberSign[] selectSigns)
    {
        ParameterExpression xParameter = ExpressionFactory<TEntity>.GetParameter();

        NewExpression xNew = ExpressionFactory<TEntity>.GetNew();

        var bindings = selectSigns.Select(sgName =>
        {
            PropertyInfo tOutProp = typeof(TEntity).GetProperty($"{sgName}")!;

            MemberExpression tEntProp = ExpressionFactory<TEntity>.GetProperty(xParameter, tOutProp);

            return ExpressionFactory<TEntity>.GetBind(tOutProp, tEntProp);
        });

        MemberInitExpression xInit = ExpressionFactory<TEntity>.GetInit(xNew, bindings);

        Expression<Func<TEntity, TEntity>> expression =
            Expression.Lambda<Func<TEntity, TEntity>>(xInit, xParameter);

        return expression;
    }


    protected virtual Expression<Func<TEntity, bool>> ContainsExp<TValue>(string target, params TValue[] values)
    {
        MethodInfo method = ExpressionFactory<TEntity>.GetContainsMethod<TValue>()!;

        var (constant, param, value) = ExpressionFactory<TEntity>.GetPackage(values, target);

        var expBody = Expression.Call(constant, method, value);

        return Expression.Lambda<Func<TEntity, bool>>(expBody, param);
    }


    protected virtual Expression<Func<TEntity, bool>> EqualExp<TValue>(string target, TValue value)
    {
        var (constant, param, evalue) = ExpressionFactory<TEntity>.GetPackage(value!, target);

        var equal = Expression.Equal(evalue, constant);

        return Expression.Lambda<Func<TEntity, bool>>(equal, param);
    }


    //protected virtual Expression<Func<TEntity, bool>> EqualExp2<TValue, TSign>(TSign fieldSign, TValue value) 
    //    where TSign : struct, Enum
    //{
    //    return value!.AsEqualsExpression<TEntity, TSign>(fieldSign);
    //}


    protected virtual Expression<Func<TEntity, bool>> NullableEqualExp<TValue>(string target, TValue? value)
    {
        var (constant, param, evalue) = ExpressionFactory<TEntity>.GetNullablePackage<TValue?>(value, target);

        var equal = Expression.Equal(evalue, constant);

        return Expression.Lambda<Func<TEntity, bool>>(equal, param);
    }

    protected virtual Expression<Func<TEntity, bool>> NotEqualExp<TValue>(string target, TValue value)
    {
        var (constant, param, evalue) = ExpressionFactory<TEntity>.GetPackage(value!, target);

        var nequal = Expression.NotEqual(evalue, constant);

        return Expression.Lambda<Func<TEntity, bool>>(nequal, param);
    }

    protected virtual Expression<Func<TEntity, bool>> NullableNotEqualExp<TValue>(string target, TValue? value)
    {
        var (constant, param, evalue) = ExpressionFactory<TEntity>.GetNullablePackage<TValue?>(value, target);

        var nequal = Expression.NotEqual(evalue, constant);

        return Expression.Lambda<Func<TEntity, bool>>(nequal, param);
    }

    private static Expression<Func<TEntity, bool>> AuxAndAlsoExp(Expression<Func<TEntity, bool>> expr1,
                                                                 Expression<Func<TEntity, bool>> expr2)
    {
        var parameter = Expression.Parameter(typeof(TEntity));

        var leftVisitor = new ReplaceExpressionVisitor(expr1.Parameters[0], parameter);
        var left        = leftVisitor.Visit(expr1.Body);

        var rightVisitor = new ReplaceExpressionVisitor(expr2.Parameters[0], parameter);
        var right        = rightVisitor.Visit(expr2.Body);

        return Expression.Lambda<Func<TEntity, bool>>(
            Expression.AndAlso(left, right), parameter);
    }

    protected virtual Expression<Func<TEntity, bool>> AndAlsoExp<TxValue, TyValue>(
        string xtarget, TxValue xvalue, string ytarget, TyValue yvalue)
    {
        var (xconstant, xparam, xevalue) = ExpressionFactory<TEntity>.GetPackage(xvalue!, xtarget);
        var xequal = Expression.Equal(xevalue, xconstant);
        var xexp   = Expression.Lambda<Func<TEntity, bool>>(xequal, xparam);

        var (yconstant, yparam, yevalue) = ExpressionFactory<TEntity>.GetPackage(yvalue!, ytarget);
        var yequal = Expression.Equal(yevalue, yconstant);
        var yexp   = Expression.Lambda<Func<TEntity, bool>>(yequal, yparam);

        return AuxAndAlsoExp(xexp, yexp);
    }
}