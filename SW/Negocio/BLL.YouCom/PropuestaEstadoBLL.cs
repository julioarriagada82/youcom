using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL;

namespace YouCom.bll
{
    public class PropuestaEstadoBLL
    {
        /// <summary>
        /// Lista Eventos Operacion 
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns></returns>
        public static IList<PropuestaEstadoDTO> getListadoPropuestaEstado()
        {
            var PropuestaEstado = YouCom.facade.PropuestaEstado.getListadoPropuestaEstado();
            return PropuestaEstado;
        }

        public static PropuestaEstadoDTO detallePropuestaEstado(decimal idPropuestaEstado)
        {
            PropuestaEstadoDTO PropuestaEstado;
            PropuestaEstado = facade.PropuestaEstado.getListadoPropuestaEstado().Where(x => x.IdPropuestaEstado == idPropuestaEstado).First();
            return PropuestaEstado;
        }

        public static IList<PropuestaEstadoDTO> getListadoPropuestaEstadoByCondominioByComunidad(decimal idCondominio, decimal idComunidad)
        {
            var estados = listaPropuestaEstadoActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return estados;
        }

        public static IList<PropuestaEstadoDTO> listaPropuestaEstadoActivo()
        {
            IList<PropuestaEstadoDTO> PropuestaEstado;
            PropuestaEstado = facade.PropuestaEstado.getListadoPropuestaEstado().Where(x => x.Estado == "1").ToList();
            return PropuestaEstado;
        }

        public static IList<PropuestaEstadoDTO> listaPropuestaEstadoInactivo()
        {
            IList<PropuestaEstadoDTO> PropuestaEstado;
            PropuestaEstado = facade.PropuestaEstado.getListadoPropuestaEstado().Where(x => x.Estado == "2").ToList();
            return PropuestaEstado;
        }

        public static bool Delete(DTO.PropuestaEstadoDTO myPropuestaEstadoDTO)
        {
            bool resultado = PropuestaEstadoDAL.Delete(myPropuestaEstadoDTO);
            return resultado;
        }

        public static bool Insert(DTO.PropuestaEstadoDTO myPropuestaEstadoDTO)
        {
            bool resultado = PropuestaEstadoDAL.Insert(myPropuestaEstadoDTO);
            return resultado;
        }

        public static bool Update(DTO.PropuestaEstadoDTO myPropuestaEstadoDTO)
        {
            bool resultado = PropuestaEstadoDAL.Update(myPropuestaEstadoDTO);
            return resultado;
        }

        public static bool ActivaPropuestaEstado(PropuestaEstadoDTO thePropuestaEstadoDTO)
        {
            bool respuesta = PropuestaEstadoDAL.ActivaPropuestaEstado(thePropuestaEstadoDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionPropuestaEstado(PropuestaEstadoDTO thePropuestaEstadoDTO)
        {
            bool respuesta = facade.PropuestaEstado.ValidaEliminacionPropuestaEstado(thePropuestaEstadoDTO);
            return respuesta;
        }
    }
}
