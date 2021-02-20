using System;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Создание чека.");
            Console.WriteLine("Введите название организации:");
            var nameOrganization = Console.ReadLine();
            var nameProduct1 = "Соль";
            var nameProduct2 = "Сахар";
            var nameProduct3 = "Масло";
            var quantityProduct1 = 1;
            var quantityProduct2 = 3;
            var quantityProduct3 = 4;
            var costProduct1 = 23;
            var costProduct2 = 54;
            var costProduct3 = 65;

            Console.WriteLine($"               {nameOrganization}") ;
            Console.WriteLine("###############################");
            Console.WriteLine("         УНП 2342325");
            Console.WriteLine("        РН 0000002132");
            Console.WriteLine($"{nameProduct1}                        {quantityProduct1* costProduct1}");
            Console.WriteLine($"{nameProduct2}                       {quantityProduct2* costProduct2}");
            Console.WriteLine($"{nameProduct3}                       {quantityProduct3* costProduct3}");
            Console.WriteLine($"Итого к оплате              {costProduct1* quantityProduct1+ costProduct2*quantityProduct2+ costProduct3*quantityProduct3}");
            Console.WriteLine("###############################");
            Console.WriteLine($"       {DateTime.Now}");
            Console.WriteLine("");
            Console.WriteLine("Спасибо за покупку!");
        }
    }
}
