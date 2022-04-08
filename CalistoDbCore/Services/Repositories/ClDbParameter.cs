using CalistoDbCore.Expressions.Enumerations;

using CalistoStandars.Definitions.Enumerations;
using CalistoStandars.Definitions.Enumerations.DbCore;
using CalistoStandars.Definitions.Models;
using CalistoStandars.Definitions.Structures;

namespace CalistoDbCore.Services.Repositories;

public sealed class ClDbParameter
{
    public ClDbParameter(in DbRequestSign sign) => RequestSign = sign;

    public DbRequestSign RequestSign { get; }

    
    [DbParamAttr(DbParameterType.Campus)]
    public DbParamMember<ClCampus>? Campus { get; set; }
    public bool UsingCampus => Campus is not null;

    
    [DbParamAttr(DbParameterType.Regularity)]
    public DbParamMember<DbRegularity>? Regularity { get; set; }
    public bool UsingRegularity => Regularity is not null;

    
    [DbParamAttr(DbParameterType.Academics)]
    public DbParamMember<int?[]>? AcademicsIDs { get; set; }
    public bool UsingAcademics => AcademicsIDs is not null;

    
    [DbParamAttr(DbParameterType.Users)]
    public DbParamMember<double[]>? UsersIDs { get; set; }
    public bool UsingUsers => UsersIDs is not null;

    
    [DbParamAttr(DbParameterType.Period)]
    public DbParamMember<Period[]>? Periods { get; set; }
    public bool UsingPeriods => Periods is not null;
}
