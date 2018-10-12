using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.AccesoHogar;
using YouCom.DAL.AccesoHogar;

namespace YouCom.bll.AccesoHogar
{
    public class TipoVisitaBLL
    {
        public static IList<TipoVisitaDTO> getListadoTipoVisita()
        {
            YouCom.facade.TipoVisita TipoVisitaFA = new YouCom.facade.TipoVisita();
            var TipoVisita = YouCom.facade.TipoVisita.getListadoTipoVisita();
            return TipoVisita;
        }

        public static TipoVisitaDTO detalleTipoVisita(decimal idTipoVisita)
        {
            TipoVisitaDTO TipoVisitas;
            TipoVisitas = facade.TipoVisita.getListadoTipoVisita().Where(x => x.IdTipoVisita == idTipoVisita).First();
            return TipoVisitas;
        }

        public static IList<TipoVisitaDTO> listaTipoVisitaActivo()
        {
            IList<TipoVisitaDTO> TipoVisitas;
            TipoVisitas = facade.TipoVisita.getListadoTipoVisita().Where(x => x.Estado == "1").ToList();
            return TipoVisitas;
        }

        public static IList<TipoVisitaDTO> listaTipoVisitaInactivo()
        {
            IList<TipoVisitaDTO> TipoVisitas;
            TipoVisitas = facade.TipoVisita.getListadoTipoVisita().Where(x => x.Estado == "2").ToList();
            return TipoVisitas;
        }

        public static bool Delete(TipoVisitaDTO myTipoVisitaDTO)
        {
            bool resultado = TipoVisitaDAL.Delete(myTipoVisitaDTO);
            return resultado;
        }

        public static bool Insert(TipoVisitaDTO myTipoVisitaDTO)
        {
            bool resultado = TipoVisitaDAL.Insert(myTipoVisitaDTO);
            return resultado;
        }

        public static bool Update(TipoVisitaDTO myTipoVisitaDTO)
        {
            bool resultado = TipoVisitaDAL.Update(myTipoVisitaDTO);
            return resultado;
        }

        public static bool ActivaTipoVisita(TipoVisitaDTO theTipoVisitaDTO)
        {
            bool respuesta = TipoVisitaDAL.ActivaTipoVisita(theTipoVisitaDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionTipoVisita(TipoVisitaDTO theTipoVisitaDTO)
        {
            bool respuesta = facade.TipoVisita.ValidaEliminacionTipoVisita(theTipoVisitaDTO);
            return respuesta;
        }
    }
}
