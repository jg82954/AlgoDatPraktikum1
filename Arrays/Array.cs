using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
	abstract class Array : IDictionary
	{
		public Array()
		{
			length = 0; // Array wird initialisiert, indem die aktuelle Anzahl an Elementen 'length' auf 0 gesetzt wird
		}

		protected const int maxlength = 50;
		protected int length; // Anzahl an Elementen, die aktuell im Array gespeichert sind
		protected int[] data = new int[maxlength];

		public void print()
		{
            Console.Write("| ");
			for (int i = 0; i < length; i++)
			{
				Console.Write(data[i] + " | ");
			}
            Console.WriteLine();
        }
		public bool search(int elem)
		{
			(bool found, int index) = _search_(elem);
			return found;
		}
		public abstract bool insert(int elem);
		public abstract bool delete(int elem);

		protected abstract (bool, int ) _search_(int elem);  
    }
}
