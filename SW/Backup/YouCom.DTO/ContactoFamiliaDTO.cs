using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class ContactoFamiliaDTO : MantenedoresBase
    {
        private decimal _idContactoFamilia;

        public decimal IdContactoFamilia
        {
            get { return _idContactoFamilia; }
            set { _idContactoFamilia = value; }
        }

        private decimal _idCasa;

        public decimal IdCasa
        {
            get { return _idCasa; }
            set { _idCasa = value; }
        }

        private decimal _idParentesco;

        public decimal IdParentesco
        {
            get { return _idParentesco; }
            set { _idParentesco = value; }
        }

        private string _nombreContacto;

        public string NombreContacto
        {
            get { return _nombreContacto; }
            set { _nombreContacto = value; }
        }
        private string _telefonoContacto;

        public string TelefonoContacto
        {
            get { return _telefonoContacto; }
            set { _telefonoContacto = value; }
        }

        private string _emailContacto;

        public string EmailContacto
        {
            get { return _emailContacto; }
            set { _emailContacto = value; }
        }
    }
}
