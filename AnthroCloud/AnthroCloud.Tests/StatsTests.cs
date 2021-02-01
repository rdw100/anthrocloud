using AnthroCloud.Business;
using AnthStat.Statistics;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AnthroCloud.Unit.Tests
{
    /// <summary>
    /// Tests statistics class.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Architecture", "DV2002:Unmapped types", Justification = "<Pending>")]
    public class StatsTests
    {
        /// <summary>
        /// Tests Weight-for-length z-score calculation.
        /// </summary>
        [Fact]
        public async void Stats_WFL_Zscore_Calculate()
        {
            var stat = new Stats();
            double z = await stat.CalculateZScore(Indicator.WeightForLength, 9.00, 73.00, Sex.Male);
 
            Assert.Equal(-0.12, Math.Round(z,2));
        }

        /// <summary>
        /// Tests Weight-for-length percentile calculation.
        /// </summary>
        [Fact]
        public async void Stats_WFL_Pcentile_Calculate()
        {
            var stat = new Stats();
            double z = await stat.CalculateZScore(Indicator.WeightForLength, 9.00, 73.00, Sex.Male);
            double p = await stat.CalculatePercentile(z);

            Assert.Equal(45.4, Math.Round(p,1));
        }

        /// <summary>
        /// Tests Weight-for-height z-score calculation.
        /// </summary>
        /// <remarks>Expected value obtained from child over 2 measured standing.</remarks>
        [Fact]
        public async void Stats_WFH_Zscore_Calculate()
        {
            var stat = new Stats();
            double z = await stat.CalculateZScore(Indicator.WeightForHeight, 12.00, 87.00, Sex.Male);

            Assert.Equal(-0.17, Math.Round(z,2));
        }

        /// <summary>
        /// Tests Weight-for-height percentile calculation.
        /// </summary>
        /// <remarks>Expected value obtained from child over 2 measured standing.</remarks>
        [Fact]
        public async void Stats_WFH_Pcentile_Calculate()
        {
            var stat = new Stats();
            double z = await stat.CalculateZScore(Indicator.WeightForHeight, 12.00, 87.00, Sex.Male);
            double p = await stat.CalculatePercentile(z);

            Assert.Equal(43.3, Math.Round(p,1));
        }

        /// <summary>
        /// Tests Weight-for-age z-score calculation.
        /// </summary>
        [Fact]
        public async void Stats_WFA_Zscore_Calculate() 
        {
            var stat = new Stats();
            double z = await stat.CalculateZScore(Indicator.WeightForAge, 9.00, 365, Sex.Male);

            Assert.Equal(-0.63, Math.Round(z, 2));
        }

        /// <summary>
        /// Tests Weight-for-age percentile calculation.
        /// </summary>
        [Fact]
        public async void Stats_WFA_Pcentile_Calculate()
        {
            var stat = new Stats();
            double z = await stat.CalculateZScore(Indicator.WeightForAge, 9.00, 365, Sex.Male);
            double p = await stat.CalculatePercentile(z);

            Assert.Equal(26.3, Math.Round(p, 1));
        }

        /// <summary>
        /// Tests Length-for-age z-score calculation.
        /// </summary>
        [Fact]
        public async void Stats_LFA_Zscore_Calculate()
        {
            var stat = new Stats();
            double z = await stat.CalculateZScore(Indicator.LengthForAge, 73.00, 365, Sex.Male);

            Assert.Equal(-1.15, Math.Round(z, 2));
        }
        /// <summary>
        /// Tests Length-for-age percentile calculation.
        /// </summary>
        [Fact]
        public async void Stats_LFA_Pcentile_Calculate()
        {
            var stat = new Stats();
            double z = await stat.CalculateZScore(Indicator.LengthForAge, 73.00, 365, Sex.Male);
            double p = await stat.CalculatePercentile(z);

            Assert.Equal(12.4, Math.Round(p, 1));
        }

        /// <summary>
        /// Tests Height-for-age z-score calculation.
        /// </summary>
        [Fact]
        public async void Stats_HFA_Zscore_Calculate()
        {
            var stat = new Stats();
            double z = await stat.CalculateZScore(Indicator.HeightForAge, 96.8, 1096, Sex.Male);

            Assert.Equal(.19, Math.Round(z, 2));
        }
        /// <summary>
        /// Tests Height-for-age percentile calculation.
        /// </summary>
        [Fact]
        public async void Stats_HFA_Pcentile_Calculate()
        {
            var stat = new Stats();
            double z = await stat.CalculateZScore(Indicator.HeightForAge, 96.8, 1096, Sex.Male);
            double p = await stat.CalculatePercentile(z);

            Assert.Equal(57.6, Math.Round(p, 1));
        }

        /// <summary>
        /// Tests BodyMassIndexForAge z-score calculation.
        /// </summary>
        [Fact]
        public async void Stats_BFA_Zscore_Calculate()
        {
            var stat = new Stats();
            double z = await stat.CalculateZScore(Indicator.BodyMassIndexForAge, 16.89, 365, Sex.Male);

            Assert.Equal(0.07, Math.Round(z, 2));
        }

        /// <summary>
        /// Tests BodyMassIndexForAge percentile calculation.
        /// </summary>
        [Fact]
        public async void Stats_BFA_Pcentile_Calculate()
        {
            var stat = new Stats();
            double z = await stat.CalculateZScore(Indicator.BodyMassIndexForAge, 16.89, 365, Sex.Male);
            double p = await stat.CalculatePercentile(z);

            Assert.Equal(52.7, Math.Round(p, 1));
        }

        /// <summary>
        /// Tests HeadCircumferenceForAge z-score calculation.
        /// </summary>
        [Fact]
        public async void Stats_HCFA_Zscore_Calculate()
        {
            var stat = new Stats();
            double z = await stat.CalculateZScore(Indicator.HeadCircumferenceForAge, 45.00, 365, Sex.Male);

            Assert.Equal(-0.83, Math.Round(z, 2));
        }

        /// <summary>
        /// Tests HeadCircumferenceForAge percentile calculation.
        /// </summary>
        [Fact]
        public async void Stats_HCFA_Pcentile_Calculate()
        {
            var stat = new Stats();
            double z = await stat.CalculateZScore(Indicator.HeadCircumferenceForAge, 45.00, 365, Sex.Male);
            double p = await stat.CalculatePercentile(z);

            Assert.Equal(20.4, Math.Round(p, 1));
        }

        /// <summary>
        /// Tests ArmCircumferenceForAge z-score calculation.
        /// </summary>
        [Fact]
        public async void Stats_MUAC_Zscore_Calculate()
        {
            var stat = new Stats();
            double z = await stat.CalculateZScore(Indicator.ArmCircumferenceForAge, 15.00, 365, Sex.Male);

            Assert.Equal(0.31, Math.Round(z, 2));
        }

        /// <summary>
        /// Tests ArmCircumferenceForAge percentile calculation.
        /// </summary>
        [Fact]
        public async void Stats_MUAC_Pcentile_Calculate()
        {
            var stat = new Stats();
            double z = await stat.CalculateZScore(Indicator.ArmCircumferenceForAge, 15.00, 365, Sex.Male);
            double p = await stat.CalculatePercentile(z);

            Assert.Equal(62.3, Math.Round(p, 1));
        }

        /// <summary>
        /// Tests TricepsSkinfoldForAge z-score calculation.
        /// </summary>
        [Fact]
        public async void Stats_TSF_Zscore_Calculate()
        {
            var stat = new Stats();
            double z = await stat.CalculateZScore(Indicator.TricepsSkinfoldForAge, 8.00, 365, Sex.Male);

            Assert.Equal(-0.07, Math.Round(z, 2));
        }

        /// <summary>
        /// Tests TricepsSkinfoldForAge percentile calculation.
        /// </summary>
        [Fact]
        public async void Stats_TSF_Pcentile_Calculate()
        {
            var stat = new Stats();
            double z = await stat.CalculateZScore(Indicator.TricepsSkinfoldForAge, 8.00, 365, Sex.Male);
            double p = await stat.CalculatePercentile(z);

            Assert.Equal(47.3, Math.Round(p, 1));
        }

        /// <summary>
        /// Tests SubscapularSkinfoldForAge z-score calculation.
        /// </summary>
        [Fact]
        public async void Stats_SSF_Zscore_Calculate()
        {
            var stat = new Stats();
            double z = await stat.CalculateZScore(Indicator.SubscapularSkinfoldForAge, 7.00, 365, Sex.Male);

            Assert.Equal(0.45, Math.Round(z, 2));
        }

        /// <summary>
        /// Tests SubscapularSkinfoldForAge percentile calculation.
        /// </summary>
        [Fact]
        public async void Stats_SSF_Pcentile_Calculate()
        {
            var stat = new Stats();
            double z = await stat.CalculateZScore(Indicator.SubscapularSkinfoldForAge, 7.00, 365, Sex.Male);
            double p = await stat.CalculatePercentile(z);

            Assert.Equal(67.4, Math.Round(p, 1));
        }

        /// <summary>
        /// Tests percentile and zscore range for all 10 indicators.
        /// </summary>
        /// <param name="indicator">The measurement indicator</param>
        /// <param name="measurement">The measured value</param>
        /// <param name="ageInDays">The age in days</param>
        /// <param name="sex">The biological determination</param>
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
        public async Task Stats_All_TupleAsync(Indicator indicator, double measurement, double ageInDays, Sex sex)
        {
            var stat = new Stats();
            Tuple<double, double> GetScores = await stat.GetScore(indicator, measurement, ageInDays, sex);
            
            Assert.InRange(GetScores.Item1, -4, 4);
            Assert.InRange(GetScores.Item2, 0, 100);
        }
    }
}
