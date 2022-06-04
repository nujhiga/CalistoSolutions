namespace CalistoStandards.Definitions.Interfaces.DbCore.Entities;
public interface IEntity
{
    object EntityID { get; }

    public object GetValue(string propName) => GetType().GetProperty(propName).GetValue(this);
}
