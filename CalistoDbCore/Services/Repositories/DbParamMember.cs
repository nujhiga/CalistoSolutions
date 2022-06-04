namespace CalistoDbCore.Services.Repositories;





public sealed class DbParamMember
{
    public DbParamMember(object value)
    {
        Value = value;
    }
    public DbParamMember()
    {
        
    }
    public DbParamMember(object value, string dbTargetField)
    {
        Value = value;
        Values = null!;
        DbTargetField = dbTargetField;
    }

    public DbParamMember(object[] values, string dbTargetField)
    {
        Values = values;
        Value = null!;
        DbTargetField = dbTargetField;
    }

    public string DbTargetField { get; set; }
    public string[] DbTargetsField { get; set; }

    public ClParamValueAssert ClParamValueAssert { get; set; }
    public ClParamValueAssert[] ParamsConditions { get; set; }

    //public ParamNextCondition ParamNextCondition { get; set; }

    public object? Value { get; set; }
    public object?[] Values { get; set; }

    public bool UniqueValue => Value is { };
    public bool ArrayValues => Values is { Length: > 0 };
}
