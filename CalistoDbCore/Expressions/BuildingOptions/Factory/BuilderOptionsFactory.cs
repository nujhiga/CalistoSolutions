using CalistoDbCore.Expressions.Enumerations;
using CalistoDbCore.Services.Repositories;
using CalistoStandars.Definitions.Structures;

namespace CalistoDbCore.Expressions.BuildingOptions.Factory;
public static class BuilderOptionsFactory
{
    public static BuilderOptions GetCareerStudentsSync(in DbRepository repository)
    {
        BuilderOptions options = new BuilderOptions();

        SetCareerSyncPeriodCampus(ref options, repository.UsingCampus, repository.UsingPeriods);

        SetRegularity(ref options, repository.UsingRegularity);

        SetCareersAndUsers(ref options, repository.UsingCareers, repository.UsingUsers);

        return options;
    }

    private static void SetCareersAndUsers(ref BuilderOptions options, in int?[] careers, in double[] users)
    {
        if (careers is { Length: > 0 })
            options.SetCareers(DbCareers.CarreraId, careers);

        if (users is { Length: > 0 })
            options.SetUsers(DbUsers.Legajo, users);
    }
    private static void SetCareerSyncPeriodCampus(ref BuilderOptions options, in CampusTarget? campus, in Period[] periods)
    {
        if (periods is { Length: > 0 })
            options.SetPeriod(DbPeriods.CuatrIngreso, periods);
        
        if (campus is { })
            options.SetCampus(DbCampus.ConvCod, campus);
    }
    private static void SetRegularity(ref BuilderOptions options, in DbRegularity regularity)
    {
        if (regularity is DbRegularity.Regular)
            options.SetRegular();
        else if (regularity is DbRegularity.Ingress)
            options.SetIngress();
        else if (regularity is DbRegularity.Disabled)
            options.SetDisabled();
        else if (regularity is DbRegularity.Ingress)
            options.SetLicence();
    }
   
    


}
