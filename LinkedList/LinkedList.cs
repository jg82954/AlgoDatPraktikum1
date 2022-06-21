using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
    public enum ListPrintVersion { List,Hash}   //Unterscheidung fuer die Printfunktion zwischen Hashverfahren und Listen
    public abstract class LinkedList:IDictionary
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
        public ListItem first = null, last = null,pos=null; //Zeigervariable pos
        public int count { get;  set; } //Zaehlt die Anzahl an Elementen in der Liste
        public ListPrintVersion Vers { get; set; }

        public bool delete(int elem)
        {
            if (search(elem))
            {
                if (first == null)  //1.Fall: die Liste ist leer
                    return false;
                if (pos==first)  //Falls 2: Das gesuchte ELement ist das Erste
                    return DeleteFirst();     
                else if (pos==last) //Fall 3: Das gesuchte Element befindet sich am Ende
                    return DeleteLast();

                else  //Fall 4: Das gesuchte Element ist mittendrin
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
            
            if (first == last)  //Falls 1: Liste besteht aus einem Element
            {
                first = last = null;
            }


            else  //Fall 2: Liste hat mehr als ein Element
            {
                first = first.next;
                first.prev = null;
            }
            count--;
            return true;
        }

        private bool DeleteLast()
        {
            if (first == last) //Falls 1: Liste besteht aus einem Element
                first = last = null;
            else //Fall 2: Liste hat mehr als ein Element
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
            if (first==null)    //1.Fall: die Liste ist leer
            {
                Console.WriteLine("Ihre Liste ist leer!");
            }
            else
            {
                if (Vers==ListPrintVersion.List)    //Die Methode wird von einer Listenklasse aufgerufen
                {
                    for (ListItem item = first; item != null; item = item.next)
                    {
                        Console.WriteLine(item.key);
                    }
                    Console.WriteLine("------");
                    Console.WriteLine($"Anzahl an Elementen: {count}");
                    Console.WriteLine("------");
                }
                else //Die Methode wird von einer Hashklasse aufgerufen
                {
                    for (ListItem item = first; item != null; item = item.next)
                    {
                        if (item==first)
                        {
                            Console.Write(item.key);
                        }
                        else
                            Console.Write($"-->{item.key}");
                    }
                }
            }
            
        }

        public abstract bool search(int elem);
        
    }
}
