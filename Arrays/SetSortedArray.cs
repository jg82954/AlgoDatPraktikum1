using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
    class SetSortedArray : ArraySorted, ISetSorted
    {
        public SetSortedArray()
        : base() { }

        public override bool insert(int elem)
        {
            (bool found, int index) = _search_(elem);

            if (found) // 'elem' bereits in Array
                return false;

            else // 'elem' muss in 'data[index]' eingefügt werden
            {
                for (int i = length; i > index; i--)
                    data[i] = data[i - 1];  // jedes Element bis (einschließlich) 'data[index]' werden "um eins nach rechts verschoben"

                data[index] = elem;         // dann wird die einzufügende Zahl 'elem' an die ensprechende Stelle gespeichert
                length++;

                return true;
            }
        }
    }
}
