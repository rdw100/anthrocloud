using System;
using Xunit;
using AnthroCloud.Business;

namespace AnthroCloud.Unit.Tests
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
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Architecture", "DV2002:Unmapped types", Justification = "<Pending>")]
    public class BMITests
    {
        [Fact]
        public void BMI_InstantiateObject_Calculation()
        {
            var BMI = new BMI(9.00, 73.00);
            double bmi = 16.9;
            Assert.Equal(bmi.ToString(), BMI.ToReadableDouble().ToString());
        }

        /// <summary>
        /// Tests equality comparison of BMI using unmodified length for a child under 2 recumbently.
        /// </summary>
        /// <remarks>
        /// If a child younger than 2 years has been measured in recumbent position 
        /// nothing is added to the child's height or converted 
        /// length used to calculate the BMI.
        /// </remarks>
        /// <param name="weight">The weight in kilograms</param>
        /// <param name="height">The height in centimeters</param>
        /// <param name="value">The expected BMI</param>
        [Theory]
        [InlineData(9.00, 73.00, 16.9)]
        [InlineData(9.50, 74.00, 17.3)]
        [InlineData(10.00, 76.00, 17.3)]
        public void BMI_TwoUnderRecumbent_QuotientIncreases(double weight, double height, double value)
        {
            var BMI = new BMI(weight, height);
            Assert.Equal(value, BMI.ToReadableDouble());
        }

        /// <summary>
        /// Tests equality comparison of BMI using +.7 length for a child under 2 standing.
        /// </summary>
        /// <remarks>
        /// If a child younger than 2 years has been measured standing — the standard procedure is to 
        /// measure in recumbent position — 0.7 cm is added to the child's height and the converted 
        /// length is used to calculate the BMI. 
        /// </remarks>
        /// <param name="weight">The weight in kilograms</param>
        /// <param name="height">The height in centimeters</param>
        /// <param name="value">The expected BMI</param>
        [Theory]
        [InlineData(9.00, 73.00, 16.6)]
        [InlineData(9.50, 74.00, 17)]
        [InlineData(10.00, 76.00, 17)]
        public void BMI_TwoUnderStanding_QuotientDecreases(double weight, double height, double value)
        {
            height += .7;
            var BMI = new BMI(weight, height);
            Assert.Equal(value, BMI.ToReadableDouble());
        }

        /// <summary>
        /// Tests equality comparison of BMI using -.7 length for a child over 2 recumbently.
        /// </summary>
        /// <remarks>
        /// In case a child aged 2 years or older has length measured, 0.7 cm is subtracted to convert 
        /// it to a height measurement before the BMI is derived
        /// </remarks>
        /// <param name="weight">The weight in kilograms</param>
        /// <param name="height">The height in centimeters</param>
        /// <param name="value">The expected BMI</param>
        [Theory]
        [InlineData(11.00, 83.70, 16)]
        [InlineData(12.00, 74.00, 22.3)]
        [InlineData(13.00, 76.00, 22.9)]
        public void BMI_TwoOverRecumbent_QuotientIncreases(double weight, double height, double value)
        {            
            height -= .7;
            var BMI = new BMI(weight, height);
            Assert.Equal(value, BMI.ToReadableDouble());
        }

        /// <summary>
        /// Tests equality comparison of BMI using unmodified length for a child over 2 standing.
        /// </summary>
        /// <param name="weight">The weight in kilograms</param>
        /// <param name="height">The height in centimeters</param>
        /// <param name="value">The expected BMI</param>
        [Theory]
        [InlineData(11.00, 83.70, 15.7)]
        [InlineData(12.00, 74.00, 21.9)]
        [InlineData(13.00, 76.00, 22.5)]
        public void BMI_TwoOverStanding_QuotientDecreases(double weight, double height, double value)
        {
            var BMI = new BMI(weight, height);
            Assert.Equal(value, BMI.ToReadableDouble());
        }
    }
}