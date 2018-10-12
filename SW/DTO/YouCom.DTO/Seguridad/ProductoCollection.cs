using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace YouCom.DTO
{
    [Serializable()]
    public class ProductoCollection : CollectionBase
    {
        public ProductoDTO this[int index]
        {
            get { return (ProductoDTO)List[index]; }
            set { List[index] = value; }
        }
        public int Add(ProductoDTO value)
        {
            return (List.Add(value));
        }
        public int IndexOf(ProductoDTO value)
        {
            return (List.IndexOf(value));
        }
        public void Insert(int index, ProductoDTO value)
        {
            List.Insert(index, value);
        }
        public void Remove(ProductoDTO value)
        {
            List.Remove(value);
        }
        public bool Contains(ProductoDTO value)
        {
            return (List.Contains(value));
        }
    }
}
