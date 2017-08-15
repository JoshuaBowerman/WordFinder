using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace WordFinder
{
    internal class Program
    {
        public static bool canSpell(string word, string letters)
        {
            List<char> needed = new List<char>(word);
            List<char> have = new List<char>(letters);
            foreach (var letter in needed)
            {
                if (have.Contains(letter))
                {
                    have.Remove(letter);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        
        public static void Main(string[] args)
        {
            Console.WriteLine("How many letters is the word you are loking for?");
            int numLetters = int.Parse(Console.ReadLine());
            Console.WriteLine("What letters do you have?");
            string letters = Console.ReadLine();
            Console.WriteLine("Words Spellable:");
            string[] dictionary = File.ReadAllLines("./words.txt");
    
            foreach (var word in dictionary)
            {
                if (numLetters == word.Length)
                {
                    if (canSpell(word.ToLower(), letters.ToLower()))
                    {
                        Console.WriteLine(word);
                    }

                }
                
                
            }
            Console.WriteLine("Done Finding Words.");
            Main(args);
        }
    }
}