using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1.CustomProviders
{
    public class PhoneFormatProvider : IFormatProvider, ICustomFormatter
    {
        private IFormatProvider parent;

        public PhoneFormatProvider() : this(CultureInfo.CurrentCulture) { }

        public PhoneFormatProvider(IFormatProvider parent)
        {
            this.parent = parent;
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            return Thread.CurrentThread.CurrentCulture.GetFormat(formatType);
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            return "haha";//todo
        }
    }
}
