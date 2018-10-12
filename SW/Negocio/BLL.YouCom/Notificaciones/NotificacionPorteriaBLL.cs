using System.Collections.Generic;
using System.Linq;
using YouCom.DTO.Notificaciones;

namespace YouCom.bll.Notificaciones
{
    public class NotificacionPorteriaBLL
    {
        public static IList<DTO.Notificaciones.Resumen.ResumenNotificacionPorteriaDTO> getListadoResumenNotificacion()
        {
            var resumen = YouCom.facade.Notificaciones.NotificacionPorteria.getListadoResumenNotificaciones();
            return resumen;
        }

        public static IList<NotificacionPorteriaDTO> getListadoNotificacion()
        {
            var notificacion = YouCom.facade.Notificaciones.NotificacionPorteria.getListadoNotificaciones();
            return notificacion;
        }

        public static NotificacionPorteriaDTO detalleNotificacion(decimal idNotificacion)
        {
            var notificacion = getListadoNotificacion().Where(x => x.IdNotificacionPorteria == idNotificacion).SingleOrDefault();
            return notificacion;
        }

        public static IList<NotificacionPorteriaDTO> getListadoMensajePorteriaByCondominioByComunidad(decimal idCondominio, decimal idComunidad)
        {
            var mensajes = listaNotificacionActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return mensajes;
        }

        public static IList<NotificacionPorteriaDTO> listaNotificacionActivo()
        {
            IList<NotificacionPorteriaDTO> MensajePropietarios;
            MensajePropietarios = facade.Notificaciones.NotificacionPorteria.getListadoNotificaciones().Where(x => x.Estado == "1").ToList();
            return MensajePropietarios;
        }

        public static IList<NotificacionPorteriaDTO> listaNotificacionInactivo()
        {
            IList<NotificacionPorteriaDTO> MensajePropietarios;
            MensajePropietarios = facade.Notificaciones.NotificacionPorteria.getListadoNotificaciones().Where(x => x.Estado == "2").ToList();
            return MensajePropietarios;
        }

        public static bool Delete(NotificacionPorteriaDTO myNotificacionPorteriaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Notificaciones.NotificacionPorteriaDAL.Delete(myNotificacionPorteriaDTO);
            return resultado;
        }

        public static bool Insert(NotificacionPorteriaDTO myNotificacionPorteriaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Notificaciones.NotificacionPorteriaDAL.Insert(myNotificacionPorteriaDTO);
            return resultado;
        }

        public static bool Update(NotificacionPorteriaDTO myNotificacionPorteriaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Notificaciones.NotificacionPorteriaDAL.Update(myNotificacionPorteriaDTO);
            return resultado;
        }
    }
}
