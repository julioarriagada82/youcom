using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Mensajeria
{
    public class EleccionMensajePorteriaDTO
    {
        private decimal _idEleccionMensajePorteria;

        public decimal IdEleccionMensajePorteria
        {
            get { return _idEleccionMensajePorteria; }
            set { _idEleccionMensajePorteria = value; }
        }

        private MensajePorteriaDTO theMensajePorteriaDTO;
        public MensajePorteriaDTO TheMensajePorteriaDTO
        {
            get { return theMensajePorteriaDTO; }
            set { theMensajePorteriaDTO = value; }
        }

        private DTO.Propietario.FamiliaDTO theFamiliaDTO;
        public DTO.Propietario.FamiliaDTO TheFamiliaDTO
        {
            get { return theFamiliaDTO; }
            set { theFamiliaDTO = value; }
        }

        private string _eleccionMensajePorteriaMeGusta;

        public string EleccionMensajePorteriaMeGusta
        {
            get { return _eleccionMensajePorteriaMeGusta; }
            set { _eleccionMensajePorteriaMeGusta = value; }
        }

        private DateTime _eleccionMensajePorteriaFecha;

        public DateTime EleccionMensajePorteriaFecha
        {
            get { return _eleccionMensajePorteriaFecha; }
            set { _eleccionMensajePorteriaFecha = value; }
        }

    }
}
