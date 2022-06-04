using CalistoStandards.Definitions.Interfaces.Cls;
using CalistoStandards.Definitions.Structures.Cls;

using static CalistoDbCore.Services.Repositories.ClParamValueFactory;

namespace CalistoDbCore.Services.Repositories;


public interface IClParamValue
{
    object Value { get; set; }
}


public sealed class ClParamValue : IClParamValue, IClGenericConvertion, IDisposable
{
    public ClParamValueType? ValueType { get; set; }
    public EntityMemberSign? ValueSign { get; set; }
    public string StrValueSign => $"{ValueSign}";
    public ClParamValueAssert? ValueAssert { get; set; }
    public TypeCode? AsValueCode { get; set; }
    public (string Target, T Value) SignValueTuple<T>() => (StrValueSign, GetValue<T>());
    


    public object Value { get; set; }
    


    public void SetValue<T>(T value) => Value = value;
    public T GetValue<T>()
    {
        return (T)Convert.ChangeType(Value, typeof(T))!;
    }
    public IEnumerable<T> EnumerateValue<T>()
    {
        if (Value is not object[] values) yield break;

        foreach (object value in values)
            yield return (T)value;
    }
    public T[] ArrayValue<T>() => EnumerateValue<T>().ToArray();

    public void Dispose()
    {
        ValueType = null;
        ValueSign = null;
        ValueAssert = null;
        AsValueCode = null;
        Value = null!;
    }
}


public sealed class ClParameter : IDisposable
{
    public DbRequestSign RequestSign { get; }
    public bool ContainsValues => Values is { Length: > 0 };
    public IEnumerable<EntityMemberSign> SelectFields { get; set; }

    private ClParamValue?[] _values;
    public ClParamValue?[] Values
    {
        get => _values.WithOutNulls().ToArray();
        set => _values = value;
    }
    public ClParamValue? this[ClParamValueType valueType]
    {
        get
        {
            if (!ContainsValues) return null!;

            ClParamValue? value = Values.SingleOrDefault(v => v?.ValueType == valueType);
            return value;
        }
    }
    public ClParamValue? this[ClParamValueType valueType, EntityMemberSign valueSign]
    {
        get
        {
            if (ContainsValues) return null!;

            ClParamValue? value = Values.SingleOrDefault(v => v?.ValueType == valueType &&
                                                                v?.ValueSign == valueSign);
            return value;
        }
    }
    public ClParameter(DbRequestSign requestSign, params ClParamValue[] values)
    {
        RequestSign = requestSign;
        Values = values;
    }
    public ClParameter(DbRequestSign requestSign, IEnumerable<EntityMemberSign> selectFields, params ClParamValue[] values)
    {
        RequestSign = requestSign;
        Values = values;
        SelectFields = selectFields;
    }

    public void Dispose()
    {
        foreach (ClParamValue? value in _values)
            value?.Dispose();

        Array.Clear(_values);

        SelectFields = Enumerable.Empty<EntityMemberSign>();
    }
}



public static class ClParameterFactory
{
    public static ClParameter GetSyncCareers(ClCampus campus, ClRegularity regularity, object periodObj, object careersidsObj)
    {
        ClParamValue regularValue = regularity switch
        {
            ClRegularity.Regular => Regularity.GetEqualsRegular(),
            ClRegularity.Ingress => Regularity.GetEqualsIngress(),
            _ => null!
        };

        ClParamValue curingValue = regularity is ClRegularity.Ingress 
            ? Regularity.GetEqualsCuring() 
            : null!;

        ClParamValue convCodValue = ConvCods.GetConvCod(campus);

        ClParamValue careerValue = careersidsObj switch
        {
            int careerid => Careers.GetEqualsStudentCareer(careerid),
            int?[] careerids => Careers.GetContainsStudentCareer(careerids),
            _ => null!,
        };

        ClParamValue periodValue = periodObj switch
        {
            Period period => Periods.GetEqualsCareerPeriod(period),
            Period[] periods => Periods.GetContainsCareerPeriod(periods),
            _ => null!,
        };

        EntityMemberSign[] selectFieldsSigns =
        {
            EntityMemberSign.Legajo,
            EntityMemberSign.Apellido,
            EntityMemberSign.Nombres,
            EntityMemberSign.Documento,
            EntityMemberSign.FecNac,
            EntityMemberSign.Mail,
            EntityMemberSign.SexoId
        };

        return new ClParameter(DbRequestSign.GetSyncCareers, selectFieldsSigns, regularValue,
            curingValue, convCodValue, careerValue, periodValue);
    }
}

public static class ClParamValueFactory
{

    public static ClParamValue Create(ClParamValueType valueType, EntityMemberSign valueSign, 
        ClParamValueAssert valueAssert, TypeCode asValueCode, object value)
    {
        ClParamValue pValue = new()
        {
            ValueType = valueType,
            ValueSign = valueSign,
            ValueAssert = valueAssert,
            Value = value,
            AsValueCode = asValueCode,
        };

        return pValue;
    }


    public static class Regularity
    {
        public static ClParamValue GetEqualsCuring()
        {
            ClParamValue campusValue = new()
            {
                ValueType = ClParamValueType.Ingress,
                ValueSign = EntityMemberSign.Curing,
                ValueAssert = ClParamValueAssert.Equal,
                Value = ConsoleKey.T,
                AsValueCode = TypeCode.String

            };

            return campusValue;
        }

