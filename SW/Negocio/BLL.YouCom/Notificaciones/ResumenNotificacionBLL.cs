using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.bll.Notificaciones
{
    public class ResumenNotificacionBLL
    {
        public static IList<DTO.Notificaciones.Resumen.ResumenNotificacionDTO> getResumenNotificacion()
        {
            decimal wvarMensajeId = 0;
            IList<DTO.Notificaciones.Resumen.ResumenNotificacionDTO> collResumenNotificacionDTO = new List<DTO.Notificaciones.Resumen.ResumenNotificacionDTO>();
            IList<DTO.Notificaciones.Resumen.ResumenNotificacionDTO> theResumenNotificacionDTO = new List<DTO.Notificaciones.Resumen.ResumenNotificacionDTO>();
            IList<DTO.Notificaciones.NotificacionDTO> theNotificacionDTO = new List<DTO.Notificaciones.NotificacionDTO>();

            var notificaciones = YouCom.facade.Notificaciones.Notificacion.getListadoNotificaciones().Where(x => x.VerNotificacion == "NO").ToList();

            foreach(DTO.Notificaciones.NotificacionDTO notificacion in notificaciones)
            {
                YouCom.DTO.Notificaciones.Resumen.ResumenNotificacionDTO resumen;

                if (notificacion.TheMensajeDTO.IdMensaje != wvarMensajeId)
                {
                    resumen = new YouCom.DTO.Notificaciones.Resumen.ResumenNotificacionDTO();

                    YouCom.DTO.Mensajeria.MensajeDTO myMensajeDTO = new DTO.Mensajeria.MensajeDTO();
                    myMensajeDTO.IdMensaje = notificacion.TheMensajeDTO.IdMensaje;
                    resumen.TheMensajeDTO = myMensajeDTO;

                    resumen.TheMensajeTipoDTO = notificacion.TheMensajeTipoDTO;

                    collResumenNotificacionDTO.Add(resumen);
                }

                wvarMensajeId = notificacion.TheMensajeDTO.IdMensaje;
            }

            foreach (DTO.Notificaciones.Resumen.ResumenNotificacionDTO resumenes in collResumenNotificacionDTO)
            {
                YouCom.DTO.Notificaciones.Resumen.ResumenNotificacionDTO resumen = new DTO.Notificaciones.Resumen.ResumenNotificacionDTO();

                resumen.TheMensajeDTO = resumenes.TheMensajeDTO;

                foreach(DTO.Notificaciones.NotificacionDTO noti in YouCom.facade.Notificaciones.Notificacion.getListadoNotificaciones().Where(x => x.TheMensajeDTO.IdMensaje == resumenes.TheMensajeDTO.IdMensaje).ToList())
                {
                    theNotificacionDTO.Add(noti);
                }

                if(theNotificacionDTO.Any())
                {
                    resumen.TheNotificacionDTO = theNotificacionDTO;
                }

                resumen.IdCantidad = theNotificacionDTO.Count();

                theResumenNotificacionDTO.Add(resumen);
            }

            return theResumenNotificacionDTO;
        }

        public static IList<DTO.Notificaciones.Resumen.ResumenNotificacionDTO> getResumenNotificacion(string pRutPropietario)
        {
            decimal wvarMensajeId = 0;
            IList<DTO.Notificaciones.Resumen.ResumenNotificacionDTO> collResumenNotificacionDTO = new List<DTO.Notificaciones.Resumen.ResumenNotificacionDTO>();
            IList<DTO.Notificaciones.Resumen.ResumenNotificacionDTO> theResumenNotificacionDTO = new List<DTO.Notificaciones.Resumen.ResumenNotificacionDTO>();
            IList<DTO.Notificaciones.NotificacionDTO> theNotificacionDTO = new List<DTO.Notificaciones.NotificacionDTO>();

            var notificaciones = YouCom.facade.Notificaciones.Notificacion.getListadoNotificaciones().Where(x => x.VerNotificacion == "NO" && x.TheMensajeDTO.TheFamiliaDTO.RutFamilia == pRutPropietario).ToList();

            foreach (DTO.Notificaciones.NotificacionDTO notificacion in notificaciones)
            {
                YouCom.DTO.Notificaciones.Resumen.ResumenNotificacionDTO resumen;

                if (notificacion.TheMensajeDTO.IdMensaje != wvarMensajeId)
                {
                    resumen = new YouCom.DTO.Notificaciones.Resumen.ResumenNotificacionDTO();

                    YouCom.DTO.Mensajeria.MensajeDTO myMensajeDTO = new DTO.Mensajeria.MensajeDTO();
                    myMensajeDTO.IdMensaje = notificacion.TheMensajeDTO.IdMensaje;
                    myMensajeDTO.MensajeTitulo = notificacion.TheMensajeDTO.MensajeTitulo;
                    myMensajeDTO.MensajeDescripcion = notificacion.TheMensajeDTO.MensajeDescripcion;
                    myMensajeDTO.MensajeFecha = notificacion.TheMensajeDTO.MensajeFecha;
                    resumen.TheMensajeDTO = myMensajeDTO;

                    resumen.TheMensajeTipoDTO = notificacion.TheMensajeTipoDTO;

                    collResumenNotificacionDTO.Add(resumen);
                }

                wvarMensajeId = notificacion.TheMensajeDTO.IdMensaje;
            }

            foreach (DTO.Notificaciones.Resumen.ResumenNotificacionDTO resumenes in collResumenNotificacionDTO)
            {
                YouCom.DTO.Notificaciones.Resumen.ResumenNotificacionDTO resumen = new DTO.Notificaciones.Resumen.ResumenNotificacionDTO();

                resumen.TheMensajeDTO = resumenes.TheMensajeDTO;
                resumen.TheMensajeTipoDTO = resumenes.TheMensajeTipoDTO;

                foreach (DTO.Notificaciones.NotificacionDTO noti in YouCom.facade.Notificaciones.Notificacion.getListadoNotificaciones().Where(x => x.TheMensajeDTO.IdMensaje == resumenes.TheMensajeDTO.IdMensaje).ToList())
                {
                    theNotificacionDTO.Add(noti);
                }

                if (theNotificacionDTO.Any())
                {
                    resumen.TheNotificacionDTO = theNotificacionDTO;
                }

                resumen.IdCantidad = theNotificacionDTO.Count();

                theResumenNotificacionDTO.Add(resumen);
            }

            return theResumenNotificacionDTO;
        }
    }
}
