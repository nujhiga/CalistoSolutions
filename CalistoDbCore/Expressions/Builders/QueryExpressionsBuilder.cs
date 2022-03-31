using System.Linq.Expressions;

using CalistoDbCore.Expressions.BuildingOptions;
using CalistoDbCore.Expressions.BuildingOptions.OptionsModels;
using CalistoDbCore.Expressions.Enumerations;
using CalistoDbCore.Expressions.Extensions;

using CalistoStandars.Definitions.Enumerations;
using CalistoStandars.Definitions.Records.DbCore;

namespace CalistoDbCore.Expressions.Builders;

public abstract class QueryExpressionsBuilder<TEntity> : BinaryExpressionsBuilder<TEntity> where TEntity : class
{
    private readonly int? ULPConvCodRef = 119;
    public BuilderOptions Options { get; set; }

    protected QueryExpressionsBuilder() => Options = new BuilderOptions();
    protected QueryExpressionsBuilder(BuilderOptions options) => Options = options;

    private Expression UsingOption(OptionType optionType) => optionType switch
    {
        OptionType.Campus => UsingCampus(),
        OptionType.ConvCod => UsingConvCod(),
        OptionType.Regular => UsingRegularity(),
        OptionType.Period => UsingPeriods(),
        OptionType.Career => UsingCareers(),
        OptionType.Commission => UsingCommissions(),
        OptionType.User => UsingUsers()!,
        _ => null!
    };
    private Expression UsingPeriods()
    {
        OptPeriod option = Options.Period;

        if (!option.IsValid()) return null!;

        if (option.Value is not { Length: > 0 }) return null!;

        return option.Value.Length == 1
            ? Equal(option.Name, option.Value[0].StrValue)
            : Contains(option.Name, option.Value.Select(p => p.ToString()).ToArray());
    }

    private Expression UsingConvCod()
    {
        OptCampus option = Options.Campus;

        if (!option.IsValid()) return null!;

        return ClCampus.U3F == option.Value ?
            NullableNotEqual(option.Name, ULPConvCodRef) :
            NullableEqual(option.Name, ULPConvCodRef);
    }
    private Expression UsingCampus()
    {
        OptCampus option = Options.Campus;

        return !option.IsValid() ? null! :
            Equal(option.Name, option.Value.SourceStr);
    }
    private Expression UsingRegularity()
    {
        OptRegular option = Options.Regular;

        if (!option.IsValid()) return null!;

        var value = option.Value;

        return value is IngressCond
            ? And(nameof(value.Regular), value.Regular,
                nameof(value.Curing), value.Curing)
            : Equal(nameof(value.Regular), value.Regular);
    }
    private Expression UsingCareers()
    {
        OptCareers option = Options.Careers;

        if (!option.IsValid()) return null!;

        if (option.Value is not { Length: > 0 }) return null!;

        return option.Value.Length == 1 ?
            NullableEqual(option.Name, option.Value[0]) :
            Contains(option.Name, option.Value);
    }
    private Expression UsingCommissions()
    {
        OptCommissions option = Options.Commissions;

        if (!option.IsValid()) return null!;

        if (option.Value is not { Length: > 0 }) return null!;

        return option.Value.Length == 1 ?
            NullableEqual(option.Name, option.Value[0]) :
            Contains(option.Name, option.Value);
    }
    private Expression UsingUsers()
    {
        OptUsers option = Options.Users;

        if (!option.IsValid()) return null!;

        if (option.Value is not { Length: > 0 }) return null!;

        return option.Value.Length == 1 ?
            NullableEqual(option.Name, option.Value[0]) :
            Contains(option.Name, option.Value);
    }
    protected IEnumerable<Expression> GetExpressionsOptions(params OptionType[] options) 
        => options.Select(UsingOption).Where(e => e is not null);
}




