using System;

namespace Dz8
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[10];
            Random rnd = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                int value = rnd.Next();
                array[i] = value;
            }
            Bucketsort(array);
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
        static void Bucketsort(int[] array)
        {
            int maxnum = array[0];
            int minnum = array[0];
            int h;
            int[][] tempArr = new int[4][];
            tempArr[0] = new int[array.Length];
            tempArr[1] = new int[array.Length];
            tempArr[2] = new int[array.Length];
            tempArr[3] = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                if (maxnum<array[i])
                {
                    maxnum = array[i];
                }
                if (minnum > array[i])
                {
                    minnum = array[i];
                }
            }
            h = (maxnum - minnum) / 4;
            int i1 = 0;
            int i2 = 0;
            int i3 = 0;
            int i4 = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (h+ minnum >  array[i])
                {
                    tempArr[0][i1] = array[i];
                    i1++;
                }else
                if (h + h + minnum > array[i])
                {
                    tempArr[1][i2] = array[i];
                    i2++;
                }
                else
               if (h + h + h + minnum > array[i])
                {
                    tempArr[2][i3] = array[i];
                    i3++;
                }
                else
                {
                    tempArr[3][i4] = array[i];
                    i4++;
                }
            }
            int[][] tempArrSort = new int[4][];
            tempArrSort[0] = new int[i1];
            tempArrSort[1] = new int[i2];
            tempArrSort[2] = new int[i3];
            tempArrSort[3] = new int[i4];
            for (int i = 0; i < tempArrSort[0].Length; i++)
            {
                tempArrSort[0][i] = tempArr[0][i];
            }
            for (int i = 0; i < tempArrSort[1].Length; i++)
            {
                tempArrSort[1][i] = tempArr[1][i];
            }
            for (int i = 0; i < tempArrSort[2].Length; i++)
            {
                tempArrSort[2][i] = tempArr[2][i];
            }
            for (int i = 0; i < tempArrSort[3].Length; i++)
            {
                tempArrSort[3][i] = tempArr[3][i];
            }

            Array.Sort(tempArrSort[0]);
            Array.Sort(tempArrSort[1]);
            Array.Sort(tempArrSort[2]);
            Array.Sort(tempArrSort[3]);
            int[] BigArraySort = new int[tempArrSort[0].Length + tempArrSort[1].Length];
            int[] BigArraySort2 = new int[tempArrSort[2].Length + tempArrSort[3].Length];
            Merge(tempArrSort[0], tempArrSort[1], BigArraySort);
            Merge(tempArrSort[2], tempArrSort[3], BigArraySort2);
            Merge(BigArraySort, BigArraySort2, array);
        }
        static void Merge(int[] array1, int [] array2, int[] arraySort )
        {
            var indarray1 = 0;
            var indarray2 = 0;
            var index = 0;
            while ((indarray1 < array1.Length) && (indarray2 < array2.Length))
            {
                if (array1[indarray1] < array2[indarray2])
                {
                    arraySort[index] = array1[indarray1];
                    indarray1++;
                }
                else
                {
                    arraySort[index] = array2[indarray2];
                    indarray2++;
                }

                index++;
            }
            if (indarray1 == array1.Length)
            {
                while  (indarray2 < array2.Length)
                {
                    arraySort[index] = array2[indarray2];
                    indarray2++;
                    index++;
                }
            }
            else
            {
                while (indarray1 < array1.Length)
                {
                    arraySort[index] = array1[indarray1];
                    indarray1++;
                    index++;
                }
            }
            
        }

    }
}
