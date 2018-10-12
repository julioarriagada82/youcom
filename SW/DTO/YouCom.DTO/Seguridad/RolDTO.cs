using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Seguridad
{
    public class RolDTO
    {
        private decimal _codRol;

        public decimal CodRol
        {
            get { return _codRol; }
            set { _codRol = value; }
        }
        private string _nombreRol;

        public string NombreRol
        {
            get { return _nombreRol; }
            set { _nombreRol = value; }
        }
    }
}
