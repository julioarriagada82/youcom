using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Foro
{
    public class ForoComunidadEstadoDTO : MantenedoresBase
    {
        private decimal _idForoComunidadEstado;

        public decimal IdForoComunidadEstado
        {
            get { return _idForoComunidadEstado; }
            set { _idForoComunidadEstado = value; }
        }
        private string _nombreForoComunidadEstado;

        public string NombreForoComunidadEstado
        {
            get { return _nombreForoComunidadEstado; }
            set { _nombreForoComunidadEstado = value; }
        }

    }
}