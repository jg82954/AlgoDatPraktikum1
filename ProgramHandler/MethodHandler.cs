using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
    class MethodHandler
    {
        public void InputHandling<T>(T element) where T : IDictionary
        {
            ErrorHandler errorhand = new ErrorHandler();
            bool abort = false;
            while (!abort)
            {
                Console.WriteLine("Sie können wählen zwischen den Befehlen: \ndelete \ninsert \nprint \nsearch \nBitte geben Sie die passende Methode mit ihrer gewünschten Zahl hinter einem Pipe ein:\nBeispiel: delete|5\nMit dem Wort exit beenden Sie den Vorgang\n");
                string[] input = Console.ReadLine().Split('|');
                bool done = false;
                switch (input[0])
                {
                    case "delete":
                        done = element.delete(errorhand.ErrorHandling(input[1]));
                        Console.Clear();
                        if (done)
                            Console.WriteLine($"Das Element {input[1]} wurde erfolgreich gelöscht\n");
                        else
                            Console.WriteLine($"Das Element {input[1]} konnte nicht gelöscht werden\n");
                        break;
                    case "search":
                        done = element.search(errorhand.ErrorHandling(input[1]));
                        Console.Clear();
                        if (done)
                            Console.WriteLine($"Das Element {input[1]} wurde erfolgreich gefunden\n");
                        else
                            Console.WriteLine($"Das Element {input[1]} konnte nicht gefunden werden\n");
                        break;
                    case "insert":
                        done = element.insert(errorhand.ErrorHandling(input[1]));
                        Console.Clear();
                        if (done)
                            Console.WriteLine($"Das Element {input[1]} wurde erfolgreich eingefügt\n");
                        else
                            Console.WriteLine($"Das Element {input[1]} konnte nicht eingefügt werden\n");
                        break;
                    case "print":
                        Console.Clear();
                        element.print();
                        break;
                    case "exit":
                        abort = true;
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Bitte geben Sie eine gültige Methode ein\n");
                        Console.Clear();
                        break;
                }
            }

        }
    }
}
