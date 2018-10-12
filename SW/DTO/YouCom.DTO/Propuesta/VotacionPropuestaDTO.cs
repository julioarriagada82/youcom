using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Propuesta
{
    public class VotacionPropuestaDTO : MantenedoresBase
    {
        private decimal _idVotacionPropuesta;

        public decimal IdVotacionPropuesta
        {
            get { return _idVotacionPropuesta; }
            set { _idVotacionPropuesta = value; }
        }

        private PropuestaDTO thePropuestaDTO;
        public PropuestaDTO ThePropuestaDTO
        {
            get { return thePropuestaDTO; }
            set { thePropuestaDTO = value; }
        }

        private DateTime _fechaInicioVotacionPropuesta;

        public DateTime FechaInicioVotacionPropuesta
        {
            get { return _fechaInicioVotacionPropuesta; }
            set { _fechaInicioVotacionPropuesta = value; }
        }

        private DateTime _fechaTerminoVotacionPropuesta;

        public DateTime FechaTerminoVotacionPropuesta
        {
            get { return _fechaTerminoVotacionPropuesta; }
            set { _fechaTerminoVotacionPropuesta = value; }
        }

        private VotacionPropuestaEstadoDTO theVotacionPropuestaEstadoDTO;
        public VotacionPropuestaEstadoDTO TheVotacionPropuestaEstadoDTO
        {
            get { return theVotacionPropuestaEstadoDTO; }
            set { theVotacionPropuestaEstadoDTO = value; }
        }

        private string _motivoEstado;

        public string MotivoEstado
        {
            get { return _motivoEstado; }
            set { _motivoEstado = value; }
        }

    }
}
