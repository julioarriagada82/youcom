using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Emergencia
{
    public class EmergenciaDTO : MantenedoresBase
    {
        private decimal _idEmergencia;

        public decimal IdEmergencia
        {
            get { return _idEmergencia; }
            set { _idEmergencia = value; }
        }


        private string _nombreEmergencia;

        public string NombreEmergencia
        {
            get { return _nombreEmergencia; }
            set { _nombreEmergencia = value; }
        }

        private string _descripcionEmergencia;

        public string DescripcionEmergencia
        {
            get { return _descripcionEmergencia; }
            set { _descripcionEmergencia = value; }
        }

        private TipoEmergenciaDTO theTipoEmergenciaDTO;
        public TipoEmergenciaDTO TheTipoEmergenciaDTO
        {
            get { return theTipoEmergenciaDTO; }
            set { theTipoEmergenciaDTO = value; }
        }
    }
}
