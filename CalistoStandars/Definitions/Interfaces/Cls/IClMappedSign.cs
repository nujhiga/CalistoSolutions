namespace CalistoStandards.Definitions.Interfaces.Cls;

[Obsolete("Review")]
public interface IClMappedSign
{
    SignMapType MapType { get; }
    string GetMappedSign<TSign>(SignMapType malType, TSign sign);
}
