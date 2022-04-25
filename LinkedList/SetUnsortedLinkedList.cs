using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
    class SetUnsortedLinkedList:MultiSetUnsortedLinkedList
    {
        public override bool insert(int elem)
        {
            if (!search(elem))
            {
                return base.insert(elem);
            }
            else
                return false;
            
        }
    }
}
