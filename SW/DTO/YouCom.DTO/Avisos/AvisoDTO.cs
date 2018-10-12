using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Avisos
{
    public class AvisoDTO : MantenedoresBase
    {
        private decimal _idAviso;

        public decimal IdAviso
        {
            get { return _idAviso; }
            set { _idAviso = value; }
        }

        private Propietario.FamiliaDTO theFamiliaDTO;
        public Propietario.FamiliaDTO TheFamiliaDTO
        {
            get { return theFamiliaDTO; }
            set { theFamiliaDTO = value; }
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

        private CategoriaDTO theCategoriaDTO;
        public CategoriaDTO TheCategoriaDTO
        {
            get { return theCategoriaDTO; }
            set { theCategoriaDTO = value; }
        }
        private decimal _precioAviso;

        public decimal PrecioAviso
        {
            get { return _precioAviso; }
            set { _precioAviso = value; }
        }
        private MonedaDTO theMonedaDTO;
        public MonedaDTO TheMonedaDTO
        {
            get { return theMonedaDTO; }
            set { theMonedaDTO = value; }
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

        private TipoAvisoDTO theTipoAvisoDTO;
        public TipoAvisoDTO TheTipoAvisoDTO
        {
            get { return theTipoAvisoDTO; }
            set { theTipoAvisoDTO = value; }
        }

        private Avisos.AvisoEstadoDTO theAvisosEstadoDTO;
        public Avisos.AvisoEstadoDTO TheAvisosEstadoDTO
        {
            get { return theAvisosEstadoDTO; }
            set { theAvisosEstadoDTO = value; }
        }

        private string _motivoAvisoEstado;

        public string MotivoAvisoEstado
        {
            get { return _motivoAvisoEstado; }
            set { _motivoAvisoEstado = value; }
        }
    }
}
