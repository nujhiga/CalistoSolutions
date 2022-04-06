using System.Linq.Expressions;
using CalistoDbCore.Expressions.BuildingOptions.OptionsModels;
using CalistoDbCore.Expressions.Enumerations;
using CalistoDbCore.Services.Repositories;
using CalistoStandars.Definitions.Enumerations;
using CalistoStandars.Definitions.Models.DbCore.Entities.Constants;
using CalistoStandars.Definitions.Structures;

namespace CalistoDbCore.Expressions.BuildingOptions.Factory;
public static class OptionFactory
{

    public static BuilderOption<TValue> WithOption<TValue, TSign>(TSign signField, TValue constValue, ExpressionType expType = ExpressionType.Equal)
    {
        return new BuilderOption<TValue>($"{signField}", constValue, expType);
    }
    public static BuilderOption<TValue> WithOption<TValue>(Enum signEnum, TValue constValue, ExpressionType expType = ExpressionType.Equal)
    {
        return new BuilderOption<TValue>($"{signEnum}", constValue, expType);
    }
    public static BuilderOption<TValue[]> WithOptions<TValue, TSign>(TSign signField, TValue[] constValue)
    {
        return new BuilderOption<TValue[]>($"{signField}", constValue, ExpressionType.OnesComplement);
    }

    public static BuilderOption<TValue[]> WithOptions<TValue>(Enum signEnum, TValue[] constValue)
    {
        return new BuilderOption<TValue[]>($"{signEnum}", constValue, ExpressionType.OnesComplement);
    }



    public static BuilderOption<Period> WithPeriod(DbPeriod periodField, Period constValue)
    {
        return new BuilderOption<Period>($"{periodField}", constValue, ExpressionType.Equal);
    }

    public static BuilderOption<Period[]> WithPeriods(DbPeriod periodField, Period[] constValue)
    {
        return new BuilderOption<Period[]>($"{periodField}", constValue, ExpressionType.OnesComplement);
    }

  

    public static BuilderOption<ClCampus> WithCampus(ClCampus constValue)
    {
        return new BuilderOption<ClCampus>(EntitiesConstants.Academic.Campus, constValue, ExpressionType.Equal);
    }

    public static BuilderOption<int?> WithConvCod(ClCampus campus)
    {
        int? constValue = 119;

        const string fieldName = EntitiesConstants.Academic.ConvCod;

        ExpressionType expType = campus == ClCampus.U3F ? ExpressionType.NotEqual : ExpressionType.Equal;

        BuilderOption<int?> option = new BuilderOption<int?>(fieldName, constValue, expType, true);
 
        return option;
    }



    /*


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













    public static BuilderOptions GetOptions(in DbRequestParameter<DbRequestSign> parameter) 
    {
        BuilderOptions options = new BuilderOptions()
        {
            RequestSign = parameter.RequestSign
        };


        if (parameter.FromCampus is { } campus)
            options.SetCampus(DbCampus.ConvCod, campus);


        if (parameter.WithRegularity is { } regularity)
            SetRegularity(ref options, in regularity);


        if (parameter.WithAcademicID is { Length: > 0 })
            options.SetCareers(DbCareers.CarreraId, parameter.WithAcademicID);


        if (parameter.WithUsers is { Length: > 0 } && parameter.RequestSign is not DbRequestSign.GetTeachers)
        {
            double[] users = parameter.WithUsers;
            options.SetUsers(DbUsers.Legajo, users);
        }

        if (parameter.OnPeriods is {} periods)
            options.SetPeriod(DbPeriod.CuatrIngreso, periods);

        return options;
    }
    */

    /*

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

    */
    /*
    public static BuilderOptions GetCareerStudentsSync(
        (CampusTarget? campus, DbRegularity regularity,
            Period[] periods, int?[] careers, double[] users) param)
    {
        BuilderOptions options = new BuilderOptions();

        SetCareerSyncPeriodCampus(ref options, param.campus, param.periods);

        SetRegularity(ref options, param.regularity);

        SetCareersAndUsers(ref options, param.careers, param.users);

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
            options.SetPeriod(DbPeriod.CuatrIngreso, periods);

        if (campus is { })
            options.SetCampus(DbCampus.ConvCod, campus);
    }


    */


}
