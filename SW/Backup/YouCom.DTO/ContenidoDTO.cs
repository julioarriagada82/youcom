using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class ContenidoDTO : MantenedoresBase
    {
        #region " Miembros Privados "
        // contenido_id
        protected decimal _contenidoId;
        // contenido_titulo
        protected string _contenidoTitulo;
        // contenido_resumen
        protected string _contenidoResumen;
        // contenido_banner
        protected string _contenidoBanner;
        // contenido_banner
        protected string _contenidoImagen;
        // contenido_detalle
        protected string _contenidoDetalle;
        #endregion // Propiedades de la Clase

        #region " Propiedades de la Clase "
        // usuario_id
        public decimal ContenidoId
        {
            get
            {
                return _contenidoId;
            }
            set
            {
                _contenidoId = value;
            }
        }
        // usua_login
        public string ContenidoTitulo
        {
            get
            {
                return _contenidoTitulo;
            }
            set
            {
                _contenidoTitulo = value;
            }
        }
        // usua_password
        public string ContenidoResumen
        {
            get
            {
                return _contenidoResumen;
            }
            set
            {
                _contenidoResumen = value;
            }
        }
        // usua_password_fecha
        public string ContenidoBanner
        {
            get
            {
                return _contenidoBanner;
            }
            set
            {
                _contenidoBanner = value;
            }
        }
        // usua_password_fecha
        public string ContenidoImagen
        {
            get
            {
                return _contenidoImagen;
            }
            set
            {
                _contenidoImagen = value;
            }
        }
        // usua_correo
        public string ContenidoDetalle
        {
            get
            {
                return _contenidoDetalle;
            }
            set
            {
                _contenidoDetalle = value;
            }
        }
        #endregion // Propiedades de la Clase
    }
}