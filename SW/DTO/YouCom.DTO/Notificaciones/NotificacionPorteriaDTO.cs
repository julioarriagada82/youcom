using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Notificaciones
{
    public class NotificacionPorteriaDTO : MantenedoresBase
    {
        private decimal _idNotificacionPorteria;

        public decimal IdNotificacionPorteria
        {
            get { return _idNotificacionPorteria; }
            set { _idNotificacionPorteria = value; }
        }

        private Mensajeria.MensajePorteriaDTO theMensajePorteriaDTO;
        public Mensajeria.MensajePorteriaDTO TheMensajePorteriaDTO
        {
            get { return theMensajePorteriaDTO; }
            set { theMensajePorteriaDTO = value; }
        }

        private PorteriaDTO thePorteriaDTO;
        public PorteriaDTO ThePorteriaDTO
        {
            get { return thePorteriaDTO; }
            set { thePorteriaDTO = value; }
        }

        private DTO.Propietario.FamiliaDTO theFamiliaDestinoDTO;
        public DTO.Propietario.FamiliaDTO TheFamiliaDestinoDTO
        {
            get { return theFamiliaDestinoDTO; }
            set { theFamiliaDestinoDTO = value; }
        }

        private NotificacionAccionDTO theNotificacionAccionDTO;
        public NotificacionAccionDTO TheNotificacionAccionDTO
        {
            get { return theNotificacionAccionDTO; }
            set { theNotificacionAccionDTO = value; }
        }

        private DateTime _fechaNotificacion;

        public DateTime FechaNotificacion
        {
            get { return _fechaNotificacion; }
            set { _fechaNotificacion = value; }
        }

        private string _verNotificacion;

        public string VerNotificacion
        {
            get { return _verNotificacion; }
            set { _verNotificacion = value; }
        }
    }
}
