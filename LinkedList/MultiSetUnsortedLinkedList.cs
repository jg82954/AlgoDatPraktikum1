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
            if (first==null)
            {
                first = last = nwItem;
                count++;
            }
            else
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
            //ListItem item = first;
            if (first == null)
                return false;
            while (pos.next != null && pos.key.CompareTo(elem) != 0)
            {
                pos = pos.next;
            }
            if (pos.key.CompareTo(elem) == 0)
            {
                return true;
            }
            return false;
        }
    }
}
