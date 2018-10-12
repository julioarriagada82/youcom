using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.facade
{
    public class PropuestaEstado
    {
        public static IList<YouCom.DTO.PropuestaEstadoDTO> getListadoPropuestaEstado()
        {
            IList<YouCom.DTO.PropuestaEstadoDTO> IPropuestaEstado = new List<YouCom.DTO.PropuestaEstadoDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.PropuestaEstadoDAL.getListadoPropuestaEstado(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.PropuestaEstadoDTO PropuestaEstado = new YouCom.DTO.PropuestaEstadoDTO();

                    PropuestaEstado.IdPropuestaEstado = decimal.Parse(wobjDataRow["IdPropuestaEstado"].ToString());
                    PropuestaEstado.NombrePropuestaEstado = wobjDataRow["nombrePropuestaEstado"].ToString();

                    PropuestaEstado.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    PropuestaEstado.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    PropuestaEstado.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    PropuestaEstado.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    PropuestaEstado.Estado = wobjDataRow["estado"].ToString();

                    IPropuestaEstado.Add(PropuestaEstado);
                }
            }

            return IPropuestaEstado;

        }

        public static bool ValidaEliminacionPropuestaEstado(YouCom.DTO.PropuestaEstadoDTO thePropuestaEstadoDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.PropuestaEstadoDAL.ValidaEliminacionPropuestaEstado(thePropuestaEstadoDTO, ref pobjDataTable))
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
