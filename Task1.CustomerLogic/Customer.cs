﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.CustomerLogic
{
    /// <summary>
    /// Contains info about customer and provides different formats
    /// to string representation of data
    /// </summary>
    public class Customer : IFormattable
    {
        public string Name { get; set; }
        public string ContactPhone { get; set; }
        public decimal Revenue { get; set; }

        /// <summary>
        /// Creates string representation of <see cref="Customer"/> info according
        /// to <paramref name="format"/> and <paramref name="formatProvider"/>
        /// </summary>
        /// <param name="format">Supports "G", "NRP", "P", "N", "R",
        ///  "NP", "NR", "F" formats</param>
        /// <param name="formatProvider">If not specified, 
        /// <see cref="CultureInfo.CurrentCulture"/> will be used</param>
        /// <returns>String representation of <see cref="Customer"/></returns>
        /// <exception cref="FormatException">Throws if 
        /// <paramref name="format"/> has and unknown format</exception>
        public string ToString(string format, IFormatProvider formatProvider = null)
        {
            if (string.IsNullOrEmpty(format))
                format = "G";
            if (formatProvider == null)
                formatProvider = CultureInfo.CurrentCulture;
            switch (format.ToUpperInvariant())
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
                    return Name + ", " + ContactPhone;
                case "NR":
                    return Name + ", " + Revenue.ToString("###,###.00", formatProvider);
                case "F":
                    return Revenue.ToString("#.##", formatProvider);
                default:
                    throw new FormatException($"The {format} format string isn't specified");
            }
        }

        /// <summary>
        /// Creates string representation of <see cref="Customer"/> by
        /// invoking <see cref="Customer.ToString(string, IFormatProvider)"/>
        /// </summary>
        public override string ToString()
        {
            return ToString("G", CultureInfo.CurrentCulture);
        }
    }
}
