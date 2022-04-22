namespace CalistoStandards.Definitions.Structures.Cls;
public readonly struct Period : IComparable<Period>, IConvertible, IEquatable<Period>, IEquatable<DateTime>, IEquatable<string>, IEquatable<short>
{
    private readonly short _value;

    public string StrValue => _value.ToString();
    public short Value => _value;
    public string Year => StrValue[..4];
    public Period(in string strSource) => _ = ValidateStrSource(strSource, out _value);
    public Period(in short shtSource) => _ = ValidateStrSource(shtSource.ToString(), out _value);
    public Period? Next()
    {
        if (!TryGetYearMonth(out short year, out short month)) return null;

        month++;

        if (month > 2)
        {
            month = 1;
            year++;
        }

        return new Period($"{year}{month}");
    }
    public Period? Previous()
    {
        if (!TryGetYearMonth(out short year, out short month)) return null;

        month--;

        if (month < 1)
        {
            month = 2;
            year--;
        }

        return new Period($"{year}{month}");
    }
    public static Period? Next(in Period prdSource)
    {
        if (!prdSource.TryGetYearMonth(out short year, out short month)) return null;

        month++;

        if (month > 2)
        {
            month = 1;
            year++;
        }

        return new Period($"{year}{month}");
    }
    public static Period? Previous(in Period prdSource)
    {
        if (!prdSource.TryGetYearMonth(out short year, out short month)) return null;

        month--;

        if (month < 1)
        {
            month = 2;
            year--;
        }

        return new Period($"{year}{month}");
    }

    public bool TryGetYearMonth(out short year, out short month)
    {
        string strSource = StrValue;
        year = 0;
        month = 0;

        if (strSource is null) return false;

        string yearStr = strSource[..4];
        string monthStr = strSource[4..];

        bool isY = short.TryParse(yearStr, out short tyear);
        bool isM = short.TryParse(monthStr, out short tmonth);

        if (!isY || !isM) return false;

        year = tyear;
        month = tmonth;

        return true;
    }
    private static bool ValidateStrSource(in string? strSource, out short value)
    {
        value = 0;

        if (string.IsNullOrWhiteSpace(strSource)) return false;

        if (strSource.Length != 5) return false;

        if (!short.TryParse(strSource, out var tmpValue)) return false;

        value = tmpValue;

        return true;
    }

    public override string ToString() => _value.ToString();

    #region Equality and Comparssion
    public int CompareTo(Period other)
    {
        if (other._value is 0) return -1;

        if (_value is 0) return 1;

        if (other._value > _value) return -1;

        return other._value < _value ? 1 : 0;
    }
    public bool Equals(Period other)
    {
        if (other._value is 0 || _value is 0) return false;
        return _value.Equals(other._value);
    }
    public bool Equals(DateTime other)
    {
        //if (other is not { } oDate) return false;

        char strMonth = other.Month >= 8 ? '2' : '1';
        string strSource = $"{other.Year}{strMonth}";

        _ = short.TryParse(strSource, out short ovalue);

        return _value.Equals(ovalue);
    }

    public bool Equals(string? other) => ValidateStrSource(other, out short ovalue) && _value.Equals(ovalue);
    public bool Equals(short other) => other is { } oval && _value is { } val && val.Equals(oval);
    public override bool Equals(object? obj) => obj is Period other && Equals(other);

    public override int GetHashCode() => _value.GetHashCode();

    public static bool operator ==(Period left, Period right) => left.Equals(right);
    public static bool operator !=(Period left, Period right) => !(left == right);

    public static bool operator ==(string left, Period right) => left != null && right.Equals(left);
    public static bool operator !=(string left, Period right) => !(left == right);

    public static bool operator ==(Period left, string right) => right != null && left.Equals(right);
    public static bool operator !=(Period left, string right) => !(left == right);

    public static bool operator <(Period left, Period right) => left.CompareTo(right) < 0;
    public static bool operator <=(Period left, Period right) => left.CompareTo(right) <= 0;
    public static bool operator >(Period left, Period right) => left.CompareTo(right) > 0;
    public static bool operator >=(Period left, Period right) => left.CompareTo(right) >= 0;
    #endregion

    TypeCode IConvertible.GetTypeCode()
    {
        return _value.GetTypeCode();
    }

    bool IConvertible.ToBoolean(IFormatProvider? provider)
    {
        return ((IConvertible)_value).ToBoolean(provider);
    }

    byte IConvertible.ToByte(IFormatProvider? provider)
    {
        return ((IConvertible)_value).ToByte(provider);
    }

    char IConvertible.ToChar(IFormatProvider? provider)
    {
        return ((IConvertible)_value).ToChar(provider);
    }

    DateTime IConvertible.ToDateTime(IFormatProvider? provider)
    {
        return ((IConvertible)_value).ToDateTime(provider);
    }

    decimal IConvertible.ToDecimal(IFormatProvider? provider)
    {
        return ((IConvertible)_value).ToDecimal(provider);
    }

    double IConvertible.ToDouble(IFormatProvider? provider)
    {
        return ((IConvertible)_value).ToDouble(provider);
    }

    short IConvertible.ToInt16(IFormatProvider? provider)
    {
        return ((IConvertible)_value).ToInt16(provider);
    }

    int IConvertible.ToInt32(IFormatProvider? provider)
    {
        return ((IConvertible)_value).ToInt32(provider);
    }

    long IConvertible.ToInt64(IFormatProvider? provider)
    {
        return ((IConvertible)_value).ToInt64(provider);
    }

    sbyte IConvertible.ToSByte(IFormatProvider? provider)
    {
        return ((IConvertible)_value).ToSByte(provider);
    }

    float IConvertible.ToSingle(IFormatProvider? provider)
    {
        return ((IConvertible)_value).ToSingle(provider);
    }

    string IConvertible.ToString(IFormatProvider? provider)
    {
        return _value.ToString(provider);
    }

    object IConvertible.ToType(Type conversionType, IFormatProvider? provider)
    {
        return ((IConvertible)_value).ToType(conversionType, provider);
    }

    ushort IConvertible.ToUInt16(IFormatProvider? provider)
    {
        return ((IConvertible)_value).ToUInt16(provider);
    }

    uint IConvertible.ToUInt32(IFormatProvider? provider)
    {
        return ((IConvertible)_value).ToUInt32(provider);
    }

    ulong IConvertible.ToUInt64(IFormatProvider? provider)
    {
        return ((IConvertible)_value).ToUInt64(provider);
    }
}
