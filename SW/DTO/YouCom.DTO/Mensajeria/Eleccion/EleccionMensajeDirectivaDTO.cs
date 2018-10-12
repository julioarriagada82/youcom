using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Mensajeria
{
    public class EleccionMensajeDirectivaDTO
    {
        private decimal _idEleccionMensajeDirectiva;

        public decimal IdEleccionMensajeDirectiva
        {
            get { return _idEleccionMensajeDirectiva; }
            set { _idEleccionMensajeDirectiva = value; }
        }

        private MensajeDirectivaDTO theMensajeDirectivaDTO;
        public MensajeDirectivaDTO TheMensajeDirectivaDTO
        {
            get { return theMensajeDirectivaDTO; }
            set { theMensajeDirectivaDTO = value; }
        }

        private DTO.Propietario.FamiliaDTO theFamiliaDTO;
        public DTO.Propietario.FamiliaDTO TheFamiliaDTO
        {
            get { return theFamiliaDTO; }
            set { theFamiliaDTO = value; }
        }

        private string _eleccionMensajeDirectivaMeGusta;

        public string EleccionMensajeDirectivaMeGusta
        {
            get { return _eleccionMensajeDirectivaMeGusta; }
            set { _eleccionMensajeDirectivaMeGusta = value; }
        }

        private DateTime _eleccionMensajeDirectivaFecha;

        public DateTime EleccionMensajeDirectivaFecha
        {
            get { return _eleccionMensajeDirectivaFecha; }
            set { _eleccionMensajeDirectivaFecha = value; }
        }

    }
}
