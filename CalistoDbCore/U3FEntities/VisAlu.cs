﻿using CalistoStandars.Definitions.Interfaces.DbCore.Entities;

namespace CalistoDbCore.U3FEntities;

public partial class VisAlu : IEntity
{
    public object EntityID => Legajo;
    public double Legajo { get; set; }
    public string? Apellido { get; set; }
    public string? Nombres { get; set; }
    public double? Documento { get; set; }
    public int? TipoDoc { get; set; }
    public string? Nacio { get; set; }
    public DateTime? FecNac { get; set; }
    public string? Direccion { get; set; }
    public string? Cp { get; set; }
    public string? Telefono { get; set; }
    public string? AnoIngreso { get; set; }
    public DateTime? FecIns { get; set; }
    public string? TitSec { get; set; }
    public DateTime? FecSec { get; set; }
    public string? TitTer { get; set; }
    public string? TitUni { get; set; }
    public int? SexoId { get; set; }
    public int? LocalidadId { get; set; }
    public string? Partido { get; set; }
    public double? Provincia { get; set; }
    public string? Mail { get; set; }
    public int? CarreraId { get; set; }
    public int? TurnoId { get; set; }
    public int? Eg1cod { get; set; }
    public string? Eg1 { get; set; }
    public int? Eg2cod { get; set; }
    public string? Eg2 { get; set; }
    public int? EstCivil { get; set; }
    public int? Hijos { get; set; }
    public int? Presento { get; set; }
    public int? Finales { get; set; }
    public DateTime? FinDes { get; set; }
    public DateTime? FinHas { get; set; }
    public string? Regular { get; set; }
    public string? ReguAnt { get; set; }
    public string? Convenio { get; set; }
    public int? ConvCod { get; set; }
    public string? Recibido { get; set; }
    public DateTime? FecRei { get; set; }
    public int? CuoIns { get; set; }
    public string? Orienta { get; set; }
    public int? PlanId { get; set; }
    public decimal? Trabaja { get; set; }
    public decimal? TraTipo { get; set; }
    public decimal? TraHrs { get; set; }
    public string? MotBaja { get; set; }
    public int Id { get; set; }
    public string? Abr { get; set; }
    public double? ResNro { get; set; }
    public string? ResAno { get; set; }
    public DateTime? ResFec { get; set; }
    public string? Tipo { get; set; }
    public DateTime? Fectit { get; set; }
    public int? Present3 { get; set; }
    public string? LetraDoc { get; set; }
    public string? Extranjero { get; set; }
    public string? Residente { get; set; }
    public string? Intercambio { get; set; }
    public string? Libreta { get; set; }
    public int? Vencresid { get; set; }
    public DateTime? Feclib { get; set; }
    public int? Cuotaextr { get; set; }
    public string? Dispos25 { get; set; }
    public double? Promsec { get; set; }
    public string? Docuextr { get; set; }
    public string? CuatrIngreso { get; set; }
    public int? IdSede { get; set; }
    public int? IdTarifa { get; set; }
    public int? IdMedioPago { get; set; }
    public string? Curing { get; set; }
    public string? Documenta { get; set; }
    public string? CuotaIngreso { get; set; }
    public string? LocalidadTxt { get; set; }
    public string? Cuotacero { get; set; }
    public string? Pais { get; set; }
    public int Expr1 { get; set; }
    public string? Usucla { get; set; }
    public string? Usualu { get; set; }
    public string? Suspendido { get; set; }
    public DateTime? Suspfecha { get; set; }
    public string? Suspcuatri { get; set; }
    public bool? Suspproce { get; set; }
    public int? Bcoleg { get; set; }
    public string? Visatarjeta { get; set; }
    public string? Visatartipo { get; set; }
    public string? Visacod { get; set; }
    public string? Visapri { get; set; }
    public string? Observa { get; set; }
    public string? LugMundo { get; set; }
    public int? PaisId { get; set; }
    public string? Cuit { get; set; }
    public string? Guacuit { get; set; }
    public int? Guapnac { get; set; }
    public int? Gualoca { get; set; }
    public int? Guatrab { get; set; }
    public int? Guainpa { get; set; }
    public int? Guainma { get; set; }
    public int? Guabeca { get; set; }
    public string? Guadate { get; set; }
    public int? Guapres { get; set; }
    public DateTime? Recifecha { get; set; }
    public int? IdTarifaGral { get; set; }
    public int? UpcnafiliadoNro { get; set; }
    public string? UpcnafiliadoTipo { get; set; }
    public string? Debedni { get; set; }
    public string? Debetit { get; set; }
    public string? ApellidoAuto { get; set; }
    public string? NombresAuto { get; set; }
    public int? Genero { get; set; }
    public string? ApellidoDni { get; set; }
    public string? NombresDni { get; set; }
    public int? SexoDni { get; set; }
}

