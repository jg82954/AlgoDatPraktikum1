using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
    class MultiSetSortedArray : ArraySorted, IMultiSetSorted
    {
        public MultiSetSortedArray(params int[] elems)
        : base(elems) { }

        public override bool insert(int elem)
        {
            (bool found, int index) = _search_(elem);

            for (int i = length; i > index; i--)
                data[i] = data[i - 1];

            data[index] = elem;
            length++;

            return true;
        }
    }
}
