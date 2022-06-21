using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
    class RestartHandler
    {
        public bool RestartHandling()
        {
            bool restart = true;
            Console.WriteLine("Noch eine Runde? j/n");
            string s = Console.ReadLine();
            switch (s)
            {
                case "j":
                    restart=true;
                    break;
                case "n":
                    restart= false;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Bitte geben Sie einen gültigen Buchstaben ein\n");
                    restart= RestartHandling();
                    break;
            }
            return restart;
        }
    }
}
