using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class ComunidadDTO: MantenedoresBase
    {
        private decimal _idComunidad;

        public decimal IdComunidad
        {
            get { return _idComunidad; }
            set { _idComunidad = value; }
        }

        private string _nombreComunidad;

        public string NombreComunidad
        {
            get { return _nombreComunidad; }
            set { _nombreComunidad = value; }
        }

        private string _rutComunidad;

        public string RutComunidad
        {
            get { return _rutComunidad; }
            set { _rutComunidad = value; }
        }
        
        private string _direccionComunidad;

        public string DireccionComunidad
        {
            get { return _direccionComunidad; }
            set { _direccionComunidad = value; }
        }

        private string _telefonoComunidad;

        public string TelefonoComunidad
        {
            get { return _telefonoComunidad; }
            set { _telefonoComunidad = value; }
        }

        private string _correoComunidad;

        public string CorreoComunidad
        {
            get { return _correoComunidad; }
            set { _correoComunidad = value; }
        }
    }
}
