using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Servicio
{
    public class ServiciosDTO: MantenedoresBase
    {
        private decimal _idServicio;

        public decimal IdServicio
        {
            get { return _idServicio; }
            set { _idServicio = value; }
        }

        private string _nombreServicio;

        public string NombreServicio
        {
            get { return _nombreServicio; }
            set { _nombreServicio = value; }
        }
        private string _descripcionServicio;

        public string DescripcionServicio
        {
            get { return _descripcionServicio; }
            set { _descripcionServicio = value; }
        }

        private CategoriaDTO theCategoriaDTO;
        public CategoriaDTO TheCategoriaDTO
        {
            get { return theCategoriaDTO; }
            set { theCategoriaDTO = value; }
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

        private string _imagenServicio;

        public string ImagenServicio
        {
            get { return _imagenServicio; }
            set { _imagenServicio = value; }
        }
    }
}
