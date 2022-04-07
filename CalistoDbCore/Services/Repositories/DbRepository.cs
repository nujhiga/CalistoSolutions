using System.Collections.Concurrent;
using System.Data;
using System.Data.Common;
using CalistoDbCore.Expressions.Builders;
using CalistoDbCore.Expressions.Enumerations;
using CalistoDbCore.U3FEntities;

using CalistoStandars.Definitions.Enumerations;
using CalistoStandars.Definitions.Interfaces.DbCore.Entities;
using CalistoStandars.Definitions.Models;
using CalistoStandars.Definitions.Structures;

using Microsoft.EntityFrameworkCore;

namespace CalistoDbCore.Services.Repositories;

public enum DbRequestSign
{
    None,
    GetPersons,
    GetNominals,
    GetStudents,
    GetTeachers,
    GetCareers,
    GetCareerPlans,
    GetAssignatures,
    GetCommissions,
    GetStudentsSync,
    GetSyncCareers,
    GetSyncCommissions,
    GetSyncExamns
}

public static class DbRequestParameterExtensions
{
    //public static DbRequestParameter<TSign> With<TSign>(this DbRequestParameter<TSign> requestParam, TSign value) where TSign : Enum
    //{
    //    requestParam.RequestSign = value;
    //    return requestParam;
    //}

    public static DbRequestParameter New(this DbRequestParameter requestParam, DbRequestSign value)
    {
        requestParam = new DbRequestParameter(value);

        return requestParam;
    }


    public static DbRequestParameter With(this DbRequestParameter requestParam, object value)
    {
        if (value is null) return requestParam;

        Type type = value.GetType();

        if (type == typeof(DbRegularity))
        {
            requestParam.Regularity = (DbRegularity)value;
            //return requestParam;
        }
        else if (type == typeof(ClCampus))
        {
            requestParam.Campus = (ClCampus)value;
            //return requestParam;
        }
        else if (type == typeof(int?[]))
        {
            requestParam.AcademicIDs = (int?[])value;
            //return requestParam;
        }
        else if (type == typeof(double[]))
        {
            requestParam.UsersIDs = (double[])value!;
            //return requestParam;
        }
        else if (type == typeof(Period[]))
        {
            requestParam.Periods = (Period[])value!;
            //return requestParam;
        }
        
        return requestParam;
    }
  
}

public sealed class DbRequestParameter : IDisposable
{
    public DbRequestSign RequestSign { get; set; }


    [DbParamAttr(typeof(ClCampus?))]
    public ClCampus? Campus { get; set; }
    public bool UseCampus => Campus is { };


    [DbParamAttr(typeof(DbRegularity?))]
    public DbRegularity? Regularity { get; set; }
    public bool UseRegularity => Regularity is { };
    

    [DbParamAttr(typeof(int?[]))]
    public int?[]? AcademicIDs { get; set; }
    public bool UseAcademicIDs => AcademicIDs is { Length: > 0 };


    [DbParamAttr(typeof(double[]))]
    public double[]? UsersIDs { get; set; }
    public bool UseUsersIDs => UsersIDs is { Length: > 0 };


    [DbParamAttr(typeof(Period[]))]
    public Period[]? Periods { get; set; }
    public bool UsePeriods => Periods is { Length: > 0 };
    
    public DbRequestParameter(in DbRequestSign sign) => RequestSign = sign;

    public void Dispose()
    {
        if (UseAcademicIDs)
            Array.Clear(AcademicIDs!, 0, AcademicIDs!.Length);

        if (UseUsersIDs)
            Array.Clear(UsersIDs!, 0, UsersIDs!.Length);

        if (UsePeriods)
            Array.Clear(Periods!, 0, Periods!.Length);
    }

    /*
    public DbRequestParameter(in TSign sign, in ClCampus fromCampus, Period[] onPeriods)
    {
        FromCampus = fromCampus;
        OnPeriods = onPeriods;
        RequestSign = sign;
    }

    public void Dispose()
    {

        if (WithAcademicID is { })
            Array.Clear(WithAcademicID, 0, WithAcademicID.Length);

        if (WithUsers is { })
            Array.Clear(WithUsers, 0, WithUsers.Length);

        if (OnPeriods is { })
            Array.Clear(OnPeriods, 0, OnPeriods.Length);

        if (SelectionSigns is { })
            Array.Clear(SelectionSigns, 0, SelectionSigns.Length);

    }*/

}

