using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalistoDbCore.Expressions.Builders;
using CalistoDbCore.Expressions.BuildingOptions.Factory;

using CalistoDbCore.Expressions.BuildingOptions;
using CalistoDbCore.Services.Repositories;
using CalistoDbCore.U3FEntities;
using CalistoStandars.Definitions.Interfaces.DbCore.Entities;
using CalistoStandars.Definitions.Enumerations;
using System.Linq.Expressions;
using CalistoDbCore.Expressions.Enumerations;
using CalistoDbCore.Expressions.Factories;

namespace CalistoDbCore.Services.Factories;


public sealed class DbRequestFactory
{
    private readonly DbRepository _repository;

    public DbRequestFactory(in DbRepository repository) => _repository = repository;

    //public IQueryable<IEntity> GetRequest(in U3FContext ctx, in RequestAction requestAction, in SelectionDepth selectionDepth) 
    //{
    //    IQueryable<IEntity> request = requestAction switch
    //    {
    //        RequestAction.SyncCareerStudents => GetSyncCareerStudents(in ctx, in selectionDepth),
    //        _ => null!
    //    };
    //    {}
    //    return request;
    //}
    /*
    public IQueryable<object> GetRequest(in U3FContext ctx, in RequestAction requestAction, in SelectionDepth selectionDepth)
    {
        IQueryable<object> request = requestAction switch
        {
            RequestAction.SyncCareerStudents => GetSyncCareerStudents(in ctx, in selectionDepth),
            _ => null!
        };
        { }
        return request;
    }*/


    public IEnumerable<object> GetSyncCareerStudents2(in U3FContext ctx, in SelectionDepth selectionDepth) 
    {
        using BuilderOptions options = BuilderOptionsFactory.
            GetCareerStudentsSync(_repository);

        StudentsQueries query = new StudentsQueries(options);

        var students = query.GetSyncCareerQuery(ctx.VisAlus)?
            .Select(SelectorFactory.GetVisAlu(selectionDepth));

        return students.ToList()!;
    }

    /*

    private IQueryable<VisAlu> GetSyncCareerStudents(in U3FContext ctx, in SelectionDepth selectionDepth)
    {
        using BuilderOptions options = BuilderOptionsFactory.
            GetCareerStudentsSync(_repository);

        StudentsQueries query = new StudentsQueries(options);

        var students = query.GetSyncCareerQuery(ctx.VisAlus)?
            .Select(SelectorFactory.GetVisAlu(selectionDepth));

        return students!;
    }

    */

    //private IQueryable<VisAlu> GetSyncCareerStudents(in U3FContext ctx, in SelectionDepth selectionDepth)
    //{
    //    using BuilderOptions options = BuilderOptionsFactory.
    //        GetCareerStudentsSync(_repository);

    //    StudentsQueries query = new StudentsQueries(options);

    //    var students = query.GetSyncCareerQuery(ctx.VisAlus)?
    //        .Select(SelectorFactory.GetVisAlu(selectionDepth));

    //    return students!;
    //}




}
