using System;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите набор чисел.");
            string str= Console.ReadLine();
            Console.WriteLine("Сумма чисел = "+Convert.ToString(GetSumStr(str)));
        }
        static int GetSumStr(string str)
        {
            string number = " ";
            int sum = 0;
            for (int i = 0 ; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]))
                {
                    number += str[i];
                }
                if (!char.IsDigit(str[i])||i==str.Length-1)
                {
                    sum += Convert.ToInt32(number);
                    number = "";
                }
            }
            

            return sum;
        }
    }
}
