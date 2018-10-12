using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class NoticiaDTO : MantenedoresBase
    {
        #region " Miembros Privados "
        protected decimal _noticiaId;
        protected string _notiTitulo;
        protected string _notiResumen;
        protected string _notiDetalle;
        private CategoriaDTO theCategoriaDTO;
        protected DateTime _notiPublicacion;
        protected DateTime _notiInicio;
        protected string _notiExpira;
        protected DateTime _notiExpiracion;
        protected string _notiAutor;
        protected string _notiImagen;
        #endregion // Miembros Privados

        #region " Propiedades de la Clase "
        public decimal NoticiaId
        {
            get
            {
                return _noticiaId;
            }
            set
            {
                _noticiaId = value;
            }
        }
        public string NotiTitulo
        {
            get
            {
                return _notiTitulo;
            }
            set
            {
                _notiTitulo = value;
            }
        }
        public string NotiResumen
        {
            get
            {
                return _notiResumen;
            }
            set
            {
                _notiResumen = value;
            }
        }
        public string NotiDetalle
        {
            get
            {
                return _notiDetalle;
            }
            set
            {
                _notiDetalle = value;
            }
        }

        public CategoriaDTO TheCategoriaDTO
        {
            get { return theCategoriaDTO; }
            set { theCategoriaDTO = value; }
        }

        public DateTime NotiPublicacion
        {
            get
            {
                return _notiPublicacion;
            }
            set
            {
                _notiPublicacion = value;
            }
        }
        public DateTime NotiInicio
        {
            get
            {
                return _notiInicio;
            }
            set
            {
                _notiInicio = value;
            }
        }
        public string NotiExpira
        {
            get
            {
                return _notiExpira;
            }
            set
            {
                _notiExpira = value;
            }
        }
        // menu_estado
        public string NotiExpiraNombre
        {
            get
            {
                return !string.IsNullOrEmpty(_notiExpira) ? ("S".Equals(_notiExpira) ? "Si" : "No") : string.Empty;
            }
        }
        public DateTime NotiExpiracion
        {
            get
            {
                return _notiExpiracion;
            }
            set
            {
                _notiExpiracion = value;
            }
        }
        public string NotiAutor
        {
            get
            {
                return _notiAutor;
            }
            set
            {
                _notiAutor = value;
            }
        }
        public string NotiImagen
        {
            get
            {
                return _notiImagen;
            }
            set
            {
                _notiImagen = value;
            }
        }
        #endregion // Propiedades de la Clase
    }
}
