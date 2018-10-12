using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class Emergencia
    {
        public static IList<YouCom.DTO.EmergenciaDTO> getListadoEmergencia()
        {
            IList<YouCom.DTO.EmergenciaDTO> IEmergencia = new List<YouCom.DTO.EmergenciaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.EmergenciaDAL.getListadoEmergencia(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.EmergenciaDTO Emergencia = new YouCom.DTO.EmergenciaDTO();

                    Emergencia.IdEmergencia = decimal.Parse(wobjDataRow["IdEmergencia"].ToString());
                    Emergencia.NombreEmergencia = wobjDataRow["nombreEmergencia"].ToString();
                    Emergencia.DescripcionEmergencia = wobjDataRow["descripcionEmergencia"].ToString();
                    
                    Emergencia.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    Emergencia.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    Emergencia.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    Emergencia.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    Emergencia.Estado = wobjDataRow["estado"].ToString();

                    IEmergencia.Add(Emergencia);
                }
            }

            return IEmergencia;

        }

        public static bool ValidaEliminacionEmergencia(YouCom.DTO.EmergenciaDTO theEmergenciaDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.EmergenciaDAL.ValidaEliminacionEmergencia(theEmergenciaDTO, ref pobjDataTable))
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
