using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
    abstract class ArraySorted : Array
    {
        public ArraySorted()
        : base() { }

        public override bool delete(int elem)
        {
            (bool found, int index) = _search_(elem);
            if (found) // 'elem' in Array
            {
                length--;
                for (int i = index; i < length; i++)    // jedes Element nach dem zu löschenden,
                    data[i] = data[i + 1];              // wird "um 1 nach linkl geschoben"

                return true;
            }
            else // 'elem' nicht in Array
                return false;
        }

        /// <summary>
        /// zusätzliche Such-Methode, die als Rückgabewert zusätzlich noch den Index enthält,
        /// an dem sich das gefundene Element befindet (wenn das Element im Array ist),
        /// bzw. an dem das einzufügende Element eingefügt werden muss (wenn das Element nicht im Array ist)
        /// </summary>
        /// <param name="elem"></param>
        /// <returns>
        /// Rueckgabewert-true  bedeutet gefunden        -> Rueckgabe-int ist Stelle, wo 'elem' sich befindet
        /// Rueckgabewert-false bedeutet nicht vorhanden -> Rueckgabe-int ist Stelle, wo 'elem' hin muss
        /// </returns>
        protected override (bool, int) _search_(int elem) 
        {
            // binäre Suche:
            int left = 0;   
            int right = length - 1;
            int i = right / 2;
            while (true)
            {
                if (left > right)       // 'elem' ist nicht in Array, aber müsste am Index 'i' eingefügt werden
                    return (false, left);

                if (data[i] < elem)     // 'elem' müsste links von i stehen
                    left = i + 1;
                else                    // 'elem' müsste rechts von i stehen
                    right = i - 1;

                if (data[i] == elem)    // 'elem' ist gefunden, und befindet sich am Index 'i'
                    return (true, i);

                i = (left + right) / 2;
            }
        } 
    }
}
