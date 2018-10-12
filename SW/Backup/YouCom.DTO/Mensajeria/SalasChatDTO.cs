using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Mensajeria
{
    public class SalasChatDTO
    {
        private int _idSala;

        public int IdSala
        {
            get { return _idSala; }
            set { _idSala = value; }
        }

        private decimal _idCondominio;

        public decimal IdCondominio
        {
            get { return _idCondominio; }
            set { _idCondominio = value; }
        }

        private string _nombreSala;

        public string NombreSala
        {
            get { return _nombreSala; }
            set { _nombreSala = value; }
        }
    }
}
