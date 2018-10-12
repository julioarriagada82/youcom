using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Servicio
{
    public class ResponsableDTO : MantenedoresBase
    {
        private decimal _idResponsable;

        public decimal IdResponsable
        {
            get { return _idResponsable; }
            set { _idResponsable = value; }
        }
        private string _nombreResponsable;

        public string NombreResponsable
        {
            get { return _nombreResponsable; }
            set { _nombreResponsable = value; }
        }

        private string _apellidoPaternoResponsable;

        public string ApellidoPaternoResponsable
        {
            get { return _apellidoPaternoResponsable; }
            set { _apellidoPaternoResponsable = value; }
        }

        private string _apellidoMaternoResponsable;

        public string ApellidoMaternoResponsable
        {
            get { return _apellidoMaternoResponsable; }
            set { _apellidoMaternoResponsable = value; }
        }

        private string _rutResponsable;

        public string RutResponsable
        {
            get { return _rutResponsable; }
            set { _rutResponsable = value; }
        }
        private string _telefonoResponsable;

        public string TelefonoResponsable
        {
            get { return _telefonoResponsable; }
            set { _telefonoResponsable = value; }
        }

        private string _celularResponsable;

        public string CelularResponsable
        {
            get { return _celularResponsable; }
            set { _celularResponsable = value; }
        }

        private string _emailResponsable;

        public string EmailResponsable
        {
            get { return _emailResponsable; }
            set { _emailResponsable = value; }
        }

        private string _fotoResponsable;

        public string FotoResponsable
        {
            get { return _fotoResponsable; }
            set { _fotoResponsable = value; }
        }

        private CargoDTO theCargoDTO;
        public CargoDTO TheCargoDTO
        {
            get { return theCargoDTO; }
            set { theCargoDTO = value; }
        }
    }
}
