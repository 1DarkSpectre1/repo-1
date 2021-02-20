using System;
using System.Collections.Generic;
using System.Text;

namespace _1
{
    class FileWt
    {
        public string Title { get; set; }

        public DateTime DataAddFile { get; set; }

        //Title --содержит имя файла (путь)
        //Дата добавления файла


        public List<FileWt> ReadFileAndWriteList(List<FileWt> list)
        {
            // Читает данные из файла и проводит сериализацию в класс FileWt и запись в List

            return list;
        }
        public List<FileWt> CheckDataFile(List<FileWt> list)
        {
            //-- проходит по всему листу и сравнивает дату проверяя дату записи с текущей если разница больше 10 дней запись о файле удаляеется
            return list;
        }
        public bool CheckFile(List<FileWt> list,string filename)
        {
            // проверяет обработан ли данный файл
            return false;
        }

    }
}
