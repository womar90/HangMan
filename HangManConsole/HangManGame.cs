using System;
using System.Collections.Generic;

namespace HangManConsole
{
    class HangManGame
    {
        static void Main()
        {
            Console.Title = ("HangMan Game");
            string secretword = "hangman";
            List<string> letterGuessed = new List<string>();
            int live = 5;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Welcome to HangMan Game");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Guess for a {0} Letter Word ", secretword.Length);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("You Have {0} Lives", live);
            Isletter(secretword, letterGuessed);
            while (live > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                string input = Console.ReadLine();
                if (letterGuessed.Contains(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You Entered Letter [{0}] already", input);
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Try a Different Word");
                    GetAlphabet(input);
                    continue;
                }
                letterGuessed.Add(input);
                if (IsWord(secretword, letterGuessed))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(secretword);
                    Console.WriteLine("Congratulations");
                    break;
                }
                else if (secretword.Contains(input))
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Nice Entry");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    string letters = Isletter(secretword, letterGuessed);
                    Console.Write(letters);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Letter Not in This Word");
                    live -= 1;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("You Have {0} Lives", live);
                }
                Console.WriteLine();
                if (live == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Game Over \nMy Secret Word is [ {0} ]", secretword);
                    break;
                }
            }
            Console.ReadKey();
        }
        static bool IsWord(string secretword, List<string> letterGuessed)
        {
            bool word = false;
            for (int i = 0; i < secretword.Length; i++)
            {
                string c = Convert.ToString(secretword[i]);
                if (letterGuessed.Contains(c))
                {
                    word = true;
                }
                else
                {
                    return word = false;
                }
            }
            return word;
        }
        static string Isletter(string secretword, List<string> letterGuessed)
        {
            string correctletters = "";
            for (int i = 0; i < secretword.Length; i++)
            {
                string c = Convert.ToString(secretword[i]);
                if (letterGuessed.Contains(c))
                {
                    correctletters += c;
                }
                else
                {
                    correctletters += "_ ";
                }
            }
            return correctletters;
        }
        static void GetAlphabet(string letters)
        {
            List<string> alphabet = new List<string>();
            for (int i = 1; i <= 26; i++)
            {
                char alpha = Convert.ToChar(i + 96);
                alphabet.Add(Convert.ToString(alpha));
            }
            int num = 49;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Letters Left are :");
            for (int i = 0; i < num; i++)
            {
                if (letters.Contains(letters))
                {
                    alphabet.Remove(letters);
                    num -= 1;
                }
                Console.Write("[" + alphabet[i] + "] ");
            }
            Console.WriteLine();
        }
    }
}
