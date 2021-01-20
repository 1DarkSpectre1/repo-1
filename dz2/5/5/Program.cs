using System;

namespace _5
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

            if ((DateTime.Now.Month==1|| DateTime.Now.Month==12|| DateTime.Now.Month==2)&& (0<(minT + maxT) / 2))
            {
                Console.WriteLine("Дождливая зима");
            }
           
        }
    }
}
