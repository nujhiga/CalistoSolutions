using System.Linq.Expressions;

using CalistoDbCore.Expressions.BuildingOptions;
using CalistoDbCore.Expressions.Enumerations;
using CalistoDbCore.Expressions.Extensions;
using CalistoDbCore.U3FEntities;

using CalistoStandars.Definitions.Interfaces.DbCore.Entities;

using Microsoft.EntityFrameworkCore;

namespace CalistoDbCore.Expressions.Builders;



public sealed class StudentsQueries<TEntity> : QueryExpressionsBuilder<TEntity> where TEntity : class, IStudentEntity
{
    public StudentsQueries(BuilderOptions options) : base(options) { }

    public IQueryable<TEntity>? GetSyncCareerQuery(IQueryable<TEntity> query)
    {
        Expression[] expressions = GetExpressionsOptions(OptionType.Period, 
            OptionType.Regular, OptionType.ConvCod, OptionType.Career).ToArray()!;

        return expressions.Length == 0 ? null :
            query.WithExpressions(expressions).AsNoTracking();
    }
}




