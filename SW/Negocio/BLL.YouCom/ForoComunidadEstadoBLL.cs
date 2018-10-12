using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.Foro;
using YouCom.DAL;

namespace YouCom.bll
{
    public class ForoComunidadEstadoBLL
    {
        /// <summary>
        /// Lista Eventos Operacion 
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns></returns>
        public static IList<ForoComunidadEstadoDTO> getListadoForoComunidadEstado()
        {
            var ForoComunidadEstado = YouCom.facade.Foro.ForoComunidadEstado.getListadoForoComunidadEstado();
            return ForoComunidadEstado;
        }

        public static ForoComunidadEstadoDTO detalleForoComunidadEstado(decimal idForoComunidadEstado)
        {
            ForoComunidadEstadoDTO ForoComunidadEstado;
            ForoComunidadEstado = facade.Foro.ForoComunidadEstado.getListadoForoComunidadEstado().Where(x => x.IdForoComunidadEstado == idForoComunidadEstado).First();
            return ForoComunidadEstado;
        }

        public static IList<ForoComunidadEstadoDTO> getListadoForoComunidadEstadoByCondominioByComunidad(decimal idCondominio, decimal idComunidad)
        {
            var estados = listaForoComunidadEstadoActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return estados;
        }

        public static IList<ForoComunidadEstadoDTO> listaForoComunidadEstadoActivo()
        {
            IList<ForoComunidadEstadoDTO> ForoComunidadEstado;
            ForoComunidadEstado = facade.Foro.ForoComunidadEstado.getListadoForoComunidadEstado().Where(x => x.Estado == "1").ToList();
            return ForoComunidadEstado;
        }

        public static IList<ForoComunidadEstadoDTO> listaForoComunidadEstadoInactivo()
        {
            IList<ForoComunidadEstadoDTO> ForoComunidadEstado;
            ForoComunidadEstado = facade.Foro.ForoComunidadEstado.getListadoForoComunidadEstado().Where(x => x.Estado == "2").ToList();
            return ForoComunidadEstado;
        }

        public static bool Delete(ForoComunidadEstadoDTO myForoComunidadEstadoDTO)
        {
            bool resultado = ForoComunidadEstadoDAL.Delete(myForoComunidadEstadoDTO);
            return resultado;
        }

        public static bool Insert(ForoComunidadEstadoDTO myForoComunidadEstadoDTO)
        {
            bool resultado = ForoComunidadEstadoDAL.Insert(myForoComunidadEstadoDTO);
            return resultado;
        }

        public static bool Update(ForoComunidadEstadoDTO myForoComunidadEstadoDTO)
        {
            bool resultado = ForoComunidadEstadoDAL.Update(myForoComunidadEstadoDTO);
            return resultado;
        }

        public static bool ActivaForoComunidadEstado(ForoComunidadEstadoDTO theForoComunidadEstadoDTO)
        {
            bool respuesta = ForoComunidadEstadoDAL.ActivaForoComunidadEstado(theForoComunidadEstadoDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionForoComunidadEstado(ForoComunidadEstadoDTO theForoComunidadEstadoDTO)
        {
            bool respuesta = facade.Foro.ForoComunidadEstado.ValidaEliminacionForoComunidadEstado(theForoComunidadEstadoDTO);
            return respuesta;
        }
    }
}
