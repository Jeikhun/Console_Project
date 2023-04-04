using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UberDelivery.Services.Services.Implementations
{
    internal class Helper
    {
        public static void Print(object text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
        public static void PrintLine(object text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void PrintSlow(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            foreach (char item in text)
            {
                Console.Write(item);
                Thread.Sleep(100);

            }
            Console.WriteLine();
            Thread.Sleep(300);
            Console.ResetColor();
        }
    }
}
