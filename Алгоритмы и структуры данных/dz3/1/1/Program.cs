using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using static _1.BechmarkClass;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {

            Random rnd = new Random();
            for (int i = 0; i < BechmarkClass.arrayStruct.Length - 1; i++)
            {
                int value = rnd.Next();
                int value1 = rnd.Next();
             
                BechmarkClass.arrayClass[i] = new PointClass { X = value, Y = value1 };
                BechmarkClass.arrayStruct[i] = new PointStruct { X = value, Y = value1 };
            }
           
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }

    }
    //Результаты работы
    //|                         Method |       Mean |   Error |  StdDev |
    //|------------------------------- |-----------:|--------:|--------:|
    //|         TestPointClassDistance |         NA |      NA |      NA |
    //|        TestPointStructDistance | 1,141.7 ns | 1.44 ns | 1.35 ns |
    //|  TestPointStructDistanceDouble | 1,224.6 ns | 0.93 ns | 0.87 ns |
    //| TestPointStructDistanceNotSQRT |   951.4 ns | 9.75 ns | 8.14 ns |
    //
    public class BechmarkClass
    {


        public static PointStruct[] arrayStruct = new PointStruct[500];
        public static PointClass[] arrayClass = new PointClass[500];

        //public static void setarrayClass(int i,PointClass pointOne)
        //{
        //    BechmarkClass.arrayClass[i] = pointOne;
        //}

        public struct PointStruct
        {
            public int X;
            public int Y;
        }

        public class PointClass
        {
            public int X;
            public int Y;

        }

        public static float PointClassDistance(PointClass pointOne, PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        public static float PointStructDistance(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        public static double PointStructDistanceDouble(PointStruct pointOne, PointStruct pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }
        public static float PointStructDistanceNotSQRT(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }

        [Benchmark]
        public  void TestPointClassDistance()
        {
            for (int i = 1; i < BechmarkClass.arrayClass.Length - 1; i++)
            {
                PointClassDistance(BechmarkClass.arrayClass[i], BechmarkClass.arrayClass[i - 1]);
            }

        }

        [Benchmark]
        public void TestPointStructDistance()
        {
            for (int i = 1; i < BechmarkClass.arrayStruct.Length - 1; i++)
            {
                PointStructDistance(BechmarkClass.arrayStruct[i], BechmarkClass.arrayStruct[i - 1]);
            }
        }
        [Benchmark]
        public void TestPointStructDistanceDouble()
        {
            for (int i = 1; i < BechmarkClass.arrayStruct.Length - 1; i++)
            {
                PointStructDistanceDouble(BechmarkClass.arrayStruct[i], BechmarkClass.arrayStruct[i - 1]);
            }
        }

        [Benchmark]
        public void TestPointStructDistanceNotSQRT()
        {
            for (int i = 1; i < BechmarkClass.arrayStruct.Length - 1; i++)
            {
                PointStructDistanceNotSQRT(BechmarkClass.arrayStruct[i], BechmarkClass.arrayStruct[i - 1]);
            }

        }


    }
}
