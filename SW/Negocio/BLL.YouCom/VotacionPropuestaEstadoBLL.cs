using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.Propuesta;
using YouCom.DAL;

namespace YouCom.bll
{
    public class VotacionPropuestaEstadoBLL
    {
        /// <summary>
        /// Lista Eventos Operacion 
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns></returns>
        public static IList<VotacionPropuestaEstadoDTO> getListadoVotacionPropuestaEstado()
        {
            var VotacionPropuestaEstado = YouCom.facade.VotacionPropuestaEstado.getListadoVotacionPropuestaEstado();
            return VotacionPropuestaEstado;
        }

        public static VotacionPropuestaEstadoDTO detalleVotacionPropuestaEstado(decimal idVotacionPropuestaEstado)
        {
            VotacionPropuestaEstadoDTO VotacionPropuestaEstado;
            VotacionPropuestaEstado = facade.VotacionPropuestaEstado.getListadoVotacionPropuestaEstado().Where(x => x.IdVotacionPropuestaEstado == idVotacionPropuestaEstado).First();
            return VotacionPropuestaEstado;
        }

        public static IList<VotacionPropuestaEstadoDTO> getListadoVotacionPropuestaEstadoByCondominioByComunidad(decimal idCondominio, decimal idComunidad)
        {
            var estados = listaVotacionPropuestaEstadoActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return estados;
        }

        public static IList<VotacionPropuestaEstadoDTO> listaVotacionPropuestaEstadoActivo()
        {
            IList<VotacionPropuestaEstadoDTO> VotacionPropuestaEstado;
            VotacionPropuestaEstado = facade.VotacionPropuestaEstado.getListadoVotacionPropuestaEstado().Where(x => x.Estado == "1").ToList();
            return VotacionPropuestaEstado;
        }

        public static IList<VotacionPropuestaEstadoDTO> listaVotacionPropuestaEstadoInactivo()
        {
            IList<VotacionPropuestaEstadoDTO> VotacionPropuestaEstado;
            VotacionPropuestaEstado = facade.VotacionPropuestaEstado.getListadoVotacionPropuestaEstado().Where(x => x.Estado == "2").ToList();
            return VotacionPropuestaEstado;
        }

        public static bool Delete(VotacionPropuestaEstadoDTO myVotacionPropuestaEstadoDTO)
        {
            bool resultado = VotacionPropuestaEstadoDAL.Delete(myVotacionPropuestaEstadoDTO);
            return resultado;
        }

        public static bool Insert(VotacionPropuestaEstadoDTO myVotacionPropuestaEstadoDTO)
        {
            bool resultado = VotacionPropuestaEstadoDAL.Insert(myVotacionPropuestaEstadoDTO);
            return resultado;
        }

        public static bool Update(VotacionPropuestaEstadoDTO myVotacionPropuestaEstadoDTO)
        {
            bool resultado = VotacionPropuestaEstadoDAL.Update(myVotacionPropuestaEstadoDTO);
            return resultado;
        }

        public static bool ActivaVotacionPropuestaEstado(VotacionPropuestaEstadoDTO theVotacionPropuestaEstadoDTO)
        {
            bool respuesta = VotacionPropuestaEstadoDAL.ActivaVotacionPropuestaEstado(theVotacionPropuestaEstadoDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionVotacionPropuestaEstado(VotacionPropuestaEstadoDTO theVotacionPropuestaEstadoDTO)
        {
            bool respuesta = facade.VotacionPropuestaEstado.ValidaEliminacionVotacionPropuestaEstado(theVotacionPropuestaEstadoDTO);
            return respuesta;
        }
    }
}
