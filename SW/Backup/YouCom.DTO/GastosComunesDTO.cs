using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class GastosComunesDTO :MantenedoresBase
    {
        private decimal _idGastoComun;

        public decimal IdGastoComun
        {
            get { return _idGastoComun; }
            set { _idGastoComun = value; }
        }
        private decimal _idCasa;

        public decimal IdCasa
        {
            get { return _idCasa; }
            set { _idCasa = value; }
        }

        private string _descripcionGasto;

        public string DescripcionGasto
        {
            get { return _descripcionGasto; }
            set { _descripcionGasto = value; }
        }

        private decimal _montoGasto;

        public decimal MontoGasto
        {
            get { return _montoGasto; }
            set { _montoGasto = value; }
        }
        private DateTime _fechaGasto;

        public DateTime FechaGasto
        {
            get { return _fechaGasto; }
            set { _fechaGasto = value; }
        }
        private string _archivoGasto;

        public string ArchivoGasto
        {
            get { return _archivoGasto; }
            set { _archivoGasto = value; }
        }

        private string _estadoGasto;

        public string EstadoGasto
        {
            get { return _estadoGasto; }
            set { _estadoGasto = value; }
        }

        private DateTime _fechaPagoGasto;

        public DateTime FechaPagoGasto
        {
            get { return _fechaPagoGasto; }
            set { _fechaPagoGasto = value; }
        }

        private string _comentarioGasto;

        public string ComentarioGasto
        {
            get { return _comentarioGasto; }
            set { _comentarioGasto = value; }
        }
    }
}
