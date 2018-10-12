using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Avisos
{
    public class ImagenAvisoDTO
    {
        private decimal _idImagenAviso;

        public decimal IdImagenAviso
        {
            get { return _idImagenAviso; }
            set { _idImagenAviso = value; }
        }

        private Avisos.AvisoDTO theAvisosDTO;
        public Avisos.AvisoDTO TheAvisosDTO
        {
            get { return theAvisosDTO; }
            set { theAvisosDTO = value; }
        }

        private string _tituloImagenAviso;

        public string TituloImagenAviso
        {
            get { return _tituloImagenAviso; }
            set { _tituloImagenAviso = value; }
        }

        private string _thumbailImagenAviso;

        public string ThumbailImagenAviso
        {
            get { return _thumbailImagenAviso; }
            set { _thumbailImagenAviso = value; }
        }

        private string _grandeImagenAviso;

        public string GrandeImagenAviso
        {
            get { return _grandeImagenAviso; }
            set { _grandeImagenAviso = value; }
        }
    }
}
