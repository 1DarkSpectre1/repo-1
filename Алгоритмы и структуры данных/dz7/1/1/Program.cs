using System;

namespace Geekbrains
{
    class Program
    {
        /// <тест>
        /// Подаем на вход 7, затем 7 ожидаем матрицу 7 на 7 с количеством шагов
        /// Подаем на вход 10, затем 7 ожидаем матрицу 10 на 7 с количеством шагов
        /// Подаем на вход -1, затем 7 ожидаем сообщение "Введите положительные числа" и повторный ввод чисел
        /// Подаем на вход строковое значение ожидаем сообщение "Введено некоректное значение" и повторный ввод чисел
        /// </тест>

        static int N;
        static int M;

        static void Print2(int n, int m, int[,] a)
        {
            int i, j;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    Console.Write(a[i, j]);
                    Console.Write(" ");
                }
                Console.Write("\r\n");
            }
        }
        static void Menu()
        {
            try
            {
            Console.WriteLine("Введите количество клеток по горизонтали");
            M=Convert.ToInt32( Console.ReadLine());
                
            Console.WriteLine("Введите количество клеток по вертикали");
            N = Convert.ToInt32(Console.ReadLine());
                if (M<0 || N<0)
                {
                    Console.WriteLine("Введите положительные числа");
                    Menu();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Введено некоректное значение");
                Menu();
            }
        }
        static void Main(string[] args)
        {
            Menu();
            int[,] A = new int[N, M];
            int i, j;
            for (j = 0; j < M; j++)
                A[0, j] = 1; // Первая строка заполнена единицами
            for (i = 1; i < N; i++)
            {
                A[i, 0] = 1;
                for (j = 1; j < M; j++)
                    A[i, j] = A[i, j - 1] + A[i - 1, j];
            }

            Print2(N, M, A);
        }
    }
}