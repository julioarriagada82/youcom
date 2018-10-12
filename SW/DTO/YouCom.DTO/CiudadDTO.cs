using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class CiudadDTO : MantenedoresBase
    {
        private decimal _idCiudad;

        public decimal IdCiudad
        {
            get { return _idCiudad; }
            set { _idCiudad = value; }
        }
        private string _nombreCiudad;

        public string NombreCiudad
        {
            get { return _nombreCiudad; }
            set { _nombreCiudad = value; }
        }
        private string _descripcionCiudad;

        public string DescripcionCiudad
        {
            get { return _descripcionCiudad; }
            set { _descripcionCiudad = value; }
        }

        private RegionDTO theRegionDTO;
        public RegionDTO TheRegionDTO
        {
            get { return theRegionDTO; }
            set { theRegionDTO = value; }
        }
    }
}
