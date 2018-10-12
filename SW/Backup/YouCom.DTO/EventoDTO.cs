using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class EventoDTO : MantenedoresBase
    {
        #region " Miembros Privados "
        protected decimal _eventoId;
        protected string _eventoTitulo;
        protected string _eventoResumen;
        protected string _eventoDetalle;
        protected decimal _categoriaId;
        protected DateTime _eventoPublicacion;
        protected DateTime _eventoInicio;
        protected DateTime _eventoExpiracion;
        protected string _eventoAutor;
        protected string _eventoImagen;
        #endregion // Miembros Privados

        #region " Propiedades de la Clase "
        public decimal EventoId
        {
            get
            {
                return _eventoId;
            }
            set
            {
                _eventoId = value;
            }
        }
        public string EventoTitulo
        {
            get
            {
                return _eventoTitulo;
            }
            set
            {
                _eventoTitulo = value;
            }
        }
        public string EventoResumen
        {
            get
            {
                return _eventoResumen;
            }
            set
            {
                _eventoResumen = value;
            }
        }
        public string EventoDetalle
        {
            get
            {
                return _eventoDetalle;
            }
            set
            {
                _eventoDetalle = value;
            }
        }
        public decimal CategoriaId
        {
            get
            {
                return _categoriaId;
            }
            set
            {
                _categoriaId = value;
            }
        }
        public DateTime EventoPublicacion
        {
            get
            {
                return _eventoPublicacion;
            }
            set
            {
                _eventoPublicacion = value;
            }
        }
        public DateTime EventoInicio
        {
            get
            {
                return _eventoInicio;
            }
            set
            {
                _eventoInicio = value;
            }
        }
        public DateTime EventoExpiracion
        {
            get
            {
                return _eventoExpiracion;
            }
            set
            {
                _eventoExpiracion = value;
            }
        }
        public string EventoAutor
        {
            get
            {
                return _eventoAutor;
            }
            set
            {
                _eventoAutor = value;
            }
        }
        public string EventoImagen
        {
            get
            {
                return _eventoImagen;
            }
            set
            {
                _eventoImagen = value;
            }
        }
        #endregion // Propiedades de la Clase
    }
}