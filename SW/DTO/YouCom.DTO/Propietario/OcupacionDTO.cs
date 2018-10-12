using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Propietario
{
    public class OcupacionDTO:MantenedoresBase
    {
        private decimal _idOcupacion;

        public decimal IdOcupacion
        {
            get { return _idOcupacion; }
            set { _idOcupacion = value; }
        }
        private string _nombreOcupacion;

        public string NombreOcupacion
        {
            get { return _nombreOcupacion; }
            set { _nombreOcupacion = value; }
        }
    }
}
