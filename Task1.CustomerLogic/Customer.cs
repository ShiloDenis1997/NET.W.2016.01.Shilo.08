using System;
using System.Collections.Generic;
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


        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{Name}, {Revenue.ToString(format, formatProvider)}, {ContactPhone}";
        }
    }
}
