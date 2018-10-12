using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouCom.DTO.Mensajeria
{
    public class MensajeBaseDTO : MantenedoresBase
    {
        private DateTime _mensajeFecha;

        public DateTime MensajeFecha
        {
            get { return _mensajeFecha; }
            set { _mensajeFecha = value; }
        }

        private string _mensajeTitulo;

        public string MensajeTitulo
        {
            get { return _mensajeTitulo; }
            set { _mensajeTitulo = value; }
        }

        private string _mensajeDescripcion;

        public string MensajeDescripcion
        {
            get { return _mensajeDescripcion; }
            set { _mensajeDescripcion = value; }
        }
    }
}
