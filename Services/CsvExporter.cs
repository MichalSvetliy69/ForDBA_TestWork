using ForDBA.Data.Models;
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
        public static void ExportToCsv(List<Abonent> items, string filePath)
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
                    string line = $"{EscapeCsvField(item.FIO)},{item.Address.HomeNumber},{item.PhoneNumber.HomePhoneNumber},{item.PhoneNumber.WorkPhoneNumber},{item.PhoneNumber.MobilePhoneNumber},{item.Street.StreetName}";

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
