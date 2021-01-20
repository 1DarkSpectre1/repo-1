using System;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the minimum daily average temperature");
            var minT = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the maximum daily average temperature");
            var maxT = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Average daily temperature today: {(minT + maxT) / 2} ");

            
        }
    }
}
