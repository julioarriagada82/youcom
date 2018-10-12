using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DAL;
using YouCom.DTO.Propuesta;

namespace YouCom.bll
{
    public class VotacionPropuestaBLL
    {
        /// <summary>
        /// Lista Eventos Operacion 
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns></returns>
        public static IList<VotacionPropuestaDTO> getListadoVotacionPropuesta()
        {
            var Propuesta = YouCom.facade.VotacionPropuesta.getListadoVotacionPropuesta();
            return Propuesta;
        }

        public static VotacionPropuestaDTO detalleVotacionPropuesta(decimal idVotacionPropuesta)
        {
            VotacionPropuestaDTO Propuestas;
            Propuestas = facade.VotacionPropuesta.getListadoVotacionPropuesta().Where(x => x.IdVotacionPropuesta == idVotacionPropuesta).First();
            return Propuestas;
        }

        public static IList<VotacionPropuestaDTO> getListadoVotacionPropuestaByCondominioByComunidad(decimal idCondominio, decimal idComunidad)
        {
            var Propuestas = listaVotacionPropuestaActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return Propuestas;
        }

        public static IList<VotacionPropuestaDTO> listaVotacionPropuestaActivo()
        {
            IList<VotacionPropuestaDTO> Propuestas;
            Propuestas = facade.VotacionPropuesta.getListadoVotacionPropuesta().Where(x => x.Estado == "1").ToList();
            return Propuestas;
        }

        public static IList<VotacionPropuestaDTO> listaVotacionPropuestaInactivo()
        {
            IList<VotacionPropuestaDTO> Propuestas;
            Propuestas = facade.VotacionPropuesta.getListadoVotacionPropuesta().Where(x => x.Estado == "2").ToList();
            return Propuestas;
        }

        public static bool Delete(DTO.Propuesta.VotacionPropuestaDTO myVotacionPropuestaDTO)
        {
            bool resultado = VotacionPropuestaDAL.Delete(myVotacionPropuestaDTO);
            return resultado;
        }

        public static bool Insert(DTO.Propuesta.VotacionPropuestaDTO myVotacionPropuestaDTO)
        {
            bool resultado = VotacionPropuestaDAL.Insert(myVotacionPropuestaDTO);
            return resultado;
        }

        public static bool Update(DTO.Propuesta.VotacionPropuestaDTO myVotacionPropuestaDTO)
        {
            bool resultado = VotacionPropuestaDAL.Update(myVotacionPropuestaDTO);
            return resultado;
        }

        public static bool ActivaVotacionPropuesta(VotacionPropuestaDTO theVotacionPropuestaDTO)
        {
            bool respuesta = YouCom.DAL.VotacionPropuestaDAL.ActivaVotacionPropuesta(theVotacionPropuestaDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionPropuesta(VotacionPropuestaDTO theVotacionPropuestaDTO)
        {
            bool respuesta = facade.VotacionPropuesta.ValidaEliminacionPropuesta(theVotacionPropuestaDTO);
            return respuesta;
        }
    }
}
