using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Seguridad
{
    public class ComunidadDTO: MantenedoresBase
    {
        private decimal _idComunidad;

        public decimal IdComunidad
        {
            get { return _idComunidad; }
            set { _idComunidad = value; }
        }

        private string _nombreCondominio;

        public string NombreCondominio
        {
            get { return _nombreCondominio; }
            set { _nombreCondominio = value; }
        }

        private string _nombreComunidad;

        public string NombreComunidad
        {
            get { return _nombreComunidad; }
            set { _nombreComunidad = value; }
        }

        private string _direccionComunidad;

        public string DireccionComunidad
        {
            get { return _direccionComunidad; }
            set { _direccionComunidad = value; }
        }
    }
}
