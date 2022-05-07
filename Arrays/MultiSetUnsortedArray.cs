using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
	class MultiSetUnsortedArray: ArrayUnsorted, IMultiSetUnsorted
	{
        public MultiSetUnsortedArray(params int[] elems)
        : base(elems) { }

        public override bool insert(int elem)
        {
            data[length++] = elem; 
            return true;
        }
    }
}
