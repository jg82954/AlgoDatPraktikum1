using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
    class MultiSetSortedHandler:IXSetHandler
    {
        public bool Handler()
        {
            Console.WriteLine("Sie haben MultiSetSorted gewählt!\n");
            ErrorHandler errorhand = new ErrorHandler();
            MethodHandler inputhand = new MethodHandler();
            Console.WriteLine("Sie können wählen zwischen: \n1. Array \n2. verkette Liste \n3. Hier kommen Sie zum Hauptmenü zurück\n");
            int number = errorhand.ErrorHandling(Console.ReadLine());
            switch (number)
            {
                case 1:
                    //MultiSetSortedArray array= new MultiSetSortedArray
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Sie haben die verkette Liste in MultiSetSorted gewählt!\n");
                    MultiSetSortedLinkedList list = new MultiSetSortedLinkedList();
                    inputhand.InputHandling(list);
                    break;
                case 3:
                    return true;
                default:
                    Console.Clear();
                    Console.WriteLine("Bitte geben Sie eine Zahl zwischen 1 und 2 ein!\n");
                    Handler();
                    break;
            }
            return false;
        }
    }
}
