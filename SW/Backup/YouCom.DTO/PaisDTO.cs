using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class PaisDTO : MantenedoresBase
    {
        private string _idPais;

        public string IdPais
        {
            get { return _idPais; }
            set { _idPais = value; }
        }
        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
    }
}
