using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
    class MultiSetUnsortedLinkedList : LinkedList
    {
        public MultiSetUnsortedLinkedList()
        {
            Vers = ListPrintVersion.List;
        }
        public override bool insert(int elem)
        {
            ListItem nwItem = new ListItem(elem);
            if (first==null)    //1.Fall: Die Liste ist leer
            {
                first = last = nwItem;
                count++;
            }
            else //2.Fall: Das Element wird hinter das Letzte eingefuegt
            {
                last.next = nwItem;
                nwItem.prev = last;
                last = nwItem;
                count++;
            }
            return true;
        }
        public override bool search(int elem)
        {
            pos = first;
            if (first == null)  //1.Fall: die Liste ist leer
                return false;
            while (pos.next != null && pos.key.CompareTo(elem) != 0)
            {
                pos = pos.next;
            }
            if (pos.key.CompareTo(elem) == 0)   //1. Fall nach dem Schleifendurchlauf: Das Element wurde gefunden
            {
                return true;
            }
            return false; //2. Fall: das Element wurde nicht gefunden
        }
    }
}
