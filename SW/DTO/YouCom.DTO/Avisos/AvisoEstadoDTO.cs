using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Avisos
{
    public class AvisoEstadoDTO : MantenedoresBase
    {

        private decimal _idAvisoEstado;

        public decimal IdAvisoEstado
        {
            get { return _idAvisoEstado; }
            set { _idAvisoEstado = value; }
        }
        private string _nombreAvisoEstado;

        public string NombreAvisoEstado
        {
            get { return _nombreAvisoEstado; }
            set { _nombreAvisoEstado = value; }
        }

    }
}