using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Notificaciones
{
    public class NotificacionDTO : MantenedoresBase
    {
        private decimal _idNotificacion;

        public decimal IdNotificacion
        {
            get { return _idNotificacion; }
            set { _idNotificacion = value; }
        }

        private Mensajeria.MensajeDTO theMensajeDTO;
        public Mensajeria.MensajeDTO TheMensajeDTO
        {
            get { return theMensajeDTO; }
            set { theMensajeDTO = value; }
        }

        private Mensajeria.MensajeTipoDTO theMensajeTipoDTO;
        public Mensajeria.MensajeTipoDTO TheMensajeTipoDTO
        {
            get { return theMensajeTipoDTO; }
            set { theMensajeTipoDTO = value; }
        }

        private DTO.Propietario.FamiliaDTO theFamiliaDTO;
        public DTO.Propietario.FamiliaDTO TheFamiliaDTO
        {
            get { return theFamiliaDTO; }
            set { theFamiliaDTO = value; }
        }

        private DirectivaDTO theDirectivaDTO;
        public DirectivaDTO TheDirectivaDTO
        {
            get { return theDirectivaDTO; }
            set { theDirectivaDTO = value; }
        }

        private PorteriaDTO thePorteriaDTO;
        public PorteriaDTO ThePorteriaDTO
        {
            get { return thePorteriaDTO; }
            set { thePorteriaDTO = value; }
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
