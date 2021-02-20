using System;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number");
            if(Convert.ToInt32(Console.ReadLine())%2==0)
                Console.WriteLine("The number is even");
            else
                Console.WriteLine("The number is odd");

        }
    }
}
