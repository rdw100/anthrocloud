using AnthroCloud.Business;
using System.Threading.Tasks;
using Xunit;

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
    public class BMITests
    {
        [Fact]
        public async Task BMI_InstantiateObject_CalculationAsync()
        {
            BMI bmi = new BMI();
            _ = await bmi.Calculate(9.00, 73.00);
            double expected = 16.9;
            Assert.Equal(expected.ToString(), bmi.ToReadableDouble().ToString());
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
        public async Task BMI_TwoUnderRecumbent_QuotientIncreasesAsync(double weight, double height, double value)
        {
            BMI bmi = new BMI();
            _ = await bmi.Calculate(weight, height);
            Assert.Equal(value, bmi.ToReadableDouble());
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
        public async Task BMI_TwoUnderStanding_QuotientDecreasesAsync(double weight, double height, double value)
        {
            height += .7;
            BMI bmi = new BMI();
            _ = await bmi.Calculate(weight, height);
            Assert.Equal(value, bmi.ToReadableDouble());
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
        public async Task BMI_TwoOverRecumbent_QuotientIncreasesAsync(double weight, double height, double value)
        {            
            height -= .7;
            BMI bmi = new BMI();
            _ = await bmi.Calculate(weight, height);
            Assert.Equal(value, bmi.ToReadableDouble());
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
        public async Task BMI_TwoOverStanding_QuotientDecreasesAsync(double weight, double height, double value)
        {
            BMI bmi = new BMI();
            _ = await bmi.Calculate(weight, height);
            Assert.Equal(value, bmi.ToReadableDouble());
        }
    }
}