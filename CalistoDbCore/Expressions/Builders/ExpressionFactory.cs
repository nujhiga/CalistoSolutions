using System.Reflection;

using CalistoDbCore.Expressions.Factories;
using CalistoDbCore.Expressions.Factories.Helpers;
using CalistoDbCore.Services.Repositories;
using CalistoDbCore.U3FEntities;

using CalistoStandards.Definitions.Interfaces.DbCore.Entities;
using CalistoStandards.Definitions.Structures.Cls;

using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Internal;

namespace CalistoDbCore.Expressions.Builders;

internal static class ExpressionFactory
{
    private const string PMarker = "p";

    internal static MethodInfo? GetContainsMethod<TValue>() => typeof(ICollection<TValue>).GetMethod(nameof(Enumerable.Contains), new[] { typeof(TValue?) });

    internal static Expression<Func<TEntity, bool>> GetEqualityEx<TEntity, TValue>(string targetName, ExpressionType xType, TValue sourceObj, bool nullableSource = false)
    {
        { }
        //ConstantExpression constEx = nullableSource
        //    ? Expression.Constant(sourceObj)
        //    : Expression.Constant(sourceObj, typeof(TValue?));
        
        ConstantExpression constEx = !nullableSource
            ? Expression.Constant(sourceObj)
            : Expression.Constant(sourceObj, typeof(TValue?));

        { }

        ParameterExpression paramEx = Expression.Parameter(typeof(TEntity), PMarker);
        { }
        MemberExpression memberEx = Expression.PropertyOrField(paramEx, targetName);
        { }
        BinaryExpression equality = xType == ExpressionType.Equal
            ? Expression.Equal(memberEx, constEx)
            : Expression.NotEqual(memberEx, constEx);
        { }
        return Expression.Lambda<Func<TEntity, bool>>(equality, paramEx);
    }



    internal static Expression<Func<TEntity, bool>> GetContainsEx<TEntity, TValue>(string targetName, bool nullableSource, TValue[] values)
    {
        { }
        MethodInfo method = GetContainsMethod<TValue>()!;

        nullableSource = false;

        ConstantExpression constEx;
        if (nullableSource)
        {
            {}
            constEx = Expression.Constant(values, typeof(TValue?));
            {}
        }
        else
        {
            {}
            constEx = Expression.Constant(values);
            {}
        }

        //ConstantExpression constEx = !nullableSource
        //    ? Expression.Constant(values)
        //    : Expression.Constant(values, typeof(TValue?));

        { }

        ParameterExpression paramEx = Expression.Parameter(typeof(TEntity), PMarker);
        { }
        MemberExpression memberEx = Expression.PropertyOrField(paramEx, targetName);
        { }
        MethodCallExpression methodCallEx = Expression.Call(constEx, method, memberEx);
        { }
        return Expression.Lambda<Func<TEntity, bool>>(methodCallEx, paramEx);
    }

    internal static Expression<Func<TEntity, TEntity>> GetSelectEx<TEntity>(EntityMemberSign[] selectSigns)
    {
        var type = typeof(TEntity);

        ParameterExpression paramEx = Expression.Parameter(typeof(TEntity), PMarker);

        NewExpression xNew = Expression.New(type);

        var bindings = selectSigns.Select(sgName =>
        {
            PropertyInfo pinfo = type.GetProperty(sgName.AsString())!;

            MemberExpression xMember = Expression.Property(paramEx, pinfo);

            return Expression.Bind(pinfo, xMember);
        });

        MemberInitExpression xInit = Expression.MemberInit(xNew, bindings);

        Expression<Func<TEntity, TEntity>> expression =
            Expression.Lambda<Func<TEntity, TEntity>>(xInit, paramEx);

        return expression;
    }

    internal static Expression<Func<TEntity, bool>> GetAndAlsoVisitorsEx<TEntity>(Expression<Func<TEntity, bool>> expr1,
        Expression<Func<TEntity, bool>> expr2)
    {
    
        var parameter = Expression.Parameter(typeof(TEntity));

        var leftVisitor = new ReplaceExpressionVisitor(expr1.Parameters[0], parameter);
        var left = leftVisitor.Visit(expr1.Body);

        var rightVisitor = new ReplaceExpressionVisitor(expr2.Parameters[0], parameter);
        var right = rightVisitor.Visit(expr2.Body);

        return Expression.Lambda<Func<TEntity, bool>>(
            Expression.AndAlso(left, right), parameter);
    }



    internal static Expression<Func<TEntity, bool>> GetAndAlsoEx<TEntity, TxValue, TyValue>(
        string xtarget, TxValue xvalue, string ytarget, TyValue yvalue, bool xnullableSource = false, bool ynullableSource = false)
    {
        { }
        ConstantExpression xconstEx = !xnullableSource
            ? Expression.Constant(xvalue)
            : Expression.Constant(xvalue, typeof(TxValue?));
        { }

        ParameterExpression xparamEx = Expression.Parameter(typeof(TEntity), PMarker);
        { }
        MemberExpression xmemberEx = Expression.PropertyOrField(xparamEx, xtarget);
        { }
        var xequal = Expression.Equal(xmemberEx, xconstEx);
        var xexp = Expression.Lambda<Func<TEntity, bool>>(xequal, xparamEx);
        { }

        ConstantExpression yconstEx = !ynullableSource
            ? Expression.Constant(yvalue)
            : Expression.Constant(yvalue, typeof(TyValue?));

        ParameterExpression yparamEx = Expression.Parameter(typeof(TEntity), PMarker);
        MemberExpression ymemberEx = Expression.PropertyOrField(yparamEx, ytarget);

        var yequal = Expression.Equal(ymemberEx, yconstEx);
        var yexp = Expression.Lambda<Func<TEntity, bool>>(yequal, yparamEx);

        return GetAndAlsoVisitorsEx(xexp, yexp);
    }
}









