using System;
using System.Collections.Generic;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            //При запуске создаём лист и запускаем две функции для проверки уже обработанных файлов
            //ReadFileAndWriteList()
            //CheckDataFile()
            //Далее получаем список всех файлов в директории
            //проходим по всему списку и для каждого файла выполняем
            //CheckFile() если файл не обработан WorkToFile() а затем добавление в лист с записью текущей даты
            //по окончанию работы выполняем WriteFile()
        }
        static List<FileWt> WorkToFile(List<FileWt> list)
        {
            //-- работа с файлом
            return list;
        }
        static void WriteFile(List<FileWt> list)
        {
            //дисериализация и сохранения листа в файл
        }
    }
}
