using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Mensajeria.Video
{
    public class VideoMensajeNoticiaDTO
    {
        private decimal _idVideoMensajeNoticia;

        public decimal IdVideoMensajeNoticia
        {
            get { return _idVideoMensajeNoticia; }
            set { _idVideoMensajeNoticia = value; }
        }

        private MensajeNoticiaDTO theMensajeNoticiaDTO;
        public MensajeNoticiaDTO TheMensajeNoticiaDTO
        {
            get { return theMensajeNoticiaDTO; }
            set { theMensajeNoticiaDTO = value; }
        }

        private string _tituloVideoMensajeNoticia;

        public string TituloVideoMensajeNoticia
        {
            get { return _tituloVideoMensajeNoticia; }
            set { _tituloVideoMensajeNoticia = value; }
        }

        private string _urlVideoMensajeNoticia;

        public string UrlVideoMensajeNoticia
        {
            get { return _urlVideoMensajeNoticia; }
            set { _urlVideoMensajeNoticia = value; }
        }

        private string _urlWatchVideoMensajeNoticia;

        public string UrlWatchVideoMensajeNoticia
        {
            get { return _urlWatchVideoMensajeNoticia; }
            set { _urlWatchVideoMensajeNoticia = value; }
        }
    }
}
