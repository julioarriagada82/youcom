using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Notificaciones.Resumen
{
    public class ResumenNotificacionDirectivaDTO : MantenedoresBase
    {
        private Mensajeria.MensajeDirectivaDTO theMensajeDirectivaDTO;
        public Mensajeria.MensajeDirectivaDTO TheMensajeDirectivaDTO
        {
            get { return theMensajeDirectivaDTO; }
            set { theMensajeDirectivaDTO = value; }
        }

        private Notificaciones.NotificacionDirectivaDTO theNotificacionDirectivaDTO;
        public Notificaciones.NotificacionDirectivaDTO TheNotificacionDirectivaDTO
        {
            get { return theNotificacionDirectivaDTO; }
            set { theNotificacionDirectivaDTO = value; }
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
