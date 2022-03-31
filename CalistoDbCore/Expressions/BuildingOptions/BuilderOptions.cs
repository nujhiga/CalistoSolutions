
using CalistoDbCore.Expressions.BuildingOptions.OptionsModels;
using CalistoDbCore.Expressions.Enumerations;
using CalistoStandars.Definitions.Records.DbCore;
using CalistoStandars.Definitions.Structures;

namespace CalistoDbCore.Expressions.BuildingOptions;

public sealed class BuilderOptions : IDisposable
{
    public OptPeriod Period { get; private set; }
    public void CleanPeriod() => Period = null;
    public void SetPeriod(DbPeriods target, Period[] periods)
    {
        if (periods is null) return;

        Period = new OptPeriod($"{target}", periods);
    }

    public OptRegular Regular { get; private set; }
    public void CleanRegular() => Regular = null;
    public void SetRegular() => Regular = new OptRegular(nameof(DbRegularity.Regular), new RegularCond());
    public void SetIngress() => Regular = new OptRegular(nameof(DbRegularity.Ingress), new IngressCond());
    public void SetDisabled() => Regular = new OptRegular(nameof(DbRegularity.Disabled), new DisableCond());
    public void SetLicence() => Regular = new OptRegular(nameof(DbRegularity.Licence), new LicenceCond());

    public OptCampus Campus { get; private set; }
    public void CleanCampus() => Campus = null;
    public void SetCampus(DbCampus target, CampusTarget? campus)
    {
        if (campus is not { } campusTarget) return;

        Campus = new OptCampus($"{target}", campusTarget);
    }

    public OptCareers Careers { get; private set; }
    public void CleanCareers() => Careers = null;
    public void SetCareers(DbCareers target, int?[] careers)
    {
        if (careers is null) return;

        Careers = new OptCareers($"{target}", careers);
    }

    public OptCommissions Commissions { get; private set; }
    public void CleanCommissions() => Commissions = null;
    public void SetCommissions(DbCommissions target, int?[] commissions)
    {
        if (commissions is null) return;

        Commissions = new OptCommissions($"{target}", commissions);
    }

    public OptUsers Users { get; private set; }
    public void CleanUsers() => Users = null;
    public void SetUsers(DbUsers target, double[] users)
    {
        if (users is null) return;

        Users = new OptUsers($"{target}", users);
    }

    public void Dispose()
    {
        CleanRegular();
        CleanCampus();

        //Period.Value.Dispose();

        CleanPeriod();

        if (Period is { })
            Array.Clear(Period.Value, 0, Period.Value.Length);

        if (Careers is { })
            Array.Clear(Careers.Value, 0, Careers.Value.Length);
        CleanCareers();

        if (Commissions is { })
            Array.Clear(Commissions.Value, 0, Commissions.Value.Length);
        CleanCommissions();

        if (Users is { })
            Array.Clear(Users.Value, 0, Users.Value.Length);

        CleanUsers();
    }
}




