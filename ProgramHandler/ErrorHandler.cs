using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatPraktikum
{
    class ErrorHandler
    {
        public int ErrorHandling(string s)
        {
            int number=-1;
            try
            {
                number = Convert.ToInt32(s);
                return number;
            }
            catch (Exception)
            {
                Console.WriteLine("\nIhre Eingabe ist ungültig!\nGeben sie erneut eine gültige Zahl ein");
                number=ErrorHandling(Console.ReadLine());
            }
            return number;
        }
    }
}
