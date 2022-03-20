using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Wordle;

namespace Wordle
{
    public class wordle
    {
        private bool gameStatus;
        private const string wordsResource = "words.txt";
        private string word;
        private int tries;
        private List<string> words;

        public wordle()
        {
            this.gameStatus = true;
            this.tries = 0;
        }

        public void progress()
        {
            while(tries < 6 && gameStatus == true)
            {
                string input = getInput();
                if(words.Contains(input))
                {
                    tries++;
                    print(input);
                }
                else
                {
                    Console.WriteLine("Enter a valid five letter word");
                }
            }
            if(tries < 6)
            {
                Console.WriteLine("You won 🎉");
            }
            else
            {
                Console.WriteLine($"You Loost😞 \nThe word was:{word}");
            }
        }

        public void start()
        {
            initialise();
            Console.WriteLine("Enter a five letter valid word");
            progress();
        }

        public string getInput()
        {
            return Console.ReadLine().ToUpperInvariant();
        }

        public void print(string input)
        {
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
            for (int i = 0; i<5; i++)
            {
                if(input[i] == word[i])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(input[i]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if(word.Contains(input[i]))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(input[i]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(input[i]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.WriteLine();
            if (String.Equals(word, input))
            {
                gameStatus = false;
                return;
            }
        }

        // This function initialisez wordle game by reading all the words from text file and choosing one word out of them
        public void initialise()
        {
            Console.WriteLine("Welcome to wordle");
            Random random = new Random();
            words = new List<string>();
            foreach (string line in System.IO.File.ReadLines(wordsResource))
            {
                words.Add(line.ToUpperInvariant());
            }
            this.word = words[random.Next(words.Count)].ToUpperInvariant();
            Console.WriteLine($"Solution word is: {word} (for testing purpose only)");
        }
    }
}
