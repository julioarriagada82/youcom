using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Mensajeria
{
    public class EleccionNoticiaDTO
    {
        private decimal _idEleccionNoticia;

        public decimal IdEleccionNoticia
        {
            get { return _idEleccionNoticia; }
            set { _idEleccionNoticia = value; }
        }

        private DTO.NoticiaDTO theNoticiaDTO;
        public DTO.NoticiaDTO TheNoticiaDTO
        {
            get { return theNoticiaDTO; }
            set { theNoticiaDTO = value; }
        }

        private DTO.Propietario.FamiliaDTO theFamiliaDTO;
        public DTO.Propietario.FamiliaDTO TheFamiliaDTO
        {
            get { return theFamiliaDTO; }
            set { theFamiliaDTO = value; }
        }

        private string _eleccionNoticiaMeGusta;

        public string EleccionNoticiaMeGusta
        {
            get { return _eleccionNoticiaMeGusta; }
            set { _eleccionNoticiaMeGusta = value; }
        }

        private DateTime _eleccionNoticiaFecha;

        public DateTime EleccionNoticiaFecha
        {
            get { return _eleccionNoticiaFecha; }
            set { _eleccionNoticiaFecha = value; }
        }

    }
}
