using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
	class SetUnsortedArray: Array, ISetUnsorted
	{
		public SetUnsortedArray()
		{

		}

		public override bool insert(int elem)
        {
			bool inserted = false;

			return inserted;
        }
		public override bool delete(int elem)
        {
            bool deleted = false;

            return deleted;
        }
        public override bool search(int elem)
        {
            bool found = false;

            return found;
        }
    }
}