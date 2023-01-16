using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace WordRiddles
{
    internal class Program
    {
        private static readonly Random Random = new Random();
        static void Main(string[] args)
        {
            var words = GetWords();
            var wordCount = 30;
            while (wordCount > 0)
            {
                var hasFoundMatch = FindWordRiddle(words);
                if (hasFoundMatch) wordCount--;
            }
        }

        private static bool FindWordRiddle(string[] words)
        {
            var randomWordIndex = Random.Next(words.Length);
            var selectedWord = words[randomWordIndex];
            Console.Write(selectedWord + " - ");
            foreach (var word in words)
            {
                if (!IsWordOverlap(selectedWord, word)) continue;
                Console.WriteLine(word);
                return true;
            }

            Console.WriteLine("<Fant ikke match>");
            return false;
        }

        private static bool IsWordOverlap(string word1, string word2)
        {
            return IsWordOverlap(3, word1, word2)
                   || IsWordOverlap(4, word1, word2)
                   || IsWordOverlap(5, word1, word2);

        }

        private static bool IsWordOverlap(int commonLength, string word1, string word2)
        {
            var lastPartOfFirstWord = word1.Substring(word1.Length - commonLength, commonLength);
            var firstPartOfSecondWord = word2.Substring(0, commonLength);
            return lastPartOfFirstWord == firstPartOfSecondWord;
        }

        static string[] GetWords()
        {
            string path = @"C:\Users\simen\OneDrive\Dokumenter\Get_Academy\Modul 3\WordRiddles\WordRiddles\ordliste.txt";
            var lastWord = string.Empty;
            var wordList = new List<string>();
            foreach (var line in File.ReadLines(path, Encoding.UTF8))
            {
                var parts = line.Split("\t");
                var word = parts[1];
                if (word != lastWord 
                    && word.Length is > 5 and < 10
                    && !word.Contains('-')) wordList.Add(word);
                lastWord = word;
            }
            return wordList.ToArray();
        }
    } 
}