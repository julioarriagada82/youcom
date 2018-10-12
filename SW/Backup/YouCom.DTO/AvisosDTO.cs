using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class AvisosDTO : MantenedoresBase
    {
        private decimal _idAviso;

        public decimal IdAviso
        {
            get { return _idAviso; }
            set { _idAviso = value; }
        }
        private decimal _idFamilia;

        public decimal IdFamilia
        {
            get { return _idFamilia; }
            set { _idFamilia = value; }
        }
        private string _tituloAviso;

        public string TituloAviso
        {
            get { return _tituloAviso; }
            set { _tituloAviso = value; }
        }

        private string _resumenAviso;

        public string ResumenAviso
        {
            get { return _resumenAviso; }
            set { _resumenAviso = value; }
        }

        private string _descripcionAviso;

        public string DescripcionAviso
        {
            get { return _descripcionAviso; }
            set { _descripcionAviso = value; }
        }

        private string _imagenAviso;

        public string ImagenAviso
        {
            get { return _imagenAviso; }
            set { _imagenAviso = value; }
        }

        private decimal _idTipo;

        public decimal IdTipo
        {
            get { return _idTipo; }
            set { _idTipo = value; }
        }
        private decimal _idCategoria;

        public decimal IdCategoria
        {
            get { return _idCategoria; }
            set { _idCategoria = value; }
        }
        private decimal _precio;

        public decimal Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }
        private decimal _idMoneda;

        public decimal IdMoneda
        {
            get { return _idMoneda; }
            set { _idMoneda = value; }
        }
        private DateTime _fechaPublicacion;

        public DateTime FechaPublicacion
        {
            get { return _fechaPublicacion; }
            set { _fechaPublicacion = value; }
        }
        private DateTime _fechaTermino;

        public DateTime FechaTermino
        {
            get { return _fechaTermino; }
            set { _fechaTermino = value; }
        }
        private string _rutComprador;

        public string RutComprador
        {
            get { return _rutComprador; }
            set { _rutComprador = value; }
        }
        private DateTime _fechaCompra;

        public DateTime FechaCompra
        {
            get { return _fechaCompra; }
            set { _fechaCompra = value; }
        }
    }
}
