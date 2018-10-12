using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Servicio
{
    public class TipoEmpresaServicioDTO
    {
        private decimal _idTipoEmpresaServicio;

        public decimal IdTipoEmpresaServicio
        {
            get { return _idTipoEmpresaServicio; }
            set { _idTipoEmpresaServicio = value; }
        }
        private string _nombreTipoEmpresaServicio;

        public string NombreTipoEmpresaServicio
        {
            get { return _nombreTipoEmpresaServicio; }
            set { _nombreTipoEmpresaServicio = value; }
        }
    }
}
