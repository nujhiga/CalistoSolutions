
using CalistoStandars.Definitions.Structures;

namespace CalistoDbCore.Expressions.BuildingOptions.OptionsModels;

public sealed class OptCampus : BuilderOption<CampusTarget>
{
    public OptCampus(string sourceName, CampusTarget sourceValue) : base(sourceName, sourceValue)
    {
    }
}




