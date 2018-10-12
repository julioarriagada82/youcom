using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class PeriodoHorarioDTO : MantenedoresBase
    {
        private decimal _idPeriodoHorario;

        public decimal IdPeriodoHorario
        {
            get { return _idPeriodoHorario; }
            set { _idPeriodoHorario = value; }
        }

        private string _nombrePeriodoHorario;

        public string NombrePeriodoHorario
        {
            get { return _nombrePeriodoHorario; }
            set { _nombrePeriodoHorario = value; }
        }

    }
}
