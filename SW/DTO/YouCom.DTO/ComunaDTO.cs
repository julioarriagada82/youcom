using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class ComunaDTO : MantenedoresBase
    {
        private decimal _idComuna;

        public decimal IdComuna
        {
            get { return _idComuna; }
            set { _idComuna = value; }
        }
        
        private string _nombreComuna;

        public string NombreComuna
        {
            get { return _nombreComuna; }
            set { _nombreComuna = value; }
        }
        private string _descripcionComuna;

        public string DescripcionComuna
        {
            get { return _descripcionComuna; }
            set { _descripcionComuna = value; }
        }

        private CiudadDTO theCiudadDTO;
        public CiudadDTO TheCiudadDTO
        {
            get { return theCiudadDTO; }
            set { theCiudadDTO = value; }
        }
    }
}
