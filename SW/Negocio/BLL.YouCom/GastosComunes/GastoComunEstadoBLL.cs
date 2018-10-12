using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.bll.GastosComunes
{
    public class GastoComunEstadoBLL
    {
        /// <summary>
        /// Lista Eventos Operacion 
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns></returns>
        public static IList<YouCom.DTO.GastosComunes.GastoComunEstadoDTO> getListadoGastoComunEstado()
        {
            var GastoComunEstado = YouCom.facade.GastosComunes.GastoComunEstado.getListadoGastoComunEstado();
            return GastoComunEstado;
        }

        public static YouCom.DTO.GastosComunes.GastoComunEstadoDTO detalleGastoComunEstado(decimal idGastoComunEstado)
        {
            YouCom.DTO.GastosComunes.GastoComunEstadoDTO GastoComunEstado;
            GastoComunEstado = facade.GastosComunes.GastoComunEstado.getListadoGastoComunEstado().Where(x => x.IdGastoComunEstado == idGastoComunEstado).First();
            return GastoComunEstado;
        }

        public static IList<YouCom.DTO.GastosComunes.GastoComunEstadoDTO> getListadoGastoComunEstadoByCondominioByComunidad(decimal idCondominio, decimal idComunidad)
        {
            var estados = listaGastoComunEstadoActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return estados;
        }

        public static IList<YouCom.DTO.GastosComunes.GastoComunEstadoDTO> listaGastoComunEstadoActivo()
        {
            IList<YouCom.DTO.GastosComunes.GastoComunEstadoDTO> GastoComunEstado;
            GastoComunEstado = facade.GastosComunes.GastoComunEstado.getListadoGastoComunEstado().Where(x => x.Estado == "1").ToList();
            return GastoComunEstado;
        }

        public static IList<YouCom.DTO.GastosComunes.GastoComunEstadoDTO> listaGastoComunEstadoInactivo()
        {
            IList<YouCom.DTO.GastosComunes.GastoComunEstadoDTO> GastoComunEstado;
            GastoComunEstado = facade.GastosComunes.GastoComunEstado.getListadoGastoComunEstado().Where(x => x.Estado == "2").ToList();
            return GastoComunEstado;
        }

        public static bool Delete(YouCom.DTO.GastosComunes.GastoComunEstadoDTO myGastoComunEstadoDTO)
        {
            bool resultado = DAL.GastosComunes.GastoComunEstadoDAL.Delete(myGastoComunEstadoDTO);
            return resultado;
        }

        public static bool Insert(YouCom.DTO.GastosComunes.GastoComunEstadoDTO myGastoComunEstadoDTO)
        {
            bool resultado = DAL.GastosComunes.GastoComunEstadoDAL.Insert(myGastoComunEstadoDTO);
            return resultado;
        }

        public static bool Update(YouCom.DTO.GastosComunes.GastoComunEstadoDTO myGastoComunEstadoDTO)
        {
            bool resultado = DAL.GastosComunes.GastoComunEstadoDAL.Update(myGastoComunEstadoDTO);
            return resultado;
        }

        public static bool ActivaGastoComunEstado(YouCom.DTO.GastosComunes.GastoComunEstadoDTO theGastoComunEstadoDTO)
        {
            bool respuesta = DAL.GastosComunes.GastoComunEstadoDAL.ActivaGastoComunEstado(theGastoComunEstadoDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionGastoComunEstado(YouCom.DTO.GastosComunes.GastoComunEstadoDTO theGastoComunEstadoDTO)
        {
            bool respuesta = facade.GastosComunes.GastoComunEstado.ValidaEliminacionGastoComunEstado(theGastoComunEstadoDTO);
            return respuesta;
        }
    }
}
