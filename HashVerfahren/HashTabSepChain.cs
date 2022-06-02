using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
    class HashTabSepChain : HashVerfahren
    {
        public HashTabSepChain() : base()
        {

        }
        /// <summary>
        /// Loescht das Element mittels der Funktion der Klasse SetUnsortedLinkedList
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        public override bool delete(int elem)
        {
            return elementlist[HashFunction(elem)].delete(elem);
        }
        /// <summary>
        /// Fuegt das Element mittels der Funktion der Klasse SetUnsortedLinkedList ein
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        public override bool insert(int elem)
        {
            return elementlist[HashFunction(elem)].insert(elem);
        }
        /// <summary>
        /// Sucht das Element mittels der Funktion der Klasse SetUnsortedLinkedList
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        public override bool search(int elem)
        {
            return elementlist[HashFunction(elem)].search(elem);
        }
    }
}
