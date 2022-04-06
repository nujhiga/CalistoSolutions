using System.Linq.Expressions;
using CalistoDbCore.Expressions.Builders;
using CalistoDbCore.Expressions.BuildingOptions.Factory;

using CalistoDbCore.Expressions.BuildingOptions;
using CalistoDbCore.Services.Repositories;
using CalistoDbCore.U3FEntities;
using CalistoStandars.Definitions.Enumerations.DbCore;
using CalistoStandars.Definitions.Interfaces.DbCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace CalistoDbCore.Services.Factories;


public static class DbRequestFactory
{



















    //public static IEnumerable<IEntity> GetEntities<TEntity>(in U3FContext ctx,
    //    in DbRequestParameter<DbRequestSign> parameter) where TEntity : class
    //{
    //    { }

    //    (BuilderOptions options, Selector selector, EntityQueryBuilder2<IEntity> builder) = GetBuildingResources<IEntity>(in parameter);

    //    using AcademicEntityContext acdCtx = new AcademicEntityContext();
        
    //    selector.RequestingSigns = new []{ EntityMemberSign.Documento, EntityMemberSign.Nombres };

    //    {}

    //    IEnumerable<IEntity> entities = builder.GetQuery(acdCtx.NominalEntities)
    //        .Select(SelectionExpressionFactory.GetSelector<IEntity>(selector));

    //    {}

    //    var mm = ctx.Model.GetEntityTypes();

    //    var vsa = mm.Where(m => m.ClrType == typeof(NominalEntity)).AsQueryable();
    //    { }


    //    //IEnumerable<IEntity> entities = builder.GetQuery(x)
    //    //    .Select(SelectionExpressionFactory.GetSelector<IEntity>(selector)).ToList();

    //    return null;
    //}



    //public static IEnumerable<INominalEntity> GetEntities2(in U3FContext ctx,
    //    in DbRequestParameter<DbRequestSign> parameter) //where TEntity : class
    //{
    //    { }

    //    (BuilderOptions options, Selector selector, EntityQueryBuilder2<INominalEntity> builder) = 
    //        GetBuildingResources<INominalEntity>(in parameter);

    //    using AcademicEntityContext acdCtx = new AcademicEntityContext();

    //   // selector.RequestingSigns = new[] { EntityMemberSign.Documento, EntityMemberSign.Nombres };

    //    { }

    //    IEnumerable<INominalEntity> entities = builder.GetQuery(acdCtx.NominalEntities)
    //        .Select(SelectionExpressionFactory.GetSelector<INominalEntity>(selector));

    //    { }

    //    var mm = ctx.Model.GetEntityTypes();

    //    var vsa = mm.Where(m => m.ClrType == typeof(NominalEntity)).AsQueryable();
    //    { }


    //    //IEnumerable<IEntity> entities = builder.GetQuery(x)
    //    //    .Select(SelectionExpressionFactory.GetSelector<IEntity>(selector)).ToList();

    //    return null;
    //}


    /*  private static IEnumerable<TEntity> GetSyncCareerStudents<TEntity>(in U3FContext ctx, in DbRequestParameter<DbRequestSign> parameter) where TEntity : class, IEntity
      {
          (BuilderOptions options, Selector selector, EntityQueryBuilder2<TEntity> builder) = GetBuildingResources<TEntity>(in parameter);

          IEnumerable<TEntity> entities = builder.GetQuery(ctx.VisAlus).
              Select(SelectionExpressionFactory.GetSelector<TEntity>(selector)).ToList();
      }*/


    //private static (BuilderOptions options, Selector selector, EntityQueryBuilder2<TEntity> builder) GetBuildingResources<TEntity>(in DbRequestParameter<DbRequestSign> parameter)
    //    where TEntity : class
    //{
    //    BuilderOptions options =
    //        BuilderOptionFactory.GetOptions(in parameter);

    //    Selector selector = new Selector
    //        (parameter.Source!, parameter.SelectionSigns!);

    //    EntityQueryBuilder2<TEntity> builder = new
    //        EntityQueryBuilder2<TEntity>(in options);

    //    return (options, selector, builder);
    //}




    //TEntity auxInstance = Activator.CreateInstance<TEntity>();

    //SelectorParameters<IPersonEntity> selParams = new SelectorParameters<IPersonEntity>(auxInstance)
    //{
    //    RequestingSigns = new[] { EntityMemberSign.Legajo, EntityMemberSign.Nombres, EntityMemberSign.Apellido }
    //};

    //EntityQueryBuilder<TEntity> qBuilder = new EntityQueryBuilder<TEntity>(options);

    //IEnumerable<IPersonEntity> entities = qBuilder.GetSyncCareerQuery(ctx.VisAlus)
    //        .Select(SelectionExpressionFactory.GetSelector<IPersonEntity>(selParams));

    //    //uss query = new StudentsQueries(options);

    //    //var students = query.GetSyncCareerQuery(ctx.VisAlus)?
    //    //    .Select(SelectorFactory.GetVisAlu(selectionDepth));

    //    return entities.ToList()!;

    /*

    private IQueryable<VisAlu> GetSyncCareerStudents(in U3FContext ctx, in SelectionDepth selectionDepth)
    {
        using BuilderOptions options = BuilderOptionFactory.
            GetCareerStudentsSync(_repository);

        StudentsQueries query = new StudentsQueries(options);

        var students = query.GetSyncCareerQuery(ctx.VisAlus)?
            .Select(SelectorFactory.GetVisAlu(selectionDepth));

        return students!;
    }

    */

    //private IQueryable<VisAlu> GetSyncCareerStudents(in U3FContext ctx, in SelectionDepth selectionDepth)
    //{
    //    using BuilderOptions options = BuilderOptionFactory.
    //        GetCareerStudentsSync(_repository);

    //    StudentsQueries query = new StudentsQueries(options);

    //    var students = query.GetSyncCareerQuery(ctx.VisAlus)?
    //        .Select(SelectorFactory.GetVisAlu(selectionDepth));

    //    return students!;
    //}




}
