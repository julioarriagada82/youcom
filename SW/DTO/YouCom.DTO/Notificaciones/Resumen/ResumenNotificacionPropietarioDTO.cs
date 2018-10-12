using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Notificaciones.Resumen
{
    public class ResumenNotificacionPropietarioDTO : MantenedoresBase
    {
        private Mensajeria.MensajePropietarioDTO theMensajePropietarioDTO;
        public Mensajeria.MensajePropietarioDTO TheMensajePropietarioDTO
        {
            get { return theMensajePropietarioDTO; }
            set { theMensajePropietarioDTO = value; }
        }

        private Notificaciones.NotificacionPropietarioDTO theNotificacionPropietarioDTO;
        public Notificaciones.NotificacionPropietarioDTO TheNotificacionPropietarioDTO
        {
            get { return theNotificacionPropietarioDTO; }
            set { theNotificacionPropietarioDTO = value; }
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
