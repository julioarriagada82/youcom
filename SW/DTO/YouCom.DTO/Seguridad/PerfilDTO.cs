using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Seguridad
{
    public class PerfilDTO : MantenedoresBase
    {
        private decimal _idPerfil;

        public decimal IdPerfil
        {
            get { return _idPerfil; }
            set { _idPerfil = value; }
        }
        private string _nombrePerfil;

        public string NombrePerfil
        {
            get { return _nombrePerfil; }
            set { _nombrePerfil = value; }
        }
        private string _descripcionPerfil;

        public string DescripcionPerfil
        {
            get { return _descripcionPerfil; }
            set { _descripcionPerfil = value; }
        }
    }
}
