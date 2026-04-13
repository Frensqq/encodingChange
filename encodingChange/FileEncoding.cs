using System;
using System.IO;
using System.Text;
using static EncodingConverter.EncodingConvert;
using EncodingConverter;

namespace encodingChange
{
    public class FileEncoding: EncodingConvert
    {
        public static string ReadFileToString(string filePath, EncodingType encoding)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException("Путь к файлу не может быть null или пустым");

            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Файл не найден: {filePath}");

            try
            {
                byte[] bytes = File.ReadAllBytes(filePath);

                if (bytes.Length == 0)
                    return "";

                return GetEncoding(encoding).GetString(bytes);
            }
            catch
            {
                throw new InvalidOperationException($"Ошибка чтения файла {filePath}");
            }
        }
        
        public static void WriteStringToFile(string data, string filePath, EncodingType encoding)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException("Путь к файлу не может быть null или пустым");

            if (data == null)
                throw new ArgumentException("Данные для записи не могут быть null");


            // наверное лишнее 
            // WriteAllBytes должен сам создавать файл
            //if (!File.Exists(filePath))
            //{
            //    using (File.Create(filePath)) { }
            //}


            try
            {
                byte[] bytes = GetEncoding(encoding).GetBytes(data);
                File.WriteAllBytes(filePath, bytes);
            }
            catch
            {
                throw new InvalidOperationException($"Ошибка записи файла {filePath}");
            }
        }
    }
}
