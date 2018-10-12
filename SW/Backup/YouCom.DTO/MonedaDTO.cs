using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class MonedaDTO:MantenedoresBase
    {
        private decimal _idMoneda;

        public decimal IdMoneda
        {
            get { return _idMoneda; }
            set { _idMoneda = value; }
        }
        private string _nombreMoneda;

        public string NombreMoneda
        {
            get { return _nombreMoneda; }
            set { _nombreMoneda = value; }
        }
    }
}
