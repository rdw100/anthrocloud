using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AnthroCloud.Business;
using AnthroCloud.Entities;
using AnthroCloud.API.Controllers;

namespace AnthroCloud.Tests
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Architecture", "DV2002:Unmapped types", Justification = "<Pending>")]
    public class AnthroControllerTests
    {
        [Fact]
        public void GetAge_SimpleValues_ShouldReturnYearMonthString()
        {
            var controller = new AnthroController();
            
            String expected = "3yr 0mo (36mo)";
            DateTime visit = new DateTime(2019, 12, 1);
            DateTime birth = new DateTime(2016, 12, 1);
            String actual = controller.GetAge(birth, visit);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetAgeInDays_SimpleValues_ShouldReturnDaysString()
        {            
            var controller = new AnthroController();

            String expected = "1095";
            DateTime visit = new DateTime(2019, 12, 1);
            DateTime birth = new DateTime(2016, 12, 1);
            String actual = controller.GetAgeInDays(birth, visit);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetBMi_SimpleValues_ShouldReturnBMIString()
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
