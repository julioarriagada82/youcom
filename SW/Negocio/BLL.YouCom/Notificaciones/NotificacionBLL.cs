using System.Collections.Generic;
using System.Linq;
using YouCom.DTO.Notificaciones;

namespace YouCom.bll.Notificaciones
{
    public class NotificacionBLL
    {
        public static IList<NotificacionDTO> getListadoNotificacionesByIdFamiliaOrigen(string pRut)
        {
            var Notificaciones = getListadoTodosNotificaciones().Where(x => x.TheMensajeDTO.TheFamiliaDTO.RutFamilia == pRut && x.TheFamiliaDTO.RutFamilia != pRut).ToList();
            return Notificaciones;
        }

        public static IList<NotificacionDTO> getListadoNotificacionesByIdMensaje(decimal pIdMensaje, string pQuienEnvia)
        {
            var Notificaciones = getListadoTodosNotificaciones().Where(x => x.TheMensajeDTO.IdMensaje == pIdMensaje && x.TheMensajeTipoDTO.NombreMensajeTipo == pQuienEnvia).ToList();
            return Notificaciones;
        }

        public static IList<NotificacionDTO> getListadoNotificacionesByUsuario(string pUsuario)
        {
            var Notificaciones = getListadoNotificacionesPropietarios().Where(x => x.TheFamiliaDTO.NombreCompleto.Contains(pUsuario)).ToList();
            return Notificaciones;
        }

        public static IList<NotificacionDTO> getListadoNotificaciones()
        {
            var Notificaciones = YouCom.facade.Notificaciones.Notificacion.getListadoNotificaciones();
            return Notificaciones;
        }

        public static IList<NotificacionDTO> getListadoNotificacionesPropietarios()
        {
            var Notificaciones = YouCom.facade.Notificaciones.Notificacion.getListadoNotificacionesPropietarios().OrderByDescending(x => x.FechaNotificacion).ToList();
            return Notificaciones;
        }

        public static IList<NotificacionDTO> getListadoNotificacionesInternos()
        {
            var Notificaciones = YouCom.facade.Notificaciones.Notificacion.getListadoNotificacionesInternas().OrderByDescending(x => x.FechaNotificacion).ToList();
            return Notificaciones;
        }

        public static IList<NotificacionDTO> getListadoTodosNotificaciones()
        {
            var Notificaciones = YouCom.facade.Notificaciones.Notificacion.getListadoTodasNotificaciones().OrderByDescending(x => x.FechaNotificacion).ToList();
            return Notificaciones;
        }

        public static NotificacionDTO detalleMensaje(decimal idMensaje)
        {
            var Notificaciones = YouCom.facade.Notificaciones.Notificacion.getListadoNotificaciones().Where(x => x.TheMensajeDTO.IdMensaje == idMensaje).First();
            return Notificaciones;
        }

        public static IList<NotificacionDTO> getListadoMensajeByCondominioByComunidad(decimal idCondominio, decimal idComunidad, decimal idFamilia)
        {
            var Notificaciones = getListadoNotificaciones().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return Notificaciones;
        }
    }
}
