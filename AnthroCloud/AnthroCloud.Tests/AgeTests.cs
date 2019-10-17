using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AnthroCloud.Business;

namespace AnthroCloud.Tests
{
    public class AgeTests
    {
        [Fact]
        public void Age_InstantiateObject_Calculation()
        {
            DateTime visit = new DateTime(2020, 10, 15);
            DateTime birth = new DateTime(2018, 10, 15);
            Age age = new Age(birth, visit);

            string ageString = "2yr 0mo (24mo)";
            Assert.Equal(ageString.ToString(), age.ToReadableString());
        }

        [Fact]
        public void Age_TotalDays_Calculation()
        {
            DateTime visit = new DateTime(2020, 11, 15);
            DateTime birth = new DateTime(2018, 10, 15);
            Age age = new Age(birth, visit);

            Console.WriteLine("It's been {0} years, {1} months, and {2} days since your birthday or {3} in total days or {4} in total months", age.Years, age.Months, age.Days, age.TotalDays, age.TotalMonths);
            Console.WriteLine(age.ToReadableString());

            int ageInDays = age.TotalDays;
            int expectedAgeInDays = 762;
            Assert.Equal(expectedAgeInDays, ageInDays);
        }

        [Fact]
        public void Age_TotalMonths_Calculation()
        {
            DateTime visit = new DateTime(2020, 10, 15);
            DateTime birth = new DateTime(2018, 10, 15);
            Age age = new Age(birth, visit);

            Console.WriteLine("It's been {0} years, {1} months, and {2} days since your birthday or {3} in total days or {4} in total months", age.Years, age.Months, age.Days, age.TotalDays, age.TotalMonths);
            Console.WriteLine(age.ToReadableString());

            int ageInMonths = age.TotalMonths;
            int expectedAgeInMonths = 24;
            Assert.Equal(expectedAgeInMonths, ageInMonths);
        }

        [Theory]
        [InlineData("10/15/2018", "10/14/2019", "11mo")]
        [InlineData("10/15/2018", "10/15/2019", "1yr 0mo (12mo)")]
        [InlineData("10/15/2018", "10/15/2020", "2yr 0mo (24mo)")]
        [InlineData("10/15/2018", "10/15/2021", "3yr 0mo (36mo)")]
        [InlineData("10/15/2018", "10/15/2022", "4yr 0mo (48mo)")]
        [InlineData("10/15/2018", "10/15/2023", "5yr 0mo (60mo)")]
        public void Age_OutputStrings_Calculation(String birthString, String visitString, String expectedValue)
        {
            DateTime birth = Convert.ToDateTime(birthString);
            DateTime visit = Convert.ToDateTime(visitString);

            Age age = new Age(birth, visit);
            Assert.Equal(expectedValue, age.ToReadableString());
        }
    }
}
