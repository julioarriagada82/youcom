using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class TurnoDiarioDTO : MantenedoresBase
    {
        private decimal _idTurnoDiario;

        public decimal IdTurnoDiario
        {
            get { return _idTurnoDiario; }
            set { _idTurnoDiario = value; }
        }

        private decimal _idPortero;

        public decimal IdPortero
        {
            get { return _idPortero; }
            set { _idPortero = value; }
        }

        private decimal _idHorario;

        public decimal IdHorario
        {
            get { return _idHorario; }
            set { _idHorario = value; }
        }

        private string _nombreTurnoDiario;

        public string NombreTurnoDiario
        {
            get { return _nombreTurnoDiario; }
            set { _nombreTurnoDiario = value; }
        }
    }
}
