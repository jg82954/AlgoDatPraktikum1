using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
	class SetUnsortedArray: ArrayUnsorted, ISetUnsorted
	{
		public SetUnsortedArray(params int[] elems)
        : base(elems) { }

        public override bool insert(int elem)
        {
            (bool found, int index) = _search_(elem);
            if (found) // falls elem schon in Array
            {
                Console.WriteLine("Element ist bereits im Array. ");
                return false;
            }
            else
            {
                data[length++] = elem;
                return true;
            }
        }
    }
}
