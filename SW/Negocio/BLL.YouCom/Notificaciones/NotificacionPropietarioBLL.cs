using System.Collections.Generic;
using System.Linq;
using YouCom.DTO.Notificaciones;

namespace YouCom.bll.Notificaciones
{
    public class NotificacionPropietarioBLL
    {
        public static IList<DTO.Notificaciones.Resumen.ResumenNotificacionPropietarioDTO> getListadoResumenNotificacion()
        {
            var resumen = YouCom.facade.Notificaciones.NotificacionPropietario.getListadoResumenNotificaciones();
            return resumen;
        }

        public static IList<NotificacionPropietarioDTO> getListadoNotificacion()
        {
            var notificacion = YouCom.facade.Notificaciones.NotificacionPropietario.getListadoNotificaciones();
            return notificacion;
        }

        public static NotificacionPropietarioDTO detalleNotificacion(decimal idNotificacion)
        {
            var notificacion = getListadoNotificacion().Where(x => x.IdNotificacionPropietario == idNotificacion).SingleOrDefault();
            return notificacion;
        }

        public static IList<NotificacionPropietarioDTO> getListadoMensajePropietarioByCondominioByComunidad(decimal idCondominio, decimal idComunidad)
        {
            var mensajes = listaNotificacionActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return mensajes;
        }

        public static IList<NotificacionPropietarioDTO> listaNotificacionActivo()
        {
            IList<NotificacionPropietarioDTO> MensajePropietarios;
            MensajePropietarios = facade.Notificaciones.NotificacionPropietario.getListadoNotificaciones().Where(x => x.Estado == "1").ToList();
            return MensajePropietarios;
        }

        public static IList<NotificacionPropietarioDTO> listaNotificacionInactivo()
        {
            IList<NotificacionPropietarioDTO> MensajePropietarios;
            MensajePropietarios = facade.Notificaciones.NotificacionPropietario.getListadoNotificaciones().Where(x => x.Estado == "2").ToList();
            return MensajePropietarios;
        }

        public static bool Delete(NotificacionPropietarioDTO myNotificacionPropietarioDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Notificaciones.NotificacionPropietarioDAL.Delete(myNotificacionPropietarioDTO);
            return resultado;
        }

        public static bool Insert(NotificacionPropietarioDTO myNotificacionPropietarioDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Notificaciones.NotificacionPropietarioDAL.Insert(myNotificacionPropietarioDTO);
            return resultado;
        }

        public static bool Update(NotificacionPropietarioDTO myNotificacionPropietarioDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Notificaciones.NotificacionPropietarioDAL.Update(myNotificacionPropietarioDTO);
            return resultado;
        }
    }
}
