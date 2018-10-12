using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DAL;
using YouCom.DTO;

namespace YouCom.bll
{
    public class ProyectoBLL
    {
        /// <summary>
        /// Lista Eventos Operacion 
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns></returns>
        public static IList<ProyectoDTO> getListadoProyecto()
        {
            YouCom.facade.Proyecto ProyectoFA = new YouCom.facade.Proyecto();
            var Proyecto = YouCom.facade.Proyecto.getListadoProyecto();
            return Proyecto;
        }

        public static ProyectoDTO detalleProyecto(decimal idProyecto)
        {
            ProyectoDTO Proyectos;
            Proyectos = facade.Proyecto.getListadoProyecto().Where(x => x.IdProyecto == idProyecto).First();
            return Proyectos;
        }

        public static IList<ProyectoDTO> getListadoProyectoByCondominioByComunidad(decimal idCondominio, decimal idComunidad)
        {
            var proyectos = listaProyectoActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return proyectos;
        }

        public static IList<ProyectoDTO> listaProyectoActivo()
        {
            IList<ProyectoDTO> Proyectos;
            Proyectos = facade.Proyecto.getListadoProyecto().Where(x => x.Estado == "1").ToList();
            return Proyectos;
        }

        public static IList<ProyectoDTO> listaProyectoInactivo()
        {
            IList<ProyectoDTO> Proyectos;
            Proyectos = facade.Proyecto.getListadoProyecto().Where(x => x.Estado == "2").ToList();
            return Proyectos;
        }

        public static bool Delete(DTO.ProyectoDTO myProyectoDTO)
        {
            bool resultado = ProyectoDAL.Delete(myProyectoDTO);
            return resultado;
        }

        public static bool Insert(DTO.ProyectoDTO myProyectoDTO)
        {
            bool resultado = ProyectoDAL.Insert(myProyectoDTO);
            return resultado;
        }

        public static bool Update(DTO.ProyectoDTO myProyectoDTO)
        {
            bool resultado = ProyectoDAL.Update(myProyectoDTO);
            return resultado;
        }

        public static bool ActivaProyecto(ProyectoDTO theProyectoDTO)
        {
            bool respuesta = YouCom.DAL.ProyectoDAL.ActivaProyecto(theProyectoDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionProyecto(ProyectoDTO theProyectoDTO)
        {
            bool respuesta = facade.Proyecto.ValidaEliminacionProyecto(theProyectoDTO);
            return respuesta;
        }
    }
}
