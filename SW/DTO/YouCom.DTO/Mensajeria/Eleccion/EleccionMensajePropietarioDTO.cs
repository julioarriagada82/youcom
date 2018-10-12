using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Mensajeria
{
    public class EleccionMensajePropietarioDTO
    {
        private decimal _idEleccionMensajePropietario;

        public decimal IdEleccionMensajePropietario
        {
            get { return _idEleccionMensajePropietario; }
            set { _idEleccionMensajePropietario = value; }
        }

        private MensajePropietarioDTO theMensajePropietarioDTO;
        public MensajePropietarioDTO TheMensajePropietarioDTO
        {
            get { return theMensajePropietarioDTO; }
            set { theMensajePropietarioDTO = value; }
        }

        private DTO.Propietario.FamiliaDTO theFamiliaDTO;
        public DTO.Propietario.FamiliaDTO TheFamiliaDTO
        {
            get { return theFamiliaDTO; }
            set { theFamiliaDTO = value; }
        }

        private string _eleccionMensajePropietarioMeGusta;

        public string EleccionMensajePropietarioMeGusta
        {
            get { return _eleccionMensajePropietarioMeGusta; }
            set { _eleccionMensajePropietarioMeGusta = value; }
        }

        private DateTime _eleccionMensajePropietarioFecha;

        public DateTime EleccionMensajePropietarioFecha
        {
            get { return _eleccionMensajePropietarioFecha; }
            set { _eleccionMensajePropietarioFecha = value; }
        }

    }
}
