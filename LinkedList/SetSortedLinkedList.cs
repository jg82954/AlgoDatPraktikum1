using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
    class SetSortedLinkedList:MultiSetSortedLinkedList
    {
        public SetSortedLinkedList()
        {
            Vers = ListPrintVersion.List;
        }
        public override bool insert(int elem)
        {
            if (!search(elem))
            {
                return base.PrivInsert(elem);
            }
            else
                return false;
           
        }
    }
}
