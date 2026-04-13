using System;
using System.IO;
using System.Text;  

namespace EncodingConverter
{
    public class EncodingConvert
    {
        public enum EncodingType
        {
            Utf8,
            Windows1251,
            Ascii,
            Koi8r,
            Unicode
        }

        public static string ConvertString(string input, EncodingType from, EncodingType to)
        {
            if (input == null )
                throw new ArgumentException(nameof(input), "Строка не может быть null");

            if (from == to)
                return input;

            try
            {
                byte[] bytes = GetEncoding(from).GetBytes(input);
                return GetEncoding(to).GetString(bytes);
            }
            catch
            {
                throw new InvalidOperationException($"Ошибка конвертации строки {input}");
            }
        }

        protected static Encoding GetEncoding(EncodingType type)
        {
            switch (type)
            {
                case EncodingType.Utf8:
                    return Encoding.UTF8;
                case EncodingType.Windows1251:
                    return Encoding.GetEncoding("windows-1251");
                case EncodingType.Ascii:
                    return Encoding.ASCII;
                case EncodingType.Koi8r:
                    return Encoding.GetEncoding("koi8-r");
                case EncodingType.Unicode:
                    return Encoding.Unicode;
                default:
                    return Encoding.UTF8;
            }
        }
    }
}