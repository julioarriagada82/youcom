using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class Emergencia
    {
        public static IList<YouCom.DTO.Emergencia.EmergenciaDTO> getListadoEmergencia()
        {
            IList<YouCom.DTO.Emergencia.EmergenciaDTO> IEmergencia = new List<YouCom.DTO.Emergencia.EmergenciaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.Emergencia.EmergenciaDAL.getListadoEmergencia(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Emergencia.EmergenciaDTO emergencia = new YouCom.DTO.Emergencia.EmergenciaDTO();

                    emergencia.IdEmergencia = decimal.Parse(wobjDataRow["IdEmergencia"].ToString());
                    
                    YouCom.DTO.Emergencia.TipoEmergenciaDTO myTipoEmergenciaDTO = new YouCom.DTO.Emergencia.TipoEmergenciaDTO();
                    myTipoEmergenciaDTO.IdTipoEmergencia = decimal.Parse(wobjDataRow["idTipoEmergencia"].ToString());
                    emergencia.TheTipoEmergenciaDTO = myTipoEmergenciaDTO;

                    emergencia.TheTipoEmergenciaDTO.NombreTipoEmergencia = wobjDataRow["nombreTipoEmergencia"].ToString();
                    emergencia.NombreEmergencia = wobjDataRow["nombreEmergencia"].ToString();
                    emergencia.DescripcionEmergencia = wobjDataRow["descripcionEmergencia"].ToString();

                    YouCom.DTO.Seguridad.CondominioDTO myCondominio = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominio.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    emergencia.TheCondominioDTO = myCondominio;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    emergencia.TheComunidadDTO = myComunidadDTO;

                    emergencia.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    emergencia.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    emergencia.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    emergencia.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    emergencia.Estado = wobjDataRow["estado"].ToString();

                    IEmergencia.Add(emergencia);
                }
            }

            return IEmergencia;

        }

        public static bool ValidaEliminacionEmergencia(YouCom.DTO.Emergencia.EmergenciaDTO theEmergenciaDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.Emergencia.EmergenciaDAL.ValidaEliminacionEmergencia(theEmergenciaDTO, ref pobjDataTable))
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
