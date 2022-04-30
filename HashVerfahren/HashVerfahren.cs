using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
    abstract class HashVerfahren:IDictionary
    {
        public int arraysize = 11;
        public SetUnsortedLinkedList[] elementlist;
        public HashVerfahren()
        {
            elementlist = new SetUnsortedLinkedList[arraysize];
            for (int i = 0; i < arraysize; i++)
            {
                elementlist[i] = new SetUnsortedLinkedList();
                elementlist[i].Vers = ListPrintVersion.HashTab;
            }
        }

        public abstract bool delete(int elem);

        public abstract bool insert(int elem);

        public void print()
        {
            foreach (var elem in elementlist)
            {
                if (elem==null||elem.count==0)
                {
                    Console.WriteLine("----");
                }
                else
                {
                    elem.print();
                    Console.Write("\n");
                }
                    
            }
        }

        public abstract bool search(int elem);

        public int HashFunction(int key)
        {
            return key % arraysize;
        }
    }
}
