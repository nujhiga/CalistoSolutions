namespace CalistoDbCore.Expressions.BuildingOptions.OptionsModels;



public abstract class BuilderOption<T> 
{
    public string Name { get; set; }
    public T Value { get; set; }

    protected BuilderOption(string sourceName, T sourceValue)
    {
        Name = sourceName;
        Value = sourceValue;
    }
}




