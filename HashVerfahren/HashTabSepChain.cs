using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
    class HashTabSepChain : HashVerfahren
    {
        public HashTabSepChain() : base()
        {

        }
        public override bool delete(int elem)
        {
            return elementlist[HashFunction(elem)].delete(elem);
        }

        public override bool insert(int elem)
        {
            return elementlist[HashFunction(elem)].insert(elem);
        }

        public override bool search(int elem)
        {
            return elementlist[HashFunction(elem)].search(elem);
        }
    }
}
