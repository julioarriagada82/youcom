using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DAL;
using YouCom.DTO.Propuesta;

namespace YouCom.bll
{
    public class VotacionPropuestaRespuestaBLL
    {
        /// <summary>
        /// Lista Eventos Operacion 
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns></returns>
        public static IList<VotacionPropuestaRespuestaDTO> getListadoVotacionPropuestaRespuesta()
        {
            var Propuesta = facade.VotacionPropuestaRespuesta.getListadoVotacionPropuestaRespuesta();
            return Propuesta;
        }

        public static IList<VotacionPropuestaRespuestaDTO> getListadoVotacionPropuestaRespuestaByVotacion(decimal idVotacionPropuesta)
        {
            IList<VotacionPropuestaRespuestaDTO> theVotacionPropuestaRespuestaDTO = new List<VotacionPropuestaRespuestaDTO>();
            
            theVotacionPropuestaRespuestaDTO = facade.VotacionPropuestaRespuesta.getListadoVotacionPropuestaRespuesta();

            if (theVotacionPropuestaRespuestaDTO.Any())
            {
                theVotacionPropuestaRespuestaDTO = theVotacionPropuestaRespuestaDTO.Where(x => x.TheVotacionPropuestaDTO.IdVotacionPropuesta == idVotacionPropuesta).ToList();
            }

            return theVotacionPropuestaRespuestaDTO;
        }

        public static VotacionPropuestaRespuestaDTO detalleVotacionPropuestaRespuesta(decimal idVotacionPropuesta, decimal idFamilia)
        {
            IList<VotacionPropuestaRespuestaDTO> theVotacionPropuestaRespuestaDTO = new List<VotacionPropuestaRespuestaDTO>();
            VotacionPropuestaRespuestaDTO myVotacionPropuestaRespuestaDTO = new VotacionPropuestaRespuestaDTO();
            theVotacionPropuestaRespuestaDTO = facade.VotacionPropuestaRespuesta.getListadoVotacionPropuestaRespuesta();
            
            if(theVotacionPropuestaRespuestaDTO.Any())
            {
                myVotacionPropuestaRespuestaDTO = theVotacionPropuestaRespuestaDTO.Where(x => x.TheVotacionPropuestaDTO.IdVotacionPropuesta == idVotacionPropuesta && x.TheFamiliaDTO.IdFamilia == idFamilia).First();
            }

            return myVotacionPropuestaRespuestaDTO;
        }

        public static bool Delete(DTO.Propuesta.VotacionPropuestaRespuestaDTO myVotacionPropuestaRespuestaDTO)
        {
            bool resultado = VotacionPropuestaRespuestaDAL.Delete(myVotacionPropuestaRespuestaDTO);
            return resultado;
        }

        public static bool Insert(DTO.Propuesta.VotacionPropuestaRespuestaDTO myVotacionPropuestaRespuestaDTO)
        {
            bool resultado = VotacionPropuestaRespuestaDAL.Insert(myVotacionPropuestaRespuestaDTO);
            return resultado;
        }


        public static bool ActivaPropuesta(VotacionPropuestaRespuestaDTO theVotacionPropuestaRespuestaDTO)
        {
            bool respuesta = YouCom.DAL.VotacionPropuestaRespuestaDAL.ActivaVotacionPropuestaRespuesta(theVotacionPropuestaRespuestaDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionPropuesta(VotacionPropuestaRespuestaDTO theVotacionPropuestaRespuestaDTO)
        {
            bool respuesta = facade.VotacionPropuestaRespuesta.ValidaEliminacionVotacionPropuestaRespuesta(theVotacionPropuestaRespuestaDTO);
            return respuesta;
        }
    }
}
