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
    /// <summary>
    /// Formats <see cref="Customer"/> to representation 
    /// "<see cref="Customer.ContactPhone"/>, <see cref="Customer.Name"/>",
    /// uses "PN" string format
    /// </summary>
    public class PhoneNameFormatProvider : IFormatProvider, ICustomFormatter
    {
        private IFormatProvider parent;

        /// <summary>Constructs provider with the <paramref name="parent"/>
        /// provider, which will be used if current provider does not know
        /// how to work with format. If not specified, 
        /// <see cref="CultureInfo.CurrentCulture"/>
        /// will be used </summary>
        /// <param name="parent"></param>
        public PhoneNameFormatProvider(IFormatProvider parent = null)
        {
            this.parent = parent ?? CultureInfo.CurrentCulture;
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
                return string.Format(parent, "{0:" + format + "}", arg);
            Customer customer = arg as Customer;
            if (customer != null)
                return customer.ContactPhone + ", " + customer.Name;
            IFormattable formattable = arg as IFormattable;
            string s = formattable?.ToString(format, formatProvider);
            return s ?? arg.ToString();
        }
    }
}
