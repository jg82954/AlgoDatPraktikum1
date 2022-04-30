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
            for (int i = 0; i < arraysize; i++)
            {
                int pos = (HashFunction(elem) + i*i) % arraysize;
                if (pos == HashFunction(elem) && i != 0)
                {
                    return false;
                }
                if (elementlist[pos].first.key==elem)
                {
                    return elementlist[pos].delete(elem);
                }
                pos = (HashFunction(elem) - i*i) % arraysize;
                if (elementlist[pos].first.key == elem)
                {
                    return elementlist[pos].delete(elem);
                }
            }
            return false;

        }

        public override bool insert(int elem)
        {
            if (search(elem))
            {
                return false;
            }
            for (int i = 0; i < arraysize; i++)
            {
                int pos = (HashFunction(elem) + i*i) % arraysize;
                if (pos==HashFunction(elem)&&i!=0)
                {
                    return false;
                }
                if (elementlist[pos].count==0)
                {
                    return elementlist[pos].insert(elem);
                }
                pos= (HashFunction(elem) - i*i) % arraysize;
                if (elementlist[pos].count == 0)
                {
                    return elementlist[pos].insert(elem);
                }
            }
            return false;
        }

        public override bool search(int elem)
        {
            return base.search(elem);
        }
        
    }
}
