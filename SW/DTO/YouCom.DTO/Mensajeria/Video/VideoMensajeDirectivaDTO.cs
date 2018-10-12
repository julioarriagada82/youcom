using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Mensajeria.Video
{
    public class VideoMensajeDirectivaDTO
    {
        private decimal _idVideoMensajeDirectiva;

        public decimal IdVideoMensajeDirectiva
        {
            get { return _idVideoMensajeDirectiva; }
            set { _idVideoMensajeDirectiva = value; }
        }

        private MensajeDirectivaDTO theMensajeDirectivaDTO;
        public MensajeDirectivaDTO TheMensajeDirectivaDTO
        {
            get { return theMensajeDirectivaDTO; }
            set { theMensajeDirectivaDTO = value; }
        }

        private string _tituloVideoMensajeDirectiva;

        public string TituloVideoMensajeDirectiva
        {
            get { return _tituloVideoMensajeDirectiva; }
            set { _tituloVideoMensajeDirectiva = value; }
        }

        private string _urlVideoMensajeDirectiva;

        public string UrlVideoMensajeDirectiva
        {
            get { return _urlVideoMensajeDirectiva; }
            set { _urlVideoMensajeDirectiva = value; }
        }

        private string _urlWatchVideoMensajeDirectiva;

        public string UrlWatchVideoMensajeDirectiva
        {
            get { return _urlWatchVideoMensajeDirectiva; }
            set { _urlWatchVideoMensajeDirectiva = value; }
        }
    }
}
