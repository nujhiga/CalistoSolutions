﻿namespace CalistoStandards.Definitions.Interfaces.DbCore.Entities;

public interface INominalEntity : IEntity
{
    [EntityAttr(EntityMemberSign.Legajo)]
    double Legajo { get; set; }

    [EntityAttr(EntityMemberSign.Apellido)]
    string? Apellido { get; set; }

    [EntityAttr(EntityMemberSign.Nombres)]
    string? Nombres { get; set; }

    [EntityAttr(EntityMemberSign.Documento)]
    double? Documento { get; set; }

    [EntityAttr(EntityMemberSign.FecNac)]
    DateTime? FecNac { get; set; }

    [EntityAttr(EntityMemberSign.Mail)]
    string? Mail { get; set; }

    [EntityAttr(EntityMemberSign.SexoId)]
    int? SexoId { get; set; }
}
