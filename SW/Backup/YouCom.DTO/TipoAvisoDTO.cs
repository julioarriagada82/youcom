using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class TipoAvisoDTO : MantenedoresBase
    {
        private decimal _idTipoAviso;

        public decimal IdTipoAviso
        {
            get { return _idTipoAviso; }
            set { _idTipoAviso = value; }
        }
        private string _nombreTipoAviso;

        public string NombreTipoAviso
        {
            get { return _nombreTipoAviso; }
            set { _nombreTipoAviso = value; }
        }
    }
}
