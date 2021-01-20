using System;

namespace _6
{
    class Program
    {
        public enum Week
        {
            // Для читаемости разряды можно разделять знаком подчёркивания.
            // Они никак не влияют на значение.
            Monday = 0b_0000001,
            Tuesday = 0b_0000010,
            Wednesday = 0b_0000100,
            Thursday = 0b_0001000,
            Friday = 0b_0010000,
            Saturday = 0b_0100000,
            Sunday= 0b_1000000,
        }
        static void Main(string[] args)
        {
           
            var office1 = Week.Monday | Week.Saturday | Week.Friday | Week.Sunday | Week.Thursday;
            var office2 = Week.Wednesday | Week.Saturday | Week.Tuesday | Week.Sunday | Week.Thursday;
            Console.WriteLine("Введите день недели");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    if(Week.Monday==(Week.Monday& office1))
                        Console.WriteLine("Офис 1 работает в этот день");
                    if (Week.Monday == (Week.Monday & office2))
                        Console.WriteLine("Офис 2 работает в этот день");
                    break;
                case 2:
                    if (Week.Tuesday == (Week.Tuesday & office1))
                        Console.WriteLine("Офис 1 работает в этот день");
                    if (Week.Tuesday == (Week.Tuesday & office2))
                        Console.WriteLine("Офис 2 работает в этот день");
                    break;
                case 3:
                    if (Week.Wednesday == (Week.Wednesday & office1))
                        Console.WriteLine("Офис 1 работает в этот день");
                    if (Week.Wednesday == (Week.Wednesday & office2))
                        Console.WriteLine("Офис 2 работает в этот день");
                    break;
                case 4:
                    if (Week.Thursday == (Week.Thursday & office1))
                        Console.WriteLine("Офис 1 работает в этот день");
                    if (Week.Thursday == (Week.Thursday & office2))
                        Console.WriteLine("Офис 2 работает в этот день");
                    break;
                case 5:
                    if (Week.Friday == (Week.Friday & office1))
                        Console.WriteLine("Офис 1 работает в этот день");
                    if (Week.Friday == (Week.Friday & office2))
                        Console.WriteLine("Офис 2 работает в этот день");
                    break;
                case 6:
                    if (Week.Saturday == (Week.Saturday & office1))
                        Console.WriteLine("Офис 1 работает в этот день");
                    if (Week.Saturday == (Week.Saturday & office2))
                        Console.WriteLine("Офис 2 работает в этот день");
                        break;
                case 7:
                    if (Week.Sunday == (Week.Sunday & office1))
                        Console.WriteLine("Офис 1 работает в этот день");
                    if (Week.Sunday == (Week.Sunday & office2))
                        Console.WriteLine("Офис 2 работает в этот день");
                        break;


                default:
                    Console.WriteLine("Неизвестный день недели");
                    break;
            }
        }
    }
}
