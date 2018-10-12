using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL;

namespace YouCom.bll
{
    public class PeriodoHorarioBLL
    {
        public static IList<PeriodoHorarioDTO> getListadoPeriodoHorario()
        {
            YouCom.facade.PeriodoHorario PeriodoHorarioFA = new YouCom.facade.PeriodoHorario();
            var PeriodoHorario = YouCom.facade.PeriodoHorario.getListadoPeriodoHorario();
            return PeriodoHorario;
        }

        public static PeriodoHorarioDTO detallePeriodoHorario(decimal idPeriodoHorario)
        {
            PeriodoHorarioDTO PeriodoHorarios;
            PeriodoHorarios = facade.PeriodoHorario.getListadoPeriodoHorario().Where(x => x.IdPeriodoHorario == idPeriodoHorario).First();
            return PeriodoHorarios;
        }

        public static IList<PeriodoHorarioDTO> listaPeriodoHorarioActivo()
        {
            IList<PeriodoHorarioDTO> PeriodoHorarios;
            PeriodoHorarios = facade.PeriodoHorario.getListadoPeriodoHorario().Where(x => x.Estado == "1").ToList();
            return PeriodoHorarios;
        }

        public static IList<PeriodoHorarioDTO> listaPeriodoHorarioInactivo()
        {
            IList<PeriodoHorarioDTO> PeriodoHorarios;
            PeriodoHorarios = facade.PeriodoHorario.getListadoPeriodoHorario().Where(x => x.Estado == "2").ToList();
            return PeriodoHorarios;
        }

        public static bool Delete(DTO.PeriodoHorarioDTO myPeriodoHorarioDTO)
        {
            bool resultado = PeriodoHorarioDAL.Delete(myPeriodoHorarioDTO);
            return resultado;
        }

        public static bool Insert(DTO.PeriodoHorarioDTO myPeriodoHorarioDTO)
        {
            bool resultado = PeriodoHorarioDAL.Insert(myPeriodoHorarioDTO);
            return resultado;
        }

        public static bool Update(DTO.PeriodoHorarioDTO myPeriodoHorarioDTO)
        {
            bool resultado = PeriodoHorarioDAL.Update(myPeriodoHorarioDTO);
            return resultado;
        }

        public static bool ActivaPeriodoHorario(PeriodoHorarioDTO thePeriodoHorarioDTO)
        {
            bool respuesta = YouCom.DAL.PeriodoHorarioDAL.ActivaPeriodoHorario(thePeriodoHorarioDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionPeriodoHorario(PeriodoHorarioDTO thePeriodoHorarioDTO)
        {
            bool respuesta = facade.PeriodoHorario.ValidaEliminacionPeriodoHorario(thePeriodoHorarioDTO);
            return respuesta;
        }
    }
}
