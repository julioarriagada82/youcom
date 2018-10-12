using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Mensajeria.Video
{
    public class VideoMensajePropietarioDTO
    {
        private decimal _idVideoMensajePropietario;

        public decimal IdVideoMensajePropietario
        {
            get { return _idVideoMensajePropietario; }
            set { _idVideoMensajePropietario = value; }
        }

        private MensajePropietarioDTO theMensajePropietarioDTO;
        public MensajePropietarioDTO TheMensajePropietarioDTO
        {
            get { return theMensajePropietarioDTO; }
            set { theMensajePropietarioDTO = value; }
        }

        private string _tituloVideoMensajePropietario;

        public string TituloVideoMensajePropietario
        {
            get { return _tituloVideoMensajePropietario; }
            set { _tituloVideoMensajePropietario = value; }
        }

        private string _urlVideoMensajePropietario;

        public string UrlVideoMensajePropietario
        {
            get { return _urlVideoMensajePropietario; }
            set { _urlVideoMensajePropietario = value; }
        }

        private string _urlWatchVideoMensajePropietario;

        public string UrlWatchVideoMensajePropietario
        {
            get { return _urlWatchVideoMensajePropietario; }
            set { _urlWatchVideoMensajePropietario = value; }
        }
    }
}
