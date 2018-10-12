using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace YouCom.DTO
{
    [Serializable()]
    public class ItemCollection : CollectionBase
    {
        public Item this[int index]
        {
            get { return (Item)List[index]; }
            set { List[index] = value; }
        }
        public int Add(Item value)
        {
            return (List.Add(value));
        }
        public int IndexOf(Item value)
        {
            return (List.IndexOf(value));
        }
        public void Insert(int index, Item value)
        {
            List.Insert(index, value);
        }
        public void Remove(Item value)
        {
            List.Remove(value);
        }
        public bool Contains(Item value)
        {
            return (List.Contains(value));
        }
    }
}
