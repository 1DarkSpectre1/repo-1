using System;

namespace _1
{
   
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = "Петров";
            string lastName = "Пётр";
            string patronymic = "Петрович";
            string firstName2 = "Иванов";
            string lastName2 = "Иван";
            string patronymic2 = "Иванович";
            string firstName3 = "Максимов";
            string lastName3 = "Максим";
            string patronymic3 = "Максимович";
            Console.WriteLine(GetFullName(firstName, lastName, patronymic));
            Console.WriteLine(GetFullName(firstName2, lastName2, patronymic2));
            Console.WriteLine(GetFullName(firstName3, lastName3, patronymic3));

        }
        static string GetFullName(string firstName, string lastName, string patronymic)
        {
            return lastName + " "+ firstName + " " + patronymic;
            
        }
    }
}
