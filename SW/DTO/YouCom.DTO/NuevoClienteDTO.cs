using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class NuevoClienteDTO : ErrorDTO
    {
        private decimal _idNuevoCliente;

        public decimal IdNuevoCliente
        {
            get { return _idNuevoCliente; }
            set { _idNuevoCliente = value; }
        }

        private DateTime _fechaCreacion;

        public DateTime FechaCreacion
        {
            get { return _fechaCreacion; }
            set { _fechaCreacion = value; }
        }

        private string _RutCondominio;

        public string RutCondominio
        {
            get { return _RutCondominio; }
            set { _RutCondominio = value; }
        }

        private string _rutLogin;

        public string RutLogin
        {
            get { return _rutLogin; }
            set { _rutLogin = value; }
        }

        private string _cambiaClave;

        public string CambiaClave
        {
            get { return _cambiaClave; }
            set { _cambiaClave = value; }
        }

        private DateTime _fechaCambioClave;

        public DateTime FechaCambioClave
        {
            get { return _fechaCambioClave; }
            set { _fechaCambioClave = value; }
        }
    }
}
