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

            byte[] byteStr = Encoding.GetEncoding(from).GetBytes(input);
            return Encoding.GetEncoding(to).GetString(byteStr);
        }

        public static string Utf8ToWindows1251(string input)
        {
            return Convert(input, "utf-8", "windows-1251");
        }

        public static string Windows1251ToUtf8(string input)
        {
            return Convert(input, "windows-1251", "utf-8");
        }

        public static string Utf8ToAscii(string input)
        {
            return Convert(input, "utf-8", "ascii");
        }
        public static string AsciiToUtf8(string input)
        {
            return Convert(input, "ascii", "utf-8");
        }

        public static string AsciiToWindows1251(string input)
        {
            return Convert(input, "ascii", "windows-1251");
        }

        public static string Windows1251ToAscii(string input) 
        {
            return Convert(input, "windows-1251", "ascii");
        }
    }
}