using System;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] a = new string[5, 2];
            for (int i = 0; i < 5; i++)
            {
                a[i, 0] = "name_" + Convert.ToString(i);
                a[i, 1] = "8937999999" + Convert.ToString(i);
            }
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(a[i, 0] + "  " + a[i, 1]);
            }
        }
    }
}
