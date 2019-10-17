using System;
using System.Collections.Generic;
using AnthroCloud.Data;
using AnthroCloud.Entities;
using AnthStat.Statistics;

namespace AnthroCloud.Business
{
    /// <summary>
    /// Provides growth curves in plotted data to draw lines on a chart to monitor growth for infants and children.
    /// </summary>
    public class Chart : IGrowthChart
    {

        /// <summary>
        /// A list of age-based indicator table data for measurement of body mass index by age used to create a WHO chart.
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of age-based indicator table data for measurement used to calculate body mass index by age.</returns>
        public List<BmiforAge> ListBmiforAge(Sexes sex)
        {
            var chartDAC = new ChartDAC();
            List<BmiforAge> wfaCurves = chartDAC.ListBmiforAge(sex);
            return wfaCurves;
        }

        /// <summary>
        /// A list of age-based indicator table data for measurement of Head circumference-for-age used to create a WHO chart.
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of age-based indicator table data for measurement of Head circumference-for-age used to create a WHO chart. </returns>
        public List<HcForAge> ListHcforAge(Sexes sex)
        {
            var chartDAC = new ChartDAC();
            List<HcForAge> hcfaCurves = chartDAC.ListHcforAge(sex);
            return hcfaCurves;
        }

        /// <summary>
        /// A list of age-based indicator table data for measurement of Length/height-for-age used to create a WHO chart.
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of age-based indicator table data for measurement of Length/height-for-age used to create a WHO chart.</returns>
        public List<LengthHeightForAge> ListLengthHeightForAge(Sexes sex)
        {
            var chartDAC = new ChartDAC();
            List<LengthHeightForAge> hcfaCurves = chartDAC.ListLengthHeightForAge(sex);
            return hcfaCurves;
        }

        /// <summary>
        /// A list of age-based indicator table data for measurement of Arm circumference-for-age used to create a WHO chart.
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of age-based indicator table data for measurement of Arm circumference-for-age used to create a WHO chart.</returns>
        public List<MuacforAge> ListMuacforAge(Sexes sex)
        {
            var chartDAC = new ChartDAC();
            List<MuacforAge> hcfaCurves = chartDAC.ListMuacforAge(sex);
            return hcfaCurves;
        }

        /// <summary>
        /// A list of age-based indicator table data for measurement of Subscapular skinfold-for-age used to create a WHO chart.
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of age-based indicator table data for measurement of Subscapular skinfold-for-age used to create a WHO chart.</returns>
        public List<SsfforAge> ListSsfforAge(Sexes sex)
        {
            var chartDAC = new ChartDAC();
            List<SsfforAge> hcfaCurves = chartDAC.ListSsfforAge(sex);
            return hcfaCurves;
        }

        /// <summary>
        /// A list of age-based indicator table data for measurement of Triceps skinfold-for-age used to create a WHO chart.
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of age-based indicator table data for measurement of Triceps skinfold-for-age used to create a WHO chart.</returns>
        public List<TsfforAge> ListTsfforAge(Sexes sex)
        {
            var chartDAC = new ChartDAC();
            List<TsfforAge> hcfaCurves = chartDAC.ListTsfforAge(sex);
            return hcfaCurves;
        }

        /// <summary>
        /// A list of age-based indicator table data for measurement of Weight-for-length/height used to create a WHO chart.
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of age-based indicator table data for measurement of Weight-for-length/height used to create a WHO chart.</returns>
        public List<WeightForAge> ListWeightForAge(Sexes sex)
        {
            var chartDAC = new ChartDAC();
            List<WeightForAge> hcfaCurves = chartDAC.ListWeightForAge(sex);
            return hcfaCurves;
        }

        /// <summary>
        /// A list of height-based indicator table data for measurement of Weight-for-length/height used to create a WHO chart (2 to 5 years).
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of height-based indicator table data for measurement of Weight-for-length/height used to create a WHO chart (2 to 5 years).</returns>
        public List<WeightForHeight> ListWeightForHeight(Sexes sex)
        {
            var chartDAC = new ChartDAC();
            List<WeightForHeight> hcfaCurves = chartDAC.ListWeightForHeight(sex);
            return hcfaCurves;
        }

        /// <summary>
        /// A list of height-based indicator table data for measurement of Weight-for-length/height used to create a WHO chart (Birth to 2 years).
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of height-based indicator table data for measurement of Weight-for-length/height used to create a WHO chart (Birth to 2 years).</returns>
        public List<WeightForLength> ListWeightForLength(Sexes sex)
        {
            var chartDAC = new ChartDAC();
            List<WeightForLength> hcfaCurves = chartDAC.ListWeightForLength(sex);
            return hcfaCurves;
        }
    }
}
