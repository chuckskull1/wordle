using System;

namespace Wordle
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "Y";
            while (input == "Y")
            {
                Console.Clear();
                wordle wordle = new wordle();
                wordle.start();
                Console.WriteLine("Do you wanna play again?(Y/N)");
                input = Console.ReadLine().ToUpperInvariant();
            }
        }
    }
}
