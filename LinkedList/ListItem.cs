using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
    public class ListItem
    {
        public int key; //integer Schluesselwert des Items
        public ListItem next = null, prev = null;
        public ListItem(int _key) 
        {
            key = _key; 
        }
        public override string ToString()
        {
            return $"Name: {key}, prev: {(prev == null ? 0 : prev.key)}, next: {(next == null ? 0 : next.key)}";
        }
    }
}
