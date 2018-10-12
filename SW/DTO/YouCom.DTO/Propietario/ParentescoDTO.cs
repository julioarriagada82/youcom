using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Propietario
{
    public class ParentescoDTO : MantenedoresBase
    {
        private decimal _idParentesco;

        public decimal IdParentesco
        {
            get { return _idParentesco; }
            set { _idParentesco = value; }
        }
        private string _nombreParentesco;

        public string NombreParentesco
        {
            get { return _nombreParentesco; }
            set { _nombreParentesco = value; }
        }
    }
}
