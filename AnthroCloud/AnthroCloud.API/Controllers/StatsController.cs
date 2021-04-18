using AnthroCloud.Business;
using AnthroCloud.Entities;
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
        /// <returns>Returns a tuple containing a zscore and percentile calcuation.</returns>
        /// <example>GET: api/Stats/WeightForAge/9.00/365/Male</example>
        [HttpGet("{indicator}/{measurement}/{ageInDays}/{sex}")]
        [Route("STATS/{indicator}/{measurement}/{ageInDays}/{sex}")]
        public async Task<Tuple<double, double>> GetScore(Indicator indicator, double measurement, double ageInDays, Sex sex)
        {
            Tuple<double, double> scores = await Stats.GetScore(indicator, measurement, ageInDays, sex);
            return scores;
        }

        /// <summary>
        /// Gets computed statistics from inputs.
        /// </summary>
        /// <param name="inputs">Calculator inputs necessary for computed statistics.</param>
        /// <returns>Returns computed statistics.</returns>
        [HttpPost]
        public async Task<Outputs> GetScores([FromBody] Inputs inputs)
        {
            Outputs outputs = new();

            Business.Age age = new(inputs.DateOfBirth, inputs.DateOfVisit);
            age = await age.Calculate(inputs.DateOfBirth, inputs.DateOfVisit);
            outputs.Age = age.ToReadableString();

            BMI bmi = new(inputs.Weight, inputs.LengthHeight);
            outputs.Bmi = await bmi.Calculate(inputs.Weight, inputs.LengthHeight);

            Tuple<double, double> wfaTuple = await Stats.GetScore(
                Indicator.WeightForAge, 
                inputs.Weight, 
                age.TotalDays, 
                (Sex)inputs.Sex
                );
            outputs.WfaZscore = wfaTuple.Item1;
            outputs.WfaPercentile = wfaTuple.Item2;

            Tuple<double, double> muacTuple = await Stats.GetScore(
                Indicator.ArmCircumferenceForAge, 
                inputs.MUAC, 
                age.TotalDays, 
                (Sex)inputs.Sex);
            outputs.MuacZscore = muacTuple.Item1;
            outputs.MuacPercentile = muacTuple.Item2;

            Tuple<double, double> bfaTuple = await Stats.GetScore(
                Indicator.BodyMassIndexForAge, 
                outputs.Bmi, 
                age.TotalDays, 
                (Sex)inputs.Sex);
            outputs.BfaZscore = bfaTuple.Item1;
            outputs.BfaPercentile = bfaTuple.Item2;

            Tuple<double, double> hcaTuple = await Stats.GetScore(
                Indicator.HeadCircumferenceForAge, 
                inputs.HeadCircumference, 
                age.TotalDays, 
                (Sex)inputs.Sex);
            outputs.HcaZscore = hcaTuple.Item1;
            outputs.HcaPercentile = hcaTuple.Item2;

            Tuple<double, double> hfaTuple = await Stats.GetScore(
                Indicator.HeightForAge, 
                inputs.LengthHeight, 
                age.TotalDays, 
                (Sex)inputs.Sex);
            outputs.HfaZscore = hfaTuple.Item1;
            outputs.HfaPercentile = hfaTuple.Item2;

            Tuple<double, double> lfaTuple = await Stats.GetScore(
                Indicator.LengthForAge, 
                inputs.LengthHeight, 
                age.TotalDays, 
                (Sex)inputs.Sex);
            outputs.LfaZscore = lfaTuple.Item1;
            outputs.LfaPercentile = lfaTuple.Item2;

            Tuple<double, double> sfaTuple = await Stats.GetScore(
                Indicator.SubscapularSkinfoldForAge, 
                inputs.SubscapularSkinFold, 
                age.TotalDays, 
                (Sex)inputs.Sex);
            outputs.SsfZscore = sfaTuple.Item1;
            outputs.SsfPercentile = sfaTuple.Item2;

            Tuple<double, double> tfaTuple = await Stats.GetScore(
                Indicator.TricepsSkinfoldForAge, 
                inputs.TricepsSkinFold, 
                age.TotalDays, 
                (Sex)inputs.Sex);
            outputs.TsfZscore = tfaTuple.Item1;
            outputs.TsfPercentile = tfaTuple.Item2;

            Tuple<double, double> wfhTuple = await Stats.GetScore(
                Indicator.WeightForHeight, 
                inputs.Weight, 
                inputs.LengthHeight, 
                (Sex)inputs.Sex);
            outputs.WfhZscore = wfhTuple.Item1;
            outputs.WfhPercentile = wfhTuple.Item2;

            Tuple<double, double> wflTuple = await Stats.GetScore(
                Indicator.WeightForLength, 
                inputs.Weight, 
                inputs.LengthHeight, 
                (Sex)inputs.Sex);
            outputs.WflZscore = wflTuple.Item1;
            outputs.WflPercentile = wflTuple.Item2;

            return outputs;
        }

        /// <summary>
        /// Gets computed statistics from length & height changes.
        /// </summary>
        /// <param name="inputs">Calculator inputs necessary for computed statistics.</param>
        /// <returns>Returns computed statistics.</returns>
        /// <remarks>Note that the difference between recumbent length and stature for this calculator is 
        /// 0.7 cm.</remarks>
        [HttpPost("MEASURED")]
        public async Task<Outputs> GetMeasuredScores([FromBody] Inputs inputs)
        {
            Outputs outputs = new();

            Tuple<double, double> wfaTuple = await Stats.GetScore(Indicator.WeightForAge, inputs.Weight, (double)inputs.Age.TotalDays, (Sex)inputs.Sex);
            outputs.WfaZscore = wfaTuple.Item1;
            outputs.WfaPercentile = wfaTuple.Item2;

            Tuple<double, double> wfhTuple = await Stats.GetScore(Indicator.WeightForHeight, inputs.Weight, inputs.LengthHeightAdjusted, (Sex)inputs.Sex);
            outputs.WfhZscore = wfhTuple.Item1;
            outputs.WfhPercentile = wfhTuple.Item2;

            Tuple<double, double> wflTuple = await Stats.GetScore(Indicator.WeightForLength, inputs.Weight, inputs.LengthHeightAdjusted, (Sex)inputs.Sex);
            outputs.WflZscore = wflTuple.Item1;
            outputs.WflPercentile = wflTuple.Item2;

            Tuple<double, double> bfaTuple = await Stats.GetScore(Indicator.BodyMassIndexForAge, inputs.BMI, (double)inputs.Age.TotalDays, (Sex)inputs.Sex);
            outputs.BfaZscore = bfaTuple.Item1;
            outputs.BfaPercentile = bfaTuple.Item2;

            Tuple<double, double> hfaTuple = await Stats.GetScore(Indicator.HeightForAge, inputs.LengthHeightAdjusted, (double)inputs.Age.TotalDays, (Sex)inputs.Sex);
            outputs.HfaZscore = hfaTuple.Item1;
            outputs.HfaPercentile = hfaTuple.Item2;

            Tuple<double, double> lfaTuple = await Stats.GetScore(Indicator.LengthForAge, inputs.LengthHeightAdjusted, (double)inputs.Age.TotalDays, (Sex)inputs.Sex);
            outputs.LfaZscore = lfaTuple.Item1;
            outputs.LfaPercentile = lfaTuple.Item2;

            return outputs;
        }

        /// <summary>
        /// Gets computed statistics from head circumference changes.
        /// </summary>
        /// <param name="inputs">Calculator inputs necessary for computed statistics.</param>
        /// <returns>Returns computed statistics.</returns>
        [HttpPost("HCA")]
        public async Task<Outputs> GetHcaScores([FromBody] Inputs inputs)
        {
            Outputs outputs = new();

            Tuple<double, double> hcaTuple = await Stats.GetScore(Indicator.HeadCircumferenceForAge, inputs.HeadCircumference, (double)inputs.Age.TotalDays, (Sex)inputs.Sex);
            outputs.HcaZscore = hcaTuple.Item1;
            outputs.HcaPercentile = hcaTuple.Item2;

            return outputs;
        }

        /// <summary>
        /// Gets computed statistics from MUAC changes.
        /// </summary>
        /// <param name="inputs">Calculator inputs necessary for computed statistics.</param>
        /// <returns>Returns computed statistics.</returns>
        [HttpPost("MUAC")]
        public async Task<Outputs> GetMuacScores([FromBody] Inputs inputs)
        {
            Outputs outputs = new();

            Tuple<double, double> muacTuple = await Stats.GetScore(Indicator.ArmCircumferenceForAge, inputs.MUAC, (double)inputs.Age.TotalDays, (Sex)inputs.Sex);
            outputs.MuacZscore = muacTuple.Item1;
            outputs.MuacPercentile = muacTuple.Item2;

            return outputs;
        }

        /// <summary>
        /// Gets computed statistics from Triceps skinfold changes.
        /// </summary>
        /// <param name="inputs">Calculator inputs necessary for computed statistics.</param>
        /// <returns>Returns computed statistics.</returns>
        [HttpPost("TSF")]
        public async Task<Outputs> GetTricepsScores([FromBody] Inputs inputs)
        {
            Outputs outputs = new();

            Tuple<double, double> tfaTuple = await Stats.GetScore(Indicator.TricepsSkinfoldForAge, inputs.TricepsSkinFold, (double)inputs.Age.TotalDays, (Sex)inputs.Sex);
            outputs.TsfZscore = tfaTuple.Item1;
            outputs.TsfPercentile = tfaTuple.Item2;

            return outputs;
        }

        /// <summary>
        /// Gets computed statistics from Subscapular skinfold changes.
        /// </summary>
        /// <param name="inputs">Calculator inputs necessary for computed statistics.</param>
        /// <returns>Returns computed statistics.</returns>
        [HttpPost("SSF")]
        public async Task<Outputs> GetSubscapularScores([FromBody] Inputs inputs)
        {
            Outputs outputs = new();

            Tuple<double, double> sfaTuple = await Stats.GetScore(Indicator.SubscapularSkinfoldForAge, inputs.SubscapularSkinFold, (double)inputs.Age.TotalDays, (Sex)inputs.Sex);
            outputs.SsfZscore = sfaTuple.Item1;
            outputs.SsfPercentile = sfaTuple.Item2;

            return outputs;
        }
    }
}