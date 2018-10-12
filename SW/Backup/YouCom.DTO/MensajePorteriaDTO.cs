using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class MensajePorteriaDTO : MantenedoresBase
    {
        private decimal _idMensajePorteria;

        public decimal IdMensajePorteria
        {
            get { return _idMensajePorteria; }
            set { _idMensajePorteria = value; }
        }

        private decimal _idFamilia;

        public decimal IdFamilia
        {
            get { return _idFamilia; }
            set { _idFamilia = value; }
        }

        private decimal _idPortero;

        public decimal IdPortero
        {
            get { return _idPortero; }
            set { _idPortero = value; }
        }
        private DateTime _fechaMensaje;

        public DateTime FechaMensaje
        {
            get { return _fechaMensaje; }
            set { _fechaMensaje = value; }
        }

        private string _descripcionMensaje;

        public string DescripcionMensaje
        {
            get { return _descripcionMensaje; }
            set { _descripcionMensaje = value; }
        }
    }
}
