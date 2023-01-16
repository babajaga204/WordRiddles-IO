using System.IO;
using System.Text;

namespace WordRiddles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\simen\\OneDrive\\Dokumenter\\Get_Academy\\Modul 3\\WordRiddles\\WordRiddles\\ordliste.txt";

            var lastWord = string.Empty;
            foreach (var line in File.ReadLines(path, Encoding.UTF8))
            {
                var parts = line.Split("\t");
                var word = parts[1];
                if (word != lastWord) { Console.WriteLine(word); }
                lastWord = word;
            }
        }

        private static void PrintText(string[] text)
        {
            foreach (var line in text)
            {
                Console.WriteLine(line);
            }
        }
    } 
}