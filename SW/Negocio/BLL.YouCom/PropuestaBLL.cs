using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DAL;
using YouCom.DTO.Propuesta;

namespace YouCom.bll
{
    public class PropuestaBLL
    {
        /// <summary>
        /// Lista Eventos Operacion 
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns></returns>
        public static IList<PropuestaDTO> getListadoPropuesta()
        {
            YouCom.facade.Propuesta PropuestaFA = new YouCom.facade.Propuesta();
            var Propuesta = YouCom.facade.Propuesta.getListadoPropuesta();
            return Propuesta;
        }

        public static PropuestaDTO detallePropuesta(decimal idPropuesta)
        {
            PropuestaDTO Propuestas;
            Propuestas = facade.Propuesta.getListadoPropuesta().Where(x => x.IdPropuesta == idPropuesta).First();
            return Propuestas;
        }

        public static IList<PropuestaDTO> getListadoPropuestaByCondominioByComunidad(decimal idCondominio, decimal idComunidad)
        {
            var Propuestas = listaPropuestaActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return Propuestas;
        }

        public static IList<PropuestaDTO> listaPropuestaActivo()
        {
            IList<PropuestaDTO> Propuestas;
            Propuestas = facade.Propuesta.getListadoPropuesta().Where(x => x.Estado == "1").ToList();
            return Propuestas;
        }

        public static IList<PropuestaDTO> listaPropuestaInactivo()
        {
            IList<PropuestaDTO> Propuestas;
            Propuestas = facade.Propuesta.getListadoPropuesta().Where(x => x.Estado == "2").ToList();
            return Propuestas;
        }

        public static bool Delete(DTO.Propuesta.PropuestaDTO myPropuestaDTO)
        {
            bool resultado = PropuestaDAL.Delete(myPropuestaDTO);
            return resultado;
        }

        public static bool Insert(DTO.Propuesta.PropuestaDTO myPropuestaDTO)
        {
            bool resultado = PropuestaDAL.Insert(myPropuestaDTO);
            return resultado;
        }

        public static bool Update(DTO.Propuesta.PropuestaDTO myPropuestaDTO)
        {
            bool resultado = PropuestaDAL.Update(myPropuestaDTO);
            return resultado;
        }

        public static bool ActivaPropuesta(PropuestaDTO thePropuestaDTO)
        {
            bool respuesta = YouCom.DAL.PropuestaDAL.ActivaPropuesta(thePropuestaDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionPropuesta(PropuestaDTO thePropuestaDTO)
        {
            bool respuesta = facade.Propuesta.ValidaEliminacionPropuesta(thePropuestaDTO);
            return respuesta;
        }
    }
}
