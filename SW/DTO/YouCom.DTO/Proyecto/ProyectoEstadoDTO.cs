using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class ProyectoEstadoDTO : MantenedoresBase
    {
        private decimal _idProyectoEstado;

        public decimal IdProyectoEstado
        {
            get { return _idProyectoEstado; }
            set { _idProyectoEstado = value; }
        }
        private string _nombreProyectoEstado;

        public string NombreProyectoEstado
        {
            get { return _nombreProyectoEstado; }
            set { _nombreProyectoEstado = value; }
        }

    }
}