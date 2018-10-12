using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class Ocupacion
    {
        public static IList<YouCom.DTO.Propietario.OcupacionDTO> getListadoOcupacion()
        {
            IList<YouCom.DTO.Propietario.OcupacionDTO> IOcupacion = new List<YouCom.DTO.Propietario.OcupacionDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.Propietario.OcupacionDAL.getListadoOcupacion(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Propietario.OcupacionDTO ocupacion = new YouCom.DTO.Propietario.OcupacionDTO();

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

        public static bool ValidaEliminacionOcupacion(YouCom.DTO.Propietario.OcupacionDTO theOcupacionDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.Propietario.OcupacionDAL.ValidaEliminacionOcupacion(theOcupacionDTO, ref pobjDataTable))
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
