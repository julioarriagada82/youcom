using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class PaisDTO : MantenedoresBase
    {
        private decimal _idPais;

        public decimal IdPais
        {
            get { return _idPais; }
            set { _idPais = value; }
        }
        private string _nombrePais;

        public string NombrePais
        {
            get { return _nombrePais; }
            set { _nombrePais = value; }
        }

        private string _descripcionPais;

        public string DescripcionPais
        {
            get { return _descripcionPais; }
            set { _descripcionPais = value; }
        }
    }
}
