using System;
using System.Diagnostics;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Приложение для завершения работы процесса");
            WriteAllProcess();
     
                
        }
        static void Menu()
        {
            Console.WriteLine("Введите номер пункта меню ");
            Console.WriteLine("1. Для завершения процесса по id.");
            Console.WriteLine("2. Для завершения по имени процесса.");
            Console.WriteLine("3. Для повторного вывода процессов");
            Console.WriteLine("4. Для выхода из приложения");
            try
            {
                int numberMenu = Convert.ToInt32(Console.ReadLine());
                switch (numberMenu)
                {
                    case 1:
                        KillByIdProcess();
                        break;
                    case 2:
                        KillByNameProcess();
                        break;
                    case 3:
                        WriteAllProcess();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Такого пункта в меню нет!");
                        Menu();
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Введено некоректное значение!!!");
                Menu();
                return;
            }
        }
        static void WriteAllProcess()
        {
            Process[] processes = Process.GetProcesses();
            foreach (var process in processes)
            {
                Console.WriteLine($"ID:{process.Id} Name:{process.ProcessName}");
            }
            Menu();
        }
        static void KillByIdProcess()
        {
            Console.WriteLine("Введите id процесса для его завершения");
            string id = Console.ReadLine();
            if (string.IsNullOrEmpty(id))
                return;
            try
            {
                using(Process closen =Process.GetProcessById(int.Parse(id)))
                {
                    if(closen.Id==int.Parse(id))
                    {
                        closen.Kill();
                        closen.WaitForExit();
                        Console.WriteLine("Процесс завершён");
                        Menu();
                    }
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Неверное значение");
                WriteAllProcess();
                return;
            }
        }
        static void KillByNameProcess()
        {
            Console.WriteLine("Введите имя процесса для его завершения");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
                return;
            try
            {
                Process[] closen = Process.GetProcessesByName(name);
                foreach (var item in closen)
                {
                    if (item.ProcessName == name)
                    {
                        item.Kill();
                        item.WaitForExit();
                        Console.WriteLine("Процесс завершён");
                        Menu();
                    }
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Неверное значение");
                Menu();
                return;
            }
        }
    }
}
