//using System.Reflection;

//using CalistoStandards.Definitions.Interfaces.DbCore.Entities;

//namespace CalistoDbCore.Expressions.Factories;

//public record ExpressionPackage(ConstantExpression Constant, ParameterExpression Param, MemberExpression Value);

//public record LambdaExpressionPackage(Expression MainExpression, ParameterExpression Param);

//public static class ExpressionFactory<TEntity> where TEntity : class, IEntity
//{
//    private const string ParamMarker = "p";


//    public static MethodInfo? GetContainsMethod<TValue>() =>
//        typeof(ICollection<TValue>).GetMethod(nameof(Enumerable.Contains), new[] { typeof(TValue) });

//    [Obsolete("I think that this one is not working at all")]
//    public static MethodInfo? GetNullableContainsMethod<TValue>() =>
//        typeof(ICollection<TValue>).GetMethod(nameof(Enumerable.Contains), new[] { typeof(TValue?) });

//    public static MemberExpression GetProperty(Expression param, string target) =>
//        Expression.PropertyOrField(param, target);

//    public static MemberExpression GetProperty(ParameterExpression param, PropertyInfo pinfo) =>
//        Expression.Property(param, pinfo);

//    public static MemberAssignment GetBind(MemberInfo minfo, Expression expression) =>
//        Expression.Bind(minfo, expression);

//    public static MemberInitExpression GetInit(NewExpression nExpression, IEnumerable<MemberAssignment> members) =>
//        Expression.MemberInit(nExpression, members);

//    public static NewExpression GetNew() => Expression.New(typeof(TEntity));
//    public static ParameterExpression GetParameter() => Expression.Parameterr(typeof(TEntity), ParamMarker);
//    public static ConstantExpression GetConstant(object source) => Expression.Constant(source);

//    public static ConstantExpression GetNullableConstant<TValue>(object source) =>
//        Expression.Constant(source, typeof(TValue?));

//    public static ExpressionPackage GetPackage(object constSource, string target)
//    {
//        var constant = GetConstant(constSource);
//        var param = GetParameter();
//        var property = GetProperty(param, target);

//        return new ExpressionPackage(constant, param, property);
//    }

//    public static ExpressionPackage GetNullablePackage<TValue>(object constSource, string target)
//    {
//        var constant = GetNullableConstant<TValue>(constSource);
//        var param = GetParameter();
//        var property = GetProperty(param, target);

//        return new ExpressionPackage(constant, param, property);
//    }
//}