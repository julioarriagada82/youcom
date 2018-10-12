using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class ArchivoDTO : MantenedoresBase
    {
        #region " Miembros Privados "
        // banner_id
        protected decimal _archivoId;
        // bann_nombre
        protected string _archivoTitulo;
        // bann_descripcion
        protected string _archivoDescripcion;
        // bann_imagen
        protected string _archivoNombre;
        // bann_archivo
        private CategoriaDTO theCategoriaDTO;
        #endregion // Propiedades de la Clase

        #region " Propiedades de la Clase "
        // configuracion_id
        public decimal ArchivoId
        {
            get
            {
                return _archivoId;
            }
            set
            {
                _archivoId = value;
            }
        }
        // bann_nombre
        public string ArchivoTitulo
        {
            get
            {
                return _archivoTitulo;
            }
            set
            {
                _archivoTitulo = value;
            }
        }
        // bann_descripcion
        public string ArchivoDescripcion
        {
            get
            {
                return _archivoDescripcion;
            }
            set
            {
                _archivoDescripcion = value;
            }
        }
        // bann_imagen
        public string ArchivoNombre
        {
            get
            {
                return _archivoNombre;
            }
            set
            {
                _archivoNombre = value;
            }
        }
        // bann_despliegue
        public CategoriaDTO TheCategoriaDTO
        {
            get { return theCategoriaDTO; }
            set { theCategoriaDTO = value; }
        }
        #endregion // Propiedades de la Clase
    }
}
