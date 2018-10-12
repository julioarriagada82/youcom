using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Mensajeria
{
    public class MensajeTipoEnvioDTO : MantenedoresBase
    {
        private decimal _idMensajeTipoEnvio;

        public decimal IdMensajeTipoEnvio
        {
            get { return _idMensajeTipoEnvio; }
            set { _idMensajeTipoEnvio = value; }
        }
        private string _nombreMensajeTipoEnvio;

        public string NombreMensajeTipoEnvio
        {
            get { return _nombreMensajeTipoEnvio; }
            set { _nombreMensajeTipoEnvio = value; }
        }
    }
}
