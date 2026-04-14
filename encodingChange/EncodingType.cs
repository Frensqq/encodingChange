using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encodingChange
{
    public class AdditionalClass
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
    }
}
