using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Mensajeria.Imagen
{
    public class ImagenMensajeNoticiaDTO
    {
        private decimal _idImagenMensajeNoticia;

        public decimal IdImagenMensajeNoticia
        {
            get { return _idImagenMensajeNoticia; }
            set { _idImagenMensajeNoticia = value; }
        }

        private MensajeNoticiaDTO theMensajeNoticiaDTO;
        public MensajeNoticiaDTO TheMensajeNoticiaDTO
        {
            get { return theMensajeNoticiaDTO; }
            set { theMensajeNoticiaDTO = value; }
        }

        private string _tituloImagenMensajeNoticia;

        public string TituloImagenMensajeNoticia
        {
            get { return _tituloImagenMensajeNoticia; }
            set { _tituloImagenMensajeNoticia = value; }
        }

        private string _thumbailImagenMensajeNoticia;

        public string ThumbailImagenMensajeNoticia
        {
            get { return _thumbailImagenMensajeNoticia; }
            set { _thumbailImagenMensajeNoticia = value; }
        }

        private string _grandeImagenMensajeNoticia;

        public string GrandeImagenMensajeNoticia
        {
            get { return _grandeImagenMensajeNoticia; }
            set { _grandeImagenMensajeNoticia = value; }
        }

    }
}
