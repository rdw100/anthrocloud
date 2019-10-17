using System;
using Xunit;
using AnthroCloud.Business;

namespace AnthroCloud.Tests
{
    /// <summary>
    /// Tests BMI calculator to theorize WHO Anthro Calculator 
    /// height adjustment behavior to explain calculations.
    /// </summary>
    /// <remarks>
    /// ************************************
    /// ************* Recumbent * Standing *
    /// ************************************
    /// * 2 Under   *          *   +.7cm   *
    /// * 2 & Over  *   -.7cm  *           *
    /// ************************************
    /// </remarks>
    public class BMITests
    {
        [Fact]
        public void BMI_InstantiateObject_Calculation()
        {
            var BMI = new BMI(9.00, 73.00);
            double bmi = 16.9;
            Assert.Equal(bmi.ToString(), BMI.ToReadableDouble().ToString());
        }

        [Theory]
        [InlineData(9.00, 73.00, 16.9)]
        [InlineData(9.50, 74.00, 17.3)]
        [InlineData(10.00, 76.00, 17.3)]
        public void BMI_UnderTwoYearRecumbentNonAdjustedHeight_CalculatedQuotientIncreases(double weight, double height, double value)
        {
            var BMI = new BMI(weight, height);
            Assert.Equal(value, BMI.ToReadableDouble());
        }

        /// <summary>
        /// If a child younger than 2 years has been measured standing — the standard procedure is to 
        /// measure in recumbent position — 0.7 cm is added to the child's height and the converted 
        /// length is used to calculate the BMI. 
        /// </summary>
        [Theory]
        [InlineData(9.00, 73.00, 16.6)]
        [InlineData(9.50, 74.00, 17)]
        [InlineData(10.00, 76.00, 17)]
        public void BMI_UnderTwoYearStandingAdjustedHeight_CalculatedQuotientDecreases(double weight, double height, double value)
        {
            height += .7;
            var BMI = new BMI(weight, height);
            Assert.Equal(value, BMI.ToReadableDouble());
        }

        /// <summary>
        /// In case a child aged 2 years or older has length measured, 0.7 cm is subtracted to convert 
        /// it to a height measurement before the BMI is derived
        /// </summary>
        [Theory]
        [InlineData(11.00, 83.70, 16)]
        [InlineData(12.00, 74.00, 22.3)]
        [InlineData(13.00, 76.00, 22.9)]
        public void BMI_OverTwoYearRecumbentAdjustedHeight_CalculatedQuotientIncreases(double weight, double height, double value)
        {            
            height -= .7;
            var BMI = new BMI(weight, height);
            Assert.Equal(value, BMI.ToReadableDouble());
        }

        [Theory]
        [InlineData(11.00, 83.70, 15.7)]
        [InlineData(12.00, 74.00, 21.9)]
        [InlineData(13.00, 76.00, 22.5)]
        public void BMI_OverTwoYearStandingAdjustedHeight_CalculatedQuotientDecreases(double weight, double height, double value)
        {
            var BMI = new BMI(weight, height);
            Assert.Equal(value, BMI.ToReadableDouble());
        }
    }
}
