using System;

namespace _4
{
    class Program
    {
        static void mbshiprow(string [,]  mb,int row,int a,int b)
        {
            if (a>b)
            {
                a = b;
            }
            for (int i = a; i <= b; i++)
            {
                mb[row, i] = "X";
            }
            
            
        }
        static void mbshipcols(string[,] mb, int cols, int a, int b)
        {
            if (a > b)
            {
                a = b;
            }
            for (int i = a; i <= b; i++)
            {
                mb[i,cols] = "X";
            }


        }
        static void Main(string[] args)
        {
            string [,] mb = new string[10, 10];
            for (int i = 0; i < mb.GetLength(0); i++)
            {
                for (int j = 0; j < mb.GetLength(1); j++)
                {
                    mb[i, j] = "O";
                }            
            }
            mbshiprow(mb, 0, 1, 5);
            mbshiprow(mb, 3, 1, 5);
            mbshipcols(mb, 2, 5, 9);
            mbshipcols(mb, 7, 4, 8);
            Console.WriteLine();
        
            for (int i = 0; i < mb.GetLength(0); i++)
            {
                for (int j = 0; j < mb.GetLength(1); j++)
                {
                    Console.Write(mb[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}

