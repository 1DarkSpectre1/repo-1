using System;
using System.IO;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "startup.txt";
            string str = Convert.ToString(DateTime.Now);
            File.AppendAllText(filename, str);
            File.AppendAllText(filename, Environment.NewLine);
        }
    }
}
