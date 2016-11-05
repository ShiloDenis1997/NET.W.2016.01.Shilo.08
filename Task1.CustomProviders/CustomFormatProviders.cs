using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task1.CustomerLogic;

namespace Task1.CustomProviders
{
    public class PhoneNameFormatProvider : IFormatProvider, ICustomFormatter
    {
        private IFormatProvider parent;

        public PhoneNameFormatProvider() : this(CultureInfo.CurrentCulture) { }

        public PhoneNameFormatProvider(IFormatProvider parent)
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
            if (arg == null || format != "PN")
                return string.Format(parent, format, arg);
            Customer customer = arg as Customer;
            if (customer != null)
                return customer.ContactPhone + customer.Name;
            IFormattable formattable = arg as IFormattable;
            string s = formattable?.ToString(format, formatProvider);
            return s ?? arg.ToString();
        }
    }
}
