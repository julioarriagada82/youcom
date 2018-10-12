using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Mensajeria
{
    public class MensajeNoticiaDTO : MensajeBaseDTO
    {
        private decimal _idMensajeNoticia;

        public decimal IdMensajeNoticia
        {
            get { return _idMensajeNoticia; }
            set { _idMensajeNoticia = value; }
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

        private DTO.Propietario.FamiliaDTO theFamiliaOrigenDTO;
        public DTO.Propietario.FamiliaDTO TheFamiliaOrigenDTO
        {
            get { return theFamiliaOrigenDTO; }
            set { theFamiliaOrigenDTO = value; }
        }

        private DTO.Propietario.FamiliaDTO theFamiliaDestinoDTO;
        public DTO.Propietario.FamiliaDTO TheFamiliaDestinoDTO
        {
            get { return theFamiliaDestinoDTO; }
            set { theFamiliaDestinoDTO = value; }
        }
    }
}
