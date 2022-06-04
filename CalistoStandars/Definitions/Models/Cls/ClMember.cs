using CalistoStandards.Definitions.Factories.Cls;

namespace CalistoStandards.Definitions.Models;

public sealed class ClMember : IClMember
{
    public MemberSign Sign { get; set; }
    public bool? Nullation { get; set; }
    public object? Value { get; set; }
    public Enum? ComponentType { get; set; }
    //public ClPattern? MessagePattern { get; set; } 

    public ClMember()
    {
        
    }

    public ClMember(MemberSign sign) => Sign = sign;
    public ClMember(MemberSign sign, object? value) : this(sign) => Value = value;
    public ClMember(MemberSign sign, object? value = null,
        bool? nullation = null, Enum? compType = null)
    {
        Sign = sign;
        Nullation = nullation;
        Value = value;
        ComponentType = compType;
    }
}