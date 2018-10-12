using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Mensajeria
{
    public class MensajeDirectivaDTO : MensajeBaseDTO
    {
        private decimal _idMensajeDirectiva;

        public decimal IdMensajeDirectiva
        {
            get { return _idMensajeDirectiva; }
            set { _idMensajeDirectiva = value; }
        }

        private decimal _idPadre;

        public decimal IdPadre
        {
            get { return _idPadre; }
            set { _idPadre = value; }
        }

        private CategoriaDTO theCategoriaDTO;
        public CategoriaDTO TheCategoriaDTO
        {
            get { return theCategoriaDTO; }
            set { theCategoriaDTO = value; }
        }

        private MensajeTipoEnvioDTO theMensajeTipoEnvioDTO;
        public MensajeTipoEnvioDTO TheMensajeTipoEnvioDTO
        {
            get { return theMensajeTipoEnvioDTO; }
            set { theMensajeTipoEnvioDTO = value; }
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
    }
}
