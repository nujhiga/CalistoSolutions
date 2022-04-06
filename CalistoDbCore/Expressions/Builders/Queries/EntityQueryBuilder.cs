using System.Linq.Expressions;

using CalistoDbCore.Expressions.BuildingOptions;
using CalistoDbCore.Expressions.Enumerations;
using CalistoDbCore.Expressions.Extensions;
using CalistoDbCore.U3FEntities;

using CalistoStandars.Definitions.Interfaces.DbCore.Entities;

using Microsoft.EntityFrameworkCore;

namespace CalistoDbCore.Expressions.Builders;





/*

internal sealed class EntityQueryBuilder2<TEntity> : UsingsExpressionBuilder<TEntity> where TEntity : class
{
    internal EntityQueryBuilder2(in BuilderOptions options) : base(options) { }

    internal IQueryable<TEntity> GetQuery(IQueryable<TEntity> query)
    {
        Expression[] expressions = GetExpressionsOptions
        (
            OptionType.Name, OptionType.Document
        ).ToArray()!;

        return expressions.Length == 0 ?
            null! : query.WithExpressions(expressions)!;

    }

    internal IQueryable<TEntity> GetQuery(IQueryable<TEntity> query) 
    {
        Expression[] expressions = GetExpressionsOptions
        (
            OptionType.Period, OptionType.Regular,
            OptionType.ConvCod, OptionType.Career
        ).ToArray()!;
       
        return expressions.Length == 0 ? 
            null! : query.WithExpressions(expressions)!;

    }
}
*/
/*
internal sealed class EntityQueryBuilder<TEntity> : ExpressionBuilder<TEntity> where TEntity : class
{
    internal EntityQueryBuilder(BuilderOptions options) : base(options) { }

    internal IQueryable<VisAlu> GetSyncCareerQuery(IQueryable<VisAlu> query)
    {
        Expression[] expressions = GetExpressionsOptions(OptionType.Period,
            OptionType.Regular, OptionType.ConvCod, OptionType.Career).ToArray()!;

        return expressions.Length == 0 ? null : query.WithExpressions(expressions)!;
    }
}
*/



