using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace YouCom.DTO
{
    [Serializable()]
    public class CondominioCollection : CollectionBase
    {
        public Condominio this[int index]
        {
            get { return (Condominio)List[index]; }
            set { List[index] = value; }
        }
        public int Add(Condominio value)
        {
            return (List.Add(value));
        }
        public int IndexOf(Condominio value)
        {
            return (List.IndexOf(value));
        }
        public void Insert(int index, Condominio value)
        {
            List.Insert(index, value);
        }
        public void Remove(Condominio value)
        {
            List.Remove(value);
        }
        public bool Contains(Condominio value)
        {
            return (List.Contains(value));
        }
    }
}
