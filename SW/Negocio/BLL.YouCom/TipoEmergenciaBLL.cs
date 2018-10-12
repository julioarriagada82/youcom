using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DAL.Emergencia;
using YouCom.DTO;

namespace YouCom.bll
{
    public class TipoEmergenciaBLL
    {
        public static IList<DTO.Emergencia.TipoEmergenciaDTO> getListadoTipoEmergencia()
        {
            YouCom.facade.TipoEmergencia TipoEmergenciaFA = new YouCom.facade.TipoEmergencia();
            var TipoEmergencia = YouCom.facade.TipoEmergencia.getListadoTipoEmergencia();
            return TipoEmergencia;
        }

        public static DTO.Emergencia.TipoEmergenciaDTO detalleTipoEmergencia(decimal idTipoEmergencia)
        {
            DTO.Emergencia.TipoEmergenciaDTO TipoEmergencias;
            TipoEmergencias = facade.TipoEmergencia.getListadoTipoEmergencia().Where(x => x.IdTipoEmergencia == idTipoEmergencia).First();
            return TipoEmergencias;
        }

        public static IList<DTO.Emergencia.TipoEmergenciaDTO> listaTipoEmergenciaActivo()
        {
            IList<DTO.Emergencia.TipoEmergenciaDTO> TipoEmergencias;
            TipoEmergencias = facade.TipoEmergencia.getListadoTipoEmergencia().Where(x => x.Estado == "1").ToList();
            return TipoEmergencias;
        }

        public static IList<DTO.Emergencia.TipoEmergenciaDTO> listaTipoEmergenciaInactivo()
        {
            IList<DTO.Emergencia.TipoEmergenciaDTO> TipoEmergencias;
            TipoEmergencias = facade.TipoEmergencia.getListadoTipoEmergencia().Where(x => x.Estado == "2").ToList();
            return TipoEmergencias;
        }

        public static bool Delete(DTO.Emergencia.TipoEmergenciaDTO myTipoEmergenciaDTO)
        {
            bool resultado = TipoEmergenciaDAL.Delete(myTipoEmergenciaDTO);
            return resultado;
        }

        public static bool Insert(DTO.Emergencia.TipoEmergenciaDTO myTipoEmergenciaDTO)
        {
            bool resultado = TipoEmergenciaDAL.Insert(myTipoEmergenciaDTO);
            return resultado;
        }

        public static bool Update(DTO.Emergencia.TipoEmergenciaDTO myTipoEmergenciaDTO)
        {
            bool resultado = TipoEmergenciaDAL.Update(myTipoEmergenciaDTO);
            return resultado;
        }

        public static bool ActivaTipoEmergencia(DTO.Emergencia.TipoEmergenciaDTO theTipoEmergenciaDTO)
        {
            bool respuesta = TipoEmergenciaDAL.ActivaTipoEmergencia(theTipoEmergenciaDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionTipoEmergencia(DTO.Emergencia.TipoEmergenciaDTO theTipoEmergenciaDTO)
        {
            bool respuesta = facade.TipoEmergencia.ValidaEliminacionTipoEmergencia(theTipoEmergenciaDTO);
            return respuesta;
        }
    }
}
