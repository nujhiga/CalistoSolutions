using System.Reflection;
using CalistoStandards.Definitions.Interfaces.Cls;

namespace CalistoStandards.Definitions.Models;

public interface IClMember : IClComponent<MemberSign>
{
    PropertyInfo NullationProperty => GetType().GetProperty(nameof(Nullation))!;
    PropertyInfo ValueProperty => GetType().GetProperty(nameof(Value))!;
    PropertyInfo ComponentTypeProperty => GetType().GetProperty(nameof(ComponentType))!;
}