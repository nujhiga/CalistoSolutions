namespace CalistoDbCore.Expressions.Builders;

internal static class QueryExtenssions
{
    internal static IQueryable<TEntity> WhereExpressions<TEntity>(this   IQueryable<TEntity> query,
                                                                  params Expression[] expressions) where TEntity : class
    {
        const string where = "Where";

        Type   caller   = typeof(Queryable);
        Type[] entities = {typeof(TEntity)};

        Expression root = query.Expression;

        MethodCallExpression callTree = Expression.Call
            (caller, where, entities, root, expressions![0]!);

        for (int i = 1; i < expressions.Length; i++)
            callTree = Expression.Call(caller, where,
                entities, callTree, expressions[i]!);

        return query.Provider.CreateQuery<TEntity>(callTree);
    }

    public static string GetRegularityValue(this DbRegularity regularity) => regularity switch
    {
        DbRegularity.Regular  => nameof(ConsoleKey.R),
        DbRegularity.Ingress  => $"{nameof(ConsoleKey.I)}{nameof(ConsoleKey.T)}",
        DbRegularity.Disabled => nameof(ConsoleKey.B),
        DbRegularity.Licence  => nameof(ConsoleKey.L),
        _                     => default!
    };

    internal static DbPeriod GetDbPeriod(this DbRequestSign sign) => sign switch
    {
        DbRequestSign.GetSyncCareers => DbPeriod.CuatrIngreso,
        DbRequestSign.GetNominals    => DbPeriod.AnoIngreso,
        DbRequestSign.GetSyncCommissions                                                    => DbPeriod.Cuatrimestre,
        _                                                                                   => throw default!
    };

    internal static DbCampus GetDbCampus(this DbRequestSign sign) => sign switch
    {
        DbRequestSign.GetSyncCareers or DbRequestSign.GetNominals => DbCampus.ConvCod,
        DbRequestSign.GetSyncCommissions                          => DbCampus.Campus,
        _                                                         => throw default!
    };

    internal static DbAcademics GetDbAcademic(this DbRequestSign sign) => sign switch
    {
        DbRequestSign.GetSyncCareers                                     => DbAcademics.CarreraId,
        DbRequestSign.GetSyncCommissions or DbRequestSign.GetCommissions => DbAcademics.Comision,
        DbRequestSign.GetCareers                                         => DbAcademics.Id,
        DbRequestSign.GetStudentsSync                                    => DbAcademics.Legajo,
        _                                                                => throw default!
    };


    internal static Enum GetEnumSign(this DbRequestSign sign) => sign switch
    {
        DbRequestSign.GetSyncCareers                                     => DbCareers.CarreraId,
        DbRequestSign.GetSyncCommissions or DbRequestSign.GetCommissions => DbCommissions.Comision,
        DbRequestSign.GetCareers                                         => DbCareers.Id,
        DbRequestSign.GetStudentsSync                                    => DbUsers.Legajo,
        _                                                                => throw default!
    };
}