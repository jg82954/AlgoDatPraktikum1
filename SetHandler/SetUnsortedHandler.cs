using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
    class SetUnsortedHandler : IXSetHandler
    {
        public bool Handler()
        {
            Console.WriteLine("Sie haben SetUnsorted gewählt!\n");
            ErrorHandler errorhand = new ErrorHandler();
            MethodHandler inputhand = new MethodHandler();
            Console.WriteLine("Sie können wählen zwischen: \n1. Array \n2. verkette Liste \n3. HashTabQuadProb \n4. HashTabSepChain\n5. Hier kommen Sie zum Hauptmenü zurück\n");
            int number = errorhand.ErrorHandling(Console.ReadLine());
            switch (number)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Sie haben das Array in SetUnsorted gewählt!\n");
                    SetUnsortedArray array = new SetUnsortedArray();
                    inputhand.InputHandling(array);
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Sie haben die verkette Liste in SetUnsorted gewählt!\n");
                    SetUnsortedLinkedList list = new SetUnsortedLinkedList();
                    inputhand.InputHandling(list);
                    break;
                case 3:
                    //hash1
                    break;
                case 4:
                    //hash2
                    break;
                case 5:
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
