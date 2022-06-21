using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
    class SetSortedLinkedList:MultiSetSortedLinkedList,ISetSorted
    {
        public SetSortedLinkedList()
        {
            Vers = ListPrintVersion.List;
        }
        public override bool insert(int elem)
        {
            if (!search(elem))  //Wenn das Element nicht gefunden wurde wird das Element eingfuegt
            {
                return base.PrivInsert(elem);
            }
            else
                return false;
           
        }
    }
}
