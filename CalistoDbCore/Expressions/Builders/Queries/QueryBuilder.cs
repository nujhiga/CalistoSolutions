using System.Data;

using CalistoDbCore.Services.Repositories;
using CalistoDbCore.U3FEntities;

using CalistoStandards.Definitions.Interfaces.DbCore.Entities;

using Microsoft.EntityFrameworkCore;

namespace CalistoDbCore.Expressions.Builders;

internal interface IQueryBuilder<out TContext> where TContext : DbContext
{
    CancellationToken CancellToken { get; }
    TContext Context { get; }
    ConnectionState DbState { get; }
    bool DbCanConnect { get; }
    bool DbWorking { get; }
    bool IsParameter { get; }
    void SetParameter(ClDbParameter parameter);
    void SetParameter(DbRequestSign sign, params object[] values);
    void SetParameter(params object[] values);
    void SetCommandTimeOut(TimeSpan timeOut);
    void SetCommandTimeOut(int timeOut);
}

internal abstract class QueryBuilderBase<TEntity, TContext> : ExpressionBuilder<TEntity>, IQueryBuilder<TContext>, IDisposable
    where TEntity : class, IEntity where TContext : DbContext
{
    private bool _disposed;

    public CancellationToken CancellToken { get; }
    public TContext Context { get; }
    public ConnectionState DbState => Context.Database.GetDbConnection().State;
    public bool DbCanConnect => Context.Database.CanConnect();

    public bool DbWorking =>
        DbState is ConnectionState.Connecting or ConnectionState.Executing or ConnectionState.Fetching;

    public bool IsParameter => Parameter is not null;

    protected Expression<Func<TEntity, TEntity>> Selector { get; set; }

    protected QueryBuilderBase(TContext context, CancellationToken cancellToken = default)
    {
        Context = context;
        CancellToken = cancellToken;
    }

    protected QueryBuilderBase(TContext context, ClDbParameter parameter, CancellationToken cancellToken = default)
    {
        Context = context;
        Parameter = parameter;
        CancellToken = cancellToken;
    }

    internal abstract IQueryable<TEntity> GetQuery(ClDbParameter parameter);

    protected static Expression<Func<TEntity, TEntity>> BuildSelector(params EntityMemberSign[] memberSigns) =>
        memberSigns.AsSelectExpression<TEntity>();

    protected virtual IQueryable<TEntity> BuildQuery(IQueryable<TEntity> query,
                                                     params EntityMemberSign[] selectionSigns)
    {
        Expression[] expressions = GetParameterAsExpressions();

        if (selectionSigns.Length == 0)

            Selector = BuildSelector(selectionSigns);

        query = query.WhereExpressions(expressions).Select(Selector).AsNoTracking();

        return query;
    }

    public void SetParameter(ClDbParameter parameter) => Parameter = parameter;

    public void SetParameter(DbRequestSign sign, params object[] values)
    {
        Parameter = Parameter.New(sign);

        SetParameter(values);
    }

    public void SetParameter(params object[] values)
    {
        if (Parameter is null) return;

        foreach (object value in values)
            Parameter = Parameter.With(value);
    }

    public virtual Expression[] GetParameterAsExpressions() => GetExpressions().Where(e => e is not null).ToArray();
    public void SetCommandTimeOut(TimeSpan timeOut) => Context.Database.SetCommandTimeout(timeOut);
    public void SetCommandTimeOut(int timeOut) => Context.Database.SetCommandTimeout(timeOut);

    #region IDisposable Pattern

    private void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                if (Context.Database.GetDbConnection().State is not ConnectionState.Closed)
                    Context.Database.GetDbConnection().Close();
            }

            Context.Dispose();
            _disposed = true;
        }
    }

    ~QueryBuilderBase()
    {
        Dispose(disposing: false);
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    #endregion
}

internal sealed class MrQueryBuilder<TEntity> : QueryBuilderBase<TEntity, U3FContext> where TEntity : class, IEntity
{
    public MrQueryBuilder() : base(new U3FContext())
    {
    }

    internal override IQueryable<TEntity> GetQuery(ClDbParameter parameter)
    {
        SetParameter(parameter);

        IQueryable<TEntity> query = parameter.RequestSign switch
        {
            DbRequestSign.GetNominals => GetNominalQuery(),


            _ => null!
        };

        return query;
    }

    private IQueryable<TEntity> GetNominalQuery()
    {
        IQueryable<TEntity> query = BuildQuery(Context.Set<TEntity>(),
            EntityMemberSignFactory.GetCompleteNominal);

        return query;
    }
}