using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
    abstract class HashVerfahren:IDictionary
    {
        public int arraysize = 11;  //feste Arraygroesse
        protected int pos; //lokale Zeigervariable
        protected SetUnsortedLinkedList[] elementlist; //Alle Eintraege der Hashtabelle sind Elemente von SetUnsortedLinkedList
        protected int count { get; set; }  //Zaehler fuer die Anzahl an Eintraegen in der Tabelle
        public HashVerfahren()
        {
            elementlist = new SetUnsortedLinkedList[arraysize]; //Die Hashtabelle wird erzeugt
            for (int i = 0; i < arraysize; i++)
            {
                elementlist[i] = new SetUnsortedLinkedList();   //jedes Element der Tabelle muss instanziiert werden
                elementlist[i].Vers = ListPrintVersion.Hash; //Die Version der Print-Methode der Klasse SetUnsortedLinkedList wird auf das HashVerfahren gestellt
                count = 0;
            }
        }

        public abstract bool delete(int elem);  //Jede Unterklasse muss die delete-Funktion überschreiben

        public abstract bool insert(int elem);  //Jede Unterklasse muss die insert-Funktion überschreiben

        public void print()
        {
            foreach (var elem in elementlist)   
            {
                if (elem==null||elem.count==0)  //1.Fall: kein Eintrag in dem Element
                {
                    Console.WriteLine("----");
                }
                else   //2. Fall: Es existiert ein Element und die print-Methode der SetUnsortedLinkedList wird ausgenutzt
                {
                    elem.print();
                    Console.Write("\n");
                }
                    
            }
        }

        public abstract bool search(int elem);  //Jede Unterklasse muss die search-Funktion überschreiben

        protected int HashFunction(int key)    //Modulo-Hashfunktion
        {
            return key % arraysize;
        }
    }
}
