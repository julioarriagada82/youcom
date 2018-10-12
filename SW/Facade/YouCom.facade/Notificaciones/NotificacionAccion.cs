using System.Collections.Generic;
using System.Data;

namespace YouCom.facade.Notificaciones
{
    public class NotificacionAccion
    {
        public static IList<YouCom.DTO.Notificaciones.NotificacionAccionDTO> getListadoNotificacionAccion()
        {
            IList<YouCom.DTO.Notificaciones.NotificacionAccionDTO> INotificacionAccion = new List<YouCom.DTO.Notificaciones.NotificacionAccionDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.Mensajeria.DAL.Notificaciones.NotificacionAccionDAL.getListadoNotificacionAccion(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Notificaciones.NotificacionAccionDTO notificacion_accion = new YouCom.DTO.Notificaciones.NotificacionAccionDTO();

                    notificacion_accion.IdNotificacionAccion = decimal.Parse(wobjDataRow["IdNotificacionAccion"].ToString());
                    notificacion_accion.NombreNotificacionAccion = wobjDataRow["NombreNotificacionAccion"].ToString();

                    notificacion_accion.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    notificacion_accion.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    notificacion_accion.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    notificacion_accion.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    notificacion_accion.Estado = wobjDataRow["estado"].ToString();

                    INotificacionAccion.Add(notificacion_accion);
                }
            }

            return INotificacionAccion;

        }

        public static bool ValidaEliminacionNotificacion(YouCom.DTO.Notificaciones.NotificacionAccionDTO theNotificacionAccionDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.Mensajeria.DAL.Notificaciones.NotificacionAccionDAL.ValidaEliminacionNotificacionAccion(theNotificacionAccionDTO, ref pobjDataTable))
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
