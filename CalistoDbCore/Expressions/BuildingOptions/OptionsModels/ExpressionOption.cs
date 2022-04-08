using System.Linq.Expressions;

namespace CalistoDbCore.Expressions.BuildingOptions.OptionsModels;





public sealed class ExpressionOption<TSign, TValue> where TSign : struct, Enum
{
    public TSign FieldSign { get; }
    public TValue ConstValue { get; }
    public ExpressionType ExpressionType { get; }
    public bool Nullable { get; }
    public bool IsValid => ConstValue is not null;
    public bool ConstIrArray => typeof(TValue).IsArray;

    public TValue[] AsArray()
    {
        if (!IsValid) return null!;

        if (!ConstValue!.GetType().IsArray) return null!;

        return ConstValue is TValue[] array ? array : null!;
    }


    public ExpressionOption(TSign fieldSign, TValue constValie, 
        ExpressionType expressionType, bool nullable = false)
    {
        FieldSign = fieldSign;
        ConstValue = constValie;
        ExpressionType = expressionType;
        Nullable = nullable;
    }
}

/*
public sealed class ExpressionOption<TValue> 
{
    public string FieldName { get; }
    public TValue ConstValue { get; }
    public ExpressionType ExpressionType { get;  }
    public  bool Nullable { get; }
    public bool IsValid => !string.IsNullOrEmpty(FieldName) && ConstValue is not null;
    
    public TValue[] AsArray()
    {
        if (!IsValid) return null!;

        if (!ConstValue!.GetType().IsArray) return null!;

        return ConstValue is TValue[] array ? array : null!;
    }
   
    public ExpressionOption(string fieldName, TValue constValie, ExpressionType expressionType, bool nullable = false)
    {
        FieldName = fieldName;
        ConstValue = constValie;
        ExpressionType = expressionType;
        Nullable = nullable;
    }
}

*/


