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
        private static string Convert(string input, string from , string to)
        {
            if (input == null) throw new ArgumentNullException("input");
            if (input == "") return "";

            byte[] byteStr = Encoding.GetEncoding(from).GetBytes(input);
            return Encoding.GetEncoding(to).GetString(byteStr);
        }
    }
}