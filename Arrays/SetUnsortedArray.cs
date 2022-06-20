using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
	class SetUnsortedArray: ArrayUnsorted, ISetUnsorted
	{
		public SetUnsortedArray()
        : base() { }

        public override bool insert(int elem)
        {
            (bool found, int index) = _search_(elem);

            if (found) // 'elem' schon in Array
                return false;
            else
            {
                data[length++] = elem; // 'elem' wird in 'data[length]' gespeichert und anschließend wird 'length' um eins erhöht
                return true;
            }
        }
    }
}
