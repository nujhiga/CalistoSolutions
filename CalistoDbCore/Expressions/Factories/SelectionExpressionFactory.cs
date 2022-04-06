using System.Linq.Expressions;
using System.Reflection;

using CalistoDbCore.Expressions.Extensions;

using CalistoStandars.Definitions.Interfaces.DbCore.Entities;

namespace CalistoDbCore.Expressions.Builders;

internal static class SelectionExpressionFactory
{
    internal static Func<TEntity, TEntity> GetSelector<TEntity>(Selector parameters) where  TEntity : IEntity
    {
        if (parameters is not { Count: > 0 }) return null!;

        IEnumerable<(string pName, Type pType, object pValue)> propsStruct = parameters.GetPropertiesStruct();
        {}
        if (propsStruct is not {}) return null!;

        ParameterExpression xParam = Expression.Parameter(typeof(TEntity), "p");
        NewExpression xNew = Expression.New(typeof(TEntity));

        IEnumerable<MemberAssignment> bindings = propsStruct.Select(p =>
        {
            PropertyInfo prop = parameters[p.pName];

            MemberExpression xOrgVal = Expression.Property(xParam, prop);

            return Expression.Bind(prop, xOrgVal);
        });
        {}
        MemberInitExpression xInit = Expression.MemberInit(xNew, bindings);
        Expression<Func<TEntity, TEntity>> xLambda = Expression.Lambda<Func<TEntity, TEntity>>(xInit, xParam);

        return xLambda.Compile();
    }
}
