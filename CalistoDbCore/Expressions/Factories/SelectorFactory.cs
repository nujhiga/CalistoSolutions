using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CalistoDbCore.Expressions.Enumerations;
using CalistoDbCore.U3FEntities;

namespace CalistoDbCore.Expressions.Factories;
public static class SelectorFactory
{

    /*
    public static Expression<Func<VisAlu, VisAlu>> GetVisAlu(SelectionDepth selDepth)
    {
        Expression<Func<VisAlu, VisAlu>> selector = selDepth switch
        {
            SelectionDepth.Simple => GetSimpleVisAlu(),
            SelectionDepth.Complete => GetCompleteVisAlu(),
            SelectionDepth.CompleteSimple => GetCompleteSimpleVisAlu(),
            _ => GetSimpleVisAlu()
        };

        return selector;
    }*/


    public static Expression<Func<VisAlu, object>> GetVisAlu(SelectionDepth selDepth)
    {
        Expression<Func<VisAlu, object>> selector = selDepth switch
        {
            SelectionDepth.Simple => GetSimpleVisAlu(),

            _ => GetSimpleVisAlu()
        };

        return selector;
    }

    private static Expression<Func<VisAlu, object>> GetSimpleVisAlu()
    {
        return (s => new 
        {
            s.Legajo,
            s.CarreraId,
            s.ConvCod,
            s.Regular,
            s.CuatrIngreso,
            s.Curing
        });
    }

    private static Expression<Func<VisAlu, VisAlu>> GetCompleteSimpleVisAlu()
    {
        return (s => new VisAlu
        {
            Legajo = s.Legajo,
            Usualu = s.Usualu,
            Documento = s.Documento,
            Nombres = s.Nombres,
            Apellido = s.Apellido,
            Mail = s.Mail,
            SexoId = s.SexoId,
            PlanId = s.PlanId,
            AnoIngreso = s.AnoIngreso,
        });
    }

    private static Expression<Func<VisAlu, VisAlu>> GetCompleteVisAlu()
    {
        return (s => new VisAlu
        {
            Legajo = s.Legajo,
            Usualu = s.Usualu,
            Documento = s.Documento,
            Nombres = s.Nombres,
            Apellido = s.Apellido,
            Mail = s.Mail,
            SexoId = s.SexoId,
            CarreraId = s.CarreraId,
            PlanId = s.PlanId,
            ConvCod = s.ConvCod,
            Regular = s.Regular,
            AnoIngreso = s.AnoIngreso,
            CuatrIngreso = s.CuatrIngreso,
            Curing = s.Curing
        });
    }
}
