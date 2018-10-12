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

        private string _apellidoPaternoPorteria;

        public string ApellidoPaternoPorteria
        {
            get { return _apellidoPaternoPorteria; }
            set { _apellidoPaternoPorteria = value; }
        }

        private string _apellidoMaternoPorteria;

        public string ApellidoMaternoPorteria
        {
            get { return _apellidoMaternoPorteria; }
            set { _apellidoMaternoPorteria = value; }
        }

        private string _rutPorteria;

        public string RutPorteria
        {
            get { return _rutPorteria; }
            set { _rutPorteria = value; }
        }

        private DateTime _fechaNacimientoPorteria;

        public DateTime FechaNacimientoPorteria
        {
            get { return _fechaNacimientoPorteria; }
            set { _fechaNacimientoPorteria = value; }
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

        public string NombreCompleto
        {
            get
            {
                return _nombrePorteria + " " + _apellidoPaternoPorteria + " " + _apellidoMaternoPorteria;
            }
        }
    }
}
