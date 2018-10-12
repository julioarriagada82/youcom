using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.facade
{
    public class TipoEmergencia
    {
        public static IList<YouCom.DTO.Emergencia.TipoEmergenciaDTO> getListadoTipoEmergencia()
        {
            IList<YouCom.DTO.Emergencia.TipoEmergenciaDTO> ITipoEmergencia = new List<YouCom.DTO.Emergencia.TipoEmergenciaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.Emergencia.TipoEmergenciaDAL.getListadoTipoEmergencia(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Emergencia.TipoEmergenciaDTO tipo_aviso = new YouCom.DTO.Emergencia.TipoEmergenciaDTO();

                    tipo_aviso.IdTipoEmergencia = decimal.Parse(wobjDataRow["IdTipoEmergencia"].ToString());

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    tipo_aviso.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    tipo_aviso.TheComunidadDTO = myComunidadDTO;

                    tipo_aviso.NombreTipoEmergencia = wobjDataRow["nombreTipoEmergencia"].ToString();

                    tipo_aviso.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    tipo_aviso.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    tipo_aviso.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    tipo_aviso.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    tipo_aviso.Estado = wobjDataRow["estado"].ToString();

                    ITipoEmergencia.Add(tipo_aviso);
                }
            }

            return ITipoEmergencia;

        }

        public static bool ValidaEliminacionTipoEmergencia(YouCom.DTO.Emergencia.TipoEmergenciaDTO theTipoEmergenciaDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.Emergencia.TipoEmergenciaDAL.ValidaEliminacionTipoEmergencia(theTipoEmergenciaDTO, ref pobjDataTable))
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
