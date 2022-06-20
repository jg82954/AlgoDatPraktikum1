using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
	class MultiSetUnsortedArray: ArrayUnsorted, IMultiSetUnsorted
	{
        public MultiSetUnsortedArray()
        : base() { }

        public override bool insert(int elem)
        {
            data[length++] = elem; // 'elem' wird in 'data[length]' gespeichert und anschließend wird 'length' um eins erhöht
            return true;
        }
    }
}
