using System.Net;

using CalistoDbCore.Services.Repositories;
using CalistoStandards.Definitions;
using CalistoStandards.Definitions.Structures.Cls;
using CalistoStandards.Providers;

namespace CalistoDbCore;

//todo: implement idisposable interface :: tdref:230322-2
public sealed class ClDbCore : IKeyedDelegation
{
   // public ClDbParameterr Parameterr { get; set; }
    public ClParameter Parameter { get; set; }

    internal readonly KeyedDelegator KyDelegator = KeyedDelegator.Instance;
    
    public void SetupDelegations()
    {

    }

    public ClDbCore()
    {
        //Parameterr = new ClDbParameterr();

        //ClCampus campus = KyDelegator.Invoke<CampusTarget>
        //    (ClConsts.ClEnviroment.GetCampusTarget).Source!;
        
        //Parameterr.SetCareerRegulars(campus, new Period(20221));

        {}
    }
}
