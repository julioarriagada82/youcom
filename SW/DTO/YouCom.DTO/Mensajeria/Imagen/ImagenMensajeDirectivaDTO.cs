using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Mensajeria.Imagen
{
    public class ImagenMensajeDirectivaDTO
    {
        private decimal _idImagenMensajeDirectiva;

        public decimal IdImagenMensajeDirectiva
        {
            get { return _idImagenMensajeDirectiva; }
            set { _idImagenMensajeDirectiva = value; }
        }

        private MensajeDirectivaDTO theMensajeDirectivaDTO;
        public MensajeDirectivaDTO TheMensajeDirectivaDTO
        {
            get { return theMensajeDirectivaDTO; }
            set { theMensajeDirectivaDTO = value; }
        }

        private string _tituloImagenMensajeDirectiva;

        public string TituloImagenMensajeDirectiva
        {
            get { return _tituloImagenMensajeDirectiva; }
            set { _tituloImagenMensajeDirectiva = value; }
        }

        private string _thumbailImagenMensajeDirectiva;

        public string ThumbailImagenMensajeDirectiva
        {
            get { return _thumbailImagenMensajeDirectiva; }
            set { _thumbailImagenMensajeDirectiva = value; }
        }

        private string _grandeImagenMensajeDirectiva;

        public string GrandeImagenMensajeDirectiva
        {
            get { return _grandeImagenMensajeDirectiva; }
            set { _grandeImagenMensajeDirectiva = value; }
        }

    }
}
