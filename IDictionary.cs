using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
    interface IDictionary
    {
        void print();
        bool insert(int elem);
        bool delete(int elem);
        bool search(int elem);

    }
}
