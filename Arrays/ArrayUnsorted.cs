using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
    abstract class ArrayUnsorted : Array
    {
        public ArrayUnsorted()
        : base() { }

        public override bool delete(int elem)
        {
            (bool found, int index) = _search_(elem);
            if (found)  // 'elem' in Array
            {
                data[index] = data[length--];     // letzten Element in Array in die entstandene Lücke speichern
                                                  // das letzte Element steht jetzt zwar doppelt im Array (an 'data[index]' und an 'data[length]'
                                                  // das ist aber nicht weiter schlimm, 'data[length]' nicht im eigentlichen Array ist, da die
                                                  // gültigen Indizes nur bis 'length-1' gehen
                return true;
            }
            else    // 'elem' nicht in Array
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
            // sequienzielle Suche:
            for (int i = 0; i < length; i++) 
                if (data[i] == elem)
                    return (true, i);

            // ab hier ist elem nicht in Array
            return (false, length);
        } 
    }
}
