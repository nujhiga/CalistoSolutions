
using CalistoStandars.Definitions.Records.DbCore;

namespace CalistoDbCore.Expressions.BuildingOptions.OptionsModels;

public sealed class OptRegular : BuilderOption<RegularityCondition>
{
    public OptRegular(string sourceName, RegularityCondition sourceValue) : base(sourceName, sourceValue)
    {
    }
}




