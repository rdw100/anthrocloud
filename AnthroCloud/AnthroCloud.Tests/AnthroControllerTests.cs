using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AnthroCloud.Business;
using AnthroCloud.Entities;
using AnthroCloud.API.Controllers;

namespace AnthroCloud.Integration.Tests
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Architecture", "DV2002:Unmapped types", Justification = "<Pending>")]
    public class AnthroControllerTests
    {
        [Fact]
        public void Age_Years_ShouldReturnYearsString()
        {
            var controller = new AnthroController();

            String expected = "3";
            DateTime visit = new DateTime(2019, 12, 1);
            DateTime birth = new DateTime(2016, 12, 1);
            String actual = controller.GetAgeInYears(birth, visit);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Age_Months_ShouldReturnMonthsString()
        {
            var controller = new AnthroController();

            String expected = "36";
            DateTime visit = new DateTime(2019, 12, 1);
            DateTime birth = new DateTime(2016, 12, 1);
            String actual = controller.GetAgeInMonths(birth, visit);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Age_String_ShouldReturnYearMonthString()
        {
            var controller = new AnthroController();
            
            String expected = "3yr 0mo (36mo)";
            DateTime visit = new DateTime(2019, 12, 1);
            DateTime birth = new DateTime(2016, 12, 1);
            String actual = controller.GetAge(birth, visit);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Age_Days_ShouldReturnDaysString()
        {            
            var controller = new AnthroController();

            String expected = "1095";
            DateTime visit = new DateTime(2019, 12, 1);
            DateTime birth = new DateTime(2016, 12, 1);
            String actual = controller.GetAgeInDays(birth, visit);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BMI_SimpleValues_ShouldReturnBMIString()
        {
            var controller = new AnthroController();
            
            double expected = 16.9;
            double weight = 9.00;
            double height = 73.00;
            double actual = controller.GetBMI(weight, height);

            Assert.Equal(expected, actual);
        }
    }
}
