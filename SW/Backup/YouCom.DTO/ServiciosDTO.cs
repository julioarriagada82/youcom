using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class ServiciosDTO: MantenedoresBase
    {
        private decimal _idServicio;

        public decimal IdServicio
        {
            get { return _idServicio; }
            set { _idServicio = value; }
        }
        private decimal _idRespServicio;

        public decimal IdRespServicio
        {
            get { return _idRespServicio; }
            set { _idRespServicio = value; }
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
        private decimal _idCategoria;

        public decimal IdCategoria
        {
            get { return _idCategoria; }
            set { _idCategoria = value; }
        }
        private decimal _idAdministracion;

        public decimal IdAdministracion
        {
            get { return _idAdministracion; }
            set { _idAdministracion = value; }
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
