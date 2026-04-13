using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EncodingConverter.EncodingConvert;

namespace encodingChange
{
    public class AdditionalMethods
    {
        public enum EncodingType
        {
            Utf8,
            Windows1251,
            Ascii,
            Koi8r,
            Unicode
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

        public static List<EncodingType> GetSupportedEncodings()
        {
            EncodingType[] values = (EncodingType[])Enum.GetValues(typeof(EncodingType));
            return new List<EncodingType>(values);
        }

        public static EncodingType GetEncodingTypeByName(string encodingName)
        {
            if (string.IsNullOrEmpty(encodingName))
                throw new ArgumentException("Название кодировки не может быть null или пустым");

            switch (encodingName)
            {
                case "Utf8":
                    return EncodingType.Utf8;
                case "Windows1251":
                    return EncodingType.Windows1251;
                case "Ascii":
                    return EncodingType.Ascii;
                case "Koi8r":
                    return EncodingType.Koi8r;
                case "Unicode":
                    return EncodingType.Unicode;
                default:
                    throw new ArgumentException($"Неизвестная кодировка: {encodingName}");
            }
        }
    }
}
