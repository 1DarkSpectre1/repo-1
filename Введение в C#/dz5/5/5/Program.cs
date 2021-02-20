using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var list = new List<ToDo>();
            
            string filename = "task.json";
            string json = File.ReadAllText(filename);
            string[] arrayJson = json.Split('\n');
            if (json!="")
            {
                foreach (var item in arrayJson)
                {
                    if (item!="")
                    {
                         
                        list.Add(JsonSerializer.Deserialize<ToDo>(item));
                    }
                  
                }
            }
            Menu(list);
            File.WriteAllText(filename,"");
            SaveData(list, filename);
        }
        static void Menu(List<ToDo> list)
        {
            Console.WriteLine("Введите номер меню для продолжения");
            Console.WriteLine("1: Переход к задачам");
            Console.WriteLine("2: Переход к созданию задачи");
            Console.WriteLine("3: Выход");
            string numberMenu= Console.ReadLine();
            switch (numberMenu)
            { 
                case  "1":
                    TaskManager(list);
                    break;
                case "2":
                    CreateTask(list);
                    break;
                case "3":
                    break;
                default:
                    Console.WriteLine("Введено некоректное значение.");
                    Menu(list);
                    break;
            }
        }
        static void TaskManager(List<ToDo> list)
        {
            Console.WriteLine("Список задач");
            
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].IsDone)
                    Console.Write("[x]");
                else
                    Console.Write("[ ]");
                Console.WriteLine($"{i+1}:{list[i].Title}");
            }
            Console.WriteLine("Введите порядковый номер задачи которую выполнили или введите 0 для перехода в меню");
            int number=Convert.ToInt32( Console.ReadLine());
            if (number==0)
            {
                Menu(list);
               
            }
            else if(number>list.Count)
            {
                Console.WriteLine("Введено некоректное значение");
                TaskManager(list);
                
            }
            else
            {
                list[number-1].IsDone = true;
                TaskManager(list);
            }

        }
        static void CreateTask(List<ToDo> list)
        {
            Console.WriteLine("Введите задачу.");
            ToDo newTask = new ToDo();
            string str = Console.ReadLine();
            newTask.CreateTask(str);
            list.Add(newTask);
            Menu(list);
        }
        static void SaveData(List<ToDo> list,string filename)
        {
            foreach (var item in list)
            {
                string jsonSerializer = JsonSerializer.Serialize(item);
                File.AppendAllText(filename, jsonSerializer);
                File.AppendAllText(filename, Environment.NewLine);
            }
        }
       
    }
}
