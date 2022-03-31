using System.Linq.Expressions;
using CalistoDbCore.Expressions.BuildingOptions.OptionsModels;

namespace CalistoDbCore.Expressions.Extensions;

public static class BuilderExtensions
{
    public static bool IsValid<T>(this BuilderOption<T> option) 
        => option is not null && option.Value is not null && option.Name is not null;

    public static IQueryable<TEntity> WithExpressions<TEntity>(this IQueryable<TEntity> query, params Expression[] expressions)
    {
        const string where = "Where";

        Type caller = typeof(Queryable);
        Type[] entities = { typeof(TEntity) };

        Expression root = query.Expression;

        MethodCallExpression callTree = Expression.Call
            (caller, where, entities, root, expressions![0]!);

        for (int i = 1; i < expressions.Length; i++)
            callTree = Expression.Call(caller, where,
                entities, callTree, expressions[i]!);

        return query.Provider.CreateQuery<TEntity>(callTree);
    }
    /*public static IQueryable<TEntity> UsginExppressions<TEntity>(this IQueryable<TEntity> query, params Expression[] expressions)
    {
        const string where = "Where";

        Type caller = typeof(Queryable);
        Type[] entities = { typeof(TEntity) };

        Expression root = query.Expression;

        MethodCallExpression callTree = Expression.Call
            (caller, where, entities, root, expressions[0]);

        for (int i = 1; i < expressions.Length; i++)
            callTree = Expression.Call(caller, where,
                entities, callTree, expressions[i]);

        return query.Provider.CreateQuery<TEntity>(callTree);
    }*/
}




