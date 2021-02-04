using System;
using System.IO;
namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите произвольный набор данных.");
            string str = Console.ReadLine();
            string filename = "text.txt";
            File.WriteAllText(filename, str);
        }
    }
}
