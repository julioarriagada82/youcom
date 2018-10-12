using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Notificaciones.Resumen
{
    public class ResumenNotificacionPorteriaDTO : MantenedoresBase
    {
        private Mensajeria.MensajePorteriaDTO theMensajePorteriaDTO;
        public Mensajeria.MensajePorteriaDTO TheMensajePorteriaDTO
        {
            get { return theMensajePorteriaDTO; }
            set { theMensajePorteriaDTO = value; }
        }

        private Notificaciones.NotificacionPorteriaDTO theNotificacionPorteriaDTO;
        public Notificaciones.NotificacionPorteriaDTO TheNotificacionPorteriaDTO
        {
            get { return theNotificacionPorteriaDTO; }
            set { theNotificacionPorteriaDTO = value; }
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
