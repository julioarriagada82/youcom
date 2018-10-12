using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Propuesta
{
    public class VotacionPropuestaRespuestaDTO
    {
        private VotacionPropuestaDTO theVotacionPropuestaDTO;
        public VotacionPropuestaDTO TheVotacionPropuestaDTO
        {
            get { return theVotacionPropuestaDTO; }
            set { theVotacionPropuestaDTO = value; }
        }

        private DTO.Propietario.FamiliaDTO theFamiliaDTO;
        public DTO.Propietario.FamiliaDTO TheFamiliaDTO
        {
            get { return theFamiliaDTO; }
            set { theFamiliaDTO = value; }
        }

        private DateTime _fechaVotacion;

        public DateTime FechaVotacion
        {
            get { return _fechaVotacion; }
            set { _fechaVotacion = value; }
        }

        private string _eleccionVotacion;

        public string EleccionVotacion
        {
            get { return _eleccionVotacion; }
            set { _eleccionVotacion = value; }
        }
    }
}
