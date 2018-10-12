using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Notificaciones.Resumen
{
    public class ResumenNotificacionDTO
    {
        private decimal _idResumenNotificacion;

        public decimal IdResumenNotificacion
        {
            get { return _idResumenNotificacion; }
            set { _idResumenNotificacion = value; }
        }

        private decimal _idCantidad;

        public decimal IdCantidad
        {
            get { return _idCantidad; }
            set { _idCantidad = value; }
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

        private IList<Notificaciones.NotificacionDTO> theNotificacionDTO;
        public IList<Notificaciones.NotificacionDTO> TheNotificacionDTO
        {
            get { return theNotificacionDTO; }
            set { theNotificacionDTO = value; }
        }
    }
}
