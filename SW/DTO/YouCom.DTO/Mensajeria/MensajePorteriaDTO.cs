using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Mensajeria
{
    public class MensajePorteriaDTO : MensajeBaseDTO
    {
        private decimal _idMensajePorteria;

        public decimal IdMensajePorteria
        {
            get { return _idMensajePorteria; }
            set { _idMensajePorteria = value; }
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

        private PorteriaDTO thePorteriaDTO;
        public PorteriaDTO ThePorteriaDTO
        {
            get { return thePorteriaDTO; }
            set { thePorteriaDTO = value; }
        }
    }
}
