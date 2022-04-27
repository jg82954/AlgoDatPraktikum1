using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
    class AbstractClassSelectionHandler
    {
        public void SelectionHandler()
        {
            ErrorHandler errorhand = new ErrorHandler();
            bool restart = true;
            bool jumpback = false;
            while (restart)
            {
                Console.WriteLine("Suchen Sie sich eine abstrakte Klasse aus: \n1. MultiSetSorted \n2. SetSorted \n3. MultiSetUnsorted \n4. SetUnsorted \n5. Hier beenden Sie das Programm\n");
                var number = errorhand.ErrorHandling(Console.ReadLine());
                Console.Clear();
                switch (number)
                {
                    case 1:
                        MultiSetSortedHandler MSetSHandler = new MultiSetSortedHandler();
                        jumpback=MSetSHandler.Handler();
                        break;
                    case 2:
                        SetSortedHandler SetSHandler = new SetSortedHandler();
                        jumpback = SetSHandler.Handler();
                        break;
                    case 3:
                        MultiSetUnsortedHandler MSetUHandler = new MultiSetUnsortedHandler();
                        jumpback = MSetUHandler.Handler();
                        break;
                    case 4:
                        SetUnsortedHandler SetUHandler = new SetUnsortedHandler();
                        jumpback = SetUHandler.Handler();
                        break;
                    case 5:
                        restart = false;
                        jumpback = true;
                        break;
                    default:
                        Console.WriteLine("Bitte geben Sie eine Zahl zwischen 1 und 4 ein!\n");
                        SelectionHandler();
                        break;
                }
                if(!jumpback)
                {
                    RestartHandler restHandler = new RestartHandler();
                    restart = restHandler.RestartHandling();
                }
                Console.Clear();
            }
            Console.WriteLine("Man sieht sich ^^ ");
        }
        
       
    }
}
