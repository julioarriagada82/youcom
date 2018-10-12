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
        private decimal _idFamilia;

        public decimal IdFamilia
        {
            get { return _idFamilia; }
            set { _idFamilia = value; }
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
        private string _apellidoListaNegra;

        public string ApellidoListaNegra
        {
            get { return _apellidoListaNegra; }
            set { _apellidoListaNegra = value; }
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
                return _nombreListaNegra + " - " + _apellidoListaNegra;
            }
        }
    }
}
