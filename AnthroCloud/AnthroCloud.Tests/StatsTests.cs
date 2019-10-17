using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AnthroCloud.Business;
using AnthStat.Statistics;

namespace AnthroCloud.Tests
{
    public class StatsTests
    {
        [Fact]
        public void Stats_WeightForLengthPercentile_Calculation()
        {
            var stat = new Stats();
            double p = stat.CalculateZScore(Indicator.WeightForLength, 9.00, 73.00, Sex.Male);
 
            Assert.Equal(-0.11587064595388744, p);
        }

        [Fact]
        public void Stats_WeightForLengthZscore_Calculation()
        {
            var stat = new Stats();
            double p = stat.CalculateZScore(Indicator.WeightForLength, 9.00, 73.00, Sex.Male);
            double z = stat.CalculatePercentile(p);

            Assert.Equal(45.3877530045168, z);
        }        

        [Fact]
        public void Stats_WeightForAgePercentile_Calculation()
        {
            var stat = new Stats();
            double p = stat.CalculateZScore(Indicator.WeightForAge, 9.00, 365, Sex.Male);

            Assert.Equal(-0.6330801913570989, p);
        }

        [Fact]
        public void Stats_WeightForAgeZscore_Calculation()
        {
            var stat = new Stats();
            double p = stat.CalculateZScore(Indicator.WeightForAge, 9.00, 365, Sex.Male);
            double z = stat.CalculatePercentile(p);

            Assert.Equal(26.334063856829903, z);
        }

        [Fact]
        public void Stats_LenghtForAgePercentile_Calculation()
        {
            var stat = new Stats();
            double p = stat.CalculateZScore(Indicator.LengthForAge, 73.00, 365, Sex.Male);

            Assert.Equal(-1.1528511286434184, p);
        }

        [Fact]
        public void Stats_LengthForAgeZscore_Calculation()
        {
            var stat = new Stats();
            double p = stat.CalculateZScore(Indicator.LengthForAge, 73.00, 365, Sex.Male);
            double z = stat.CalculatePercentile(p);

            Assert.Equal(12.448574715727684, z);
        }

        [Fact]
        public void Stats_BMIForAgePercentile_Calculation()
        {
            var stat = new Stats();
            double p = stat.CalculateZScore(Indicator.BodyMassIndexForAge, 16.89, 365, Sex.Male);

            Assert.Equal(0.06723053329109611, p);
        }

        [Fact]
        public void Stats_BMIForAgeZscore_Calculation()
        {
            var stat = new Stats();
            double p = stat.CalculateZScore(Indicator.BodyMassIndexForAge, 16.89, 365, Sex.Male);
            double z = stat.CalculatePercentile(p);

            Assert.Equal(52.680091097505944, z);
        }

        [Fact]
        public void Stats_HeadCircumferenceForAgePercentile_Calculation()
        {
            var stat = new Stats();
            double p = stat.CalculateZScore(Indicator.HeadCircumferenceForAge, 45.00, 365, Sex.Male);

            Assert.Equal(-0.8279647089449516, p);
        }

        [Fact]
        public void Stats_HeadCircumferenceForAgeZscore_Calculation()
        {
            var stat = new Stats();
            double p = stat.CalculateZScore(Indicator.HeadCircumferenceForAge, 45.00, 365, Sex.Male);
            double z = stat.CalculatePercentile(p);

            Assert.Equal(20.384524323408026, z);
        }

        [Fact]
        public void Stats_ArmCircumferenceForAgePercentile_Calculation()
        {
            var stat = new Stats();
            double p = stat.CalculateZScore(Indicator.ArmCircumferenceForAge, 15.00, 365, Sex.Male);

            Assert.Equal(0.3122386679064194, p);
        }

        [Fact]
        public void Stats_ArmCircumferenceForAgeZscore_Calculation()
        {
            var stat = new Stats();
            double p = stat.CalculateZScore(Indicator.ArmCircumferenceForAge, 15.00, 365, Sex.Male);
            double z = stat.CalculatePercentile(p);

            Assert.Equal(62.25704263560083, z);
        }

        [Fact]
        public void Stats_TricepsSkinfoldForAgePercentile_Calculation()
        {
            var stat = new Stats();
            double p = stat.CalculateZScore(Indicator.TricepsSkinfoldForAge, 8.00, 365, Sex.Male);

            Assert.Equal(-0.06708173943452408, p);
        }

        [Fact]
        public void Stats_TricepsSkinfoldForAgeZscore_Calculation()
        {
            var stat = new Stats();
            double p = stat.CalculateZScore(Indicator.TricepsSkinfoldForAge, 8.00, 365, Sex.Male);
            double z = stat.CalculatePercentile(p);

            Assert.Equal(47.32583154805701, z);
        }

        [Fact]
        public void Stats_SubscapularSkinfoldForAgeTuple_Calculation()
        {
            var stat = new Stats();
            Tuple<double, double> GetScores = stat.getScores(Indicator.SubscapularSkinfoldForAge, 7.00, 365, Sex.Male);

            Assert.Equal(0.45, GetScores.Item1);
            Assert.Equal(67.4, GetScores.Item2);
        }

        [Fact]
        public void Stats_SubscapularSkinfoldForAgePercentile_Calculation()
        {
            var stat = new Stats();
            double p = stat.CalculateZScore(Indicator.SubscapularSkinfoldForAge, 7.00, 365, Sex.Male);

            Assert.Equal(0.45105402279903917, p);
        }

        [Fact]
        public void Stats_SubscapularSkinfoldForAgeZscore_Calculation()
        {
            var stat = new Stats();
            double p = stat.CalculateZScore(Indicator.SubscapularSkinfoldForAge, 7.00, 365, Sex.Male);
            double z = stat.CalculatePercentile(p);

            Assert.Equal(67.40246931726722, z);
        }

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
        public void Stats_AllIndicatorTuple_Calculation(Indicator indicator, double measurement, double ageInDays, Sex sex)
        {
            var stat = new Stats();
            Tuple<double, double> GetScores = stat.getScores(indicator, measurement, ageInDays, sex);
            
            Assert.InRange(GetScores.Item1, -4, 4);
            Assert.InRange(GetScores.Item2, 0, 100);
        }
    }
}
