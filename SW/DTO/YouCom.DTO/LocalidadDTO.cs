using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class LocalidadDTO : MantenedoresBase
    {
        private string _idLocalidad;

        public string IdLocalidad
        {
            get { return _idLocalidad; }
            set { _idLocalidad = value; }
        }
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
        private RegionDTO theRegionDTO;

        public RegionDTO TheRegionDTO
        {
            get { return theRegionDTO; }
            set { theRegionDTO = value; }
        }
        private string _alias;
        public string Alias
        {
            get { return _alias; }
            set { _alias = value; }
        }

    }
}
