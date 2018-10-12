using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    [Serializable()]
    public class ProductoDTO : Item
    {
        private ItemCollection _funciones;
        public ItemCollection Funciones
        {
            get
            {
                if (_funciones == null)
                    _funciones = new ItemCollection();
                return _funciones;
            }
           
        }
    }
}
