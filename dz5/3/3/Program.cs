using System;
using System.IO;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите произвольный набор чисел.");
            string str = Console.ReadLine();
            string[] arraystr = str.Split(' ');
            byte[] arraynumber = new byte[arraystr.Length];
            for (int i = 0; i < arraystr.Length; i++)
            {
                arraynumber[i] = Convert.ToByte(arraystr[i]);
            }
            string filename = "bytes.bin";
            File.WriteAllBytes(filename, arraynumber);
        }
    }
}
