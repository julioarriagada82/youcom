using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class PropuestaEstadoDTO : MantenedoresBase
    {
        private decimal _idPropuestaEstado;

        public decimal IdPropuestaEstado
        {
            get { return _idPropuestaEstado; }
            set { _idPropuestaEstado = value; }
        }
        private string _nombrePropuestaEstado;

        public string NombrePropuestaEstado
        {
            get { return _nombrePropuestaEstado; }
            set { _nombrePropuestaEstado = value; }
        }

    }
}