using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Notificaciones.Resumen
{
    public class ResumenNotificacionNoticiaDTO : MantenedoresBase
    {
        private Mensajeria.MensajeNoticiaDTO theMensajeNoticiaDTO;
        public Mensajeria.MensajeNoticiaDTO TheMensajeNoticiaDTO
        {
            get { return theMensajeNoticiaDTO; }
            set { theMensajeNoticiaDTO = value; }
        }

        private Notificaciones.NotificacionNoticiaDTO theNotificacionNoticiaDTO;
        public Notificaciones.NotificacionNoticiaDTO TheNotificacionNoticiaDTO
        {
            get { return theNotificacionNoticiaDTO; }
            set { theNotificacionNoticiaDTO = value; }
        }

        private Notificaciones.NotificacionAccionDTO theNotificacionAccionDTO;
        public Notificaciones.NotificacionAccionDTO TheNotificacionAccionDTO
        {
            get { return theNotificacionAccionDTO; }
            set { theNotificacionAccionDTO = value; }
        }

        private DTO.Propietario.FamiliaDTO theFamiliaDTO;
        public DTO.Propietario.FamiliaDTO TheFamiliaDTO
        {
            get { return theFamiliaDTO; }
            set { theFamiliaDTO = value; }
        }
    }
}
