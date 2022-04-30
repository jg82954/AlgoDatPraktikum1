using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
    class SetUnsortedLinkedList:MultiSetUnsortedLinkedList
    {
        public SetUnsortedLinkedList()
        {
            Vers = ListPrintVersion.List;
        }
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
