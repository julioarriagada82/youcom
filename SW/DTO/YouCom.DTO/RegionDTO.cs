using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class RegionDTO : MantenedoresBase
    {
        private decimal _idRegion;
        public decimal IdRegion
        {
            get { return _idRegion; }
            set { _idRegion = value; }
        }

        private string _nombreRegion;

        public string NombreRegion
        {
            get { return _nombreRegion; }
            set { _nombreRegion = value; }
        }
        private string _descripcionRegion;

        public string DescripcionRegion
        {
            get { return _descripcionRegion; }
            set { _descripcionRegion = value; }
        }
        private PaisDTO thePaisDTO;
        public PaisDTO ThePaisDTO
        {
            get { return thePaisDTO; }
            set { thePaisDTO = value; }
        }
    }
}
