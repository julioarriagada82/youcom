using System.Collections.Generic;
using System.Linq;
using YouCom.DTO.Notificaciones;

namespace YouCom.bll.Notificaciones
{
    public class NotificacionDirectivaBLL
    {
        public static IList<DTO.Notificaciones.Resumen.ResumenNotificacionDirectivaDTO> getListadoResumenNotificacion()
        {
            var resumen = YouCom.facade.Notificaciones.NotificacionDirectiva.getListadoResumenNotificaciones();
            return resumen;
        }

        public static IList<NotificacionDirectivaDTO> getListadoNotificacion()
        {
            var notificacion = YouCom.facade.Notificaciones.NotificacionDirectiva.getListadoNotificaciones();
            return notificacion;
        }

        public static NotificacionDirectivaDTO detalleNotificacion(decimal idNotificacion)
        {
            var notificacion = getListadoNotificacion().Where(x => x.IdNotificacionDirectiva == idNotificacion).SingleOrDefault();
            return notificacion;
        }

        public static IList<NotificacionDirectivaDTO> getListadoMensajeDirectivaByCondominioByComunidad(decimal idCondominio, decimal idComunidad)
        {
            var mensajes = listaNotificacionActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return mensajes;
        }

        public static IList<NotificacionDirectivaDTO> listaNotificacionActivo()
        {
            IList<NotificacionDirectivaDTO> MensajePropietarios;
            MensajePropietarios = facade.Notificaciones.NotificacionDirectiva.getListadoNotificaciones().Where(x => x.Estado == "1").ToList();
            return MensajePropietarios;
        }

        public static IList<NotificacionDirectivaDTO> listaNotificacionInactivo()
        {
            IList<NotificacionDirectivaDTO> MensajePropietarios;
            MensajePropietarios = facade.Notificaciones.NotificacionDirectiva.getListadoNotificaciones().Where(x => x.Estado == "2").ToList();
            return MensajePropietarios;
        }

        public static bool Delete(NotificacionDirectivaDTO myNotificacionDirectivaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Notificaciones.NotificacionDirectivaDAL.Delete(myNotificacionDirectivaDTO);
            return resultado;
        }

        public static bool Insert(NotificacionDirectivaDTO myNotificacionDirectivaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Notificaciones.NotificacionDirectivaDAL.Insert(myNotificacionDirectivaDTO);
            return resultado;
        }

        public static bool Update(NotificacionDirectivaDTO myNotificacionDirectivaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Notificaciones.NotificacionDirectivaDAL.Update(myNotificacionDirectivaDTO);
            return resultado;
        }
    }
}
