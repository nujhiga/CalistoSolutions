﻿namespace CalistoStandars.Definitions.Interfaces;

public interface ICommissionInfo : IGenericAcademicInfo
{
    int? CommissionID { get; set; }
    int? CareerRef { get; set; }
    int? AssignatureID { get; set; }
}