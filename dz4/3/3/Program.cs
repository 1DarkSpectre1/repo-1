using System;

namespace _3
{
    enum seasons
    {
        Winter,
        Spring,
        Summer,
        Autumn
    }
    class Program
    {
        static void Main(string[] args)
        {
            int mounth = 0; ;
            bool error = false;
                
            while (!error)
            {
                Console.WriteLine("Введите порядковый номер месяца.");
                mounth = Convert.ToInt32(Console.ReadLine());
                if (mounth >= 1 && mounth <= 12)
                {
                    error = true;
                    continue;
                }
                Console.WriteLine("Ошибка: введите число от 1 до 12.");
            }
            Console.WriteLine("Данный месяц относится к сезону: "+GetNameSeasons(GetSeasons(mounth)));
            
            
        }
        static seasons GetSeasons(int mounth)
        {
            switch(mounth)
            {
                case 12:
                case 1:
                case 2:
                    return seasons.Winter;
                case 3:
                case 4:
                case 5:
                    return seasons.Spring;
                case 6:
                case 7:
                case 8:
                    return seasons.Summer;
                default:
                    return seasons.Autumn;                 
            }    
        }
        static string GetNameSeasons(seasons season)
        {
            switch (season)
            {
                case seasons.Winter:
                    return "зима";
                case seasons.Spring:
                    return "весна";
                case seasons.Summer:
                    return "лето";
                default:
                    return "осень";
            }
        }
    }
}
