using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class CategoriaDTO : MantenedoresBase
    {
        private decimal _idCategoria;

        public decimal IdCategoria
        {
            get { return _idCategoria; }
            set { _idCategoria = value; }
        }
        private string _nombreCategoria;

        public string NombreCategoria
        {
            get { return _nombreCategoria; }
            set { _nombreCategoria = value; }
        }
        private string _descripcionCategoria;

        public string DescripcionCategoria
        {
            get { return _descripcionCategoria; }
            set { _descripcionCategoria = value; }
        }

        private TipoCategoriaDTO theTipoCategoriaDTO;
        public TipoCategoriaDTO TheTipoCategoriaDTO
        {
            get { return theTipoCategoriaDTO; }
            set { theTipoCategoriaDTO = value; }
        }
    }
}
