using System.Linq.Expressions;
using System.Reflection;
using CalistoStandars.Definitions.Interfaces.DbCore.Entities;

namespace CalistoDbCore.Expressions.Builders;

public abstract class BinaryExpressionBuilder<TEntity> where TEntity : class, IEntity //: BaseExpressionBuilder<TEntity> where TEntity : class
{






    protected virtual Expression<Func<TEntity, bool>> Contains<TValue>(string target, params TValue[] values)
    {
        MethodInfo method = ExpressionFactory<TEntity>.GetContainsMethod<TValue>()!;
        { }
        var (constant, param, value) = ExpressionFactory<TEntity>.GetPackage(values, target);
        { }
        var expBody = Expression.Call(constant, method, value);
        { }
        return Expression.Lambda<Func<TEntity, bool>>(expBody, param);
    }
    /*
    protected virtual Expression<Func<TEntity, bool>> NullableContains<TValue>(string target, params TValue[] values)
    {
        MethodInfo method = ExpressionFactory<TEntity>.GetNullableContainsMethod<TValue>()!;
        { }
        var (constant, param, value) = ExpressionFactory<TEntity>.GetNullablePackage<TValue>(values, target);
        { }
        var expBody = Expression.Call(constant, method!, value);
        { }
        return Expression.Lambda<Func<TEntity, bool>>(expBody, param);
    }*/

    protected virtual Expression<Func<TEntity, bool>> Equal<TValue>(string target, TValue value)
    {
        var (constant, param, evalue) = ExpressionFactory<TEntity>.GetPackage(value!, target);

        var equal = Expression.Equal(evalue, constant);

        return Expression.Lambda<Func<TEntity, bool>>(equal, param);
    }
    protected virtual Expression<Func<TEntity, bool>> NullableEqual<TValue>(string target, TValue? value)
    {
        var (constant, param, evalue) = ExpressionFactory<TEntity>.GetNullablePackage<TValue?>(value, target);
        { }
        var equal = Expression.Equal(evalue, constant);

        return Expression.Lambda<Func<TEntity, bool>>(equal, param);
    }

    protected virtual Expression<Func<TEntity, bool>> NotEqual<TValue>(string target, TValue value)
    {
        var (constant, param, evalue) = ExpressionFactory<TEntity>.GetPackage(value!, target);

        var nequal = Expression.NotEqual(evalue, constant);

        return Expression.Lambda<Func<TEntity, bool>>(nequal, param);
    }

    protected virtual Expression<Func<TEntity, bool>> NullableNotEqual<TValue>(string target, TValue? value)
    {
        var (constant, param, evalue) = ExpressionFactory<TEntity>.GetNullablePackage<TValue?>(value, target);
        { }
        var nequal = Expression.NotEqual(evalue, constant);
        { }
        return Expression.Lambda<Func<TEntity, bool>>(nequal, param);
    }

    /*
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
    */

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

    protected virtual Expression<Func<TEntity, bool>> And<TxValue, TyValue>
        (string xtarget, TxValue xvalue, string ytarget, TyValue yvalue)
    {
        var (xconstant, xparam, xevalue) = ExpressionFactory<TEntity>.GetPackage(xvalue!, xtarget);
        var xequal = Expression.Equal(xevalue, xconstant);
        var xexp = Expression.Lambda<Func<TEntity, bool>>(xequal, xparam);

        var (yconstant, yparam, yevalue) = ExpressionFactory<TEntity>.GetPackage(yvalue!, ytarget);
        var yequal = Expression.Equal(yevalue, yconstant);
        var yexp = Expression.Lambda<Func<TEntity, bool>>(yequal, yparam);

        return AndAlso(xexp, yexp);
    }


    /*
    protected virtual Expression<Func<TEntity, bool>> AndAlso<TValue>(string target, TValue value, params Expression[] alsoBinaries)
    {
        var (constant, param, evalue) = ExpressionFactory<TEntity>.GetPackage(value!, target);
        var equalSource = Expression.Equal(evalue, constant);

        var alsoSource = alsoBinaries[0];
        BinaryExpression andAlso = Expression.AndAlso(equalSource, alsoSource);

        for (int i = 1; i < alsoBinaries.Length; i++)
            andAlso = Expression.AndAlso(andAlso, alsoBinaries[i]);

        return Expression.Lambda<Func<TEntity, bool>>(andAlso, param);
    }

    */

    /*
    protected virtual Expression<Func<TEntity, bool>> NullableAndAlso<TValue>(string target, TValue? value, params Expression[] alsoBinaries)
    {
        var (constant, param, evalue) = ExpressionFactory<TEntity>.GetPackage(value!, target);
        var equalSource = Expression.Equal(evalue, constant);

        var alsoSource = alsoBinaries[0];
        BinaryExpression andAlso = Expression.AndAlso(equalSource, alsoSource);

        for (int i = 1; i < alsoBinaries.Length; i++)
            andAlso = Expression.AndAlso(andAlso, alsoBinaries[i]);

        return Expression.Lambda<Func<TEntity, bool>>(andAlso, param);
    }*/
}

