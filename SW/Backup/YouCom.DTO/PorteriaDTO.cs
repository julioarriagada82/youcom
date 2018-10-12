using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class PorteriaDTO : MantenedoresBase
    {
        private decimal _idPorteria;

        public decimal IdPorteria
        {
            get { return _idPorteria; }
            set { _idPorteria = value; }
        }
        private string _nombrePorteria;

        public string NombrePorteria
        {
            get { return _nombrePorteria; }
            set { _nombrePorteria = value; }
        }

        private string _apellidoPorteria;

        public string ApellidoPorteria
        {
            get { return _apellidoPorteria; }
            set { _apellidoPorteria = value; }
        }

        private string _rutPorteria;

        public string RutPorteria
        {
            get { return _rutPorteria; }
            set { _rutPorteria = value; }
        }

        private string _telefonoPorteria;

        public string TelefonoPorteria
        {
            get { return _telefonoPorteria; }
            set { _telefonoPorteria = value; }
        }

        private string _emailPorteria;

        public string EmailPorteria
        {
            get { return _emailPorteria; }
            set { _emailPorteria = value; }
        }
    }
}
