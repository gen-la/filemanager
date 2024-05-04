using System;
using System.Collections.Generic;
using System.IO;

namespace filemanager
{
    internal class Program
    {
        static string character = "";
        static bool checkChar = false;
        static void Main(string[] args)
        {
            while (!checkChar) // let user type a letter and do so untill only one letter is typed
            {
                Console.WriteLine("Type a letter:");
                character = Console.ReadLine();
                if (character.Length != 1) // if its not one single letter then ask user to type again
                {
                    Console.Clear();
                    Console.WriteLine("Please type a single letter.");
                }
                else checkChar = true; // if its one letter then break the loop and continue
            }
            // array with words
            string[] arrayOFwords = { "Dog", "PC", "Book", "Cat", "Door", "boot", "Money", "Apple", "day", "diet" };

            // call function to filter the arrayOFwords and store the result in a list
            List<string> filteredWords = Filter(arrayOFwords);

            // print the filtered words to the console
            Console.WriteLine($"\nWords starting with {character.ToUpper()}:");
            foreach (string word in filteredWords)
            {
                Console.WriteLine(word);
            }

            // call function to create folder and text file
            string filePath = FolderAndFile(filteredWords);

            Console.WriteLine($"\nWords starting with {character.ToUpper()} are saved in the file: " + filePath);
        }

        static List<string> Filter(string[] words)
        {
            List<string> filteredWords = new List<string>();

            // add all words starting with 'D' to the list
            foreach (string word in words)
            {
                if (word.StartsWith($"{character}", StringComparison.OrdinalIgnoreCase)) // ignore upper and lower case
                {
                    filteredWords.Add(word);
                }
            }

            // sort the list alphabetically
            filteredWords.Sort();

            return filteredWords;
        }

        static string FolderAndFile(List<string> words)
        {
            // create a folder named "D" if it doesn't exist
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), $"{character.ToUpper()}");
            Directory.CreateDirectory(directoryPath);

            // create a text file named "D.txt"
            string filePath = Path.Combine(directoryPath, $"{character.ToUpper()}.txt");
            // write the filtered words to it
            File.WriteAllLines(filePath, words);

            return filePath;
        }
    }
}
