using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Foro
{
    public class TipoForoDTO : MantenedoresBase
    {
        private decimal _idTipoForo;

        public decimal IdTipoForo
        {
            get { return _idTipoForo; }
            set { _idTipoForo = value; }
        }
        private string _nombreTipoForo;

        public string NombreTipoForo
        {
            get { return _nombreTipoForo; }
            set { _nombreTipoForo = value; }
        }
    }
}
