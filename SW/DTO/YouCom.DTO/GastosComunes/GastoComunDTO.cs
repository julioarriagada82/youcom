using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.GastosComunes
{
    public class GastoComunDTO :MantenedoresBase
    {
        private decimal _idGastoComun;

        public decimal IdGastoComun
        {
            get { return _idGastoComun; }
            set { _idGastoComun = value; }
        }
        
        private DTO.Propietario.CasaDTO theCasaDTO;
        public DTO.Propietario.CasaDTO TheCasaDTO
        {
            get { return theCasaDTO; }
            set { theCasaDTO = value; }
        }

        private GastoComunEstadoDTO theGastoComunEstadoDTO;
        public GastoComunEstadoDTO TheGastoComunEstadoDTO
        {
            get { return theGastoComunEstadoDTO; }
            set { theGastoComunEstadoDTO = value; }
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

        private DateTime _fechaVencimiento;

        public DateTime FechaVencimiento
        {
            get { return _fechaVencimiento; }
            set { _fechaVencimiento = value; }
        }
        private string _archivoGasto;

        public string ArchivoGasto
        {
            get { return _archivoGasto; }
            set { _archivoGasto = value; }
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
