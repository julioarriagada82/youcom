using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.AccesoHogar
{
    public class AccesoHogarDTO : MantenedoresBase
    {
        private decimal _idAccesoHogar;

        public decimal IdAccesoHogar
        {
            get { return _idAccesoHogar; }
            set { _idAccesoHogar = value; }
        }
        private DTO.Propietario.CasaDTO theCasaDTO;
        public DTO.Propietario.CasaDTO TheCasaDTO
        {
            get { return theCasaDTO; }
            set { theCasaDTO = value; }
        }
        private TipoVisitaDTO theTipoVisitaDTO;
        public TipoVisitaDTO TheTipoVisitaDTO
        {
            get { return theTipoVisitaDTO; }
            set { theTipoVisitaDTO = value; }
        }
        private FrecuenciaDTO theFrecuenciaDTO;
        public FrecuenciaDTO TheFrecuenciaDTO
        {
            get { return theFrecuenciaDTO; }
            set { theFrecuenciaDTO = value; }
        }

        private Propietario.FamiliaDTO theFamiliaDTO;
        public Propietario.FamiliaDTO TheFamiliaDTO
        {
            get { return theFamiliaDTO; }
            set { theFamiliaDTO = value; }
        }

        private DateTime _fechaInicio;

        public DateTime FechaInicio
        {
            get { return _fechaInicio; }
            set { _fechaInicio = value; }
        }
        private DateTime _fechaTermino;

        public DateTime FechaTermino
        {
            get { return _fechaTermino; }
            set { _fechaTermino = value; }
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

        private string _nombreVisita;

        public string NombreVisita
        {
            get { return _nombreVisita; }
            set { _nombreVisita = value; }
        }

        private string _apellidoPaternoVisita;

        public string ApellidoPaternoVisita
        {
            get { return _apellidoPaternoVisita; }
            set { _apellidoPaternoVisita = value; }
        }

        private string _apellidoMaternoVisita;

        public string ApellidoMaternoVisita
        {
            get { return _apellidoMaternoVisita; }
            set { _apellidoMaternoVisita = value; }
        }
        private string _rutVisita;

        public string RutVisita
        {
            get { return _rutVisita; }
            set { _rutVisita = value; }
        }
        private string _emailVisita;

        public string EmailVisita
        {
            get { return _emailVisita; }
            set { _emailVisita = value; }
        }
        private string _avisar;

        public string Avisar
        {
            get { return _avisar; }
            set { _avisar = value; }
        }

        public string NombreCompleto
        {
            get
            {
                return _nombreVisita + " " + _apellidoPaternoVisita + " " + _apellidoMaternoVisita;
            }
        }
    }
}
