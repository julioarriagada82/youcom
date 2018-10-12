using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class VacacionesDTO: MantenedoresBase
    {
        private decimal _idVacaciones;

        public decimal IdVacaciones
        {
            get { return _idVacaciones; }
            set { _idVacaciones = value; }
        }
        private decimal _idCasa;

        public decimal IdCasa
        {
            get { return _idCasa; }
            set { _idCasa = value; }
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
        private string _destinoVacaciones;

        public string DestinoVacaciones
        {
            get { return _destinoVacaciones; }
            set { _destinoVacaciones = value; }
        }
        private string _telefonoContacto;

        public string TelefonoContacto
        {
            get { return _telefonoContacto; }
            set { _telefonoContacto = value; }
        }
        private string _nombreContacto;

        public string NombreContacto
        {
            get { return _nombreContacto; }
            set { _nombreContacto = value; }
        }
        private decimal _idParentesco;

        public decimal IdParentesco
        {
            get { return _idParentesco; }
            set { _idParentesco = value; }
        }

        private string _comentario;

        public string Comentario
        {
            get { return _comentario; }
            set { _comentario = value; }
        }
    }
}
