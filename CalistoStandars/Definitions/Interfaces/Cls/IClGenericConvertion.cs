namespace CalistoStandards.Definitions.Interfaces.Cls;

public interface IClGenericConvertion
{
    void SetValue<T>(T value);
    IEnumerable<T> EnumerateValue<T>();
    T[] ArrayValue<T>();


}
