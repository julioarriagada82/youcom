using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class ComercioDTO : MantenedoresBase
    {
        private decimal _idComercio;

        public decimal IdComercio
        {
            get { return _idComercio; }
            set { _idComercio = value; }
        }

        private CategoriaDTO theCategoriaDTO;
        public CategoriaDTO TheCategoriaDTO
        {
            get { return theCategoriaDTO; }
            set { theCategoriaDTO = value; }
        }

        private string _nombreComercio;

        public string NombreComercio
        {
            get { return _nombreComercio; }
            set { _nombreComercio = value; }
        }

        private string _logoComercio;

        public string LogoComercio
        {
            get { return _logoComercio; }
            set { _logoComercio = value; }
        }

        private string _direccionComercio;

        public string DireccionComercio
        {
            get { return _direccionComercio; }
            set { _direccionComercio = value; }
        }

        private ComunaDTO theComunaDTO;
        public ComunaDTO TheComunaDTO
        {
            get { return theComunaDTO; }
            set { theComunaDTO = value; }
        }

        private string _telefonoComercio;

        public string TelefonoComercio
        {
            get { return _telefonoComercio; }
            set { _telefonoComercio = value; }
        }

        private string _urlComercio;

        public string UrlComercio
        {
            get { return _urlComercio; }
            set { _urlComercio = value; }
        }

        private string _emailComercio;

        public string EmailComercio
        {
            get { return _emailComercio; }
            set { _emailComercio = value; }
        }
    }
}
