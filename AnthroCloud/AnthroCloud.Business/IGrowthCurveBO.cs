using AnthroCloud.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnthroCloud.Business
{
    interface IGrowthCurveBO
    {
        public List<WeightForAge> ListWeightForAge(byte sex);
        public List<WeightForLength> ListWeightForLength(byte sex);
        public List<WeightForHeight> ListWeightForHeight(byte sex);
        public List<BmiforAge> ListBmiforAge(byte sex);
        public List<HcforAge> ListHcforAge(byte sex);
        public List<LengthHeightForAge> ListLengthHeightForAge(byte sex);
        public List<MuacforAge> ListMuacforAge(byte sex);
        public List<SsfforAge> ListSsfforAge(byte sex);
        public List<TsfforAge> ListTsfforAge(byte sex);
    }
}
