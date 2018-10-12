using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class CasaDTO : MantenedoresBase
    {
        private decimal _idCasa;

        public decimal IdCasa
        {
            get { return _idCasa; }
            set { _idCasa = value; }
        }
        private decimal _idFamilia;

        public decimal IdFamilia
        {
            get { return _idFamilia; }
            set { _idFamilia = value; }
        }

        private string _nombreCasa;

        public string NombreCasa
        {
            get { return _nombreCasa; }
            set { _nombreCasa = value; }
        }

        private string _direccionCasa;

        public string DireccionCasa
        {
            get { return _direccionCasa; }
            set { _direccionCasa = value; }
        }
        private string _telefonoCasa;

        public string TelefonoCasa
        {
            get { return _telefonoCasa; }
            set { _telefonoCasa = value; }
        }
        private int _cantidadIntegrantes;

        public int CantidadIntegrantes
        {
            get { return _cantidadIntegrantes; }
            set { _cantidadIntegrantes = value; }
        }
    }
}
