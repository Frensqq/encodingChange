 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encodingChange
{
    public class EncodingConvert
    {

        public enum EncodingType
        {
            Utf8,
            Windows1251,
            Ascii,
            Koi8r,
            Utf16
        }

        //Универсальный метод для создания публичных
        private static string Convert(string input, EncodingType from, EncodingType to)
        {
            if (input == null) throw new ArgumentNullException("input is null");
            if (input == "") return "";
            if (from == to) return input;

            try
            {
                string fromStr = GetEncodingString(from);
                string toStr = GetEncodingString(to);


                byte[] byteStr = Encoding.GetEncoding(fromStr).GetBytes(input);
                return Encoding.GetEncoding(toStr).GetString(byteStr);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Ошибка конвертации из {from} в {to}", ex);
            }
        }

        //получение строки с названием кодировки
        private static string GetEncodingString(EncodingType encoding)
        {
            switch (encoding)
            {
                case EncodingType.Utf8:
                    return "utf-8";
                case EncodingType.Windows1251:
                    return "windows-1251";
                case EncodingType.Ascii:
                    return "ascii";
                case EncodingType.Koi8r:
                    return "koi8-r";
                case EncodingType.Utf16:
                    return "utf-16";
                default:
                    throw new ArgumentException($"Неподдерживаемая кодировка: {encoding}");
            }
        }

        //Универсальный метод для создания публичных со значениями по умолчанию
        public static string ConvertDefault(
            string input,
            EncodingType from = EncodingType.Utf16,
            EncodingType to = EncodingType.Windows1251)
        {
            return Convert(input, from, to);
        }
    }
}