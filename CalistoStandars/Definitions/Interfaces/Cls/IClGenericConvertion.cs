namespace CalistoStandards.Definitions.Interfaces.Cls;

public interface IClGenericConvertion
{
    void SetValue<T>(T value);
    T GetValue<T>();
    IEnumerable<T> EnumerateValue<T>();
    T[] ArrayValue<T>();


}
