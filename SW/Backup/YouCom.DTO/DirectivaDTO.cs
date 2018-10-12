using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class DirectivaDTO : MantenedoresBase
    {
        private decimal _idDirectiva;

        public decimal IdDirectiva
        {
            get { return _idDirectiva; }
            set { _idDirectiva = value; }
        }

        private decimal _idCargo;

        public decimal IdCargo
        {
            get { return _idCargo; }
            set { _idCargo = value; }
        }

        private string _rutDirectiva;

        public string RutDirectiva
        {
            get { return _rutDirectiva; }
            set { _rutDirectiva = value; }
        }
        private string _nombreDirectiva;

        public string NombreDirectiva
        {
            get { return _nombreDirectiva; }
            set { _nombreDirectiva = value; }
        }
        private string _apellidoDirectiva;

        public string ApellidoDirectiva
        {
            get { return _apellidoDirectiva; }
            set { _apellidoDirectiva = value; }
        }
        private string _telefonoDirectiva;

        public string TelefonoDirectiva
        {
            get { return _telefonoDirectiva; }
            set { _telefonoDirectiva = value; }
        }

        private string _imagenDirectiva;

        public string ImagenDirectiva
        {
            get { return _imagenDirectiva; }
            set { _imagenDirectiva = value; }
        }

        private string _emailDirectiva;

        public string EmailDirectiva
        {
            get { return _emailDirectiva; }
            set { _emailDirectiva = value; }
        }
    }
}
