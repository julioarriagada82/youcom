using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.Avisos;
using YouCom.DAL;

namespace YouCom.bll.Avisos
{
    public class AvisoEstadoBLL
    {
        /// <summary>
        /// Lista Eventos Operacion 
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns></returns>
        public static IList<AvisoEstadoDTO> getListadoAvisoEstado()
        {
            var AvisoEstado = YouCom.facade.Avisos.AvisoEstado.getListadoAvisoEstado();
            return AvisoEstado;
        }

        public static AvisoEstadoDTO detalleAvisoEstado(decimal idAvisoEstado)
        {
            AvisoEstadoDTO AvisoEstado;
            AvisoEstado = facade.Avisos.AvisoEstado.getListadoAvisoEstado().Where(x => x.IdAvisoEstado == idAvisoEstado).First();
            return AvisoEstado;
        }

        public static IList<AvisoEstadoDTO> getListadoAvisoEstadoByCondominioByComunidad(decimal idCondominio, decimal idComunidad)
        {
            var estados = listaAvisoEstadoActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return estados;
        }

        public static IList<AvisoEstadoDTO> listaAvisoEstadoActivo()
        {
            IList<AvisoEstadoDTO> AvisoEstado;
            AvisoEstado = facade.Avisos.AvisoEstado.getListadoAvisoEstado().Where(x => x.Estado == "1").ToList();
            return AvisoEstado;
        }

        public static IList<AvisoEstadoDTO> listaAvisoEstadoInactivo()
        {
            IList<AvisoEstadoDTO> AvisoEstado;
            AvisoEstado = facade.Avisos.AvisoEstado.getListadoAvisoEstado().Where(x => x.Estado == "2").ToList();
            return AvisoEstado;
        }

        public static bool Delete(AvisoEstadoDTO myAvisoEstadoDTO)
        {
            bool resultado = AvisoEstadoDAL.Delete(myAvisoEstadoDTO);
            return resultado;
        }

        public static bool Insert(AvisoEstadoDTO myAvisoEstadoDTO)
        {
            bool resultado = AvisoEstadoDAL.Insert(myAvisoEstadoDTO);
            return resultado;
        }

        public static bool Update(AvisoEstadoDTO myAvisoEstadoDTO)
        {
            bool resultado = AvisoEstadoDAL.Update(myAvisoEstadoDTO);
            return resultado;
        }

        public static bool ActivaAvisoEstado(AvisoEstadoDTO theAvisoEstadoDTO)
        {
            bool respuesta = AvisoEstadoDAL.ActivaAvisoEstado(theAvisoEstadoDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionAvisoEstado(AvisoEstadoDTO theAvisoEstadoDTO)
        {
            bool respuesta = facade.Avisos.AvisoEstado.ValidaEliminacionAvisoEstado(theAvisoEstadoDTO);
            return respuesta;
        }
    }
}
