using System.Collections.Concurrent;
using System.Data;
using System.Data.Common;
using CalistoStandards.Definitions.Interfaces.DbCore.Entities;
using CalistoStandards.Definitions.Models.CacheHandling;
using CalistoStandards.Definitions.Structures.Cls;
using Microsoft.EntityFrameworkCore;

namespace CalistoDbCore.Services.Repositories;

public static class DbRequestParameterExtensions
{
    //public static ClDbParameter<TSign> With<TSign>(this ClDbParameter<TSign> param, TSign value) where TSign : Enum
    //{
    //    param.RequestSign = value;
    //    return param;
    //}

    public static ClDbParameter New(this ClDbParameter param, DbRequestSign value)
    {
        param = new ClDbParameter(value);

        return param;
    }


    public static ClDbParameter With(this ClDbParameter param, object value)
    {
        if (value is null) return param;

        if (value is DbRegularity regularity)
        {
            Handler.HandleRegularity(ref param, regularity);
        }
        else if (value is ClCampus campus)
        {
        }
        else if (value is int academic)
        {
        }
        else if (value is int?[] academics)
        {
        }
        else if (value is double[] users)
        {
        }
        else if (value is Period[] periods)
        {
        }

        //if (type == typeof(DbRegularity))
        //{
        //    Handler.HandleRegularity(ref param, value);
        //    //if (param.Regularity is null)
        //    //    param.Regularity = Provider.GetNewParamMember<DbRegularity>(value);
        //}
        //else if (type == typeof(ClCampus))
        //{
        //    param.Campus = value as DbParamMember<ClCampus>;
        //}
        //else if (type == typeof(int?[]))
        //{
        //    param.AcademicsIDs = value as DbParamMember<int?[]>;
        //}
        //else if (type == typeof(double[]))
        //{
        //    param.UsersIDs = value as DbParamMember<double[]>;
        //}
        //else if (type == typeof(Period[]))
        //{
        //    param.Periods = value as DbParamMember<Period[]>;
        //}

        return param;
    }

    private static class Handler
    {
        internal static void HandleStrategy(ref ClDbParameter parameter, in object value)
        {
        }


        internal static void HandleRegularity(ref ClDbParameter parameter, DbRegularity regularity)
        {
            if (!parameter.UsingRegularity)
                parameter.Regularity = new DbParamMember<DbRegularity>(regularity);
            else
            {
                parameter.Regularity!.Value = regularity;
            }
        }
    }
}

public sealed class DbRepository : ConcurrentDictionary<DbRequestSign, IEnumerable<IEntity>>
{
    public bool              Working      { get; private set; }
    public CancellationToken Cancellation { get; }

    private readonly CacheHandler<DbRequestSign> _cacheControl;

    public DbRepository(CampusTarget campus, Period[] periods)
    {
        Cancellation  = new CancellationToken();
        _cacheControl = new CacheHandler<DbRequestSign>(CleanCacheRequest);
    }


    private void CleanCacheRequest(DbRequestSign rtype)
    {
        //TryRemove(rtype, out IEnumerable<TEntity> entities);
        //entities = Enumerable.Empty<TEntity>();
    }

    public async Task<bool> ExecuteRequestAsync<TEntity>(DbRequestSign    dataRequestType,
                                                         ExecutionOptions executionOptions, bool disposeParams = true)
        where TEntity : class, IEntity
    {
        if (Working) return false;

        Working = true;

        using MrQueryBuilder<TEntity> builder = new MrQueryBuilder<TEntity>();

        ClDbParameter parameter = new ClDbParameter(dataRequestType);
        parameter = parameter.With(ClCampus.U3F).With(new Period[] {new(20221)});

        IQueryable<TEntity> query = builder.GetQuery(parameter);


        {
        }

        //QueryBuilder<VisAlu> mm = new QueryBuilder<VisAlu>();

        //using U3FContext ctx = new();

        //var x = await mm.GetSyncQuery( ctx);
        {
        }

        //  var qry = x.ToQueryString();

        // var xx = mm.GetNominalEntities();

        {
        }
        //await using U3FContext ctx = new();

        //    INominalEntity person = new NominalEntity();
        {
        }
        //  RequestParam = RequestParam.With<IEntity>(person).With<DbRegularity>(DbRegularity.Regular).With<EntityMemberSign[]>(new[] { EntityMemberSign.Nombres, EntityMemberSign.Documento });

        {
        }
        //   var res = DbRequestFactory.GetEntities2(in ctx, RequestParam);
        //IQueryable<IEntity> requestingEntities = _dbRequestFactory.
        //    GetRequest(in ctx, in dataRequestType, in selectionDepth);
        {
        }
        // if (requestingEntities is null) return false;

        // IEnumerable<IEntity> results = _dbRequestFactory.GetSyncCareerStudents2(in ctx, selectionDepth);
        //IEnumerable<TEntity> results = _dbRequestFactory.GetSyncCareerStudents2(in ctx, selectionDepth);


        //requestingEntities.ToListAsync(Cancellation);
        {
        }

        // if (executionOptions.CacheResults)
        //      SetCache(dataRequestType, in results, ref executionOptions);

        //  if (disposeParams) RequestParam.Dispose();

        Working = false;

        {
        }
        return false; //results.Any();
    }

