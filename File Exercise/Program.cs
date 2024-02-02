using System.IO;
using System;
using System.Collections.Generic;

namespace FileExercise
{
    class Program
    {
        public static void FileExercise_one()
        {
            String path = @"c:\temp\textFile.txt";

            Console.Write("Enter text to add to the .txt file: ");
            var text = Console.ReadLine();

            try
            {
                if (!File.Exists(path))
                {
                    File.WriteAllText(path, text);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            var textString = File.ReadAllText(path);

            var newString = textString.Split(" ");

            var totalWords = 0;

            foreach (var item in newString)
            {
                Console.WriteLine(item);
                totalWords++;
            }

            Console.WriteLine(totalWords);
        }
        public static void Main(string[] arg)
        {
            String path = @"c:\temp\textFile2.txt";
            String pathName = Path.GetFileName(path);

            Console.WriteLine("Write anything for the saver: ");
            var input = Console.ReadLine();

            var file = new FileInfo(path);

            if (!file.Exists)
            {
                using (StreamWriter sw = file.CreateText()) 
                {
                    sw.WriteLine(input);
                }
            }

            var s = "";
            using (StreamReader sr = file.OpenText())
            {
                while (!sr.EndOfStream)
                {
                    s += sr.ReadLine();
                }
            }

            String[] newString = s.Split(" ");

            int longestWordCount = newString[0].Length;
            String longestWord = "";

            foreach (var item in newString)
            {
                if (longestWordCount <= item.Length)
                    longestWordCount = item.Length;

                if (item.Length == longestWordCount)
                    longestWord = item;

            }
                Console.WriteLine($"The longest word: \"{longestWord}\", in the text file: \"{pathName}\", is {longestWordCount} characters long.");
        }
    }
}