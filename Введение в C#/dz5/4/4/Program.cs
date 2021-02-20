using System;
using System.IO;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Введите путь к дериктории дерево которой нужно вывести.");
            string workDir = Console.ReadLine();
            string tab = "\t";
            if (Directory.Exists(@workDir))
            {
                GetTree(@workDir, tab);
            }
            else { Console.WriteLine($"Указана несуществующя директория {workDir}"); }
            
        }
        public static void GetTree(string workdir, string tab)
        {
            var dir = new DirectoryInfo(workdir); // папка с файлами 

            foreach (FileInfo file in dir.GetFiles())
            {
                Console.WriteLine($"{tab} file: {Path.GetFileNameWithoutExtension(file.FullName)}");
            }
            

            
            string[] subdirectoryEntries = Directory.GetDirectories(workdir);
            foreach (string subdirectory in subdirectoryEntries)
            {
                string dirName = new DirectoryInfo(subdirectory).Name;

                Console.WriteLine($"{tab} {dirName}");
                GetTree(subdirectory, tab += tab);
            }
        }
      
    }
}