using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL;

namespace YouCom.bll
{
    public class HorarioTurnoBLL
    {
        public static IList<HorarioTurnoDTO> getListadoHorarioTurno()
        {
            YouCom.facade.HorarioTurno HorarioTurnoFA = new YouCom.facade.HorarioTurno();
            var HorarioTurno = YouCom.facade.HorarioTurno.getListadoHorarioTurno();
            return HorarioTurno;
        }

        public static HorarioTurnoDTO detalleHorarioTurno(decimal idHorarioTurno)
        {
            HorarioTurnoDTO HorarioTurnos;
            HorarioTurnos = facade.HorarioTurno.getListadoHorarioTurno().Where(x => x.IdHorarioTurno == idHorarioTurno).First();
            return HorarioTurnos;
        }

        public static IList<HorarioTurnoDTO> getListadoHorarioTurnoByCondominioByComunidad(decimal idCondominio, decimal idComunidad)
        {
            var horarios = listaHorarioTurnoActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return horarios;
        }

        public static IList<HorarioTurnoDTO> listaHorarioTurnoActivo()
        {
            IList<HorarioTurnoDTO> HorarioTurnos;
            HorarioTurnos = facade.HorarioTurno.getListadoHorarioTurno().Where(x => x.Estado == "1").ToList();
            return HorarioTurnos;
        }

        public static IList<HorarioTurnoDTO> listaHorarioTurnoInactivo()
        {
            IList<HorarioTurnoDTO> HorarioTurnos;
            HorarioTurnos = facade.HorarioTurno.getListadoHorarioTurno().Where(x => x.Estado == "2").ToList();
            return HorarioTurnos;
        }

        public static bool Delete(DTO.HorarioTurnoDTO myHorarioTurnoDTO)
        {
            bool resultado = HorarioTurnoDAL.Delete(myHorarioTurnoDTO);
            return resultado;
        }

        public static bool Insert(DTO.HorarioTurnoDTO myHorarioTurnoDTO)
        {
            bool resultado = HorarioTurnoDAL.Insert(myHorarioTurnoDTO);
            return resultado;
        }

        public static bool Update(DTO.HorarioTurnoDTO myHorarioTurnoDTO)
        {
            bool resultado = HorarioTurnoDAL.Update(myHorarioTurnoDTO);
            return resultado;
        }

        public static bool ActivaHorarioTurno(HorarioTurnoDTO theHorarioTurnoDTO)
        {
            bool respuesta = HorarioTurnoDAL.ActivaHorarioTurno(theHorarioTurnoDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionHorarioTurno(HorarioTurnoDTO theHorarioTurnoDTO)
        {
            bool respuesta = facade.HorarioTurno.ValidaEliminacionHorarioTurno(theHorarioTurnoDTO);
            return respuesta;
        }
    }
}
