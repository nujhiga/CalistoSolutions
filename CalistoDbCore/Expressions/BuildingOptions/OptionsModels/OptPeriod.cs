
using CalistoStandars.Definitions.Structures;

namespace CalistoDbCore.Expressions.BuildingOptions.OptionsModels;

public sealed class OptPeriod : BuilderOption<Period[]>
{
    public OptPeriod(string sourceName, Period[] sourceValue) : base(sourceName, sourceValue)
    {
    }
}




