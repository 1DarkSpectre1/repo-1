using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

class Program
{
    static void Main(string[] args)
    {
        BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
    }
}
public class BechmarkClass
{


    public static string[] arrayString = new string[10000];
    public static HashSet<string> hashSet = new HashSet<string>();
    private static Random random = new Random(Environment.TickCount);
    public static string globalstr;

    public static void Setarray()
    {
        Random rnd = new Random();
        int value;
        string str;
        for (int i = 0; i < arrayString.Length-1; i++)
        {
            value = rnd.Next(0, 20);
            str = RandomString(value);
            arrayString[i] = str;
            hashSet.Add(str);

        }
        globalstr = arrayString[5012];
    }

    public static string RandomString(int length)
    {
        string chars = "0123456789abcdefghijklmnopqrstuvwxyz";
        StringBuilder builder = new StringBuilder(length);

        for (int i = 0; i < length; ++i)
            builder.Append(chars[random.Next(chars.Length)]);

        return builder.ToString();
    }

    public static bool checkHashSetstr()
    {
        for (int i = 0; i < arrayString.Length-1; i++)
        {
            if (arrayString[i]==globalstr)
            {
                return true;
            }
        }
        return false;
    }
    public static bool checkArrayStringstr()
    {
        return hashSet.Contains(globalstr);
    }
    [Benchmark]
    public void TestHashSet()
    {
        checkHashSetstr();
    }

    [Benchmark]
    public void TestArrayString()
    {
        checkArrayStringstr();
    }



}
