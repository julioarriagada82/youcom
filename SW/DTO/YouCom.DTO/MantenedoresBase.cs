using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class MantenedoresBase
    {
        private Seguridad.CondominioDTO theCondominioDTO;
        public Seguridad.CondominioDTO TheCondominioDTO
        {
            get { return theCondominioDTO; }
            set { theCondominioDTO = value; }
        }

        private Seguridad.ComunidadDTO theComunidadDTO;
        public Seguridad.ComunidadDTO TheComunidadDTO
        {
            get { return theComunidadDTO; }
            set { theComunidadDTO = value; }
        }

        private string _estado;

        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        private string _usuarioIngreso;

        public string UsuarioIngreso
        {
            get { return _usuarioIngreso; }
            set { _usuarioIngreso = value; }
        }
        private string _fechaIngreso;

        public string FechaIngreso
        {
            get { return _fechaIngreso; }
            set { _fechaIngreso = value; }
        }
        private string _usuarioModificacion;

        public string UsuarioModificacion
        {
            get { return _usuarioModificacion; }
            set { _usuarioModificacion = value; }
        }
        private string _fechaModificacion;

        public string FechaModificacion
        {
            get { return _fechaModificacion; }
            set { _fechaModificacion = value; }
        }
    }
}
