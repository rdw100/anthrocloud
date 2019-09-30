using System;
using System.Collections.Generic;
using AnthroCloud.Data.Models;

namespace AnthroCloud.Business
{
    public class GrowthChart : IGrowthCurveBO, IGrowthScoreBO
    {
        double IGrowthScoreBO.CalculatePercentile(double zScore)
        {
            throw new NotImplementedException();
        }

        double IGrowthScoreBO.CalculateZScore(byte indicator, double measurement, double ageInDays, byte sex)
        {
            throw new NotImplementedException();
        }

        List<BmiforAge> IGrowthCurveBO.ListBmiforAge(byte sex)
        {
            throw new NotImplementedException();
        }

        List<HcforAge> IGrowthCurveBO.ListHcforAge(byte sex)
        {
            throw new NotImplementedException();
        }

        List<LengthHeightForAge> IGrowthCurveBO.ListLengthHeightForAge(byte sex)
        {
            throw new NotImplementedException();
        }

        List<MuacforAge> IGrowthCurveBO.ListMuacforAge(byte sex)
        {
            throw new NotImplementedException();
        }

        List<SsfforAge> IGrowthCurveBO.ListSsfforAge(byte sex)
        {
            throw new NotImplementedException();
        }

        List<TsfforAge> IGrowthCurveBO.ListTsfforAge(byte sex)
        {
            throw new NotImplementedException();
        }

        List<WeightForAge> IGrowthCurveBO.ListWeightForAge(byte sex)
        {
            throw new NotImplementedException();
        }

        List<WeightForHeight> IGrowthCurveBO.ListWeightForHeight(byte sex)
        {
            throw new NotImplementedException();
        }

        List<WeightForLength> IGrowthCurveBO.ListWeightForLength(byte sex)
        {
            throw new NotImplementedException();
        }
    }
}
