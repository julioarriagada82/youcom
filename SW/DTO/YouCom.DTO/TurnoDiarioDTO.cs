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

        private PorteriaDTO thePorteriaDTO;
        public PorteriaDTO ThePorteriaDTO
        {
            get { return thePorteriaDTO; }
            set { thePorteriaDTO = value; }
        }

        private HorarioTurnoDTO theHorarioTurnoDTO;
        public HorarioTurnoDTO TheHorarioTurnoDTO
        {
            get { return theHorarioTurnoDTO; }
            set { theHorarioTurnoDTO = value; }
        }

        private string _nombreTurnoDiario;

        public string NombreTurnoDiario
        {
            get { return _nombreTurnoDiario; }
            set { _nombreTurnoDiario = value; }
        }
    }
}
