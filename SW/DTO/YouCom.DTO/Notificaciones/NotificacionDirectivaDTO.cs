using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Notificaciones
{
    public class NotificacionDirectivaDTO : MantenedoresBase
    {
        private decimal _idNotificacionDirectiva;

        public decimal IdNotificacionDirectiva
        {
            get { return _idNotificacionDirectiva; }
            set { _idNotificacionDirectiva = value; }
        }

        private Mensajeria.MensajeDirectivaDTO theMensajeDirectivaDTO;
        public Mensajeria.MensajeDirectivaDTO TheMensajeDirectivaDTO
        {
            get { return theMensajeDirectivaDTO; }
            set { theMensajeDirectivaDTO = value; }
        }

        private DirectivaDTO theDirectivaDTO;
        public DirectivaDTO TheDirectivaDTO
        {
            get { return theDirectivaDTO; }
            set { theDirectivaDTO = value; }
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