        public static ClParamValue GetEqualsIngress()
        {
            ClParamValue campusValue = new()
            {
                ValueType = ClParamValueType.Regularity,
                ValueSign = EntityMemberSign.Regular,
                ValueAssert = ClParamValueAssert.Equal,
                Value = ConsoleKey.I,
                AsValueCode = TypeCode.String
            };

            return campusValue;
        }

        public static ClParamValue GetEqualsRegular()
        {
            ClParamValue campusValue = new()
            {
                ValueType = ClParamValueType.Regularity,
                ValueSign = EntityMemberSign.Regular,
                ValueAssert = ClParamValueAssert.Equal,
                Value = ConsoleKey.R,
                AsValueCode = TypeCode.String
            };

            return campusValue;
        }

    }
    public static class Careers
    {
        public static ClParamValue GetContainsStudentCareer(int?[] careers)
        {
            ClParamValue campusValue = new()
            {
                ValueType = ClParamValueType.Careers,
                ValueSign = EntityMemberSign.CarreraId,
                ValueAssert = ClParamValueAssert.Contains,
                AsValueCode = TypeCode.Int32,
                Value = careers
            };

            return campusValue;
        }

        public static ClParamValue GetEqualsStudentCareer(int? career)
        {
            ClParamValue campusValue = new()
            {
                ValueType = ClParamValueType.Career,
                ValueSign = EntityMemberSign.CarreraId,
                ValueAssert = ClParamValueAssert.Equal,
                AsValueCode = TypeCode.Int32,
                Value = career
            };

            return campusValue;
        }

        public static ClParamValue GetNotEqualsStudentCareer(int? career)
        {
            ClParamValue campusValue = new()
            {
                ValueType = ClParamValueType.Career,
                ValueSign = EntityMemberSign.CarreraId,
                ValueAssert = ClParamValueAssert.NotEqual,
                AsValueCode = TypeCode.Int32,
                Value = career
            };

            return campusValue;
        }
    }
    public static class ConvCods
    {
        public static ClParamValue GetConvCod(ClCampus value)
        {
            int? convVal = 119;

            ClParamValueAssert vassert = value == ClCampus.ULP
                ? ClParamValueAssert.Equal
                : ClParamValueAssert.NotEqual;

            ClParamValue campusValue = new()
            {
                ValueType = ClParamValueType.ConvCod,
                ValueSign = EntityMemberSign.ConvCod,
                ValueAssert = vassert,
                Value = convVal,
                AsValueCode = TypeCode.Int32
            };

            return campusValue;
        }
    }
    public static class Campus
    {
        public static ClParamValue GetEqualsCampus(ClCampus value)
        {
            ClParamValue campusValue = new()
            {
                ValueType = ClParamValueType.Campus,
                ValueSign = EntityMemberSign.Campus,
                ValueAssert = ClParamValueAssert.Equal,
                Value = value
            };

            return campusValue;
        }

        public static ClParamValue GetNotEqualsCampus(ClCampus value)
        {
            ClParamValue campusValue = new()
            {
                ValueType = ClParamValueType.Campus,
                ValueSign = EntityMemberSign.Campus,
                ValueAssert = ClParamValueAssert.NotEqual,
                Value = value
            };

            return campusValue;
        }
    }
    public static class Periods
    {
        public static ClParamValue GetEqualsPeriod(Period value)
        {
            ClParamValue periodValue = new()
            {
                ValueType = ClParamValueType.Period,
                ValueSign = EntityMemberSign.Cuatrimrestre,
                ValueAssert = ClParamValueAssert.Equal,
                AsValueCode = TypeCode.String,
                Value = value
            };

            return periodValue;
        }
        public static ClParamValue GetContainsPeriod(Period[] values)
        {
            ClParamValue periodValue = new()
            {
                ValueType = ClParamValueType.Periods,
                ValueSign = EntityMemberSign.Cuatrimrestre,
                ValueAssert = ClParamValueAssert.Contains,
                AsValueCode = TypeCode.String,
                Value = values
            };

            return periodValue;
        }

        public static ClParamValue GetEqualsCareerPeriod(Period value)
        {
            ClParamValue periodValue = new()
            {
                ValueType = ClParamValueType.Period,
                ValueSign = EntityMemberSign.CuatrIngreso,
                ValueAssert = ClParamValueAssert.Equal,
                AsValueCode = TypeCode.String,
                Value = value
            };

            return periodValue;
        }
        public static ClParamValue GetContainsCareerPeriod(Period[] values)
        {
            ClParamValue periodValue = new()
            {
                ValueType = ClParamValueType.Periods,
                ValueSign = EntityMemberSign.CuatrIngreso,
                ValueAssert = ClParamValueAssert.Contains,
                AsValueCode = TypeCode.String,
                Value = values
            };

            return periodValue;
        }
        public static ClParamValue GetEqualsPeriod(Period value, EntityMemberSign valueSign)
        {
            ClParamValue periodValue = new()
            {
                ValueType = ClParamValueType.Period,
                ValueSign = valueSign,
                ValueAssert = ClParamValueAssert.Equal,
                AsValueCode = TypeCode.String,
                Value = value
            };

            return periodValue;
        }
        public static ClParamValue GetContainsPeriod(Period[] values, EntityMemberSign valueSign)
        {
            ClParamValue periodValue = new()
            {
                ValueType = ClParamValueType.Periods,
                ValueSign = valueSign,
                ValueAssert = ClParamValueAssert.Contains,
                AsValueCode = TypeCode.String,
                Value = values
            };

            return periodValue;
        }
    }
}



public enum ClParamValueAssert
{
    None,
    Equal,
    NotEqual,
    Contains,
    NotContains
}
