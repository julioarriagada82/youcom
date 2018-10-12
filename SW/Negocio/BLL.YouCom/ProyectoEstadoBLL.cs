using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DAL;
using YouCom.DTO;

namespace YouCom.bll
{
    public class ProyectoEstadoBLL
    {
        /// <summary>
        /// Lista Eventos Operacion 
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns></returns>
        public static IList<ProyectoEstadoDTO> getListadoProyectoEstado()
        {
            var ProyectoEstado = YouCom.facade.ProyectoEstado.getListadoProyectoEstado();
            return ProyectoEstado;
        }

        public static ProyectoEstadoDTO detalleProyectoEstado(decimal idProyectoEstado)
        {
            ProyectoEstadoDTO ProyectoEstado;
            ProyectoEstado = facade.ProyectoEstado.getListadoProyectoEstado().Where(x => x.IdProyectoEstado == idProyectoEstado).First();
            return ProyectoEstado;
        }

        public static IList<ProyectoEstadoDTO> getListadoProyectoEstadoByCondominioByComunidad(decimal idCondominio, decimal idComunidad)
        {
            var estados = listaProyectoEstadoActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return estados;
        }

        public static IList<ProyectoEstadoDTO> listaProyectoEstadoActivo()
        {
            IList<ProyectoEstadoDTO> ProyectoEstado;
            ProyectoEstado = facade.ProyectoEstado.getListadoProyectoEstado().Where(x => x.Estado == "1").ToList();
            return ProyectoEstado;
        }

        public static IList<ProyectoEstadoDTO> listaProyectoEstadoInactivo()
        {
            IList<ProyectoEstadoDTO> ProyectoEstado;
            ProyectoEstado = facade.ProyectoEstado.getListadoProyectoEstado().Where(x => x.Estado == "2").ToList();
            return ProyectoEstado;
        }

        public static bool Delete(DTO.ProyectoEstadoDTO myProyectoEstadoDTO)
        {
            bool resultado = ProyectoEstadoDAL.Delete(myProyectoEstadoDTO);
            return resultado;
        }

        public static bool Insert(DTO.ProyectoEstadoDTO myProyectoEstadoDTO)
        {
            bool resultado = ProyectoEstadoDAL.Insert(myProyectoEstadoDTO);
            return resultado;
        }

        public static bool Update(DTO.ProyectoEstadoDTO myProyectoEstadoDTO)
        {
            bool resultado = ProyectoEstadoDAL.Update(myProyectoEstadoDTO);
            return resultado;
        }

        public static bool ActivaProyectoEstado(ProyectoEstadoDTO theProyectoEstadoDTO)
        {
            bool respuesta = ProyectoEstadoDAL.ActivaProyectoEstado(theProyectoEstadoDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionProyectoEstado(ProyectoEstadoDTO theProyectoEstadoDTO)
        {
            bool respuesta = facade.ProyectoEstado.ValidaEliminacionProyectoEstado(theProyectoEstadoDTO);
            return respuesta;
        }
    }
}
