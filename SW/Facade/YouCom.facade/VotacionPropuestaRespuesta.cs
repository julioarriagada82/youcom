using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.facade
{
    public class VotacionPropuestaRespuesta
    {
        public static IList<YouCom.DTO.Propuesta.VotacionPropuestaRespuestaDTO> getListadoVotacionPropuestaRespuesta()
        {
            IList<YouCom.DTO.Propuesta.VotacionPropuestaRespuestaDTO> IVotacionPropuesta = new List<YouCom.DTO.Propuesta.VotacionPropuestaRespuestaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.VotacionPropuestaRespuestaDAL.getListadoVotacionPropuestaRespuesta(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Propuesta.VotacionPropuestaRespuestaDTO votacion = new YouCom.DTO.Propuesta.VotacionPropuestaRespuestaDTO();

                    YouCom.DTO.Propuesta.VotacionPropuestaDTO myVotacionPropuestaDTO = new YouCom.DTO.Propuesta.VotacionPropuestaDTO();
                    myVotacionPropuestaDTO.IdVotacionPropuesta = decimal.Parse(wobjDataRow["idVotacionPropuesta"].ToString());
                    votacion.TheVotacionPropuestaDTO = myVotacionPropuestaDTO;

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                    myFamiliaDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamilia"].ToString());
                    myFamiliaDTO.NombreFamilia = wobjDataRow["nombreFamilia"].ToString();
                    myFamiliaDTO.ApellidoPaternoFamilia = wobjDataRow["apellidoPaternoFamilia"].ToString();
                    myFamiliaDTO.ApellidoMaternoFamilia = wobjDataRow["apellidoMaternoFamilia"].ToString();
                    votacion.TheFamiliaDTO = myFamiliaDTO;

                    votacion.FechaVotacion = Convert.ToDateTime(wobjDataRow["fechaVotacion"].ToString());
                    votacion.EleccionVotacion = wobjDataRow["eleccionVotacion"].ToString() == "S" ? "SI" : "NO";
                    
                    IVotacionPropuesta.Add(votacion);
                }
            }

            return IVotacionPropuesta;

        }

        public static bool ValidaEliminacionVotacionPropuestaRespuesta(YouCom.DTO.Propuesta.VotacionPropuestaRespuestaDTO theVotacionPropuestaRespuestaDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.VotacionPropuestaRespuestaDAL.ValidaEliminacionVotacionPropuestaRespuesta(theVotacionPropuestaRespuestaDTO, ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    retorno = true;
                }
            }

            return retorno;
        }
    }
}
