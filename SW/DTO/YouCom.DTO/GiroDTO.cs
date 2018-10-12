using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class GiroDTO : MantenedoresBase
    {
        private decimal _idGiro;

        public decimal IdGiro
        {
            get { return _idGiro; }
            set { _idGiro = value; }
        }
        private string _nombreGiro;

        public string NombreGiro
        {
            get { return _nombreGiro; }
            set { _nombreGiro = value; }
        }
        private string _descripcionGiro;

        public string DescripcionGiro
        {
            get { return _descripcionGiro; }
            set { _descripcionGiro = value; }
        }
    }
}
