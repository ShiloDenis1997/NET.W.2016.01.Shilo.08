using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task1.CustomerLogic;

namespace Task1.CustomProviders.Tests
{
    [TestFixture]
    public class CustomFormatProvidersTests
    {
        public static IEnumerable<TestCaseData> PhoneNameFormatProviderTestData
        {
            get
            {
                yield return new TestCaseData("{0:PN} {1:E2} {2:#,} {3:N3}",
                    new PhoneNameFormatProvider(CultureInfo.InvariantCulture),
                    "+1 (425) 555-0100, Jeffrey Richter 1.26E+001 1 42.120", new object[]
                    {
                        new Customer
                        {
                            Name = "Jeffrey Richter",
                            Revenue = 1000000,
                            ContactPhone = "+1 (425) 555-0100"
                        },
                        12.563, 1000, 42.12
                    });
                yield return new TestCaseData("{0:PN} {0:NRP} {1:E2} {2:#,} {3:N3}",
                    new PhoneNameFormatProvider(CultureInfo.InvariantCulture),
                    "+1 (425) 555-0100, Jeffrey Richter Jeffrey Richter, " +
                    "1,000,000.00, +1 (425) 555-0100 1.26E+001 1 42.120", 
                    new object[]
                    {
                        new Customer
                        {
                            Name = "Jeffrey Richter",
                            Revenue = 1000000,
                            ContactPhone = "+1 (425) 555-0100"
                        },
                        12.563, 1000, 42.12
                    });
            }
        }

        [TestCaseSource(nameof(PhoneNameFormatProviderTestData))]
        [Test]
        public void PhoneNameFormatProvider_CustomerFormatFormatProvider_StringExpected
            (string format, IFormatProvider provider, string expectedString,
            params object[] args)
        {
            //act
            string actual = string.Format(provider, format, args);
            //assert
            Assert.AreEqual(0, string.CompareOrdinal(actual, expectedString),
                $"expected \"{expectedString}\", but got \"{actual}\"");
        }
    }
}
