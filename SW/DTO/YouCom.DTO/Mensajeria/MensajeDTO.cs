using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Mensajeria
{
    public class MensajeDTO : MensajeBaseDTO
    {
        private decimal _idMensaje;

        public decimal IdMensaje
        {
            get { return _idMensaje; }
            set { _idMensaje = value; }
        }

        private decimal _idPadre;

        public decimal IdPadre
        {
            get { return _idPadre; }
            set { _idPadre = value; }
        }

        private MensajeTipoDTO theMensajeTipoDTO;
        public MensajeTipoDTO TheMensajeTipoDTO
        {
            get { return theMensajeTipoDTO; }
            set { theMensajeTipoDTO = value; }
        }

        private CategoriaDTO theCategoriaDTO;
        public CategoriaDTO TheCategoriaDTO
        {
            get { return theCategoriaDTO; }
            set { theCategoriaDTO = value; }
        }

        private DTO.Propietario.FamiliaDTO theFamiliaDTO;
        public DTO.Propietario.FamiliaDTO TheFamiliaDTO
        {
            get { return theFamiliaDTO; }
            set { theFamiliaDTO = value; }
        }

        private DirectivaDTO theDirectivaDTO;
        public DirectivaDTO TheDirectivaDTO
        {
            get { return theDirectivaDTO; }
            set { theDirectivaDTO = value; }
        }

        private PorteriaDTO thePorteriaDTO;
        public PorteriaDTO ThePorteriaDTO
        {
            get { return thePorteriaDTO; }
            set { thePorteriaDTO = value; }
        }
    }
}
