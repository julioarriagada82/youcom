using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Emergencia
{
    public class TipoEmergenciaDTO : MantenedoresBase
    {
        private decimal _idTipoEmergencia;

        public decimal IdTipoEmergencia
        {
            get { return _idTipoEmergencia; }
            set { _idTipoEmergencia = value; }
        }

        private string _nombreTipoEmergencia;

        public string NombreTipoEmergencia
        {
            get { return _nombreTipoEmergencia; }
            set { _nombreTipoEmergencia = value; }
        }
    }
}