public sealed class DbRepository : ConcurrentDictionary<DbRequestSign, IEnumerable<IEntity>>
{
    public bool Working { get; private set; }
    public CancellationToken Cancellation { get; }

    private readonly CacheHandler<DbRequestSign> _cacheControl;

    // public DbRequestParameter<DbRequestSign> RequestParam { get; set; }

    public DbRepository(CampusTarget campus, Period[] periods)
    {
        Cancellation = new CancellationToken();
        _cacheControl = new CacheHandler<DbRequestSign>(CleanCacheRequest);

        // RequestParam = new DbRequestParameter<DbRequestSign>(DbRequestSign.GetSyncCareers, campus.Source, ref periods);

    }



    private void CleanCacheRequest(DbRequestSign rtype)
    {
        //TryRemove(rtype, out IEnumerable<TEntity> entities);
        //entities = Enumerable.Empty<TEntity>();
    }

    public async Task<bool> ExecuteRequestAsync<TEntity>(DbRequestSign dataRequestType, SelectionDepth selectionDepth,
         ExecutionOptions executionOptions, bool disposeParams = true) 
    where TEntity : class, IEntity
    {
        if (Working) return false;

        Working = true;

        using MrQueryBuilder<TEntity> builder = new MrQueryBuilder<TEntity>();

        DbRequestParameter parameter = new DbRequestParameter(dataRequestType);
        parameter = parameter.With(ClCampus.U3F).With(new Period[]{new(20221)});

        IQueryable<TEntity> query = builder.GetQuery(parameter);


        {}

        //QueryBuilder<VisAlu> mm = new QueryBuilder<VisAlu>();

        //using U3FContext ctx = new();

        //var x = await mm.GetSyncQuery( ctx);
        {}

      //  var qry = x.ToQueryString();

        // var xx = mm.GetNominalEntities();

        { }
        //await using U3FContext ctx = new();

        //    INominalEntity person = new NominalEntity();
        { }
        //  RequestParam = RequestParam.With<IEntity>(person).With<DbRegularity>(DbRegularity.Regular).With<EntityMemberSign[]>(new[] { EntityMemberSign.Nombres, EntityMemberSign.Documento });

        { }
        //   var res = DbRequestFactory.GetEntities2(in ctx, RequestParam);
        //IQueryable<IEntity> requestingEntities = _dbRequestFactory.
        //    GetRequest(in ctx, in dataRequestType, in selectionDepth);
        { }
        // if (requestingEntities is null) return false;

        // IEnumerable<IEntity> results = _dbRequestFactory.GetSyncCareerStudents2(in ctx, selectionDepth);
        //IEnumerable<TEntity> results = _dbRequestFactory.GetSyncCareerStudents2(in ctx, selectionDepth);


        //requestingEntities.ToListAsync(Cancellation);
        { }

        // if (executionOptions.CacheResults)
        //      SetCache(dataRequestType, in results, ref executionOptions);

        //  if (disposeParams) RequestParam.Dispose();

        Working = false;

        { }
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

        if (UsingPeriods.Contains(period))
            return false;

        UsingPeriods.Add(period);

        return true;
    }
    public bool TryAddPeriod(short period)
    {
        if (UsingPeriods == null)
            UsingPeriods = new Periods(period);

        if (UsingPeriods.Contains(period))
            return false;

        UsingPeriods.Add(period);

        return true;
    }
    public bool TryAddPeriod(Period period)
    {
        if (UsingPeriods == null)
            UsingPeriods = new Periods(period);

        if (UsingPeriods.Contains(period))
            return false;

        UsingPeriods.Add(period);

        return true;
    }
    public void DisposePeriod() => UsingPeriods.Dispose();
    public bool TryAddCareer(int? career)
    {
        if (UsingCareers is null) UsingCareers = new();

        if (UsingCareers.Contains(career)) return false;

        UsingCareers.Add(career);
        return true;
    }
    public void DisposeCareers() => UsingCareers.Dispose();
    public bool TryAddCommission(int commission)
    {
        if (UsingCommissions is null) UsingCommissions = new();

        if (UsingCommissions.Contains(commission)) return false;

        UsingCommissions.Add(commission);
        return true;
    }
    public void DisposeCommissions() => UsingCommissions.Dispose();
    public bool TryAddUser(double user)
    {
        if (UsingUsers is null) UsingUsers = new();

        if (UsingUsers.Contains(user)) return false;

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
