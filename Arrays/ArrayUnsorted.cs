using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
    abstract class ArrayUnsorted : Array
    {
        public ArrayUnsorted(params int[] elems)
        : base(elems) { }

        public override bool delete(int elem)
        {
            (bool found, int index) = _search_(elem);
            if (found)
            {
                data[index] = data[length];     // letzten in Lücke speicher
                data[length--] = -1;            // negative zahlen sind nicht erlaubt :)
                                                // aber geht das mit length-- richtig?
                return true;
            }
            else
            {
                Console.WriteLine("Item nicht im Array vorhanden. ");
                return false;
            }
        } 
        public override bool search(int elem)
        {
            (bool found, int index) = _search_(elem);
            return found;
        } 

        protected override (bool, int) _search_(int elem)  // bei true -> Item ist gefunden und befindet sich an index [int]
                                                           // bei false -> Item ist NICHT in Array, [int] ist Ort wo einzufügen (einfach length)
        {
            for (int i = 0; i < length; i++)
                if (data[i] == elem)
                    return (true, i);

            // ab hier ist elem NICHT in Array

            return (false, length);
        } 
    }
}
