using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
	abstract class Array : IDictionary
	{
		public Array(params int[] elems)
		{
			length = 0;
			foreach (int item in elems)
			{
				//length++;		// length muss hier immer erhöht werden, da sonst binäre Suche nicht funzt
				insert(item);	// noch testen welche isert Methode er hier nimmt
			}
		}

		protected const int maxlength = 50;
		protected int length; // anzahl an Elementen, die aktuell im Array gespeichert sind
		protected int[] data = new int[maxlength];

		// (indexer)

		public void print()// ist überall gleich 
		{
            Console.Write("| ");
			for (int i = 0; i < length; i++)
			{
				Console.Write(data[i] + " | ");
			}
            Console.WriteLine(/*"  Länge: " + length*/);
        }
		public abstract bool insert(int elem);
		public abstract bool delete(int elem);
		public abstract bool search(int elem);

		protected abstract (bool, int ) _search_(int elem); // wird dann trotz protected das richtige aufgerufen?
    }
}