using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.AccesoHogar
{
    public class AccesoHogarDetalleDTO : MantenedoresBase
    {
        private decimal _idAccesoHogarDetalle;

        public decimal IdAccesoHogarDetalle
        {
            get { return _idAccesoHogarDetalle; }
            set { _idAccesoHogarDetalle = value; }
        }

        private DTO.AccesoHogar.AccesoHogarDTO theAccesoHogarDTO;
        public DTO.AccesoHogar.AccesoHogarDTO TheAccesoHogarDTO
        {
            get { return theAccesoHogarDTO; }
            set { theAccesoHogarDTO = value; }
        }

        private DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        private DateTime _fechaVisita;

        public DateTime FechaVisita
        {
            get { return _fechaVisita; }
            set { _fechaVisita = value; }
        }
    }
}
