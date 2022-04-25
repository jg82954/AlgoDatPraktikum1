using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
    public abstract class LinkedList:IDictionary
    {
        protected ListItem first = null, last = null,pos=null;
        protected int count;

        public bool delete(int elem)
        {
            if (search(elem))
            {
                //Falls 2: Das gesuchte ELement ist das Erste
                if (pos==first)
                    return DeleteFirst();
                //Fall 3: Das gesuchte Element befindet sich am Ende
                else if (pos==last)
                    return DeleteLast();
                //Fall 4: Das gesuchte Element ist mittendrin
                else
                {
                    pos.prev.next = pos.next;
                    pos.next.prev = pos.prev;
                    count--;
                    return true;
                    
                }
            }
            return false;
        }
        private bool DeleteFirst()
        {
            //Falls 2: Liste besteht aus einem Element
            if (first == last)
            {
                first = last = null;
            }
                
            //Fall 3: Liste hat mehr als ein Element
            else
            {
                first = first.next;
                first.prev = null;
            }
            count--;
            return true;
        }

        private bool DeleteLast()
        {
            if (first == last)
                first = last = null;
            else
            {
                last = last.prev;
                last.next = null;
            }
            count--;
            return true;
        }
        public abstract bool insert(int elem);

        public void print()
        {
            if (first==null)
            {
                Console.WriteLine("Ihre Liste ist leer!");
            }
            else
            {
                for (ListItem item = first; item != null; item = item.next)
                {
                    Console.WriteLine(item.key);
                }
            }
            Console.WriteLine("------");
            Console.WriteLine($"Anzahl an Elementen: {count}");
            Console.WriteLine("------");
        }

        public abstract bool search(int elem);
        //public override bool search(int elem)
        //{
        //    pos = null;
        //    ListItem item = first;
        //    if (first == null)
        //        return false;
        //    while (item.next != null && item.key.CompareTo(elem) < 0)
        //    {
        //        item = item.next;
        //        pos = item;
        //        
        //    }
        //    if (item.key.CompareTo(elem) == 0)
        //    {
        //        return true;
        //    }
        //    else if (item.key.CompareTo(elem) > 0)
        //    {
        //        return false;
        //    }
        //    else if (item.next == null)
        //    {
        //        if (item.key.CompareTo(elem) < 0)
        //        {
        //            pos = null;
        //        }
        //        return false;
        //    }
        //    return false;
        //}

    }
}
