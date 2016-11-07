using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Task1.CustomerLogic.Tests
{
    [TestFixture]
    public class CustomerTests
    {
        public static IEnumerable<TestCaseData> ToStringTestData
        {
            get
            {
                yield return new TestCaseData(new Customer
                    {
                        Name = "Jeffrey Richter",
                        Revenue = 1000000,
                        ContactPhone = "+1 (425) 555-0100"
                    },
                    "NRP", CultureInfo.GetCultureInfo("en-GB"),
                    "Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100");
                yield return new TestCaseData(new Customer
                    {
                        Name = "Jeffrey Richter",
                        Revenue = 1000000,
                        ContactPhone = "+1 (425) 555-0100"
                    },
                    "P", CultureInfo.GetCultureInfo("en-GB"),
                    "+1 (425) 555-0100");
                yield return new TestCaseData(new Customer
                    {
                        Name = "Jeffrey Richter",
                        Revenue = 1000000,
                        ContactPhone = "+1 (425) 555-0100"
                    },
                    "N", CultureInfo.GetCultureInfo("en-GB"),
                    "Jeffrey Richter");
                yield return new TestCaseData(new Customer
                    {
                        Name = "Jeffrey Richter",
                        Revenue = 1000000,
                        ContactPhone = "+1 (425) 555-0100"
                    },
                    "R", CultureInfo.GetCultureInfo("en-GB"),
                    "1,000,000.00");
                yield return new TestCaseData(new Customer
                    {
                        Name = "Jeffrey Richter",
                        Revenue = 1000000,
                        ContactPhone = "+1 (425) 555-0100"
                    },
                    "NP", CultureInfo.GetCultureInfo("en-GB"),
                    "Jeffrey Richter +1 (425) 555-0100");
                yield return new TestCaseData(new Customer
                    {
                        Name = "Jeffrey Richter",
                        Revenue = 1000000,
                        ContactPhone = "+1 (425) 555-0100"
                    },
                    "NR", CultureInfo.GetCultureInfo("en-GB"),
                    "Jeffrey Richter 1,000,000.00");
                yield return new TestCaseData(new Customer
                    {
                        Name = "Jeffrey Richter",
                        Revenue = 1000000,
                        ContactPhone = "+1 (425) 555-0100"
                    },
                    "F", CultureInfo.GetCultureInfo("en-GB"),
                    "1000000");
            }
        }

        [TestCaseSource(nameof(ToStringTestData))]
        [Test]
        public void ToString_FormatAndFormatProvider_FormattedStringReturns
            (Customer customer, string format, IFormatProvider provider, string expected)
        {
            //act
            string actual = customer.ToString(format, provider);
            //assert
            Assert.AreEqual(0, string.CompareOrdinal(actual, expected),
                $"{expected} expected, but {actual} got");
        }


        [TestCase("A", typeof(FormatException))]
        [Test]
        public void ToString_UnsupportedFormat_ExceptionExpected(string format, Type expectedException)
        {
            Assert.Throws(expectedException, () => { new Customer().ToString(format); });
        }
    }
}
