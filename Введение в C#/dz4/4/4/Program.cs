using System;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число");
            int number = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Число фибоначи = " + Convert.ToString(Fibonachi(number)));       
        }
        static int Fibonachi(int number)
        {
            if (number==0)
            {
                return number;
            }
            if (number==1)
            {
                return number;
            }
            if (number == -1)
            {
                return -1*number;
            }
            if (number>0)
            {
                return Fibonachi(number - 1) + Fibonachi(number - 2);
            }
            else
            {
                return Convert.ToInt32(Math.Pow(-1.0, Convert.ToDouble(-1 * number + 1))) * (Fibonachi(-1 * number - 1) + Fibonachi(-1 * number - 2));
            }
        }
    }
}
