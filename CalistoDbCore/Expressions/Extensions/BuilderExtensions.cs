using System.Linq.Expressions;

using CalistoDbCore.Expressions.Enumerations;
using CalistoDbCore.Services.Repositories;
using CalistoStandars.Definitions.Interfaces.DbCore.Entities;

namespace CalistoDbCore.Expressions.Extensions;

public static class BuilderExtensions
{


    





    public static IQueryable<TEntity> WithExpressions<TEntity>(this IQueryable<TEntity> query, params Expression[] expressions) where TEntity : class, IEntity
    {
        const string where = "Where";
        
        Type caller = typeof(Queryable);
        Type[] entities = { typeof(TEntity) };

        Expression root = query.Expression;

        MethodCallExpression callTree = Expression.Call
            (caller, where, entities, root, expressions![0]!);

        for (int i = 1; i < expressions.Length; i++)
            callTree = Expression.Call(caller, where,
                entities, callTree, expressions[i]!);

        return query.Provider.CreateQuery<TEntity>(callTree);
    }


    public static DbPeriod GetDbPeriod(this DbRequestSign sign) => sign switch
    {
        DbRequestSign.GetSyncCareers  => DbPeriod.CuatrIngreso,
        DbRequestSign.GetNominals => DbPeriod.AnoIngreso,
        DbRequestSign.GetSyncCommissions => DbPeriod.Cuatrimestre,
        _ => throw default
    };

    public static DbCampus GetDbCampus(this DbRequestSign sign) => sign switch
    {
        DbRequestSign.GetSyncCareers or DbRequestSign.GetNominals => DbCampus.ConvCod,
        DbRequestSign.GetSyncCommissions => DbCampus.Campus,
        _ => throw default
    };



    public static Enum GetEnumSign(this DbRequestSign sign) => sign switch
    {
        DbRequestSign.GetSyncCareers => DbCareers.CarreraId,
        DbRequestSign.GetSyncCommissions or DbRequestSign.GetCommissions => DbCommissions.Comision,
        DbRequestSign.GetCareers => DbCareers.Id,
        DbRequestSign.GetStudentsSync => DbUsers.Legajo,
        _ => throw default
    };
    
}


