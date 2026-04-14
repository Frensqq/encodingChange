using encodingChange;
using System;
using System.IO;
using System.Text;  

namespace encodingChange
{
    public class EncodingConvert: AdditionalClass
    {

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
    }
}