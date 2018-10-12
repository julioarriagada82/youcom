using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class MensajePorteria
    {
        public static IList<YouCom.DTO.MensajePorteriaDTO> getListadoMensajePorteria()
        {
            IList<YouCom.DTO.MensajePorteriaDTO> IMensajePorteria = new List<YouCom.DTO.MensajePorteriaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.Mensajeria.DAL.MensajePorteriaDAL.getListadoMensajePorteria(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.MensajePorteriaDTO tipo_aviso = new YouCom.DTO.MensajePorteriaDTO();

                    tipo_aviso.IdMensajePorteria = decimal.Parse(wobjDataRow["IdMensajePorteria"].ToString());
                    tipo_aviso.IdFamilia = decimal.Parse(wobjDataRow["IdFamilia"].ToString());
                    tipo_aviso.IdPortero = decimal.Parse(wobjDataRow["IdPortero"].ToString());
                    tipo_aviso.FechaMensaje = DateTime.Parse(wobjDataRow["fechaMensaje"].ToString());
                    tipo_aviso.DescripcionMensaje = wobjDataRow["descripcionMensaje"].ToString();

                    tipo_aviso.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    tipo_aviso.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    tipo_aviso.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    tipo_aviso.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    tipo_aviso.Estado = wobjDataRow["estado"].ToString();

                    IMensajePorteria.Add(tipo_aviso);
                }
            }

            return IMensajePorteria;

        }

        public static bool ValidaEliminacionMensajePorteria(YouCom.DTO.MensajePorteriaDTO theMensajePorteriaDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.Mensajeria.DAL.MensajePorteriaDAL.ValidaEliminacionMensajePorteria(theMensajePorteriaDTO, ref pobjDataTable))
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
