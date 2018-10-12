using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class BannerDTO : MantenedoresBase
    {
        #region " Miembros Privados "
        // banner_id
        protected decimal _bannerId;
        // bann_nombre
        protected string _bannerNombre;
        // bann_descripcion
        protected string _bannerDescripcion;
        // bann_imagen
        protected string _bannerImagen;
        // bann_tipo_despliegue
        protected string _bannerTipoDespliegue;
        // bann_link
        protected string _bannerLink;
        // bann_despliegue
        protected string _bannerTarget;
        // bann_archivo
        protected string _bannerArchivo;
        #endregion // Propiedades de la Clase

        #region " Propiedades de la Clase "
        // configuracion_id
        public decimal BannerId
        {
            get
            {
                return _bannerId;
            }
            set
            {
                _bannerId = value;
            }
        }
        // bann_nombre
        public string BannerNombre
        {
            get
            {
                return _bannerNombre;
            }
            set
            {
                _bannerNombre = value;
            }
        }
        // bann_descripcion
        public string BannerDescripcion
        {
            get
            {
                return _bannerDescripcion;
            }
            set
            {
                _bannerDescripcion = value;
            }
        }
        // bann_imagen
        public string BannerImagen
        {
            get
            {
                return _bannerImagen;
            }
            set
            {
                _bannerImagen = value;
            }
        }
        // bann_tipo_despliegue
        public string BannerTipoDespliegue
        {
            get
            {
                return _bannerTipoDespliegue;
            }
            set
            {
                _bannerTipoDespliegue = value;
            }
        }
        public string BannerTipoDespliegueNombre
        {
            get
            {
                switch (_bannerTipoDespliegue)
                {
                    case "A": return "Archivo";
                    case "L": return "URL";
                    case "F": return "Fijo";
                    default: return string.Empty;
                }
            }
        }
        // bann_archivo
        public string BannerArchivo
        {
            get
            {
                return _bannerArchivo;
            }
            set
            {
                _bannerArchivo = value;
            }
        }
        // bann_link
        public string BannerLink
        {
            get
            {
                return _bannerLink;
            }
            set
            {
                _bannerLink = value;
            }
        }
        // bann_despliegue
        public string BannerTarget
        {
            get
            {
                return _bannerTarget;
            }
            set
            {
                _bannerTarget = value;
            }
        }
        #endregion // Propiedades de la Clase
    }
}
