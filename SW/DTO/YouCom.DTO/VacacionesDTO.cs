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
        private DTO.Propietario.CasaDTO theCasaDTO;
        public DTO.Propietario.CasaDTO TheCasaDTO
        {
            get { return theCasaDTO; }
            set { theCasaDTO = value; }
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
        private Propietario.ParentescoDTO theParentescoDTO;
        public Propietario.ParentescoDTO TheParentescoDTO
        {
            get { return theParentescoDTO; }
            set { theParentescoDTO = value; }
        }
    }
}
