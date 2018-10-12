using System.Collections.Generic;
using System.Linq;
using YouCom.DTO.Notificaciones;

namespace YouCom.bll.Notificaciones
{
    public class NotificacionAccionBLL
    {
        public static IList<NotificacionAccionDTO> getListadoNotificacion()
        {
            var notificacion_accion = YouCom.facade.Notificaciones.NotificacionAccion.getListadoNotificacionAccion();
            return notificacion_accion;
        }

        public static NotificacionAccionDTO detalleNotificacionAccion(decimal idNotificacionAccion)
        {
            var notificacion = getListadoNotificacion().Where(x => x.IdNotificacionAccion == idNotificacionAccion).SingleOrDefault();
            return notificacion;
        }

        public static IList<NotificacionAccionDTO> listaNotificacionAccion2ºActivo()
        {
            IList<NotificacionAccionDTO> notificacionAccion;
            notificacionAccion = facade.Notificaciones.NotificacionAccion.getListadoNotificacionAccion().Where(x => x.Estado == "1").ToList();
            return notificacionAccion;
        }

        public static IList<NotificacionAccionDTO> listaNotificacionAccionInactivo()
        {
            IList<NotificacionAccionDTO> notificacionAccion;
            notificacionAccion = facade.Notificaciones.NotificacionAccion.getListadoNotificacionAccion().Where(x => x.Estado == "2").ToList();
            return notificacionAccion;
        }

        public static bool Delete(NotificacionAccionDTO myNotificacionAccionDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Notificaciones.NotificacionAccionDAL.Delete(myNotificacionAccionDTO);
            return resultado;
        }

        public static bool Insert(NotificacionAccionDTO myNotificacionAccionDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Notificaciones.NotificacionAccionDAL.Insert(myNotificacionAccionDTO);
            return resultado;
        }

        public static bool Update(NotificacionAccionDTO myNotificacionAccionDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Notificaciones.NotificacionAccionDAL.Update(myNotificacionAccionDTO);
            return resultado;
        }

        public static bool ActivaMensajePropietario(NotificacionAccionDTO theNotificacionAccionDTO)
        {
            bool respuesta = YouCom.Mensajeria.DAL.Notificaciones.NotificacionAccionDAL.ActivaNotificaciones(theNotificacionAccionDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionMensajePropietario(NotificacionAccionDTO theNotificacionAccionDTO)
        {
            bool respuesta = facade.Notificaciones.NotificacionAccion.ValidaEliminacionNotificacion(theNotificacionAccionDTO);
            return respuesta;
        }
    }
}
