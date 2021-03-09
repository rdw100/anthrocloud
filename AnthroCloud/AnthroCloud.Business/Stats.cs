using AnthStat.Statistics;
using System;
using System.Threading.Tasks;

namespace AnthroCloud.Business
{
    /// <summary>
    /// Calculates statistical summary of the anthropometric indicators.
    /// </summary>
    public class Stats : IGrowthStats
    {
        /// <summary>
        /// Calculates the percentile using z-score.
        /// </summary>
        /// <param name="zScore"></param>
        /// <returns>Returns the percentile using z-score.</returns>
        public async Task<double> CalculatePercentile(double zScore)
        {
            double p = await Task.FromResult(StatisticsHelper.CalculatePercentile(zScore));
            return p;
        }

        /// <summary>
        /// Calculates the z-score for a growth measure using a specified value.
        /// </summary>
        /// <param name="indicator">The growth indicator</param>
        /// <param name="measurement">The specified measured value</param>
        /// <param name="ageInDays">The age in total days</param>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns the z-score for a growth measure using a specified value.</returns>
        public async Task<double> CalculateZScore(Indicator indicator, double measurement, double ageInDays, Sex sex)
        {
            WHO2006 who2006 = new();
            double z = 0.0;

            if (await Task.FromResult(who2006.TryCalculateZScore(indicator, measurement, ageInDays, sex, z: ref z)))
            {
                return z;
            }

            return z;
        }

        /// <summary>
        /// Calculates both the Zscore and Percentile.
        /// </summary>
        /// <param name="indicator">The growth indicator</param>
        /// <param name="measurement">The specified measured value</param>
        /// <param name="ageInDays">The age in total days</param>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns the z-score and percentile for a growth measure using a specified value.</returns>
        public static async Task<Tuple<double, double>> GetScore(Indicator indicator, double measurement, double ageInDays, Sex sex)
        {
            WHO2006 who2006 = new();

            double z = 0.0;
            double p = 0.0;

            if (who2006.TryCalculateZScore(indicator, measurement, ageInDays, sex, z: ref z))
            {
                p = await Task.FromResult(StatisticsHelper.CalculatePercentile(z));
            }

            z = Math.Round(z, 2);
            p = Math.Round(p, 1);

            return Tuple.Create(z, p);
        }
    }
}