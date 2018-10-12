using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    [Serializable()]
    public class Item
    {
        private string _codigo;
        private string _descripcion;

        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public Item()
        {
        }

    }
}
