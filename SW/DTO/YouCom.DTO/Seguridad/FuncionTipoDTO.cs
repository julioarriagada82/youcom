using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Seguridad
{
    public class FuncionTipoDTO : MantenedoresBase
    {
        private string _funcionTipoCod;
        public string FuncionTipoCod
        {
            get { return _funcionTipoCod; }
            set { _funcionTipoCod = value; }
        }
        private string _funcionTipoNombre;

        public string FuncionTipoNombre
        {
            get { return _funcionTipoNombre; }
            set { _funcionTipoNombre = value; }
        }
    }
}
