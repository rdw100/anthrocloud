using AnthStat.Statistics;
using System.Threading.Tasks;

namespace AnthroCloud.Business
{
    /// <summary>
    /// Defines the standard operations to be performed by the statistics object.
    /// </summary>
    public interface IGrowthStats
    {
        /// <summary>
        /// Calculates the percentile using z-score.
        /// </summary>
        /// <param name="zScore"></param>
        /// <returns>Returns the percentile using z-score.</returns>
        public Task<double> CalculatePercentile(double zScore);

        /// <summary>
        /// Calculates the z-score for a growth measure using a specified value.
        /// </summary>
        /// <param name="indicator">The growth indicator</param>
        /// <param name="measurement">The specified measured value</param>
        /// <param name="ageInDays">The age in total days</param>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns the z-score for a growth measure using a specified value.</returns>
        public Task<double> CalculateZScore(Indicator indicator, double measurement, double age, Sex sex);
    }
}
