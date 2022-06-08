using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
    class SetSortedHandler : IXSetHandler
    {
        public bool Handler()
        {
            Console.WriteLine("Sie haben SetSorted gewählt!\n");
            ErrorHandler errorhand = new ErrorHandler();
            MethodHandler inputhand = new MethodHandler();
            Console.WriteLine("Sie können wählen zwischen: \n1. Array \n2. verkette Liste \n3. BinSearchTree \n4. Treap \n5. AVLTree\n6. Hier kommen Sie zum Hauptmenü zurück\n");
            int number = errorhand.ErrorHandling(Console.ReadLine());
            switch (number)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Sie haben das Array in SetSorted gewählt!\n");
                    SetSortedArray array = new SetSortedArray();
                    inputhand.InputHandling(array);
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Sie haben die verkette Liste in SetSorted gewählt!\n");
                    SetSortedLinkedList list = new SetSortedLinkedList();
                    inputhand.InputHandling(list);
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Sie haben den binären Baum gewählt!\n");
                    BinSearchTree binsearchTree = new BinSearchTree();
                    inputhand.InputHandling(binsearchTree);
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Sie haben den Treap gewählt!\n");
                    Treap treap = new Treap();
                    inputhand.InputHandling(treap);
                    break;
                case 5:
                    //avlbaum
                    break;
                case 6:
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
