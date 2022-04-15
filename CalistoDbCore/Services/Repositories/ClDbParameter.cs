using CalistoStandards.Definitions.Structures.Cls;

namespace CalistoDbCore.Services.Repositories;

//public interface IClComponent<TSign, TValue> : IClGenericComponent<TValue>, IClSignedComponent<TSign>
//    where TSign : struct, Enum
//{

//}

//public interface IClComponent<TSign> : IClComponent, IClSignedComponent<TSign>
//    where TSign : struct, Enum
//{
//    string MappedSignName();
//}
/*

public abstract class ClComponent<TSign, TCtype> : IClComponent<TSign, TCtype>
    where TSign : struct, Enum
    where TCtype : struct, Enum
{
    public TSign Sign { get; }
    public TCtype? ComponentType { get; }
    public virtual bool? Nullation { get; }

    public object? Value { get; private set; }

    protected ClComponent(TSign sign)
    {
        Sign = sign;
    }
    protected ClComponent(TSign sign, TCtype componentType) : this(sign)
    {
        ComponentType = componentType;
    }
    protected ClComponent(TSign sign, TCtype componentType, bool nullation) : this(sign, componentType)
    {
        Nullation = nullation;
    }

    public void SetValue<T>(T value) => Value = value;
    public T GetValueAs<T>() => Value is not T tValue ? default! : tValue;

    public virtual IEnumerable<T> EnumerateValue<T>()
    {
        yield return GetValueAs<T>();
    }

    public T[] ArrayValue<T>() => EnumerateValue<T>().ToArray();


    public virtual PropertyInfo SingPropertyInfo => GetType().GetProperty(nameof(Sign))!;
    public virtual PropertyInfo ValuePropertyInfo => GetType().GetProperty(nameof(Value))!;
}

public sealed class ClExMember : ClComponent<EntityMemberSign, ExpressionType>
{
    public ClExMember(EntityMemberSign sign, ExpressionType componentType, bool nullation) : base(sign, componentType, nullation)
    {
    }


}

public sealed class ClExParameter : KeyedCollection<EntityMemberSign, ClExMember>, IClSignedComponent<DbRequestSign>
{
    public DbRequestSign Sign { get; }

    public ClExParameter(DbRequestSign sign)
    {
        Sign = sign;
    }



    protected override EntityMemberSign GetKeyForItem(ClExMember item) => item.Sign;
}

*/
/*
public abstract class ClComponent<TSign, TCtype, TValue> : IClComponent<TSign, TCtype, TValue>
    where TSign : struct, Enum
    where TCtype : struct, Enum
{
    public TSign Sign { get; }
    public TCtype? ComponentType { get; }
    
    public TValue Value { get; set; }
    public bool Nullable { get; }

    protected ClComponent(TSign sign, bool nullable)
    {
        Sign = sign;
        Nullable = nullable;
    }
    protected ClComponent(TSign sign, TCtype cType, bool nullable) : this(sign, nullable)
    {
        ComponentType = cType;
    }

    public abstract IEnumerable<TValue> EnumerateValue();
}

public sealed class ClParameterMember
{






    public void Dispose()
    {
        throw new NotImplementedException();
    }
}

public abstract class ClParameterBase2<TParamSign, TMemberSign> : KeyedCollection<>
    where TParamSign : struct, Enum
    where TMemberSign : struct, Enum
{
    public readonly TParamSign ParamSign;
    


}


public abstract class ClParameterBase<TParamSign, TMemberSign> : Dictionary<TMemberSign, object>
    where TParamSign : struct, Enum 
    where TMemberSign : struct, Enum 
{
    public readonly TParamSign ParamSign;
    
    protected ClParameterBase(TParamSign paramSign) => ParamSign = paramSign;
    
    protected virtual bool TakeMember<TValue>(TMemberSign memberSign, out TValue takeValue)
    {
        takeValue = default!;

        if (!ContainsKey(memberSign)) return false;
        if (!Remove(memberSign, out object? outMemVlue)) return false;
        if (outMemVlue is not TValue taked) return false;

        takeValue = taked;
        return true;
    }
    protected virtual bool WriteMember<TValue>(TValue value, TMemberSign memberSign)
    {
        bool writed = false;

        if (ContainsKey(memberSign))
        {
            Remove(memberSign);
            WriteMember(value, memberSign);
        }
        else
        {
            writed = TryAdd(memberSign, value!);
        }

        return writed;
    }

    protected virtual TValue ReadMember<TValue>(TMemberSign memberSign)
    {
        if (!ContainsKey(memberSign)) return default!;

        object memberValue = this[memberSign];

        if (memberValue is TValue readValue)
            return readValue;

        return default!;
    }
    

}


public sealed class ClDtParameter : ClParameterBase<DbRequestSign, ClParameterType>
{
    public ClDtParameter(DbRequestSign paramSign) : base(paramSign)
    {
    }
}




*/

public sealed class ClDbParameter
{
    public ClDbParameter(in DbRequestSign sign) => RequestSign = sign;

    public DbRequestSign RequestSign { get; }


    [DbParamAttr(ClParameterType.Campus)] public DbParamMember<ClCampus>? Campus      { get; set; }
    public                                       bool                     UsingCampus => Campus is not null;


    [DbParamAttr(ClParameterType.Regularity)]
    public DbParamMember<DbRegularity>? Regularity { get; set; }

    public bool UsingRegularity => Regularity is not null;


    [DbParamAttr(ClParameterType.Academics)]
    public DbParamMember<int?[]>? AcademicsIDs { get; set; }

    public bool UsingAcademics => AcademicsIDs is not null;


    [DbParamAttr(ClParameterType.Users)] public DbParamMember<double[]>? UsersIDs   { get; set; }
    public                                      bool                     UsingUsers => UsersIDs is not null;


    [DbParamAttr(ClParameterType.Period)] public DbParamMember<Period[]>? Periods      { get; set; }
    public                                       bool                     UsingPeriods => Periods is not null;
}