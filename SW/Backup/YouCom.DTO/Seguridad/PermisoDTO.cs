using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Seguridad
{
    public class PermisoDTO
    {
        private string _empresa;
        public string Empresa
        {
            get { return _empresa; }
            set { _empresa = value; }
        }
        private string _usuario;
        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
        private string _funcion;
        public string Funcion
        {
            get { return _funcion; }
            set { _funcion = value; }
        }
    }
}
