using CalistoStandards.Definitions.Factories.Cls;

namespace CalistoStandards.Definitions.Interfaces.Cls;

public interface IClComponent
{

    object? Value { get; set; }
    Enum? ComponentType { get; set; }
    //ClPattern? MessagePattern { get; set; }
}

public interface IClComponent<TSign> : IClSignedComponent<TSign>, IClComponent where TSign : struct, Enum
{
    bool? Nullation { get; set; }
    //bool? Nullation { get; }
    //object? Value { get; }
    //Enum? ComponentType { get; set; }
}


//PropertyInfo NullationProperty => GetType().GetProperty(nameof(Nullation))!;
//PropertyInfo ValueProperty => GetType().GetProperty(nameof(Value))!;
//PropertyInfo ComponentTypeProperty => GetType().GetProperty(nameof(ComponentType))!;



//PropertyInfo NullationProperty => GetType().GetProperty(nameof(Nullation))!;
//PropertyInfo ValueProperty => GetType().GetProperty(nameof(Value))!;
//PropertyInfo ComponentTypeProperty => GetType().GetProperty(nameof(ComponentType))!;