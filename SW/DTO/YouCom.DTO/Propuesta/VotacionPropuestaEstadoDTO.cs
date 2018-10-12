using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Propuesta
{
    public class VotacionPropuestaEstadoDTO : MantenedoresBase
    {
        private decimal _idVotacionPropuestaEstado;

        public decimal IdVotacionPropuestaEstado
        {
            get { return _idVotacionPropuestaEstado; }
            set { _idVotacionPropuestaEstado = value; }
        }
        private string _nombreVotacionPropuestaEstado;

        public string NombreVotacionPropuestaEstado
        {
            get { return _nombreVotacionPropuestaEstado; }
            set { _nombreVotacionPropuestaEstado = value; }
        }

    }
}