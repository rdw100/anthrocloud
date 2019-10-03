using AnthStat.Statistics;
using System;
using System.Collections.Generic;
using System.Text;

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
        public double CalculatePercentile(double zScore)
        {
            double p = StatisticsHelper.CalculatePercentile(zScore);
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
        public double CalculateZScore(Indicator indicator, double measurement, double ageInDays, Sex sex)
        {
            WHO2006 who2006 = new WHO2006();
            double z = 0.0;

            if (who2006.TryCalculateZScore(indicator, measurement, ageInDays, AnthStat.Statistics.Sex.Male, z: ref z))
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
        public Tuple<double, double> getScores(Indicator indicator, double measurement, double ageInDays, Sex sex)
        {
            WHO2006 who2006 = new WHO2006();

            double z = 0.0;
            double p = 0.0;

            if (who2006.TryCalculateZScore(indicator, measurement, ageInDays, AnthStat.Statistics.Sex.Male, z: ref z))
            {
                p = StatisticsHelper.CalculatePercentile(z);
            }

            z = Math.Round(z, 2);
            p = Math.Round(p, 2);

            return Tuple.Create(z, p);
        }
    }
}