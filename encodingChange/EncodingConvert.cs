 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encodingChange
{
    public class EncodingConvert
    {
        //Универсальный метод для создания публичных
        private static string Convert(string input, string from, string to)
        {
            if (input == null) throw new ArgumentNullException("input");
            if (input == "") return "";

            try
            {
                byte[] byteStr = Encoding.GetEncoding(from).GetBytes(input);
                return Encoding.GetEncoding(to).GetString(byteStr);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Неподдерживаемая кодировка: {from} или {to}", ex);
            }
        }

        //Utf-8 в другие форматы
        public static string Utf8ToWindows1251(string input)
            => Convert(input, "utf-8", "windows-1251");
        public static string Utf8ToAscii(string input)
            => Convert(input, "utf-8", "ascii");
        public static string Utf8ToKoi8r(string input)
            => Convert(input, "utf-8", "koi8-r");
        public static string Utf8ToUtf16(string input) 
            => Convert(input, "utf-8", "utf-16");


        //Windows1251 в другие форматы
        public static string Windows1251ToUtf8(string input) 
            => Convert(input, "windows-1251", "utf-8");
        public static string Windows1251ToAscii(string input)
            => Convert(input, "windows-1251", "ascii");
        public static string Windows1251ToKoi8r(string input)
            => Convert(input, "windows-1251", "koi8-r");
        public static string Windows1251ToUtf16(string input) 
            => Convert(input, "windows-1251", "utf-16");

        //Ascii в другие форматы
        public static string AsciiToUtf8(string input)
            => Convert(input, "ascii", "utf-8");

        public static string AsciiToWindows1251(string input) 
            => Convert(input, "ascii", "windows-1251");
        public static string AsciiToKoi8r(string input)
            => Convert(input, "ascii", "koi8-r");
        public static string AsciiToUtf16(string input) 
            => Convert(input, "ascii", "utf-16");

        //Koi8-R в другие форматы
        public static string Koi8rToUtf8(string input) 
            => Convert(input, "koi8-r", "utf-8");
        public static string Koi8rToWindows1251(string input) 
            => Convert(input, "koi8-r", "windows-1251");
        public static string Koi8rToAscii(string input) 
            => Convert(input, "koi8-r", "ascii");
        public static string Koi8rToUtf16(string input) 
            => Convert(input, "koi8-r", "utf-16");


        //Utf16 в другие форматы
        public static string Utf16ToUtf8(string input) 
            => Convert(input, "utf-16", "utf-8");
        public static string Utf16ToWindows1251(string input) 
            => Convert(input, "utf-16", "windows-1251");
        public static string Utf16ToAscii(string input)
            => Convert(input, "utf-16", "ascii");
        public static string Utf16ToKoi8r(string input) 
            => Convert(input, "utf-16", "koi8-r");
    }
}