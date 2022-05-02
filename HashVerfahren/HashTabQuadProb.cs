using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
    class HashTabQuadProb : HashTabSepChain
    {
        public HashTabQuadProb():base()
        {
        }
        public override bool delete(int elem)
        {
            if (!search(elem))
            {
                return false;
            }
            return elementlist[pos].delete(elem);
        }

        public override bool insert(int elem)
        {
            if (search(elem))
            {
                return false;
            }
            return elementlist[pos].insert(elem);
        }

        public override bool search(int elem)
        {
            pos = 0;
            for (int i = 0; i < arraysize; i++)
            {
                pos = (HashFunction(elem) + i * i) % arraysize;
                if (pos == HashFunction(elem) && i != 0)
                {
                    return false;
                }
                if (elementlist[pos].count == 0)
                {
                    return false;
                }
                pos = (HashFunction(elem) - i * i) % arraysize;
                if (elementlist[pos].count == 0)
                {
                    return false;
                }
            }
            return true;
        }
        
    }
}
