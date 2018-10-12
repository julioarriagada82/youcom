using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Mensajeria
{
    public class MensajeTipoDTO: MantenedoresBase
    {
        private decimal _idMensajeTipo;

        public decimal IdMensajeTipo
        {
            get { return _idMensajeTipo; }
            set { _idMensajeTipo = value; }
        }
        private string _nombreMensajeTipo;

        public string NombreMensajeTipo
        {
            get { return _nombreMensajeTipo; }
            set { _nombreMensajeTipo = value; }
        }
    }
}
