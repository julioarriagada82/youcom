using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DTO.Avisos;
using YouCom.DAL;

namespace YouCom.bll.Avisos
{
    public class TipoAvisoBLL
    {
        public static IList<TipoAvisoDTO> getListadoTipoAviso()
        {
            YouCom.facade.TipoAviso TipoAvisoFA = new YouCom.facade.TipoAviso();
            var TipoAviso = YouCom.facade.TipoAviso.getListadoTipoAviso();
            return TipoAviso;
        }

        public static TipoAvisoDTO detalleTipoAviso(decimal idTipoAviso)
        {
            TipoAvisoDTO TipoAvisos;
            TipoAvisos = facade.TipoAviso.getListadoTipoAviso().Where(x => x.IdTipoAviso == idTipoAviso).First();
            return TipoAvisos;
        }

        public static IList<TipoAvisoDTO> listaTipoAvisoActivo()
        {
            IList<TipoAvisoDTO> TipoAvisos;
            TipoAvisos = facade.TipoAviso.getListadoTipoAviso().Where(x => x.Estado == "1").ToList();
            return TipoAvisos;
        }

        public static IList<TipoAvisoDTO> listaTipoAvisoInactivo()
        {
            IList<TipoAvisoDTO> TipoAvisos;
            TipoAvisos = facade.TipoAviso.getListadoTipoAviso().Where(x => x.Estado == "2").ToList();
            return TipoAvisos;
        }

        public static bool Delete(DTO.Avisos.TipoAvisoDTO myTipoAvisoDTO)
        {
            bool resultado = TipoAvisoDAL.Delete(myTipoAvisoDTO);
            return resultado;
        }

        public static bool Insert(DTO.Avisos.TipoAvisoDTO myTipoAvisoDTO)
        {
            bool resultado = TipoAvisoDAL.Insert(myTipoAvisoDTO);
            return resultado;
        }

        public static bool Update(DTO.Avisos.TipoAvisoDTO myTipoAvisoDTO)
        {
            bool resultado = TipoAvisoDAL.Update(myTipoAvisoDTO);
            return resultado;
        }

        public static bool ActivaTipoAviso(TipoAvisoDTO theTipoAvisoDTO)
        {
            bool respuesta = TipoAvisoDAL.ActivaTipoAviso(theTipoAvisoDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionTipoAviso(TipoAvisoDTO theTipoAvisoDTO)
        {
            bool respuesta = facade.TipoAviso.ValidaEliminacionTipoAviso(theTipoAvisoDTO);
            return respuesta;
        }
    }
}
