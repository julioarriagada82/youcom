using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Seguridad
{
    public class CondominioDTO : MantenedoresBase
    {
        private decimal _idPorteria;

        public decimal IdPorteria
        {
            get { return _idPorteria; }
            set { _idPorteria = value; }
        }
        private decimal _idAdministracion;

        public decimal IdAdministracion
        {
            get { return _idAdministracion; }
            set { _idAdministracion = value; }
        }
        private string _rutCondominio;

        public string RutCondominio
        {
            get { return _rutCondominio; }
            set { _rutCondominio = value; }
        }
        private string _nombreCondominio;

        public string NombreCondominio
        {
            get { return _nombreCondominio; }
            set { _nombreCondominio = value; }
        }

        private string _telefonoCondominio;

        public string TelefonoCondominio
        {
            get { return _telefonoCondominio; }
            set { _telefonoCondominio = value; }
        }

        private string _direccionCondominio;

        public string DireccionCondominio
        {
            get { return _direccionCondominio; }
            set { _direccionCondominio = value; }
        }

        private string _emailCondominio;

        public string EmailCondominio
        {
            get { return _emailCondominio; }
            set { _emailCondominio = value; }
        }
    }
}
