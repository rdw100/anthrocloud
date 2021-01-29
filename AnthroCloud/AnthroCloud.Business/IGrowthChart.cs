using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AnthroCloud.Entities;

namespace AnthroCloud.Business
{
    /// <summary>
    /// Defines the standard operations to be performed by the chart object.
    /// </summary>
    public interface IGrowthChart
    {
        /// <summary>
        /// A list of age-based indicator table data for measurement of Weight-for-length/height used to create a WHO chart.
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of age-based indicator table data for measurement of Weight-for-length/height used to create a WHO chart.</returns>
        public Task<List<WeightForAge>> ListWeightForAge(Sexes sex, byte newX, decimal newY);

        /// <summary>
        /// A list of height-based indicator table data for measurement of Weight-for-length/height used to create a WHO chart (Birth to 2 years).
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of height-based indicator table data for measurement of Weight-for-length/height used to create a WHO chart (Birth to 2 years).</returns>
        public Task<List<WeightForLength>> ListWeightForLength(Sexes sex, decimal newX, decimal newY);

        /// <summary>
        /// A list of height-based indicator table data for measurement of Weight-for-length/height used to create a WHO chart (2 to 5 years).
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of height-based indicator table data for measurement of Weight-for-length/height used to create a WHO chart (2 to 5 years).</returns>
        public Task<List<WeightForHeight>> ListWeightForHeight(Sexes sex, decimal newX, decimal newY);

        /// <summary>
        /// A list of age-based indicator table data for measurement of body mass index by age used to create a WHO chart.
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of age-based indicator table data for measurement used to calculate body mass index by age.</returns>
        public Task<List<BmiforAge>> ListBmiforAgeAsync(Sexes sex, byte newX, decimal newY);

        /// <summary>
        /// A list of age-based indicator table data for measurement of Head circumference-for-age used to create a WHO chart.
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of age-based indicator table data for measurement of Head circumference-for-age used to create a WHO chart. </returns>
        public Task<List<HcForAge>> ListHcforAge(Sexes sex, byte newX, decimal newY);

        /// <summary>
        /// A list of age-based indicator table data for measurement of Length/height-for-age used to create a WHO chart.
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of age-based indicator table data for measurement of Length/height-for-age used to create a WHO chart.</returns>
        public Task<List<LengthHeightForAge>> ListLengthHeightForAge(Sexes sex, byte newX, decimal newY);

        /// <summary>
        /// A list of age-based indicator table data for measurement of Arm circumference-for-age used to create a WHO chart.
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of age-based indicator table data for measurement of Arm circumference-for-age used to create a WHO chart.</returns>
        public Task<List<MuacforAge>> ListMuacforAge(Sexes sex, byte newX, decimal newY);

        /// <summary>
        /// A list of age-based indicator table data for measurement of Subscapular skinfold-for-age used to create a WHO chart.
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of age-based indicator table data for measurement of Subscapular skinfold-for-age used to create a WHO chart.</returns>
        public Task<List<SsfforAge>> ListSsfforAge(Sexes sex, byte newX, decimal newY);
        
        /// <summary>
        /// A list of age-based indicator table data for measurement of Triceps skinfold-for-age used to create a WHO chart.
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of age-based indicator table data for measurement of Triceps skinfold-for-age used to create a WHO chart.</returns>
        public Task<List<TsfforAge>> ListTsfforAge(Sexes sex, byte newX, decimal newY);
    }
}
