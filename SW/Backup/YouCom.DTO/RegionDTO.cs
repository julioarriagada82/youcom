using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class RegionDTO : MantenedoresBase
    {
        private string _idRegion;
        public string IdRegion
        {
            get { return _idRegion; }
            set { _idRegion = value; }
        }

        private string _idPais;
        public string IdPais
        {
            get { return _idPais; }
            set { _idPais = value; }
        }
        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        private PaisDTO thePaisDTO;
        public PaisDTO ThePaisDTO
        {
            get { return thePaisDTO; }
            set { thePaisDTO = value; }
        }
    }
}
