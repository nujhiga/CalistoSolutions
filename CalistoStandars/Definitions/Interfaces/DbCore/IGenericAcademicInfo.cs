namespace CalistoStandars.Definitions.Interfaces;

public interface IGenericAcademicInfo
{
    int? Period { get; set; }
    bool? Disabled { get; }
    DateTime? InscriptionDate { get; set; }
}