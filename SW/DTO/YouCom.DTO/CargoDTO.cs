using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class CargoDTO : MantenedoresBase
    {
        private decimal _idCargo;

        public decimal IdCargo
        {
            get { return _idCargo; }
            set { _idCargo = value; }
        }
        private string _nombreCargo;

        public string NombreCargo
        {
            get { return _nombreCargo; }
            set { _nombreCargo = value; }
        }
        private string _descripcionCargo;

        public string DescripcionCargo
        {
            get { return _descripcionCargo; }
            set { _descripcionCargo = value; }
        }
    }
}
