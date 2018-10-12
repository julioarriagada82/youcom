using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class AreasComunesDTO : MantenedoresBase
    {
        private decimal _idAreaSComunes;

        public decimal IdAreasComunes
        {
            get { return _idAreaSComunes; }
            set { _idAreaSComunes = value; }
        }
        private string _nombreAreasComunes;

        public string NombreAreasComunes
        {
            get { return _nombreAreasComunes; }
            set { _nombreAreasComunes = value; }
        }

        private int _cantidadHora;

        public int CantidadHora
        {
            get { return _cantidadHora; }
            set { _cantidadHora = value; }
        }
    }
}
