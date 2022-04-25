using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
    class ErrorHandler
    {
        public int ErrorHandling(string s)
        {
            try
            {
                int number = Convert.ToInt32(s);
                return number;
            }
            catch (Exception)
            {
                Console.WriteLine("\nIhre Eingabe ist ungültig!\nGeben sie erneut eine gültige Zahl ein");
                ErrorHandling(Console.ReadLine());
            }
            return -1;
        }
    }
}
