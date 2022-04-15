namespace CalistoDbCore.Services.Repositories;

//public abstract record DbParamMember(Type MemberType);

public sealed class DbParamMember<TValue> //(TMember Member/*, Type MemberType*/) //: DbParamMember(MemberType)
{
    public DbParamMember(TValue value)
    {
        Value = value;
    }


    public TValue? Value    { get; set; }
    public bool    HasValue => Value is { };
    public bool    IsArray  => HasValue && Value is TValue[] {Length: > 1};
}