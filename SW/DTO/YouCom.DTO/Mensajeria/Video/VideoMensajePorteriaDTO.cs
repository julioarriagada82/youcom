using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Mensajeria.Video
{
    public class VideoMensajePorteriaDTO
    {
        private decimal _idVideoMensajePorteria;

        public decimal IdVideoMensajePorteria
        {
            get { return _idVideoMensajePorteria; }
            set { _idVideoMensajePorteria = value; }
        }

        private MensajePorteriaDTO theMensajePorteriaDTO;
        public MensajePorteriaDTO TheMensajePorteriaDTO
        {
            get { return theMensajePorteriaDTO; }
            set { theMensajePorteriaDTO = value; }
        }

        private string _tituloVideoMensajePorteria;

        public string TituloVideoMensajePorteria
        {
            get { return _tituloVideoMensajePorteria; }
            set { _tituloVideoMensajePorteria = value; }
        }

        private string _urlVideoMensajePorteria;

        public string UrlVideoMensajePorteria
        {
            get { return _urlVideoMensajePorteria; }
            set { _urlVideoMensajePorteria = value; }
        }

        private string _urlWatchVideoMensajePorteria;

        public string UrlWatchVideoMensajePorteria
        {
            get { return _urlWatchVideoMensajePorteria; }
            set { _urlWatchVideoMensajePorteria = value; }
        }
    }
}
