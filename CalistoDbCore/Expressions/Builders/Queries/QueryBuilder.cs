using System.Data;
using System.Reflection.Metadata;

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
    ClParameter Parameter { get; set; }
    void SetParameter(ClParameter parameter);
    void SetParameter(DbRequestSign sign, params object[] values);
    void SetParameter(params object[] values);
    void SetCommandTimeOut(TimeSpan timeOut);
    void SetCommandTimeOut(int timeOut);

}

internal abstract class QueryBuilderBase<TEntity, TContext> : IQueryBuilder<TContext>, IDisposable
    where TEntity : class, IEntity where TContext : DbContext
{
    private bool _disposed;

    public CancellationToken CancellToken { get; }
    public TContext Context { get; }
    public ConnectionState DbState => Context.Database.GetDbConnection().State;
    public bool DbCanConnect => Context.Database.CanConnect();
    public bool DbWorking => DbState is ConnectionState.Connecting or ConnectionState.Executing or ConnectionState.Fetching;
    
    public ClParameter Parameter { get; set; }

    protected Expression<Func<TEntity, TEntity>> Selector { get; set; }

    protected QueryBuilderBase(TContext context, CancellationToken cancellToken = default)
    {
        Context = context;
        CancellToken = cancellToken;
    }

    protected QueryBuilderBase(TContext context, ClParameter parameter, CancellationToken cancellToken = default)
    {
        Context = context;
        Parameter = parameter;
        CancellToken = cancellToken;
    }

    internal abstract IQueryable<TEntity> GetQuery(ClParameter parameter);

    protected virtual IQueryable<TEntity> BuildQuery(IQueryable<TEntity> query)
    {
        Expression[] expressions = Parameter.ToExpressions<TEntity>();
  
        Selector = Parameter.ToSelectExpression<TEntity>();
        
        return query.WhereExpressions(expressions).Select(Selector).AsNoTracking(); 
    }

    public void SetParameter(ClParameter parameter) => Parameter = parameter;

    public void SetParameter(DbRequestSign sign, params object[] values)
    {
        SetParameter(values);
    }

    public void SetParameter(params object[] values)
    {
    }



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

    internal override IQueryable<TEntity> GetQuery(ClParameter parameterr)
    {
        SetParameter(parameterr);
        { }
        IQueryable<TEntity> query = parameterr.RequestSign switch
        {
            DbRequestSign.GetNominals => GetNominalQuery(),
            DbRequestSign.GetSyncCareers => GetSyncCareerQuery(),

            _ => null!
        };

        return query;
    }
    private IQueryable<TEntity> GetSyncCareerQuery()
    {
        IQueryable<TEntity> query = BuildQuery(Context.Set<TEntity>());

        return query;
    }
    private IQueryable<TEntity> GetNominalQuery()
    {
        IQueryable<TEntity> query = BuildQuery(Context.Set<TEntity>());

        return query;
    }
}