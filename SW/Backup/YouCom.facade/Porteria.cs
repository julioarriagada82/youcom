using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class Porteria
    {
        public static IList<YouCom.DTO.PorteriaDTO> getListadoPorteria()
        {
            IList<YouCom.DTO.PorteriaDTO> IPorteria = new List<YouCom.DTO.PorteriaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.PorteriaDAL.getListadoPorteria(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.PorteriaDTO tipo_aviso = new YouCom.DTO.PorteriaDTO();

                    tipo_aviso.IdPorteria = decimal.Parse(wobjDataRow["IdPorteria"].ToString());
                    tipo_aviso.NombrePorteria = wobjDataRow["nombrePorteria"].ToString();
                    tipo_aviso.ApellidoPorteria = wobjDataRow["apellidoPorteria"].ToString();
                    tipo_aviso.RutPorteria = wobjDataRow["rutPorteria"].ToString();
                    tipo_aviso.TelefonoPorteria = wobjDataRow["telefonoPorteria"].ToString();
                    tipo_aviso.EmailPorteria = wobjDataRow["emailPorteria"].ToString();

                    tipo_aviso.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    tipo_aviso.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    tipo_aviso.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    tipo_aviso.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    tipo_aviso.Estado = wobjDataRow["estado"].ToString();

                    IPorteria.Add(tipo_aviso);
                }
            }

            return IPorteria;

        }

        public static bool ValidaEliminacionPorteria(YouCom.DTO.PorteriaDTO thePorteriaDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.PorteriaDAL.ValidaEliminacionPorteria(thePorteriaDTO, ref pobjDataTable))
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
