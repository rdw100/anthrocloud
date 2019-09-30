using System;
using System.Collections.Generic;
using System.Text;

namespace AnthroCloud.Business
{
    interface IGrowthScoreBO
    {
        public double CalculatePercentile(double zScore);

        public double CalculateZScore(byte indicator, double measurement, double ageInDays, byte sex);
    }
}
