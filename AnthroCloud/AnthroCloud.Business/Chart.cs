using System;
using System.Collections.Generic;
using System.Linq;
using AnthroCloud.Data;
using AnthroCloud.Entities;
using AnthStat.Statistics;
using AnthroCloud.Framework.Drawing;
using Microsoft.EntityFrameworkCore;

namespace AnthroCloud.Business
{
    /// <summary>
    /// Provides growth curves in plotted data to draw lines on a chart to monitor growth for infants and children.
    /// </summary>
    public class Chart : IGrowthChart
    {
        private AnthroCloudContextMySql _context;

        public Chart() { }

        /// <summary>
        /// Constructs controller with database context.
        /// </summary>
        /// <param name="context">The database context</param>
        public Chart(AnthroCloudContextMySql context)
        {
            _context = context;
        }

        /// <summary>
        /// A list of age-based indicator table data for measurement of body mass index by age used to create a WHO chart.  
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of age-based indicator table data for measurement used to calculate body mass index by age.</returns>
        public List<BmiforAge> ListBmiforAge(Sexes sex)
        {
            var chartDAC = new ChartDAC(_context);
            List<BmiforAge> bmiCurves = chartDAC.ListBmiforAge(sex);
            return bmiCurves;
        }

        /// <summary>
        /// A list of age-based indicator table data for measurement of body mass index by age used to create a WHO chart.  Data point (x,y) is insert if new; otherwise updated.
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of age-based indicator table data for measurement used to calculate body mass index by age.</returns>
        public List<BmiforAge> ListBmiforAge(Sexes sex, byte newX, decimal newY)
        {
            var chartDAC = new ChartDAC(_context);
            List<BmiforAge> bmiCurves = chartDAC.ListBmiforAge(sex);

            // Update adjacent length-for-age and height-for-age with a vertical 
            // line at 2 years of age to mark the change from length to height; 
            // from 0 - 60 completed months
            var markElement = bmiCurves.FindIndex(0, x => x.Month == 24);
            bmiCurves[markElement].Mark = "Length | Height";
            bmiCurves[markElement].Marktext = "Length | Height";

            decimal existingX = (from n1 in bmiCurves
                                 where n1.Month == newX
                                 select n1.Month).FirstOrDefault();

            if (newX != existingX)
            {
                // Get smaller value closest to x.  This is X0.
                var smallerNearestValue = (from n1 in bmiCurves
                                           where n1.Month < newX
                                           orderby n1.Month descending
                                           select n1.Month).First();

                // Get smaller value closest to x.  This is X1.
                var largerNearestValue = (from n1 in bmiCurves
                                          where n1.Month > newX
                                          orderby n1.Month ascending
                                          select n1.Month).First();

                // Get Index explicitly
                var smallNearElement = bmiCurves.FindIndex(0, x => x.Month == smallerNearestValue);
                var largeNearElement = bmiCurves.FindIndex(0, x => x.Month == largerNearestValue);

                // Interpolate Data Point Pair for Y
                LinearInterpolation yDataPoint = new LinearInterpolation();

                yDataPoint = new LinearInterpolation(newX, bmiCurves[smallNearElement].Month, bmiCurves[smallNearElement].Month, bmiCurves[smallNearElement].P3, bmiCurves[largeNearElement].P3);
                decimal newP3 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, bmiCurves[smallNearElement].Month, bmiCurves[smallNearElement].Month, bmiCurves[smallNearElement].P15, bmiCurves[largeNearElement].P15);
                decimal newP15 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, bmiCurves[smallNearElement].Month, bmiCurves[smallNearElement].Month, bmiCurves[smallNearElement].P50, bmiCurves[largeNearElement].P50);
                decimal newP50 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, bmiCurves[smallNearElement].Month, bmiCurves[smallNearElement].Month, bmiCurves[smallNearElement].P85, bmiCurves[largeNearElement].P85);
                decimal newP85 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, bmiCurves[smallNearElement].Month, bmiCurves[smallNearElement].Month, bmiCurves[smallNearElement].P97, bmiCurves[largeNearElement].P97);
                decimal newP97 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, bmiCurves[smallNearElement].Month, bmiCurves[smallNearElement].Month, bmiCurves[smallNearElement].Sd3neg, bmiCurves[largeNearElement].Sd3neg);
                decimal newSd3neg = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, bmiCurves[smallNearElement].Month, bmiCurves[smallNearElement].Month, bmiCurves[smallNearElement].Sd2neg, bmiCurves[largeNearElement].Sd2neg);
                decimal newSd2neg = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, bmiCurves[smallNearElement].Month, bmiCurves[smallNearElement].Month, bmiCurves[smallNearElement].Sd1neg, bmiCurves[largeNearElement].Sd1neg);
                decimal newSd1neg = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, bmiCurves[smallNearElement].Month, bmiCurves[smallNearElement].Month, bmiCurves[smallNearElement].Sd0, bmiCurves[largeNearElement].Sd0);
                decimal newSd0 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, bmiCurves[smallNearElement].Month, bmiCurves[smallNearElement].Month, bmiCurves[smallNearElement].Sd1, bmiCurves[largeNearElement].Sd1);
                decimal newSd1 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, bmiCurves[smallNearElement].Month, bmiCurves[smallNearElement].Month, bmiCurves[smallNearElement].Sd2, bmiCurves[largeNearElement].Sd2);
                decimal newSd2 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, bmiCurves[smallNearElement].Month, bmiCurves[smallNearElement].Month, bmiCurves[smallNearElement].Sd3, bmiCurves[largeNearElement].Sd3);
                decimal newSd3 = yDataPoint.CalculateY();

                // Add Score Record with Interpolated Data for Chart
                bmiCurves.Insert(smallNearElement + 1, new BmiforAge { Sex = (byte)sex, Month = newX, Score = newY, P3 = newP3, P15 = newP15, P50 = newP50, P85 = newP85, P97 = newP97, Sd3neg = newSd3neg, Sd2neg = newSd2neg, Sd1neg = newSd1neg, Sd0 = newSd0, Sd1 = newSd1, Sd2 = newSd2, Sd3 = newSd3 });

            }
            else if (newX == existingX)
            {
                var existingElement = bmiCurves.FindIndex(0, x => x.Month == existingX);
                bmiCurves[existingElement].Score = newY;
            }

            return bmiCurves;
        }

        /// <summary>
        /// A list of age-based indicator table data for measurement of Head circumference-for-age used to create a WHO chart.
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <ret
        public List<HcForAge> ListHcforAge(Sexes sex)
        {
            var chartDAC = new ChartDAC(_context);
            List<HcForAge> hcfaCurves = chartDAC.ListHcforAge(sex);
            return hcfaCurves;
        }

        /// <summary>
        /// A list of age-based indicator table data for measurement of Head circumference-for-age used to create a WHO chart.  Data point (x,y) is insert if new; otherwise updated.
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of age-based indicator table data for measurement of Head circumference-for-age used to create a WHO chart. </returns>
        public List<HcForAge> ListHcforAge(Sexes sex, byte newX, decimal newY)
        {
            var chartDAC = new ChartDAC(_context);
            List<HcForAge> hcfaCurves = chartDAC.ListHcforAge(sex);

            decimal existingX = (from n1 in hcfaCurves
                                 where n1.Month == newX
                                 select n1.Month).FirstOrDefault();

            if (newX != existingX)
            {            
                // Get smaller value closest to x.  This is X0.
                var smallerNearestValue = (from n1 in hcfaCurves
                                           where n1.Month < newX
                                           orderby n1.Month descending
                                           select n1.Month).First();

                // Get smaller value closest to x.  This is X1.
                var largerNearestValue = (from n1 in hcfaCurves
                                          where n1.Month > newX
                                          orderby n1.Month ascending
                                          select n1.Month).First();

                // Get Index explicitly
                var smallNearElement = hcfaCurves.FindIndex(0, x => x.Month == smallerNearestValue);
                var largeNearElement = hcfaCurves.FindIndex(0, x => x.Month == largerNearestValue);

                // Interpolate Data Point Pair for Y
                LinearInterpolation yDataPoint = new LinearInterpolation();

                yDataPoint = new LinearInterpolation(newX, hcfaCurves[smallNearElement].Month, hcfaCurves[smallNearElement].Month, hcfaCurves[smallNearElement].P3, hcfaCurves[largeNearElement].P3);
                decimal newP3 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, hcfaCurves[smallNearElement].Month, hcfaCurves[smallNearElement].Month, hcfaCurves[smallNearElement].P15, hcfaCurves[largeNearElement].P15);
                decimal newP15 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, hcfaCurves[smallNearElement].Month, hcfaCurves[smallNearElement].Month, hcfaCurves[smallNearElement].P50, hcfaCurves[largeNearElement].P50);
                decimal newP50 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, hcfaCurves[smallNearElement].Month, hcfaCurves[smallNearElement].Month, hcfaCurves[smallNearElement].P85, hcfaCurves[largeNearElement].P85);
                decimal newP85 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, hcfaCurves[smallNearElement].Month, hcfaCurves[smallNearElement].Month, hcfaCurves[smallNearElement].P97, hcfaCurves[largeNearElement].P97);
                decimal newP97 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, hcfaCurves[smallNearElement].Month, hcfaCurves[smallNearElement].Month, hcfaCurves[smallNearElement].Sd3neg, hcfaCurves[largeNearElement].Sd3neg);
                decimal newSd3neg = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, hcfaCurves[smallNearElement].Month, hcfaCurves[smallNearElement].Month, hcfaCurves[smallNearElement].Sd2neg, hcfaCurves[largeNearElement].Sd2neg);
                decimal newSd2neg = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, hcfaCurves[smallNearElement].Month, hcfaCurves[smallNearElement].Month, hcfaCurves[smallNearElement].Sd1neg, hcfaCurves[largeNearElement].Sd1neg);
                decimal newSd1neg = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, hcfaCurves[smallNearElement].Month, hcfaCurves[smallNearElement].Month, hcfaCurves[smallNearElement].Sd0, hcfaCurves[largeNearElement].Sd0);
                decimal newSd0 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, hcfaCurves[smallNearElement].Month, hcfaCurves[smallNearElement].Month, hcfaCurves[smallNearElement].Sd1, hcfaCurves[largeNearElement].Sd1);
                decimal newSd1 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, hcfaCurves[smallNearElement].Month, hcfaCurves[smallNearElement].Month, hcfaCurves[smallNearElement].Sd2, hcfaCurves[largeNearElement].Sd2);
                decimal newSd2 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, hcfaCurves[smallNearElement].Month, hcfaCurves[smallNearElement].Month, hcfaCurves[smallNearElement].Sd3, hcfaCurves[largeNearElement].Sd3);
                decimal newSd3 = yDataPoint.CalculateY();

                // Add Score Record with Interpolated Data for Chart
                hcfaCurves.Insert(smallNearElement + 1, new HcForAge { Sex = (byte)sex, Month = newX, Score = newY, P3 = newP3, P15 = newP15, P50 = newP50, P85 = newP85, P97 = newP97, Sd3neg = newSd3neg, Sd2neg = newSd2neg, Sd1neg = newSd1neg, Sd0 = newSd0, Sd1 = newSd1, Sd2 = newSd2, Sd3 = newSd3 });

            }
            else if (newX == existingX)
            {
                var existingElement = hcfaCurves.FindIndex(0, x => x.Month == existingX);
                hcfaCurves[existingElement].Score = newY;
            }

            return hcfaCurves;
        }

        /// <summary>
        /// A list of age-based indicator table data for measurement of Length/height-for-age used to create a WHO chart.
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of age-based indicator table data for measurement of Length/height-for-age used to create a WHO chart.</returns>
        public List<LengthHeightForAge> ListLengthHeightForAge(Sexes sex)
        {
            var chartDAC = new ChartDAC(_context);
            List<LengthHeightForAge> lhfaCurves = chartDAC.ListLengthHeightForAge(sex);
            return lhfaCurves;
        }

        /// <summary>
        /// A list of age-based indicator table data for measurement of Length/height-for-age used to create a WHO chart.  Data point (x,y) is insert if new; otherwise updated.
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of age-based indicator table data for measurement of Length/height-for-age used to create a WHO chart.</returns>
        public List<LengthHeightForAge> ListLengthHeightForAge(Sexes sex, byte newX, decimal newY)
        {
            var chartDAC = new ChartDAC(_context);
            List<LengthHeightForAge> lhfaCurves = chartDAC.ListLengthHeightForAge(sex);

            // Update adjacent length-for-age and height-for-age with a vertical 
            // line at 2 years of age to mark the change from length to height; 
            // from 0 - 60 completed months
            var markElement = lhfaCurves.FindIndex(0, x => x.Month == 24);
            lhfaCurves[markElement].Mark = "Length | Height";
            lhfaCurves[markElement].Marktext = "Length | Height";

            decimal existingX = (from n1 in lhfaCurves
                                 where n1.Month == newX
                                 select n1.Month).FirstOrDefault();

            if (newX != existingX)
            {
                // Get smaller value closest to x.  This is X0.
                var smallerNearestValue = (from n1 in lhfaCurves
                                           where n1.Month < newX
                                           orderby n1.Month descending
                                           select n1.Month).First();

                // Get smaller value closest to x.  This is X1.
                var largerNearestValue = (from n1 in lhfaCurves
                                          where n1.Month > newX
                                          orderby n1.Month ascending
                                          select n1.Month).First();

                // Get Index explicitly
                var smallNearElement = lhfaCurves.FindIndex(0, x => x.Month == smallerNearestValue);
                var largeNearElement = lhfaCurves.FindIndex(0, x => x.Month == largerNearestValue);

                // Interpolate Data Point Pair for Y
                LinearInterpolation yDataPoint = new LinearInterpolation();

                yDataPoint = new LinearInterpolation(newX, lhfaCurves[smallNearElement].Month, lhfaCurves[smallNearElement].Month, lhfaCurves[smallNearElement].P3, lhfaCurves[largeNearElement].P3);
                decimal newP3 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, lhfaCurves[smallNearElement].Month, lhfaCurves[smallNearElement].Month, lhfaCurves[smallNearElement].P15, lhfaCurves[largeNearElement].P15);
                decimal newP15 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, lhfaCurves[smallNearElement].Month, lhfaCurves[smallNearElement].Month, lhfaCurves[smallNearElement].P50, lhfaCurves[largeNearElement].P50);
                decimal newP50 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, lhfaCurves[smallNearElement].Month, lhfaCurves[smallNearElement].Month, lhfaCurves[smallNearElement].P85, lhfaCurves[largeNearElement].P85);
                decimal newP85 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, lhfaCurves[smallNearElement].Month, lhfaCurves[smallNearElement].Month, lhfaCurves[smallNearElement].P97, lhfaCurves[largeNearElement].P97);
                decimal newP97 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, lhfaCurves[smallNearElement].Month, lhfaCurves[smallNearElement].Month, lhfaCurves[smallNearElement].Sd3neg, lhfaCurves[largeNearElement].Sd3neg);
                decimal newSd3neg = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, lhfaCurves[smallNearElement].Month, lhfaCurves[smallNearElement].Month, lhfaCurves[smallNearElement].Sd2neg, lhfaCurves[largeNearElement].Sd2neg);
                decimal newSd2neg = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, lhfaCurves[smallNearElement].Month, lhfaCurves[smallNearElement].Month, lhfaCurves[smallNearElement].Sd0, lhfaCurves[largeNearElement].Sd0);
                decimal newSd0 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, lhfaCurves[smallNearElement].Month, lhfaCurves[smallNearElement].Month, lhfaCurves[smallNearElement].Sd2, lhfaCurves[largeNearElement].Sd2);
                decimal newSd2 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, lhfaCurves[smallNearElement].Month, lhfaCurves[smallNearElement].Month, lhfaCurves[smallNearElement].Sd3, lhfaCurves[largeNearElement].Sd3);
                decimal newSd3 = yDataPoint.CalculateY();

                // Add Score Record with Interpolated Data for Chart
                lhfaCurves.Insert(smallNearElement + 1, new LengthHeightForAge { Sex = (byte)sex, Month = newX, Score = newY, Mark = null, Marktext = null, P3 = newP3, P15 = newP15, P50 = newP50, P85 = newP85, P97 = newP97, Sd3neg = newSd3neg, Sd2neg = newSd2neg, Sd0 = newSd0, Sd2 = newSd2, Sd3 = newSd3 });
            }
            else if (newX == existingX)
            {
                var existingElement = lhfaCurves.FindIndex(0, x => x.Month == existingX);
                lhfaCurves[existingElement].Score = newY;
            }

            return lhfaCurves;
        }

        /// <summary>
        /// A list of age-based indicator table data for measurement of Arm circumference-for-age used to create a WHO chart.
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of age-based indicator table data for measurement of Arm circumference-for-age used to create a WHO chart.</returns>
        public List<MuacforAge> ListMuacforAge(Sexes sex)
        {
            var chartDAC = new ChartDAC(_context);
            List<MuacforAge> muacCurves = chartDAC.ListMuacforAge(sex);
            return muacCurves;
        }

        /// <summary>
        /// A list of age-based indicator table data for measurement of Arm circumference-for-age used to create a WHO chart.  Data point (x,y) is insert if new; otherwise updated.
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of age-based indicator table data for measurement of Arm circumference-for-age used to create a WHO chart.</returns>
        public List<MuacforAge> ListMuacforAge(Sexes sex, byte newX, decimal newY)
        {
            var chartDAC = new ChartDAC(_context);
            List<MuacforAge> muacCurves = chartDAC.ListMuacforAge(sex);

            decimal existingX = (from n1 in muacCurves
                                 where n1.Month == newX
                                 select n1.Month).FirstOrDefault();

            if (newX != existingX)
            {
                // Get smaller value closest to x.  This is X0.
                var smallerNearestValue = (from n1 in muacCurves
                                           where n1.Month < newX
                                           orderby n1.Month descending
                                           select n1.Month).First();

                // Get smaller value closest to x.  This is X1.
                var largerNearestValue = (from n1 in muacCurves
                                          where n1.Month > newX
                                          orderby n1.Month ascending
                                          select n1.Month).First();

                // Get Index explicitly
                var smallNearElement = muacCurves.FindIndex(0, x => x.Month == smallerNearestValue);
                var largeNearElement = muacCurves.FindIndex(0, x => x.Month == largerNearestValue);

                // Interpolate Data Point Pair for Y
                LinearInterpolation yDataPoint = new LinearInterpolation();

                yDataPoint = new LinearInterpolation(newX, muacCurves[smallNearElement].Month, muacCurves[smallNearElement].Month, muacCurves[smallNearElement].P3, muacCurves[largeNearElement].P3);
                decimal newP3 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, muacCurves[smallNearElement].Month, muacCurves[smallNearElement].Month, muacCurves[smallNearElement].P15, muacCurves[largeNearElement].P15);
                decimal newP15 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, muacCurves[smallNearElement].Month, muacCurves[smallNearElement].Month, muacCurves[smallNearElement].P50, muacCurves[largeNearElement].P50);
                decimal newP50 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, muacCurves[smallNearElement].Month, muacCurves[smallNearElement].Month, muacCurves[smallNearElement].P85, muacCurves[largeNearElement].P85);
                decimal newP85 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, muacCurves[smallNearElement].Month, muacCurves[smallNearElement].Month, muacCurves[smallNearElement].P97, muacCurves[largeNearElement].P97);
                decimal newP97 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, muacCurves[smallNearElement].Month, muacCurves[smallNearElement].Month, muacCurves[smallNearElement].Sd3neg, muacCurves[largeNearElement].Sd3neg);
                decimal newSd3neg = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, muacCurves[smallNearElement].Month, muacCurves[smallNearElement].Month, muacCurves[smallNearElement].Sd2neg, muacCurves[largeNearElement].Sd2neg);
                decimal newSd2neg = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, muacCurves[smallNearElement].Month, muacCurves[smallNearElement].Month, muacCurves[smallNearElement].Sd1neg, muacCurves[largeNearElement].Sd1neg);
                decimal newSd1neg = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, muacCurves[smallNearElement].Month, muacCurves[smallNearElement].Month, muacCurves[smallNearElement].Sd0, muacCurves[largeNearElement].Sd0);
                decimal newSd0 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, muacCurves[smallNearElement].Month, muacCurves[smallNearElement].Month, muacCurves[smallNearElement].Sd1, muacCurves[largeNearElement].Sd1);
                decimal newSd1 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, muacCurves[smallNearElement].Month, muacCurves[smallNearElement].Month, muacCurves[smallNearElement].Sd2, muacCurves[largeNearElement].Sd2);
                decimal newSd2 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, muacCurves[smallNearElement].Month, muacCurves[smallNearElement].Month, muacCurves[smallNearElement].Sd3, muacCurves[largeNearElement].Sd3);
                decimal newSd3 = yDataPoint.CalculateY();

                // Add Score Record with Interpolated Data for Chart
                muacCurves.Insert(smallNearElement + 1, new MuacforAge { Sex = (byte)sex, Month = newX, Score = newY, P3 = newP3, P15 = newP15, P50 = newP50, P85 = newP85, P97 = newP97, Sd3neg = newSd3neg, Sd2neg = newSd2neg, Sd1neg = newSd1neg, Sd0 = newSd0, Sd1 = newSd1, Sd2 = newSd2, Sd3 = newSd3 });
            }
            else if (newX == existingX)
            {
                var existingElement = muacCurves.FindIndex(0, x => x.Month == existingX);
                muacCurves[existingElement].Score = newY;
            }
            return muacCurves;
        }


        /// <summary>
        /// A list of age-based indicator table data for measurement of Subscapular skinfold-for-age used to create a WHO chart.
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of age-based indicator table data for measurement of Subscapular skinfold-for-age used to create a WHO chart.</returns>
        public List<SsfforAge> ListSsfforAge(Sexes sex)
        {
            var chartDAC = new ChartDAC(_context);
            List<SsfforAge> ssfCurves = chartDAC.ListSsfforAge(sex);
            return ssfCurves;
        }

        /// <summary>
        /// A list of age-based indicator table data for measurement of Subscapular skinfold-for-age used to create a WHO chart.  Data point (x,y) is insert if new; otherwise updated.
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of age-based indicator table data for measurement of Subscapular skinfold-for-age used to create a WHO chart.</returns>
        public List<SsfforAge> ListSsfforAge(Sexes sex, byte newX, decimal newY)
        {
            var chartDAC = new ChartDAC(_context);
            List<SsfforAge> ssfCurves = chartDAC.ListSsfforAge(sex);

            decimal existingX = (from n1 in ssfCurves
                                 where n1.Month == newX
                                 select n1.Month).FirstOrDefault();

            if (newX != existingX)
            {

                // Get smaller value closest to x.  This is X0.
                var smallerNearestValue = (from n1 in ssfCurves
                                           where n1.Month < newX
                                           orderby n1.Month descending
                                           select n1.Month).First();

                // Get smaller value closest to x.  This is X1.
                var largerNearestValue = (from n1 in ssfCurves
                                          where n1.Month > newX
                                          orderby n1.Month ascending
                                          select n1.Month).First();

                // Get Index explicitly
                var smallNearElement = ssfCurves.FindIndex(0, x => x.Month == smallerNearestValue);
                var largeNearElement = ssfCurves.FindIndex(0, x => x.Month == largerNearestValue);

                // Interpolate Data Point Pair for Y
                LinearInterpolation yDataPoint = new LinearInterpolation();

                yDataPoint = new LinearInterpolation(newX, ssfCurves[smallNearElement].Month, ssfCurves[smallNearElement].Month, ssfCurves[smallNearElement].P3, ssfCurves[largeNearElement].P3);
                decimal newP3 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, ssfCurves[smallNearElement].Month, ssfCurves[smallNearElement].Month, ssfCurves[smallNearElement].P15, ssfCurves[largeNearElement].P15);
                decimal newP15 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, ssfCurves[smallNearElement].Month, ssfCurves[smallNearElement].Month, ssfCurves[smallNearElement].P50, ssfCurves[largeNearElement].P50);
                decimal newP50 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, ssfCurves[smallNearElement].Month, ssfCurves[smallNearElement].Month, ssfCurves[smallNearElement].P85, ssfCurves[largeNearElement].P85);
                decimal newP85 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, ssfCurves[smallNearElement].Month, ssfCurves[smallNearElement].Month, ssfCurves[smallNearElement].P97, ssfCurves[largeNearElement].P97);
                decimal newP97 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, ssfCurves[smallNearElement].Month, ssfCurves[smallNearElement].Month, ssfCurves[smallNearElement].Sd3neg, ssfCurves[largeNearElement].Sd3neg);
                decimal newSd3neg = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, ssfCurves[smallNearElement].Month, ssfCurves[smallNearElement].Month, ssfCurves[smallNearElement].Sd2neg, ssfCurves[largeNearElement].Sd2neg);
                decimal newSd2neg = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, ssfCurves[smallNearElement].Month, ssfCurves[smallNearElement].Month, ssfCurves[smallNearElement].Sd1neg, ssfCurves[largeNearElement].Sd1neg);
                decimal newSd1neg = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, ssfCurves[smallNearElement].Month, ssfCurves[smallNearElement].Month, ssfCurves[smallNearElement].Sd0, ssfCurves[largeNearElement].Sd0);
                decimal newSd0 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, ssfCurves[smallNearElement].Month, ssfCurves[smallNearElement].Month, ssfCurves[smallNearElement].Sd1, ssfCurves[largeNearElement].Sd1);
                decimal newSd1 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, ssfCurves[smallNearElement].Month, ssfCurves[smallNearElement].Month, ssfCurves[smallNearElement].Sd2, ssfCurves[largeNearElement].Sd2);
                decimal newSd2 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, ssfCurves[smallNearElement].Month, ssfCurves[smallNearElement].Month, ssfCurves[smallNearElement].Sd3, ssfCurves[largeNearElement].Sd3);
                decimal newSd3 = yDataPoint.CalculateY();

                // Add Score Record with Interpolated Data for Chart
                ssfCurves.Insert(smallNearElement + 1, new SsfforAge { Sex = (byte)sex, Month = newX, Score = newY, P3 = newP3, P15 = newP15, P50 = newP50, P85 = newP85, P97 = newP97, Sd3neg = newSd3neg, Sd2neg = newSd2neg, Sd1neg = newSd1neg, Sd0 = newSd0, Sd1 = newSd1, Sd2 = newSd2, Sd3 = newSd3 });
            }
            else if (newX == existingX)
            {
                var existingElement = ssfCurves.FindIndex(0, x => x.Month == existingX);
                ssfCurves[existingElement].Score = newY;
            }

            return ssfCurves;
        }

        /// <summary>
        /// A list of age-based indicator table data for measurement of Triceps skinfold-for-age used to create a WHO chart.
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of age-based indicator table data for measurement of Triceps skinfold-for-age used to create a WHO chart.</returns>
        public List<TsfforAge> ListTsfforAge(Sexes sex)
        {
            var chartDAC = new ChartDAC(_context);
            List<TsfforAge> tsfCurves = chartDAC.ListTsfforAge(sex);
            return tsfCurves;
        }

        /// <summary>
        /// A list of age-based indicator table data for measurement of Triceps skinfold-for-age used to create a WHO chart.  Data point (x,y) is insert if new; otherwise updated.
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of age-based indicator table data for measurement of Triceps skinfold-for-age used to create a WHO chart.</returns>
        public List<TsfforAge> ListTsfforAge(Sexes sex, byte newX, decimal newY)
        {
            var chartDAC = new ChartDAC(_context);
            List<TsfforAge> tsfCurves = chartDAC.ListTsfforAge(sex);

            decimal existingX = (from n1 in tsfCurves
                                 where n1.Month == newX
                                 select n1.Month).FirstOrDefault();

            if (newX != existingX)
            {
                // Get smaller value closest to x.  This is X0.
                var smallerNearestValue = (from n1 in tsfCurves
                                           where n1.Month < newX
                                           orderby n1.Month descending
                                           select n1.Month).First();

                // Get smaller value closest to x.  This is X1.
                var largerNearestValue = (from n1 in tsfCurves
                                          where n1.Month > newX
                                          orderby n1.Month ascending
                                          select n1.Month).First();

                // Get Index explicitly
                var smallNearElement = tsfCurves.FindIndex(0, x => x.Month == smallerNearestValue);
                var largeNearElement = tsfCurves.FindIndex(0, x => x.Month == largerNearestValue);

                // Interpolate Data Point Pair for Y
                LinearInterpolation yDataPoint = new LinearInterpolation();

                yDataPoint = new LinearInterpolation(newX, tsfCurves[smallNearElement].Month, tsfCurves[smallNearElement].Month, tsfCurves[smallNearElement].P3, tsfCurves[largeNearElement].P3);
                decimal newP3 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, tsfCurves[smallNearElement].Month, tsfCurves[smallNearElement].Month, tsfCurves[smallNearElement].P15, tsfCurves[largeNearElement].P15);
                decimal newP15 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, tsfCurves[smallNearElement].Month, tsfCurves[smallNearElement].Month, tsfCurves[smallNearElement].P50, tsfCurves[largeNearElement].P50);
                decimal newP50 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, tsfCurves[smallNearElement].Month, tsfCurves[smallNearElement].Month, tsfCurves[smallNearElement].P85, tsfCurves[largeNearElement].P85);
                decimal newP85 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, tsfCurves[smallNearElement].Month, tsfCurves[smallNearElement].Month, tsfCurves[smallNearElement].P97, tsfCurves[largeNearElement].P97);
                decimal newP97 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, tsfCurves[smallNearElement].Month, tsfCurves[smallNearElement].Month, tsfCurves[smallNearElement].Sd3neg, tsfCurves[largeNearElement].Sd3neg);
                decimal newSd3neg = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, tsfCurves[smallNearElement].Month, tsfCurves[smallNearElement].Month, tsfCurves[smallNearElement].Sd2neg, tsfCurves[largeNearElement].Sd2neg);
                decimal newSd2neg = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, tsfCurves[smallNearElement].Month, tsfCurves[smallNearElement].Month, tsfCurves[smallNearElement].Sd1neg, tsfCurves[largeNearElement].Sd1neg);
                decimal newSd1neg = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, tsfCurves[smallNearElement].Month, tsfCurves[smallNearElement].Month, tsfCurves[smallNearElement].Sd0, tsfCurves[largeNearElement].Sd0);
                decimal newSd0 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, tsfCurves[smallNearElement].Month, tsfCurves[smallNearElement].Month, tsfCurves[smallNearElement].Sd1, tsfCurves[largeNearElement].Sd1);
                decimal newSd1 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, tsfCurves[smallNearElement].Month, tsfCurves[smallNearElement].Month, tsfCurves[smallNearElement].Sd2, tsfCurves[largeNearElement].Sd2);
                decimal newSd2 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, tsfCurves[smallNearElement].Month, tsfCurves[smallNearElement].Month, tsfCurves[smallNearElement].Sd3, tsfCurves[largeNearElement].Sd3);
                decimal newSd3 = yDataPoint.CalculateY();

                // Add Score Record with Interpolated Data for Chart
                tsfCurves.Insert(smallNearElement + 1, new TsfforAge { Sex = (byte)sex, Month = newX, Score = newY, P3 = newP3, P15 = newP15, P50 = newP50, P85 = newP85, P97 = newP97, Sd3neg = newSd3neg, Sd2neg = newSd2neg, Sd1neg = newSd1neg, Sd0 = newSd0, Sd1 = newSd1, Sd2 = newSd2, Sd3 = newSd3 });
            }
            else if (newX == existingX)
            {
                var existingElement = tsfCurves.FindIndex(0, x => x.Month == existingX);
                tsfCurves[existingElement].Score = newY;
            }

            return tsfCurves;
        }

        /// <summary>
        /// A list of age-based indicator table data for measurement of Weight-for-length/height used to create a WHO chart.
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of age-based indicator table data for measurement of Weight-for-length/height used to create a WHO chart.</returns>
        public List<WeightForAge> ListWeightForAge(Sexes sex)
        {
            var chartDAC = new ChartDAC(_context);
            List<WeightForAge> wfaCurves = chartDAC.ListWeightForAge(sex);
            return wfaCurves;
        }

        /// <summary>
        /// A list of age-based indicator table data for measurement of Weight-for-length/height used to create a WHO chart.  Data point (x,y) is insert if new; otherwise updated.
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of age-based indicator table data for measurement of Weight-for-length/height used to create a WHO chart.</returns>
        public List<WeightForAge> ListWeightForAge(Sexes sex, byte newX, decimal newY)
        {
            var chartDAC = new ChartDAC(_context);
            List<WeightForAge> wfaCurves = chartDAC.ListWeightForAge(sex);

            decimal existingX = (from n1 in wfaCurves
                                 where n1.Month == newX
                                 select n1.Month).FirstOrDefault();

            if (newX != existingX)
            {
                // Get smaller value closest to x.  This is X0.
                var smallerNearestValue = (from n1 in wfaCurves
                                           where n1.Month < newX
                                           orderby n1.Month descending
                                           select n1.Month).First();

                // Get smaller value closest to x.  This is X1.
                var largerNearestValue = (from n1 in wfaCurves
                                          where n1.Month > newX
                                          orderby n1.Month ascending
                                          select n1.Month).First();

                // Get Index explicitly
                var smallNearElement = wfaCurves.FindIndex(0, x => x.Month == smallerNearestValue);
                var largeNearElement = wfaCurves.FindIndex(0, x => x.Month == largerNearestValue);

                // Interpolate Data Point Pair for Y
                LinearInterpolation yDataPoint = new LinearInterpolation();

                yDataPoint = new LinearInterpolation(newX, wfaCurves[smallNearElement].Month, wfaCurves[smallNearElement].Month, wfaCurves[smallNearElement].P3, wfaCurves[largeNearElement].P3);
                decimal newP3 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, wfaCurves[smallNearElement].Month, wfaCurves[smallNearElement].Month, wfaCurves[smallNearElement].P15, wfaCurves[largeNearElement].P15);
                decimal newP15 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, wfaCurves[smallNearElement].Month, wfaCurves[smallNearElement].Month, wfaCurves[smallNearElement].P50, wfaCurves[largeNearElement].P50);
                decimal newP50 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, wfaCurves[smallNearElement].Month, wfaCurves[smallNearElement].Month, wfaCurves[smallNearElement].P85, wfaCurves[largeNearElement].P85);
                decimal newP85 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, wfaCurves[smallNearElement].Month, wfaCurves[smallNearElement].Month, wfaCurves[smallNearElement].P97, wfaCurves[largeNearElement].P97);
                decimal newP97 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, wfaCurves[smallNearElement].Month, wfaCurves[smallNearElement].Month, wfaCurves[smallNearElement].Sd3neg, wfaCurves[largeNearElement].Sd3neg);
                decimal newSd3neg = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, wfaCurves[smallNearElement].Month, wfaCurves[smallNearElement].Month, wfaCurves[smallNearElement].Sd2neg, wfaCurves[largeNearElement].Sd2neg);
                decimal newSd2neg = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, wfaCurves[smallNearElement].Month, wfaCurves[smallNearElement].Month, wfaCurves[smallNearElement].Sd0, wfaCurves[largeNearElement].Sd0);
                decimal newSd0 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, wfaCurves[smallNearElement].Month, wfaCurves[smallNearElement].Month, wfaCurves[smallNearElement].Sd2, wfaCurves[largeNearElement].Sd2);
                decimal newSd2 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, wfaCurves[smallNearElement].Month, wfaCurves[smallNearElement].Month, wfaCurves[smallNearElement].Sd3, wfaCurves[largeNearElement].Sd3);
                decimal newSd3 = yDataPoint.CalculateY();

                // Add Score Record with Interpolated Data for Chart
                wfaCurves.Insert(smallNearElement + 1, new WeightForAge { Sex = (byte)sex, Month = newX, Score = newY, P3 = newP3, P15 = newP15, P50 = newP50, P85 = newP85, P97 = newP97, Sd3neg = newSd3neg, Sd2neg = newSd2neg, Sd0 = newSd0, Sd2 = newSd2, Sd3 = newSd3 });
            }
            else if (newX == existingX)
            {
                var existingElement = wfaCurves.FindIndex(0, x => x.Month == existingX);
                wfaCurves[existingElement].Score = newY;
            }

            return wfaCurves;
        }

        /// <summary>
        /// A list of height-based indicator table data for measurement of Weight-for-length/height used to create a WHO chart (2 to 5 years).
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of height-based indicator table data for measurement of Weight-for-length/height used to create a WHO chart (2 to 5 years).</returns>
        public List<WeightForHeight> ListWeightForHeight(Sexes sex)
        {
            var chartDAC = new ChartDAC(_context);
            List<WeightForHeight> wfhCurves = chartDAC.ListWeightForHeight(sex);
            return wfhCurves;
        }

        /// <summary>
        /// A list of height-based indicator table data for measurement of Weight-for-length/height used to create a WHO chart (2 to 5 years).  Data point (x,y) is insert if new; otherwise updated.
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of height-based indicator table data for measurement of Weight-for-length/height used to create a WHO chart (2 to 5 years).</returns>
        public List<WeightForHeight> ListWeightForHeight(Sexes sex, decimal newX, decimal newY)
        {
            var chartDAC = new ChartDAC(_context);
            List<WeightForHeight> wfhCurves = chartDAC.ListWeightForHeight(sex);

            decimal existingX = (from n1 in wfhCurves
                                 where n1.Heightincm == newX
                                 select n1.Heightincm).FirstOrDefault();

            if (newX != existingX)
            {
                // Get smaller value closest to x.  This is X0.
                var smallerNearestValue = (from n1 in wfhCurves
                                           where n1.Heightincm < newX
                                           orderby n1.Heightincm descending
                                           select n1.Heightincm).First();

                // Get smaller value closest to x.  This is X1.
                var largerNearestValue = (from n1 in wfhCurves
                                          where n1.Heightincm > newX
                                          orderby n1.Heightincm ascending
                                          select n1.Heightincm).First();

                // Get Index explicitly
                var smallNearElement = wfhCurves.FindIndex(0, x => x.Heightincm == smallerNearestValue);
                var largeNearElement = wfhCurves.FindIndex(0, x => x.Heightincm == largerNearestValue);

                // Interpolate Data Point Pair for Y
                LinearInterpolation yDataPoint = new LinearInterpolation();

                yDataPoint = new LinearInterpolation(newX, wfhCurves[smallNearElement].Heightincm, wfhCurves[smallNearElement].Heightincm, wfhCurves[smallNearElement].P3, wfhCurves[largeNearElement].P3);
                decimal newP3 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, wfhCurves[smallNearElement].Heightincm, wfhCurves[smallNearElement].Heightincm, wfhCurves[smallNearElement].P15, wfhCurves[largeNearElement].P15);
                decimal newP15 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, wfhCurves[smallNearElement].Heightincm, wfhCurves[smallNearElement].Heightincm, wfhCurves[smallNearElement].P50, wfhCurves[largeNearElement].P50);
                decimal newP50 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, wfhCurves[smallNearElement].Heightincm, wfhCurves[smallNearElement].Heightincm, wfhCurves[smallNearElement].P85, wfhCurves[largeNearElement].P85);
                decimal newP85 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, wfhCurves[smallNearElement].Heightincm, wfhCurves[smallNearElement].Heightincm, wfhCurves[smallNearElement].P97, wfhCurves[largeNearElement].P97);
                decimal newP97 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, wfhCurves[smallNearElement].Heightincm, wfhCurves[smallNearElement].Heightincm, wfhCurves[smallNearElement].Sd3neg, wfhCurves[largeNearElement].Sd3neg);
                decimal newSd3neg = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, wfhCurves[smallNearElement].Heightincm, wfhCurves[smallNearElement].Heightincm, wfhCurves[smallNearElement].Sd2neg, wfhCurves[largeNearElement].Sd2neg);
                decimal newSd2neg = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, wfhCurves[smallNearElement].Heightincm, wfhCurves[smallNearElement].Heightincm, wfhCurves[smallNearElement].Sd1neg, wfhCurves[largeNearElement].Sd1neg);
                decimal newSd1neg = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, wfhCurves[smallNearElement].Heightincm, wfhCurves[smallNearElement].Heightincm, wfhCurves[smallNearElement].Sd0, wfhCurves[largeNearElement].Sd0);
                decimal newSd0 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, wfhCurves[smallNearElement].Heightincm, wfhCurves[smallNearElement].Heightincm, wfhCurves[smallNearElement].Sd1, wfhCurves[largeNearElement].Sd1);
                decimal newSd1 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, wfhCurves[smallNearElement].Heightincm, wfhCurves[smallNearElement].Heightincm, wfhCurves[smallNearElement].Sd2, wfhCurves[largeNearElement].Sd2);
                decimal newSd2 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, wfhCurves[smallNearElement].Heightincm, wfhCurves[smallNearElement].Heightincm, wfhCurves[smallNearElement].Sd3, wfhCurves[largeNearElement].Sd3);
                decimal newSd3 = yDataPoint.CalculateY();

                // Add Score Record with Interpolated Data for Chart
                wfhCurves.Insert(smallNearElement + 1, new WeightForHeight { Sex = (byte)sex, Heightincm = newX, Score = newY, P3 = newP3, P15 = newP15, P50 = newP50, P85 = newP85, P97 = newP97, Sd3neg = newSd3neg, Sd2neg = newSd2neg, Sd1neg = newSd1neg, Sd0 = newSd0, Sd1 = newSd1, Sd2 = newSd2, Sd3 = newSd3 });
            }
            else if (newX == existingX)
            {
                var existingElement = wfhCurves.FindIndex(0, x => x.Heightincm == existingX);
                wfhCurves[existingElement].Score = newY;
            }

            return wfhCurves;
        }

        /// <summary>
        /// A list of height-based indicator table data for measurement of Weight-for-length/height used to create a WHO chart (Birth to 2 years).
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of height-based indicator table data for measurement of Weight-for-length/height used to create a WHO chart (Birth to 2 years).</returns>
        public List<WeightForLength> ListWeightForLength(Sexes sex)
        {
            var chartDAC = new ChartDAC(_context);
            List<WeightForLength> wflCurves = chartDAC.ListWeightForLength(sex);
            return wflCurves;
        }

        /// <summary>
        /// A list of height-based indicator table data for measurement of Weight-for-length/height used to create a WHO chart (Birth to 2 years).  Data point (x,y) is insert if new; otherwise updated.
        /// </summary>
        /// <param name="sex">Human sex designation per ISO/IEC 5218 code</param>
        /// <returns>Returns a list of height-based indicator table data for measurement of Weight-for-length/height used to create a WHO chart (Birth to 2 years).</returns>
        public List<WeightForLength> ListWeightForLength(Sexes sex, decimal newX, decimal newY)
        {
            var chartDAC = new ChartDAC(_context);
            List<WeightForLength> wflCurves = chartDAC.ListWeightForLength(sex);

            decimal existingX = (from n1 in wflCurves
                                 where n1.Lengthincm == newX
                                 select n1.Lengthincm).FirstOrDefault();

            if (newX != existingX)
            {                               
                // Get smaller value closest to x.  This is X0.
                var smallerNearestValue = (from n1 in wflCurves
                                           where n1.Lengthincm < newX
                                           orderby n1.Lengthincm descending
                                           select n1.Lengthincm).First();

                // Get smaller value closest to x.  This is X1.
                var largerNearestValue = (from n1 in wflCurves
                                          where n1.Lengthincm > newX
                                          orderby n1.Lengthincm ascending
                                          select n1.Lengthincm).First();

                // Get Index explicitly
                var smallNearElement = wflCurves.FindIndex(0, x => x.Lengthincm == smallerNearestValue);
                var largeNearElement = wflCurves.FindIndex(0, x => x.Lengthincm == largerNearestValue);
            
                // Interpolate Data Point Pair for Y
                LinearInterpolation yDataPoint = new LinearInterpolation();

                yDataPoint = new LinearInterpolation(newX, wflCurves[smallNearElement].Lengthincm, wflCurves[smallNearElement].Lengthincm, wflCurves[smallNearElement].P3, wflCurves[largeNearElement].P3);
                decimal newP3 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, wflCurves[smallNearElement].Lengthincm, wflCurves[smallNearElement].Lengthincm, wflCurves[smallNearElement].P15, wflCurves[largeNearElement].P15);
                decimal newP15 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, wflCurves[smallNearElement].Lengthincm, wflCurves[smallNearElement].Lengthincm, wflCurves[smallNearElement].P50, wflCurves[largeNearElement].P50);
                decimal newP50 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, wflCurves[smallNearElement].Lengthincm, wflCurves[smallNearElement].Lengthincm, wflCurves[smallNearElement].P85, wflCurves[largeNearElement].P85);
                decimal newP85 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, wflCurves[smallNearElement].Lengthincm, wflCurves[smallNearElement].Lengthincm, wflCurves[smallNearElement].P97, wflCurves[largeNearElement].P97);
                decimal newP97 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, wflCurves[smallNearElement].Lengthincm, wflCurves[smallNearElement].Lengthincm, wflCurves[smallNearElement].Sd3neg, wflCurves[largeNearElement].Sd3neg);
                decimal newSd3neg = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, wflCurves[smallNearElement].Lengthincm, wflCurves[smallNearElement].Lengthincm, wflCurves[smallNearElement].Sd2neg, wflCurves[largeNearElement].Sd2neg);
                decimal newSd2neg = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, wflCurves[smallNearElement].Lengthincm, wflCurves[smallNearElement].Lengthincm, wflCurves[smallNearElement].Sd1neg, wflCurves[largeNearElement].Sd1neg);
                decimal newSd1neg = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, wflCurves[smallNearElement].Lengthincm, wflCurves[smallNearElement].Lengthincm, wflCurves[smallNearElement].Sd0, wflCurves[largeNearElement].Sd0);
                decimal newSd0 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, wflCurves[smallNearElement].Lengthincm, wflCurves[smallNearElement].Lengthincm, wflCurves[smallNearElement].Sd1, wflCurves[largeNearElement].Sd1);
                decimal newSd1 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, wflCurves[smallNearElement].Lengthincm, wflCurves[smallNearElement].Lengthincm, wflCurves[smallNearElement].Sd2, wflCurves[largeNearElement].Sd2);
                decimal newSd2 = yDataPoint.CalculateY();
                yDataPoint = new LinearInterpolation(newX, wflCurves[smallNearElement].Lengthincm, wflCurves[smallNearElement].Lengthincm, wflCurves[smallNearElement].Sd3, wflCurves[largeNearElement].Sd3);
                decimal newSd3 = yDataPoint.CalculateY();

                // Add Score Record with Interpolated Data for Chart
                wflCurves.Insert(smallNearElement + 1, new WeightForLength { Sex = (byte)sex, Lengthincm = newX, Score = newY, P3 = newP3, P15 = newP15, P50 = newP50, P85 = newP85, P97 = newP97, Sd3neg = newSd3neg, Sd2neg = newSd2neg, Sd1neg = newSd1neg, Sd0 = newSd0, Sd1 = newSd1, Sd2 = newSd2, Sd3 = newSd3 });
            }
            else if (newX == existingX)
            {
                var existingElement = wflCurves.FindIndex(0, x => x.Lengthincm == existingX);
                wflCurves[existingElement].Score = newY;
            }

            return wflCurves;
        }
    }
}