using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
    class SetSortedArray : ArraySorted, ISetSorted
    {
        public SetSortedArray(params int[] elems)
        : base(elems) { }

        public override bool insert(int elem)
        {
            (bool found, int index) = _search_(elem);
            if (found) // item bereits in Array
            {
                Console.WriteLine("Das Element befindet sich bereits im Array. ");
                return false;
            }
            else // item muss an index Stelle eingefügt werden
            {
                for (int i = length; i > index; i--)
                    data[i] = data[i - 1];

                data[index] = elem;
                length++;
                return true;
            }
        }
    }
}
