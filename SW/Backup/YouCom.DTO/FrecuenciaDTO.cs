using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class FrecuenciaDTO : MantenedoresBase
    {
        private decimal _idFrecuencia;

        public decimal IdFrecuencia
        {
            get { return _idFrecuencia; }
            set { _idFrecuencia = value; }
        }
        private string _nombreFrecuencia;

        public string NombreFrecuencia
        {
            get { return _nombreFrecuencia; }
            set { _nombreFrecuencia = value; }
        }
    }
}
