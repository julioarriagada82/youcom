using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.facade
{
    public class VotacionPropuestaEstado
    {
        public static IList<YouCom.DTO.Propuesta.VotacionPropuestaEstadoDTO> getListadoVotacionPropuestaEstado()
        {
            IList<YouCom.DTO.Propuesta.VotacionPropuestaEstadoDTO> IVotacionPropuestaEstado = new List<YouCom.DTO.Propuesta.VotacionPropuestaEstadoDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.VotacionPropuestaEstadoDAL.getListadoVotacionPropuestaEstado(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Propuesta.VotacionPropuestaEstadoDTO VotacionPropuestaEstado = new YouCom.DTO.Propuesta.VotacionPropuestaEstadoDTO();

                    VotacionPropuestaEstado.IdVotacionPropuestaEstado = decimal.Parse(wobjDataRow["IdVotacionPropuestaEstado"].ToString());
                    VotacionPropuestaEstado.NombreVotacionPropuestaEstado = wobjDataRow["nombreVotacionPropuestaEstado"].ToString();

                    VotacionPropuestaEstado.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    VotacionPropuestaEstado.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    VotacionPropuestaEstado.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    VotacionPropuestaEstado.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    VotacionPropuestaEstado.Estado = wobjDataRow["estado"].ToString();

                    IVotacionPropuestaEstado.Add(VotacionPropuestaEstado);
                }
            }

            return IVotacionPropuestaEstado;

        }

        public static bool ValidaEliminacionVotacionPropuestaEstado(YouCom.DTO.Propuesta.VotacionPropuestaEstadoDTO theVotacionPropuestaEstadoDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.VotacionPropuestaEstadoDAL.ValidaEliminacionVotacionPropuestaEstado(theVotacionPropuestaEstadoDTO, ref pobjDataTable))
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
