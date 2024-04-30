using ForDBA.Data.Models;
using ForDBA.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForDBA.Services
{
    class CsvExporter
    {
        public static void ExportToCsv(List<MainDataGrid> items, string filePath)
        {
            // Открываем файл для записи
            using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                // Записываем заголовки столбцов
                sw.WriteLine("Name,Address,HomePhoneNumber,WorkPhoneNumber,MobilePhoneNumber,StreetName");

                // Записываем данные по каждому товару
                foreach (var item in items)
                {
                    // Форматируем строку для записи в CSV
                    string line = $"{EscapeCsvField(item.FIO)},{item.HomeNumber},{item.HomePhoneNumber},{item.WorkPhoneNumber},{item.MobilePhoneNumber},{item.StreetName}";

                    // Записываем строку в файл
                    sw.WriteLine(line);
                }
            }
        }

        // Функция для экранирования специальных символов в поле CSV
        private static string EscapeCsvField(string field)
        {
            // Если поле содержит запятую или двойные кавычки, заключаем его в двойные кавычки
            if (field.Contains(",") || field.Contains("\""))
            {
                field = field.Replace("\"", "\"\"");
                field = $"\"{field}\"";
            }
            return field;
        }
    }
}
