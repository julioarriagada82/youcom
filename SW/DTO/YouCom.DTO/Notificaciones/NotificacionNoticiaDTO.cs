using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Notificaciones
{
    public class NotificacionNoticiaDTO : MantenedoresBase
    {
        private decimal _idNotificacionNoticia;

        public decimal IdNotificacionNoticia
        {
            get { return _idNotificacionNoticia; }
            set { _idNotificacionNoticia = value; }
        }

        private Mensajeria.MensajeNoticiaDTO theMensajeNoticiaDTO;
        public Mensajeria.MensajeNoticiaDTO TheMensajeNoticiaDTO
        {
            get { return theMensajeNoticiaDTO; }
            set { theMensajeNoticiaDTO = value; }
        }

        private DTO.Propietario.FamiliaDTO theFamiliaCreadorDTO;
        public DTO.Propietario.FamiliaDTO TheFamiliaCreadorDTO
        {
            get { return theFamiliaCreadorDTO; }
            set { theFamiliaCreadorDTO = value; }
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
