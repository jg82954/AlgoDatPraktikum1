using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
     class MultiSetSortedLinkedList : LinkedList
    {
        private bool found;
        public MultiSetSortedLinkedList()
        {
            Vers = ListPrintVersion.List;
        }
        protected bool PrivInsert(int elem)
        {
            ListItem nwItem = new ListItem(elem);
            if (first == null)  //1.Fall: Die Liste ist leer
            {
                first = last = nwItem;
                count++;
                return true;
            }
            if (found)  //Das Element wurde gefunden
            {
                if (pos==last)  //Die einzufuegende Stelle ist die Letzte
                {
                    nwItem.prev = last;
                    last.next = nwItem;
                    last = nwItem;
                    count++;
                    return true;
                }
                else  //Die einzufuegende Stelle ist mittendrin
                {
                    pos.next.prev = nwItem;
                    nwItem.prev = pos;
                    nwItem.next = pos.next;
                    pos.next = nwItem;
                    count++;
                    return true;
                }
            }
            else   //Das Element wurde nicht gefunden
            {
                if (pos==null)  //Das ELement muss vor das Letzte eingefuegt werden
                {
                    nwItem.prev = last;
                    last.next = nwItem;
                    last = nwItem;
                    count++;
                    return true;
                }
                else if (pos==first)    //Das Element muss als Erstes eingefuegt werden
                {
                    nwItem.next = pos;
                    pos.prev = nwItem;
                    first = nwItem;
                    count++;
                    return true;
                }
                else //Das Element muss vor die Stelle pos eingefuegt werden
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
            if (first == null)  //1.Fall: die Liste ist leer
                return false;
            while (pos.next != null && pos.key.CompareTo(elem) != 0)
            {
                if (pos.key.CompareTo(elem) > 0)    //Das aktuelle Element pos ist schon groesser als das zu suchende Element
                {
                    return false;
                }
                pos = pos.next;
            }
            if (pos.key.CompareTo(elem) == 0)   //1. Fall nach der Schleife: Das gesuchte ELement wurde gefunden
            {
                return true;
            }
            else //2. Fall: Das Ende der Liste wurde erreicht
            {
                if (pos.key.CompareTo(elem) < 0)    //Das Element ist kleiner als das Letzte
                {
                    pos = null;
                }
                return false;
            }
        }
    }
}