    private async Task ForceCtxDispose(DbContext ctx)
    {
        DbConnection conn = ctx.Database.GetDbConnection();

        if (conn.State is not ConnectionState.Closed)
        {
            await conn.CloseAsync();

            await ctx.DisposeAsync();
        }
    }
    /*
    private void SetCache(in DataRequestSign dataRequestType, in IEnumerable<TEntity> entities, ref ExecutionOptions options)
    {
        TryAdd(dataRequestType, entities);

        if (options.CacheLifeTime is { } lifeTime)
            _cacheControl.AddStart(dataRequestType, lifeTime);
    }*/


    /*
    private async Task<IEnumerable<VisAlu>> RequestCareersStudentsSync()
    {
        await using U3FContext ctx = new U3FContext();

        using BuilderOptions options = BuilderOptionFactory.GetCareerStudentsSync(this);

        StudentsQueries query = new StudentsQueries(options);

        var students = await
            (from std in query.GetSyncCareerQuery(ctx.VisAlus)
             select new VisAlu
             {
                 Legajo = std.Legajo,
                 Usualu = std.Usualu,
                 Documento = std.Documento,
                 Nombres = std.Nombres,
                 Apellido = std.Apellido,
                 Mail = std.Mail,
                 SexoId = std.SexoId,
                 CarreraId = std.CarreraId,
                 PlanId = std.PlanId,
                 ConvCod = std.ConvCod,
                 Regular = std.Regular,
                 AnoIngreso = std.AnoIngreso,
                 CuatrIngreso = std.CuatrIngreso,
                 Curing = std.Curing
             }).ToListAsync(Cancellation);

        return students;
    }


    */


    /*

    public bool TryAddPeriod(string period)
    {
        if (UsingPeriods == null)
            UsingPeriods = new Periods(period);

        if (UsingPeriods.ContainsExp(period))
            return false;

        UsingPeriods.Add(period);

        return true;
    }
    public bool TryAddPeriod(short period)
    {
        if (UsingPeriods == null)
            UsingPeriods = new Periods(period);

        if (UsingPeriods.ContainsExp(period))
            return false;

        UsingPeriods.Add(period);

        return true;
    }
    public bool TryAddPeriod(Period period)
    {
        if (UsingPeriods == null)
            UsingPeriods = new Periods(period);

        if (UsingPeriods.ContainsExp(period))
            return false;

        UsingPeriods.Add(period);

        return true;
    }
    public void DisposePeriod() => UsingPeriods.Dispose();
    public bool TryAddCareer(int? career)
    {
        if (UsingCareers is null) UsingCareers = new();

        if (UsingCareers.ContainsExp(career)) return false;

        UsingCareers.Add(career);
        return true;
    }
    public void DisposeCareers() => UsingCareers.Dispose();
    public bool TryAddCommission(int commission)
    {
        if (UsingCommissions is null) UsingCommissions = new();

        if (UsingCommissions.ContainsExp(commission)) return false;

        UsingCommissions.Add(commission);
        return true;
    }
    public void DisposeCommissions() => UsingCommissions.Dispose();
    public bool TryAddUser(double user)
    {
        if (UsingUsers is null) UsingUsers = new();

        if (UsingUsers.ContainsExp(user)) return false;

        UsingUsers.Add(user);

        return true;
    }
    public void DisposeUsers() => UsingUsers.Dispose();
    public void DisposeParams(bool fullDispose = false)
    {
        if (UsingCareers is not null)
            UsingCareers.Dispose();

        if (UsingCommissions is not null)
            UsingCommissions.Dispose();

        if (UsingUsers is not null)
            UsingUsers.Dispose();

        if (fullDispose)
        {
            UsingCampus = null;

            if (UsingPeriods is not null)
                UsingPeriods.Dispose();
        }
    }
    */
}