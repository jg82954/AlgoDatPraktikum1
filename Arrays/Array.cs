using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
	abstract class Array : IDictionary
	{
		public Array(params int[] elems)
		{
			length = elems.Length;
			foreach (int item in elems)
			{
				insert(item); // noch testen welche isert Methode er hier nimmt
			}
		}

		const int maxlength = 50;
		int length;
		int aktpos;
		int[] data = new int[maxlength];

		// indexer

		public void print()// ist überall gleich 
		{
            for (int i = 0; i < length; i++)
            {
                Console.Write(data[i] + " ");
            }
		}
		public abstract bool insert(int elem);
		public abstract bool delete(int elem);
		public abstract bool search(int elem);
        //protected int _search_(int elem)
        //{
        //    return 3;
        //}
    }
}