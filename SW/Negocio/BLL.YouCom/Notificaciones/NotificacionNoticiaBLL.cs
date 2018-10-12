using System.Collections.Generic;
using System.Linq;
using YouCom.DTO.Notificaciones;

namespace YouCom.bll.Notificaciones
{
    public class NotificacionNoticiaBLL
    {
        public static IList<DTO.Notificaciones.Resumen.ResumenNotificacionNoticiaDTO> getListadoResumenNotificacion()
        {
            var resumen = YouCom.facade.Notificaciones.NotificacionNoticia.getListadoResumenNotificaciones();
            return resumen;
        }

        public static IList<NotificacionNoticiaDTO> getListadoNotificacion()
        {
            var notificacion = YouCom.facade.Notificaciones.NotificacionNoticia.getListadoNotificaciones();
            return notificacion;
        }

        public static NotificacionNoticiaDTO detalleNotificacion(decimal idNotificacion)
        {
            var notificacion = getListadoNotificacion().Where(x => x.IdNotificacionNoticia == idNotificacion).SingleOrDefault();
            return notificacion;
        }

        public static IList<NotificacionNoticiaDTO> getListadoMensajeNoticiaByCondominioByComunidad(decimal idCondominio, decimal idComunidad)
        {
            var mensajes = listaNotificacionActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return mensajes;
        }

        public static IList<NotificacionNoticiaDTO> listaNotificacionActivo()
        {
            IList<NotificacionNoticiaDTO> MensajePropietarios;
            MensajePropietarios = facade.Notificaciones.NotificacionNoticia.getListadoNotificaciones().Where(x => x.Estado == "1").ToList();
            return MensajePropietarios;
        }

        public static IList<NotificacionNoticiaDTO> listaNotificacionInactivo()
        {
            IList<NotificacionNoticiaDTO> MensajePropietarios;
            MensajePropietarios = facade.Notificaciones.NotificacionNoticia.getListadoNotificaciones().Where(x => x.Estado == "2").ToList();
            return MensajePropietarios;
        }

        public static bool Delete(NotificacionNoticiaDTO myNotificacionNoticiaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Notificaciones.NotificacionNoticiaDAL.Delete(myNotificacionNoticiaDTO);
            return resultado;
        }

        public static bool Insert(NotificacionNoticiaDTO myNotificacionNoticiaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Notificaciones.NotificacionNoticiaDAL.Insert(myNotificacionNoticiaDTO);
            return resultado;
        }

        public static bool Update(NotificacionNoticiaDTO myNotificacionNoticiaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Notificaciones.NotificacionNoticiaDAL.Update(myNotificacionNoticiaDTO);
            return resultado;
        }
    }
}
