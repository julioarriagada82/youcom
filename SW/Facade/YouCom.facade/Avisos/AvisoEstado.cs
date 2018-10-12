using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.facade.Avisos
{
    public class AvisoEstado
    {
        public static IList<YouCom.DTO.Avisos.AvisoEstadoDTO> getListadoAvisoEstado()
        {
            IList<YouCom.DTO.Avisos.AvisoEstadoDTO> IAvisoEstado = new List<YouCom.DTO.Avisos.AvisoEstadoDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.AvisoEstadoDAL.getListadoAvisoEstado(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Avisos.AvisoEstadoDTO avisos = new YouCom.DTO.Avisos.AvisoEstadoDTO();

                    avisos.IdAvisoEstado = decimal.Parse(wobjDataRow["IdAvisoEstado"].ToString());
                    avisos.NombreAvisoEstado = wobjDataRow["nombreAvisoEstado"].ToString();

                    avisos.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    avisos.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    avisos.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    avisos.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    avisos.Estado = wobjDataRow["estado"].ToString();

                    IAvisoEstado.Add(avisos);
                }
            }

            return IAvisoEstado;

        }

        public static bool ValidaEliminacionAvisoEstado(YouCom.DTO.Avisos.AvisoEstadoDTO theAvisoEstadoDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.AvisoEstadoDAL.ValidaEliminacionAvisoEstado(theAvisoEstadoDTO, ref pobjDataTable))
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
