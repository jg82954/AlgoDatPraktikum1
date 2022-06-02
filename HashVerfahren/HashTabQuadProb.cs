using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
    class HashTabQuadProb : HashTabSepChain
    {
        public HashTabQuadProb():base()
        {
        }
        /// <summary>
        /// Löscht das Element über das quadratische Sondieren
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        public override bool delete(int elem)
        {
            if (!search(elem))  //Prüft, ob das Element bereits existiert und setzt die lokale Variable pos auf die Stelle an der das Element geloescht werden muesste
            {
                return false;
            }
            count--;
            return elementlist[pos].delete(elem);   //Das Element wird an der Stelle pos geloescht
        }
        /// <summary>
        /// Fügt das Element über das quadratische Sondieren ein
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        public override bool insert(int elem)
        {
            if (count==arraysize)   //Prüft, ob die Tabelle schon voll ist
            {
                Console.WriteLine("Die Hashtabelle ist voll!");
                return false;
            }
            if (search(elem))   //Prüft, ob das Element bereits existiert und setzt die lokale Variable pos auf die Stelle an der das Element einguegt werden muesste
            {
                return false;
            }
            count++;   
            return elementlist[pos].insert(elem);   //Das Element existiert noch nicht und wird deswegen an der Stelle pos über die Methode der Klasse SetUnsortedLinkedList eingefuegt
        }
        /// <summary>
        /// Suche durch quadratisches Sondieren
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        public override bool search(int elem)
        {
            pos = 0;
            for (int i = 0; i < arraysize; i++)
            {
                pos = (HashFunction(elem) + i * i) % arraysize;
                if (pos == HashFunction(elem) && i != 0)    //1. Fall: Der Zaehler pos zeigt auf dieselbe Stelle wie die Hashfunktion und es ist Nicht der erste Schritt => Abbruch 
                {
                    return false;
                }
                if (elementlist[pos].count==0)  //2. Fall: An der Stelle pos gibt es kein Element => nicht gefunden
                {
                    return false;
                }
                else if (elementlist[pos].first.key.CompareTo(elem) == 0)   //3. Fall: Das Element an der Stelle pos ist das gesuchte Element => wurde gefunden
                {
                    return true;
                }
                pos = GetPositive((HashFunction(elem) - i * i) % arraysize);    //Testen für - i^2
                if (elementlist[pos].count == 0)    // siehe 2. Fall
                {
                    return false;
                }
                else if (elementlist[pos].first.key.CompareTo(elem) == 0)   // siehe 3. Fall
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Liefert den positiven Modulowert des Element zurück
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        private int GetPositive(int elem)
        {
            while (elem<0)
            {
                elem += arraysize;
            }
            return elem;
        }
    }
}
