using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.GastosComunes
{
    public class GastoComunEstadoDTO : MantenedoresBase
    {
        private decimal _idGastoComunEstado;

        public decimal IdGastoComunEstado
        {
            get { return _idGastoComunEstado; }
            set { _idGastoComunEstado = value; }
        }
        private string _nombreGastoComunEstado;

        public string NombreGastoComunEstado
        {
            get { return _nombreGastoComunEstado; }
            set { _nombreGastoComunEstado = value; }
        }
    }
}
