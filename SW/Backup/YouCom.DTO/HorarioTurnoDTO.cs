using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class HorarioTurnoDTO : MantenedoresBase
    {
        private decimal _idHorarioTurno;

        public decimal IdHorarioTurno
        {
            get { return _idHorarioTurno; }
            set { _idHorarioTurno = value; }
        }

        private decimal _idPeriodo;

        public decimal IdPeriodo
        {
            get { return _idPeriodo; }
            set { _idPeriodo = value; }
        }

        private string _horaInicio;

        public string HoraInicio
        {
            get { return _horaInicio; }
            set { _horaInicio = value; }
        }

        private string _horaTermino;

        public string HoraTermino
        {
            get { return _horaTermino; }
            set { _horaTermino = value; }
        }
    }
}
