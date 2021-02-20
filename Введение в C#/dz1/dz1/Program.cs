using System;

namespace dz1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name!");
            var name = Console.ReadLine();
            Console.WriteLine($"Привет, {name}, сегодня: {DateTime.Now} ") ;
        }
    }
}
