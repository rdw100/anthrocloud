using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AnthroCloud.Business;
using AnthroCloud.Entities;
using AnthroCloud.API.Controllers;
using AnthStat.Statistics;

namespace AnthroCloud.Integration.Tests
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Architecture", "DV2002:Unmapped types", Justification = "<Pending>")]
    public class StatsControllerTests
    {
        /// <summary>
        /// Tests InRange comparison theory where percentile and z-score numeric ranges are expected.
        /// </summary>
        /// <param name="indicator">The growth indicator</param>
        /// <param name="measurement">The specified measured value</param>
        /// <param name="ageInDays">The age in total days</param>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        [Theory]
        [InlineData(Indicator.ArmCircumferenceForAge, 15.00, 365, Sex.Male)]
        [InlineData(Indicator.BodyMassIndexForAge, 16.89, 365, Sex.Male)]
        [InlineData(Indicator.HeadCircumferenceForAge, 45.00, 365, Sex.Male)]
        [InlineData(Indicator.HeightForAge, 96.00, 1095, Sex.Male)]
        [InlineData(Indicator.LengthForAge, 73.00, 365, Sex.Male)]
        [InlineData(Indicator.SubscapularSkinfoldForAge, 7.00, 365, Sex.Male)]
        [InlineData(Indicator.TricepsSkinfoldForAge, 8.00, 365, Sex.Male)]
        [InlineData(Indicator.WeightForAge, 9.00, 365, Sex.Male)]
        [InlineData(Indicator.WeightForHeight, 14.00, 96.00, Sex.Male)]
        [InlineData(Indicator.WeightForLength, 9.00, 73.00, Sex.Male)]
        public void GetScores_PairValues_ShouldReturnTuples(Indicator indicator, double measurement, double ageInDays, Sex sex)
        {
            var controller = new StatsController();
            Tuple<double, double> GetScores = controller.GetScore(indicator, measurement, ageInDays, sex);

            Assert.InRange(GetScores.Item1, -4, 4);
            Assert.InRange(GetScores.Item2, 0, 100);
        }

        /// <summary>
        /// Tests equality comparison theory where expected chart line color code is assigned from percentile and z-score numeric range.
        /// </summary>
        /// <param name="indicator">The growth indicator</param>
        /// <param name="measurement">The specified measured value</param>
        /// <param name="ageInDays">The age in total days</param>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <param name="expectedColor">The chart line color code expected from z-score numeric range </param>
        [Theory]
        [InlineData(Indicator.ArmCircumferenceForAge, 15.50, 365, Sex.Female, "Gold")]
        [InlineData(Indicator.BodyMassIndexForAge, 19.9, 365, Sex.Female, "Red")]
        [InlineData(Indicator.HeadCircumferenceForAge, 43.5, 365, Sex.Female, "Gold")]
        [InlineData(Indicator.HeightForAge, 96.00, 1095, Sex.Female, "Green")]
        [InlineData(Indicator.LengthForAge, 81.8, 365, Sex.Female, "Black")]
        [InlineData(Indicator.SubscapularSkinfoldForAge, 9.00, 365, Sex.Female, "Gold")]
        [InlineData(Indicator.TricepsSkinfoldForAge, 9.8, 365, Sex.Female, "Green")]
        [InlineData(Indicator.WeightForAge, 10.6, 365, Sex.Female, "Gold")]
        [InlineData(Indicator.WeightForHeight, 14.00, 96.00, Sex.Female, "Green")]
        [InlineData(Indicator.WeightForLength, 12.80, 82.20, Sex.Female, "Red")]
        public void GetScores_ColorCoding_ShouldReturnZscoreSeverity(Indicator indicator, double measurement, double ageInDays, Sex sex, String expectedColor)
        {
            var controller = new StatsController();
            Tuple<double, double> GetScores = controller.GetScore(indicator, measurement, ageInDays, sex);

            string actualColor = GetColorCoding(GetScores.Item1);
            Assert.Equal(expectedColor, actualColor);
        }

        /// <summary>
        /// Retrieves the chart line color code expected from z-score numeric range
        /// </summary>
        /// <param name="zscore"></param>
        /// <returns></returns>
        /// <remarks>Range-based switching is possible with the switch statement.</remarks>
        private string GetColorCoding(double zscore)
        {
            var testColorCode = zscore switch
            {
                double n when (n <=  1  && n >= -1) => "Green",
                double n when (n <= -1  && n >= -2) || (n <= 2 && n > 1) => "Gold",
                double n when (n <  -2  && n >= -3) || (n <= 3 && n > 2) => "Red",
                double n when (n >   3  || n <  -3) => "Black",
                _ => string.Empty,
            };
            return testColorCode;
        }
    }
}
