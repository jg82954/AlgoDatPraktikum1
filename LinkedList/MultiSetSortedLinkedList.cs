using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
     class MultiSetSortedLinkedList : LinkedList
    {
        bool found;
        public MultiSetSortedLinkedList()
        {
            Vers = ListPrintVersion.List;
        }
        protected bool PrivInsert(int elem)
        {
            ListItem nwItem = new ListItem(elem);
            if (first == null)
            {
                first = last = nwItem;
                count++;
                return true;
            }
            if (found)
            {
                if (pos==last)
                {
                    nwItem.prev = last;
                    last.next = nwItem;
                    last = nwItem;
                    count++;
                    return true;
                }
                else
                {
                    pos.next.prev = nwItem;
                    nwItem.prev = pos;
                    nwItem.next = pos.next;
                    pos.next = nwItem;
                    count++;
                    return true;
                }
            }
            else
            {
                if (pos==null)
                {
                    nwItem.prev = last;
                    last.next = nwItem;
                    last = nwItem;
                    count++;
                    return true;
                }
                else if (pos==first)
                {
                    nwItem.next = pos;
                    pos.prev = nwItem;
                    first = nwItem;
                    count++;
                    return true;
                }
                else
                {
                    pos.prev.next = nwItem;
                    nwItem.prev = pos.prev;
                    nwItem.next = pos;
                    pos.prev = nwItem;
                    count++;
                    return true;
                }
            }
        }
        public override bool insert(int elem)
        {
            found = search(elem);
            return PrivInsert(elem);
        }
        public override bool search(int elem)
        {
            pos = first;
            //ListItem item = first;
            if (first == null)
                return false;
            while (pos.next != null && pos.key.CompareTo(elem) != 0)
            {
                if (pos.key.CompareTo(elem) > 0)
                {
                    return false;
                }
                pos = pos.next;
            }
            if (pos.key.CompareTo(elem) == 0)
            {
                return true;
            }
            else
            {
                if (pos.key.CompareTo(elem) < 0)
                {
                    pos = null;
                }
                return false;
            }
        }
    }
}
