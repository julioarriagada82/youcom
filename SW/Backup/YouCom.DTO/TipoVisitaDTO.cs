using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class TipoVisitaDTO : MantenedoresBase
    {
        private decimal _idTipoVisita;

        public decimal IdTipoVisita
        {
            get { return _idTipoVisita; }
            set { _idTipoVisita = value; }
        }
        private string _nombreTipoVisita;

        public string NombreTipoVisita
        {
            get { return _nombreTipoVisita; }
            set { _nombreTipoVisita = value; }
        }
    }
}
