using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Mensajeria.Imagen
{
    public class ImagenMensajePorteriaDTO
    {
        private decimal _idImagenMensajePorteria;

        public decimal IdImagenMensajePorteria
        {
            get { return _idImagenMensajePorteria; }
            set { _idImagenMensajePorteria = value; }
        }

        private MensajePorteriaDTO theMensajePorteriaDTO;
        public MensajePorteriaDTO TheMensajePorteriaDTO
        {
            get { return theMensajePorteriaDTO; }
            set { theMensajePorteriaDTO = value; }
        }

        private string _tituloImagenMensajePorteria;

        public string TituloImagenMensajePorteria
        {
            get { return _tituloImagenMensajePorteria; }
            set { _tituloImagenMensajePorteria = value; }
        }

        private string _thumbailImagenMensajePorteria;

        public string ThumbailImagenMensajePorteria
        {
            get { return _thumbailImagenMensajePorteria; }
            set { _thumbailImagenMensajePorteria = value; }
        }

        private string _grandeImagenMensajePorteria;

        public string GrandeImagenMensajePorteria
        {
            get { return _grandeImagenMensajePorteria; }
            set { _grandeImagenMensajePorteria = value; }
        }

    }
}
