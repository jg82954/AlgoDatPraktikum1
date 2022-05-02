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
            Console.Clear();
            switch (number)
            {
                case 1:
                    //Array
                    break;
                case 2:
                    Console.WriteLine("Sie haben die verkette Liste in SetUnsorted gewählt!\n");
                    SetUnsortedLinkedList list = new SetUnsortedLinkedList();
                    inputhand.InputHandling(list);
                    break;
                case 3:
                    HashTabQuadProb hashQuad = new HashTabQuadProb();
                    Console.WriteLine($"Sie haben HashTabQuadProb in SetUnsorted mit Arraygroesse {hashQuad.arraysize} gewählt\n");
                    inputhand.InputHandling(hashQuad);
                    break;
                case 4:
                    HashTabSepChain hashChain = new HashTabSepChain();
                    Console.WriteLine($"Sie haben HashTabSepChain in SetUnsorted mit Arraygroesse {hashChain.arraysize} gewählt!\n");
                    inputhand.InputHandling(hashChain);
                    break;
                case 5:
                    return true;
                default:
                    Console.WriteLine("Bitte geben Sie eine Zahl zwischen 1 und 2 ein!\n");
                    Handler();
                    break;
            }
            return false;
        }
    }
}
