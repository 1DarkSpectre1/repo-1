using System;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Введите количество столбцов масива");
            int cols =Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество строк масива");
            int row = Convert.ToInt32(Console.ReadLine());
            int[,] array = new int[row, cols];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = j+i;
                    Console.Write(array[i, j]+" ");
                }
                Console.WriteLine();
            }
            int minlength;
                if (array.GetLength(0) < array.GetLength(1))
                    minlength = array.GetLength(0);
                else
                    minlength = array.GetLength(1);
            for (int i = 0; i < minlength; i++)
            {
                Console.WriteLine(array[i, i]);
            }
        }
    }
}
