using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class AccesoLoginDTO
    {
        private decimal _idAccesoLogin;

        public decimal IdAccesoLogin
        {
            get { return _idAccesoLogin; }
            set { _idAccesoLogin = value; }
        }
        private string _rutLogin;

        public string RutLogin
        {
            get { return _rutLogin; }
            set { _rutLogin = value; }
        }
        private string _RutCondominio;

        public string RutCondominio
        {
            get { return _RutCondominio; }
            set { _RutCondominio = value; }
        }

        private string _ip;

        public string Ip
        {
            get { return _ip; }
            set { _ip = value; }
        }

        private DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
    }
}
