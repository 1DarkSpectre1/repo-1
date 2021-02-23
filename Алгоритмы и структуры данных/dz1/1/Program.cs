using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckNumber();
            //На вход подаем 1, ожидаем Число простое
            //На вход подаем 4, ожидаем Число не простое
            //На вход подаем 7, ожидаем Число не простое
            //На вход подаем отрицательное чилсло, ожидаем Число простое(Согласно блок схеме)


        }
        static void CheckNumber()
        {
            int n;
            Console.WriteLine("Введите число");
            try
            {
                 n = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка введено некоректное число");
                return;
            }
            int d = 0;
            int i = 2;
            while (i<n)
            {
                if (n%i==0)
                {
                    d++;
                }
                    i++;
            }
            if (d==0)
            {
                Console.WriteLine("Число простое");
            }
            else
            {
                Console.WriteLine("Число не простое");
            }
        }
    }
}
