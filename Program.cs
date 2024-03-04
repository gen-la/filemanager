using System;
using System.Collections.Generic;
using System.IO;
namespace filemanager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // array with words
            string[] arrayOFwords = { "Dog", "PC", "Cat", "Door", "boot", "Money", "Apple", "day", "diet" };

            // call function to filter the arrayOFwords and store the result in a list
            List<string> filteredWords = Filter(arrayOFwords);

            // print the filtered words to the console
            Console.WriteLine("Words starting with 'D':");
            foreach (string word in filteredWords)
            {
                Console.WriteLine(word);
            }

            // call function to create folder and text file
            string filePath = FolderAndFile(filteredWords);

            Console.WriteLine("Words starting with 'D' are saved in the file: " + filePath);
        }

        static List<string> Filter(string[] words)
        {
            List<string> filteredWords = new List<string>();

            // add all words starting with 'D' to the list
            foreach (string word in words)
            {
                if (word.StartsWith("D", StringComparison.OrdinalIgnoreCase)) // ignore upper and lower case
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
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "D");
            Directory.CreateDirectory(directoryPath);

            // create a text file named "D.txt"
            string filePath = Path.Combine(directoryPath, "D.txt");
            // write the filtered words to it
            File.WriteAllLines(filePath, words);

            return filePath;
        }
    }
}
