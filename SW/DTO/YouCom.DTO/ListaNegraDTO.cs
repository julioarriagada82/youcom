using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class ListaNegraDTO :MantenedoresBase
    {
        private decimal _idListaNegra;

        public decimal IdListaNegra
        {
            get { return _idListaNegra; }
            set { _idListaNegra = value; }
        }

        private DTO.Propietario.CasaDTO theCasaDTO;
        public DTO.Propietario.CasaDTO TheCasaDTO
        {
            get { return theCasaDTO; }
            set { theCasaDTO = value; }
        }

        private DTO.Propietario.FamiliaDTO theFamiliaDTO;
        public DTO.Propietario.FamiliaDTO TheFamiliaDTO
        {
            get { return theFamiliaDTO; }
            set { theFamiliaDTO = value; }
        }
        private string _rutListaNegra;

        public string RutListaNegra
        {
            get { return _rutListaNegra; }
            set { _rutListaNegra = value; }
        }
        private string _nombreListaNegra;

        public string NombreListaNegra
        {
            get { return _nombreListaNegra; }
            set { _nombreListaNegra = value; }
        }

        private string _apellidoPaternoListaNegra;

        public string ApellidoPaternoListaNegra
        {
            get { return _apellidoPaternoListaNegra; }
            set { _apellidoPaternoListaNegra = value; }
        }

        private string _apellidoMaternoListaNegra;

        public string ApellidoMaternoListaNegra
        {
            get { return _apellidoMaternoListaNegra; }
            set { _apellidoMaternoListaNegra = value; }
        }

        private string _motivoListaNegra;

        public string MotivoListaNegra
        {
            get { return _motivoListaNegra; }
            set { _motivoListaNegra = value; }
        }

        public string NombreCompleto
        {
            get
            {
                return _nombreListaNegra + "  " + _apellidoPaternoListaNegra + "  " + _apellidoMaternoListaNegra;
            }
        }
    }
}
