using System;
using System.Collections.Generic;
using System.Text;
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
        public List<WeightForAge> ListWeightForAge(Sexes sex, byte newX, decimal newY);

        /// <summary>
        /// A list of height-based indicator table data for measurement of Weight-for-length/height used to create a WHO chart (Birth to 2 years).
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of height-based indicator table data for measurement of Weight-for-length/height used to create a WHO chart (Birth to 2 years).</returns>
        public List<WeightForLength> ListWeightForLength(Sexes sex, decimal newX, decimal newY);

        /// <summary>
        /// A list of height-based indicator table data for measurement of Weight-for-length/height used to create a WHO chart (2 to 5 years).
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of height-based indicator table data for measurement of Weight-for-length/height used to create a WHO chart (2 to 5 years).</returns>
        public List<WeightForHeight> ListWeightForHeight(Sexes sex, decimal newX, decimal newY);

        /// <summary>
        /// A list of age-based indicator table data for measurement of body mass index by age used to create a WHO chart.
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of age-based indicator table data for measurement used to calculate body mass index by age.</returns>
        public List<BmiforAge> ListBmiforAge(Sexes sex, byte newX, decimal newY);

        /// <summary>
        /// A list of age-based indicator table data for measurement of Head circumference-for-age used to create a WHO chart.
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of age-based indicator table data for measurement of Head circumference-for-age used to create a WHO chart. </returns>
        public List<HcForAge> ListHcforAge(Sexes sex, byte newX, decimal newY);

        /// <summary>
        /// A list of age-based indicator table data for measurement of Length/height-for-age used to create a WHO chart.
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of age-based indicator table data for measurement of Length/height-for-age used to create a WHO chart.</returns>
        public List<LengthHeightForAge> ListLengthHeightForAge(Sexes sex, byte newX, decimal newY);

        /// <summary>
        /// A list of age-based indicator table data for measurement of Arm circumference-for-age used to create a WHO chart.
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of age-based indicator table data for measurement of Arm circumference-for-age used to create a WHO chart.</returns>
        public List<MuacforAge> ListMuacforAge(Sexes sex, byte newX, decimal newY);

        /// <summary>
        /// A list of age-based indicator table data for measurement of Subscapular skinfold-for-age used to create a WHO chart.
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of age-based indicator table data for measurement of Subscapular skinfold-for-age used to create a WHO chart.</returns>
        public List<SsfforAge> ListSsfforAge(Sexes sex, byte newX, decimal newY);
        
        /// <summary>
        /// A list of age-based indicator table data for measurement of Triceps skinfold-for-age used to create a WHO chart.
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of age-based indicator table data for measurement of Triceps skinfold-for-age used to create a WHO chart.</returns>
        public List<TsfforAge> ListTsfforAge(Sexes sex, byte newX, decimal newY);
    }
}
