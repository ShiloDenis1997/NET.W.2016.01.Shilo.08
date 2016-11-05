using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.CustomerLogic
{
    public class Customer : IFormattable
    {
        public string Name { get; set; }
        public string ContactPhone { get; set; }
        public decimal Revenue { get; set; }


        public string ToString(string format, IFormatProvider formatProvider = null)
        {
            if (string.IsNullOrEmpty(format))
                format = "G";
            if (formatProvider == null)
                formatProvider = CultureInfo.CurrentCulture;
            switch (format)
            {
                case "G":
                case "NRP":
                    return $"{Name}, {Revenue.ToString("###,###.00", formatProvider)}," +
                           $" {ContactPhone}";
                case "P":
                    return ContactPhone;
                case "N":
                    return Name;
                case "R":
                    return Revenue.ToString("###,###.00", formatProvider);
                case "NP":
                    return Name + ContactPhone;
                case "NR":
                    return Name + Revenue.ToString("###,###.00", formatProvider);
                case "F":
                    return Revenue.ToString("#.##", formatProvider);

                default:
                    throw new FormatException($"The {format} format string isn't specified");
            }
        }
    }
}
