using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CalistoDbCore.Expressions.Builders;
using CalistoDbCore.Expressions.BuildingOptions.Factory;
using CalistoDbCore.Expressions.BuildingOptions;
using CalistoDbCore.Expressions.Enumerations;
using CalistoDbCore.Services.Factories;
using CalistoDbCore.U3FEntities;
using CalistoStandars.Definitions.Interfaces.DbCore.Entities;
using CalistoStandars.Definitions.Models;
using CalistoStandars.Definitions.Structures;
using Microsoft.EntityFrameworkCore;

namespace CalistoDbCore.Services.Repositories;

public enum RequestAction
{
    None,
    SyncCareerStudents,

}



public sealed class DbRepository : ConcurrentDictionary<RequestAction, IEnumerable<IEntity>>
{
    public CampusTarget? UsingCampus { get; set; }
    public Period[] UsingPeriods { get; set; }
    public int?[] UsingCareers { get; set; }
    public int?[] UsingCommissions { get; set; }
    public double[] UsingUsers { get; set; }
    public DbRegularity UsingRegularity { get; set; }

    public bool Working { get; private set; }
    public CancellationToken Cancellation { get; }

    private readonly CacheHandler<RequestAction> _cacheControl;

    private readonly DbRequestFactory _dbRequestFactory;

    //public IEnumerable<IEntity> LastResults { get; private set; }
    //public void DisposeLastResults() => LastResults = Enumerable.Empty<IEntity>();

    public DbRepository(CampusTarget campus, Period[] periodses)
    {
        UsingCampus = campus;
        UsingPeriods = periodses;

        UsingCareers = null!;
        UsingCommissions = null!;
        UsingUsers = null!;

        Cancellation = new CancellationToken();

        _cacheControl = new CacheHandler<RequestAction>(CleanCacheRequest);
        _dbRequestFactory = new DbRequestFactory(this);
    }


    private void CleanCacheRequest(RequestAction rtype)
    {
        TryRemove(rtype, out IEnumerable<IEntity> entities);
        entities = Enumerable.Empty<IEntity>();
    }

    public async Task<bool> ExecuteRequestAsync(RequestAction requestType, SelectionDepth selectionDepth,
         ExecutionOptions executionOptions, bool disposeParams = true)
    {
        if (Working) return false;

        Working = true;

        await using U3FContext ctx = new();

        //IQueryable<IEntity> requestingEntities = _dbRequestFactory.
        //    GetRequest(in ctx, in requestType, in selectionDepth);
        {}
       // if (requestingEntities is null) return false;

      // IEnumerable<IEntity> results = _dbRequestFactory.GetSyncCareerStudents2(in ctx, selectionDepth);
       IEnumerable<object> results = _dbRequestFactory.GetSyncCareerStudents2(in ctx, selectionDepth);


        //requestingEntities.ToListAsync(Cancellation);
        { }
      
       // if (executionOptions.CacheResults)
      //      SetCache(requestType, in results, ref executionOptions);

        if (disposeParams) DisposeParams();

        Working = false;

        {}
        return results.Any();
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

    private void SetCache(in RequestAction requestType, in IEnumerable<IEntity> entities, ref ExecutionOptions options)
    {
        TryAdd(requestType, entities);

        if (options.CacheLifeTime is { } lifeTime)
            _cacheControl.AddStart(requestType, lifeTime);
    }

    private void DisposeParams()
    {
        if (UsingPeriods is { })
            Array.Clear(UsingPeriods, 0, UsingPeriods.Length);

        if (UsingCareers is { })
            Array.Clear(UsingCareers, 0, UsingCareers.Length);

        if (UsingCommissions is { })
            Array.Clear(UsingCommissions, 0, UsingCommissions.Length);

        if (UsingUsers is { })
            Array.Clear(UsingUsers, 0, UsingUsers.Length);
    }

    /*
    private async Task<IEnumerable<VisAlu>> RequestCareersStudentsSync()
    {
        await using U3FContext ctx = new U3FContext();

        using BuilderOptions options = BuilderOptionsFactory.GetCareerStudentsSync(this);

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
