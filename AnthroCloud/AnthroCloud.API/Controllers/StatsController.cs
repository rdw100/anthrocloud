using AnthroCloud.Business;
using AnthStat.Statistics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AnthroCloud.API.Controllers
{
    /// <summary>
    /// Calculates zscore and percentile for given measurements.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        /// <summary>
        /// Gets tuple of zscore and percentile calculation for specified measurement indicator given measurement, age, and sex.
        /// </summary>
        /// <param name="indicator">The growth indicator</param>
        /// <param name="measurement">The specified measured value</param>
        /// <param name="ageInDays">The age in total days</param>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a tuple containing a zscore and percentile cacluation.</returns>
        /// <example>GET: api/Stats/WeightForAge/9.00/365/Male</example>
        [HttpGet("{indicator}/{measurement}/{ageInDays}/{sex}")]
        [Route("STATS/{indicator}/{measurement}/{ageInDays}/{sex}")]
        public async Task<Tuple<double, double>> GetScore(Indicator indicator, double measurement, double ageInDays, Sex sex)
        {
            Stats stats = new Stats();
            Tuple<double, double> scores = await stats.GetScore(indicator, measurement, ageInDays, sex);
            return scores;
        }
    }
}
