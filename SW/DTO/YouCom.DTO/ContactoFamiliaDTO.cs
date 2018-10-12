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

        private Propietario.CasaDTO theCasaDTO;
        public Propietario.CasaDTO TheCasaDTO
        {
            get { return theCasaDTO; }
            set { theCasaDTO = value; }
        }

        private Propietario.ParentescoDTO theParentescoDTO;
        public Propietario.ParentescoDTO TheParentescoDTO
        {
            get { return theParentescoDTO; }
            set { theParentescoDTO = value; }
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
