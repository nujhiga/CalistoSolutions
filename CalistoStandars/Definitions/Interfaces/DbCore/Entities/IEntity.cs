﻿namespace CalistoStandars.Definitions.Interfaces.DbCore.Entities;
public interface IEntity
{
    object EntityID { get; }
    abstract string MyView { get; }
}
