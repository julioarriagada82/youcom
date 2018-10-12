using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Notificaciones
{
    public class NotificacionPropietarioDTO : MantenedoresBase
    {
        private decimal _idNotificacionPropietario;

        public decimal IdNotificacionPropietario
        {
            get { return _idNotificacionPropietario; }
            set { _idNotificacionPropietario = value; }
        }

        private Mensajeria.MensajePropietarioDTO theMensajePropietarioDTO;
        public Mensajeria.MensajePropietarioDTO TheMensajePropietarioDTO
        {
            get { return theMensajePropietarioDTO; }
            set { theMensajePropietarioDTO = value; }
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
