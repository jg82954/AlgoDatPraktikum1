using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
    abstract class ArraySorted : Array
    {
        public ArraySorted(params int[] elems)
        : base(elems) { }

        public override bool delete(int elem)
        {
            (bool found, int index) = _search_(elem);
            if (found) // elem ist in Array
            {
                data[length] = -1;
                for (int i = index; i < length; i++)
                    data[i] = data[i + 1];

                length--;
                // jetzt gilt:
                // data[length] = data[length+1] = -1

                return true;
            }
            else // elem nicht in Array
            {
                Console.WriteLine("Das Element war nicht in dem Array. ");
                return false;
            }
        }  
        public override bool search(int elem)
        {
            (bool found, int index) = _search_(elem);
            return found;
        } 

        protected override (bool, int) _search_(int elem) // true bedeutet gefunden,        -> int ist Stelle, wo elem sich befindet
                                                          // false bedeutet nicht vorhanden -> int ist Stelle, wo elem rein muss
        {
            int left = 0;
            int right = length - 1;
            int i = right / 2;
            while (true)
            {
                if (left > right) // item nicht in Array
                    return (false, left);

                if (data[i] < elem)
                    left = i + 1;
                else
                    right = i - 1;

                if (data[i] == elem)
                    return (true, i);

                i = (left + right) / 2;
            }
        } 
    }
}
