using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class Ocupacion
    {
        public static IList<YouCom.DTO.OcupacionDTO> getListadoOcupacion()
        {
            IList<YouCom.DTO.OcupacionDTO> IOcupacion = new List<YouCom.DTO.OcupacionDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.OcupacionDAL.getListadoOcupacion(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.OcupacionDTO ocupacion = new YouCom.DTO.OcupacionDTO();

                    ocupacion.IdOcupacion = decimal.Parse(wobjDataRow["IdOcupacion"].ToString());
                    ocupacion.NombreOcupacion = wobjDataRow["nombreOcupacion"].ToString();

                    ocupacion.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    ocupacion.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    ocupacion.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    ocupacion.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    ocupacion.Estado = wobjDataRow["estado"].ToString();

                    IOcupacion.Add(ocupacion);
                }
            }

            return IOcupacion;

        }

        public static bool ValidaEliminacionOcupacion(YouCom.DTO.OcupacionDTO theOcupacionDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.OcupacionDAL.ValidaEliminacionOcupacion(theOcupacionDTO, ref pobjDataTable))
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
