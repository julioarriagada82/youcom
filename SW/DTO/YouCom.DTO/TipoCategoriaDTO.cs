using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class TipoCategoriaDTO : MantenedoresBase
    {
        private decimal _idTipoCategoria;

        public decimal IdTipoCategoria
        {
            get { return _idTipoCategoria; }
            set { _idTipoCategoria = value; }
        }
        private string _nombreTipoCategoria;

        public string NombreTipoCategoria
        {
            get { return _nombreTipoCategoria; }
            set { _nombreTipoCategoria = value; }
        }
    }
}
