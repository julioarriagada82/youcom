using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Mensajeria.Imagen
{
    public class ImagenMensajePropietarioDTO
    {
        private decimal _idImagenMensajePropietario;

        public decimal IdImagenMensajePropietario
        {
            get { return _idImagenMensajePropietario; }
            set { _idImagenMensajePropietario = value; }
        }

        private MensajePropietarioDTO theMensajePropietarioDTO;
        public MensajePropietarioDTO TheMensajePropietarioDTO
        {
            get { return theMensajePropietarioDTO; }
            set { theMensajePropietarioDTO = value; }
        }

        private string _tituloImagenMensajePropietario;

        public string TituloImagenMensajePropietario
        {
            get { return _tituloImagenMensajePropietario; }
            set { _tituloImagenMensajePropietario = value; }
        }

        private string _thumbailImagenMensajePropietario;

        public string ThumbailImagenMensajePropietario
        {
            get { return _thumbailImagenMensajePropietario; }
            set { _thumbailImagenMensajePropietario = value; }
        }

        private string _grandeImagenMensajePropietario;

        public string GrandeImagenMensajePropietario
        {
            get { return _grandeImagenMensajePropietario; }
            set { _grandeImagenMensajePropietario = value; }
        }

    }
}
