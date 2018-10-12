using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class AccesoHogarDTO : MantenedoresBase
    {
        private decimal _idAccesoHogar;

        public decimal IdAccesoHogar
        {
            get { return _idAccesoHogar; }
            set { _idAccesoHogar = value; }
        }
        private decimal _idCasa;

        public decimal IdCasa
        {
            get { return _idCasa; }
            set { _idCasa = value; }
        }
        private decimal _idTipoVisita;

        public decimal IdTipoVisita
        {
            get { return _idTipoVisita; }
            set { _idTipoVisita = value; }
        }
        private decimal _idFrecuencia;

        public decimal IdFrecuencia
        {
            get { return _idFrecuencia; }
            set { _idFrecuencia = value; }
        }
        private decimal _idFamilia;

        public decimal IdFamilia
        {
            get { return _idFamilia; }
            set { _idFamilia = value; }
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
        private string _nombreVisita;

        public string NombreVisita
        {
            get { return _nombreVisita; }
            set { _nombreVisita = value; }
        }
        private string _rutVisita;

        public string RutVisita
        {
            get { return _rutVisita; }
            set { _rutVisita = value; }
        }
        private string _avisar;

        public string Avisar
        {
            get { return _avisar; }
            set { _avisar = value; }
        }
    }
}
