using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    [Serializable]
    public class ErrorDTO
    {
        private decimal _codError;
        private string _desError;

        public decimal CodError
        {
            get { return _codError; }
            set { _codError = value; }
        }

        public string DesError
        {
            get { return _desError; }
            set { _desError = value; }
        }
    }
}
