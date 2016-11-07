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

        public IFormatProvider Parent { get; private set; }
        /// <summary>Constructs provider with the <paramref name="parent"/>
        /// provider, which will be used if current provider does not know
        /// how to work with format. If not specified, 
        /// <see cref="CultureInfo.CurrentCulture"/>
        /// will be used </summary>
        /// <param name="parent"></param>
        public PhoneNameFormatProvider(IFormatProvider parent = null)
        {
            Parent = parent ?? CultureInfo.CurrentCulture;
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            return Thread.CurrentThread.CurrentCulture.GetFormat(formatType);
        }
        
        /// <param name="format"></param>
        /// <param name="arg"></param>
        /// <param name="formatProvider"></param>
        /// <exception cref="ArgumentNullException">Throws if 
        /// <paramref name="arg"/> is null</exception>
        /// <exception cref="FormatException">Throws if neither this nor <see cref="Parent"/>
        ///  knows how to work with <paramref name="format"/></exception>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg == null || format != "PN")
                return string.Format(Parent, "{0:" + format + "}", arg);
            Customer customer = arg as Customer;
            if (customer != null)
                return customer.ContactPhone + ", " + customer.Name;
            IFormattable formattable = arg as IFormattable;
            string s = formattable?.ToString(format, formatProvider);
            return s ?? arg.ToString();
        }
    }
}
