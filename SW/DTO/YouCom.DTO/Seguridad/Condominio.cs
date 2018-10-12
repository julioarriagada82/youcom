using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    [Serializable()]
    public class Condominio : Item
    {
        private ProductoCollection _productos;
        public ProductoCollection Productos
        {
            get
            {
                if (_productos == null)
                    _productos = new ProductoCollection();
                return _productos;
            }
        }
    }
}
