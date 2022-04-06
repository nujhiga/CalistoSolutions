using System.Linq.Expressions;
using System.Reflection.Emit;
using Microsoft.VisualBasic.CompilerServices;

namespace CalistoDbCore.Expressions.BuildingOptions.OptionsModels;



public sealed class BuilderOption<TValue> 
{
    public string FieldName { get;  }
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
   
    public BuilderOption(string fieldName, TValue constValie, ExpressionType expressionType, bool nullable = false)
    {
        FieldName = fieldName;
        ConstValue = constValie;
        ExpressionType = expressionType;
        Nullable = nullable;
    }
}




