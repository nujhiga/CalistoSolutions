﻿namespace CalistoStandards.Definitions.Interfaces.DbCore.Students;

public interface IGenericAcademicInfo
{
    int? Period { get; set; }
    bool? Disabled { get; }
    DateTime? InscriptionDate { get; set; }
}