using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AnthroCloud.Business;
using AnthroCloud.Entities;
using AnthroCloud.API.Controllers;
using System.Linq;

namespace AnthroCloud.Tests
{
    /// <summary>
    /// 
    /// </summary>
    public class ChartControllerTests
    {
        [Fact]
        public void GetAllBMI_ShouldReturnAllMale()
        {
            List<BmiforAge> expected = GetTestBmiforAge_Male();

            var controller = new ChartController();
            var target = controller.GetAllBFA(1) as List<BmiforAge>;

            Assert.Equal(1857, target.Count());
            
            var actual = (from l in target select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);            
            Assert.Equal(expected.FirstOrDefault().AgeInDays, actual.AgeInDays);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        private List<BmiforAge> GetTestBmiforAge_Male()
        {
            var testBmiforAge = new List<BmiforAge>();
            testBmiforAge.Add(new BmiforAge
            {
                AgeInDays = 0,
                Sex = 1,
                L = -0.3053M,
                M = 13.4069M,
                S = 0.09560M,
                Sd3neg = 10.184M,
                Sd2neg = 11.133M,
                Sd1neg = 12.201M,
                Sd0 = 13.407M,
                Sd1 = 14.773M,
                Sd2 = 16.326M,
                Sd3 = 18.100M,
                P3 = 11.254M,
                P15 = 12.160M,
                P50 = 13.407M,
                P85 = 14.826M,
                P97 = 16.130M
            });

            return testBmiforAge;
        }

        [Fact]
        public void GetAllBMI_ShouldReturnAllFemale()
        {
            List<BmiforAge> expected = GetTestBmiforAge_Female();

            var controller = new ChartController();
            var target = controller.GetAllBFA(2) as List<BmiforAge>;

            Assert.Equal(1857, target.Count());

            var actual = (from l in target select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);
            Assert.Equal(expected.FirstOrDefault().AgeInDays, actual.AgeInDays);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        private List<BmiforAge> GetTestBmiforAge_Female()
        {
            var testBmiforAge = new List<BmiforAge>();
            testBmiforAge.Add(new BmiforAge
            {
                AgeInDays = 0,
                Sex = 2,
                L = -0.0631M,
                M = 13.3363M,
                S = 0.09272M,
                Sd3neg = 10.122M,
                Sd2neg = 11.091M,
                Sd1neg = 12.159M,
                Sd0 = 13.336M,
                Sd1 = 14.636M,
                Sd2 = 16.071M,
                Sd3 = 17.657M,
                P3 = 11.213M,
                P15 = 12.118M,
                P50 = 13.336M,
                P85 = 14.686M,
                P97 = 15.892M
            });

            return testBmiforAge;
        }

        [Fact]
        public void GetAllHCFA_ShouldReturnAllMale()
        {
            List<HcForAge> expected = GetAllHCFA_Male();

            var controller = new ChartController();
            var target = controller.GetAllHCFA(1) as List<HcForAge>;

            Assert.Equal(1857, target.Count());

            var actual = (from l in target select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);
            Assert.Equal(expected.FirstOrDefault().AgeInDays, actual.AgeInDays);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        private List<HcForAge> GetAllHCFA_Male()
        {
            var testHcforAge = new List<HcForAge>();
            testHcforAge.Add(new HcForAge
            {
                AgeInDays = 0,
                Sex = 1,
                L = 1,
                M = 34.4618M,
                S = 0.03686M,
                Sd3neg = 30.651M,
                Sd2neg = 31.921M,
                Sd1neg = 33.192M,
                Sd0 = 34.462M,
                Sd1 = 35.732M,
                Sd2 = 37.002M,
                Sd3 = 38.273M,
                P3 = 32.073M,
                P15 = 33.145M,
                P50 = 34.462M,
                P85 = 35.778M,
                P97 = 36.851M
            });

            return testHcforAge;
        }

        [Fact]
        public void GetAllHCFA_ShouldReturnAllFemale()
        {
            List<HcForAge> expected = GetAllHCFA_Female();

            var controller = new ChartController();
            var target = controller.GetAllHCFA(2) as List<HcForAge>;

            Assert.Equal(1857, target.Count());

            var actual = (from l in target select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);
            Assert.Equal(expected.FirstOrDefault().AgeInDays, actual.AgeInDays);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        private List<HcForAge> GetAllHCFA_Female()
        {
            var testHcforAge = new List<HcForAge>();
            testHcforAge.Add(new HcForAge
            {
                AgeInDays = 0,
                Sex = 2,
                L = 1,
                M = 33.8787M,
                S = 0.03496M,
                Sd3neg = 30.326M,
                Sd2neg = 31.510M,
                Sd1neg = 32.694M,
                Sd0 = 33.879M,
                Sd1 = 35.063M,
                Sd2 = 36.247M,
                Sd3 = 37.432M,
                P3 = 31.651M,
                P15 = 32.651M,
                P50 = 33.879M,
                P85 = 35.106M,
                P97 = 36.106M
            });

            return testHcforAge;
        }

        [Fact]
        public void GetAllLHFA_ShouldReturnAllMale()
        {
            List<LengthHeightForAge> expected = GetAllLHFA_Male();

            var controller = new ChartController();
            var target = controller.GetAllLHFA(1) as List<LengthHeightForAge>;

            Assert.Equal(1857, target.Count());

            var actual = (from l in target select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);
            Assert.Equal(expected.FirstOrDefault().AgeInDays, actual.AgeInDays);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        private List<LengthHeightForAge> GetAllLHFA_Male()
        {
            var testLhfaforAge = new List<LengthHeightForAge>();
            testLhfaforAge.Add(new LengthHeightForAge
            {
                AgeInDays = 0,
                Sex = 1,
                L = 1,
                M = 49.8842M,
                S = 0.03795M,
                Sd3neg = 44.205M,
                Sd2neg = 46.098M,
                Sd0 = 49.884M,
                Sd2 = 53.670M,
                Sd3 = 55.564M,
                P3 = 46.324M,
                P15 = 47.922M,
                P50 = 49.884M,
                P85 = 51.846M,
                P97 = 53.445M
            });

            return testLhfaforAge;
        }

        [Fact]
        public void GetAllLHFA_ShouldReturnAllFemale()
        {
            List<LengthHeightForAge> expected = GetAllLHFA_Female();

            var controller = new ChartController();
            var target = controller.GetAllLHFA(2) as List<LengthHeightForAge>;

            Assert.Equal(1857, target.Count());

            var actual = (from l in target select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);
            Assert.Equal(expected.FirstOrDefault().AgeInDays, actual.AgeInDays);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        private List<LengthHeightForAge> GetAllLHFA_Female()
        {
            var testLhfaforAge = new List<LengthHeightForAge>();
            testLhfaforAge.Add(new LengthHeightForAge
            {
                AgeInDays = 0,
                Sex = 2,
                L = 1,
                M = 49.1477M,
                S = 0.03790M,
                Sd3neg = 43.560M,
                Sd2neg = 45.422M,
                Sd0 = 49.148M,
                Sd2 = 52.873M,
                Sd3 = 54.736M,
                P3 = 45.644M,
                P15 = 47.217M,
                P50 = 49.148M,
                P85 = 51.078M,
                P97 = 52.651M
            });

            return testLhfaforAge;
        }

        [Fact]
        public void GetAllMUAC_ShouldReturnAllMale()
        {
            List<MuacforAge> expected = GetAllMUAC_Male();

            var controller = new ChartController();
            var target = controller.GetAllMUAC(1) as List<MuacforAge>;

            Assert.Equal(1766, target.Count());

            var actual = (from l in target select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);
            Assert.Equal(expected.FirstOrDefault().AgeInDays, actual.AgeInDays);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        private List<MuacforAge> GetAllMUAC_Male()
        {
            var testMuacforAge = new List<MuacforAge>();
            testMuacforAge.Add(new MuacforAge
            {
                AgeInDays = 91,
                Sex = 1,
                L = 0.3933M,
                M = 13.4779M,
                S = 0.07474M,
                Sd3neg = 10.658M,
                Sd2neg = 11.554M,
                Sd1neg = 12.493M,
                Sd0 = 13.478M,
                Sd1 = 14.508M,
                Sd2 = 15.585M,
                Sd3 = 16.709M,
                P3 = 11.663M,
                P15 = 12.458M,
                P50 = 13.478M,
                P85 = 14.547M,
                P97 = 15.454M
            });

            return testMuacforAge;
        }

        [Fact]
        public void GetAllMUAC_ShouldReturnAllFemale()
        {
            List<MuacforAge> expected = GetAllMUAC_Female();

            var controller = new ChartController();
            var target = controller.GetAllMUAC(2) as List<MuacforAge>;

            Assert.Equal(1766, target.Count());

            var actual = (from l in target select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);
            Assert.Equal(expected.FirstOrDefault().AgeInDays, actual.AgeInDays);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        private List<MuacforAge> GetAllMUAC_Female()
        {
            var testMuacforAge = new List<MuacforAge>();
            testMuacforAge.Add(new MuacforAge
            {
                AgeInDays = 91,
                Sex = 2,
                L = -0.1733M,
                M = 13.0245M,
                S = 0.08262M,
                Sd3neg = 10.218M,
                Sd2neg = 11.066M,
                Sd1neg = 11.999M,
                Sd0 = 13.024M,
                Sd1 = 14.155M,
                Sd2 = 15.402M,
                Sd3 = 16.780M,
                P3 = 11.173M,
                P15 = 11.963M,
                P50 = 13.025M,
                P85 = 14.198M,
                P97 = 15.247M
            });

            return testMuacforAge;
        }

        [Fact]
        public void GetAllSSFA_ShouldReturnAllMale()
        {
            List<SsfforAge> expected = GetAllSSFA_Male();

            var controller = new ChartController();
            var target = controller.GetAllSSFA(1) as List<SsfforAge>;

            Assert.Equal(1766, target.Count());

            var actual = (from l in target select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);
            Assert.Equal(expected.FirstOrDefault().AgeInDays, actual.AgeInDays);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        private List<SsfforAge> GetAllSSFA_Male()
        {
            var testSSFforAge = new List<SsfforAge>();
            testSSFforAge.Add(new SsfforAge
            {
                AgeInDays = 91,
                Sex = 1,
                L = -0.3030M,
                M = 7.6920M,
                S = 0.17019M,
                Sd3neg = 4.785M,
                Sd2neg = 5.564M,
                Sd1neg = 6.516M,
                Sd0 = 7.692M,
                Sd1 = 9.161M,
                Sd2 = 11.017M,
                Sd3 = 13.395M,
                P3 = 5.667M,
                P15 = 6.478M,
                P50 = 7.692M,
                P85 = 9.221M,
                P97 = 10.771M
            });

            return testSSFforAge;
        }

        [Fact]
        public void GetAllSSFA_ShouldReturnAllFemale()
        {
            List<SsfforAge> expected = GetAllSSFA_Female();

            var controller = new ChartController();
            var target = controller.GetAllSSFA(2) as List<SsfforAge>;

            Assert.Equal(1766, target.Count());

            var actual = (from l in target select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);
            Assert.Equal(expected.FirstOrDefault().AgeInDays, actual.AgeInDays);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        private List<SsfforAge> GetAllSSFA_Female()
        {
            var testSSFforAge = new List<SsfforAge>();
            testSSFforAge.Add(new SsfforAge
            {
                AgeInDays = 91,
                Sex = 2,
                L = -0.2019M,
                M = 7.7874M,
                S = 0.18428M,
                Sd3neg = 4.611M,
                Sd2neg = 5.458M,
                Sd1neg = 6.499M,
                Sd0 = 7.787M,
                Sd1 = 9.396M,
                Sd2 = 11.422M,
                Sd3 = 13.995M,
                P3 = 5.571M,
                P15 = 6.457M,
                P50 = 7.787M,
                P85 = 9.462M,
                P97 = 11.154M
            });

            return testSSFforAge;
        }

        [Fact]
        public void GetAllTSFA_ShouldReturnAllMale()
        {
            List<TsfforAge> expected = GetAllTSFA_Male();

            var controller = new ChartController();
            var target = controller.GetAllTSFA(1) as List<TsfforAge>;

            Assert.Equal(1766, target.Count());

            var actual = (from l in target select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);
            Assert.Equal(expected.FirstOrDefault().AgeInDays, actual.AgeInDays);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        private List<TsfforAge> GetAllTSFA_Male()
        {
            var testTsfforAge = new List<TsfforAge>();
            testTsfforAge.Add(new TsfforAge
            {
                AgeInDays = 91,
                Sex = 1,
                L = 0.0030M,
                M = 9.7658M,
                S = 0.16611M,
                Sd3neg = 5.931M,
                Sd2neg = 7.004M,
                Sd1neg = 8.271M,
                Sd0 = 9.766M,
                Sd1 = 11.530M,
                Sd2 = 13.612M,
                Sd3 = 16.068M,
                P3 = 7.144M,
                P15 = 8.221M,
                P50 = 9.766M,
                P85 = 11.600M,
                P97 = 13.345M
            });

            return testTsfforAge;
        }

        [Fact]
        public void GetAllTSFA_ShouldReturnAllFemale()
        {
            List<TsfforAge> expected = GetAllTSFA_Female();

            var controller = new ChartController();
            var target = controller.GetAllTSFA(2) as List<TsfforAge>;

            Assert.Equal(1766, target.Count());

            var actual = (from l in target select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);
            Assert.Equal(expected.FirstOrDefault().AgeInDays, actual.AgeInDays);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        private List<TsfforAge> GetAllTSFA_Female()
        {
            var testTsfforAge = new List<TsfforAge>();
            testTsfforAge.Add(new TsfforAge
            {
                AgeInDays = 91,
                Sex = 2,
                L = 0.1882M,
                M = 9.7533M,
                S = 0.17525M,
                Sd3neg = 5.607M,
                Sd2neg = 6.787M,
                Sd1neg = 8.161M,
                Sd0 = 9.753M,
                Sd1 = 11.589M,
                Sd2 = 13.695M,
                Sd3 = 16.102M,
                P3 = 6.940M,
                P15 = 8.108M,
                P50 = 9.753M,
                P85 = 11.660M,
                P97 = 13.429M
            });

            return testTsfforAge;
        }

        [Fact]
        public void GetAllWFA_ShouldReturnAllMale()
        {
            List<WeightForAge> expected = GetAllWFA_Male();

            var controller = new ChartController();
            var target = controller.GetAllWFA(1) as List<WeightForAge>;

            Assert.Equal(1857, target.Count());

            var actual = (from l in target select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);
            Assert.Equal(expected.FirstOrDefault().AgeInDays, actual.AgeInDays);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        private List<WeightForAge> GetAllWFA_Male()
        {
            var testWeightForAge = new List<WeightForAge>();
            testWeightForAge.Add(new WeightForAge
            {
                AgeInDays = 0,
                Sex = 1,
                L = 0.3487M,
                M = 3.3464M,
                S = 0.14602M,
                Sd3neg = 2.080M,
                Sd2neg = 2.459M,
                Sd0 = 3.346M,
                Sd2 = 4.419M,
                Sd3 = 5.031M,
                P3 = 2.507M,
                P15 = 2.865M,
                P50 = 3.346M,
                P85 = 3.878M,
                P97 = 4.350M
            });

            return testWeightForAge;
        }

        [Fact]
        public void GetAllWFA_ShouldReturnAllFemale()
        {
            List<WeightForAge> expected = GetAllWFA_Female();

            var controller = new ChartController();
            var target = controller.GetAllWFA(2) as List<WeightForAge>;

            Assert.Equal(1857, target.Count());

            var actual = (from l in target select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);
            Assert.Equal(expected.FirstOrDefault().AgeInDays, actual.AgeInDays);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        private List<WeightForAge> GetAllWFA_Female()
        {
            var testWeightForAge = new List<WeightForAge>();
            testWeightForAge.Add(new WeightForAge
            {
                AgeInDays = 0,
                Sex = 2,
                L = 0.3809M,
                M = 3.2322M,
                S = 0.14171M,
                Sd3neg = 2.033M,
                Sd2neg = 2.395M,
                Sd0 = 3.232M,
                Sd2 = 4.230M,
                Sd3 = 4.793M,
                P3 = 2.440M,
                P15 = 2.779M,
                P50 = 3.232M,
                P85 = 3.729M,
                P97 = 4.166M
            });

            return testWeightForAge;
        }

        [Fact]
        public void GetAllWFH_ShouldReturnAllMale()
        {
            List<WeightForHeight> expected = GetAllWFH_Male();

            var controller = new ChartController();
            var target = controller.GetAllWFH(1) as List<WeightForHeight>;

            Assert.Equal(551, target.Count());

            var actual = (from l in target select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);
            Assert.Equal(expected.FirstOrDefault().HeightInCm, actual.HeightInCm);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        private List<WeightForHeight> GetAllWFH_Male()
        {
            var testWeightForHeight = new List<WeightForHeight>();
            testWeightForHeight.Add(new WeightForHeight
            {
                Sex = 1,
                HeightInCm = 65.0M,
                L = -0.3521M,
                M = 7.4327M,
                S = 0.08217M,
                Sd3neg = 5.868M,
                Sd2neg = 6.335M,
                Sd1neg = 6.854M,
                Sd0 = 7.433M,
                Sd1 = 8.079M,
                Sd2 = 8.804M,
                Sd3 = 9.619M,
                P3 = 6.394M,
                P15 = 6.834M,
                P50 = 7.433M,
                P85 = 8.104M,
                P97 = 8.713M
            });

            return testWeightForHeight;
        }

        [Fact]
        public void GetAllWFH_ShouldReturnAllFemale()
        {
            List<WeightForHeight> expected = GetAllWFH_Female();

            var controller = new ChartController();
            var target = controller.GetAllWFH(2) as List<WeightForHeight>;

            Assert.Equal(551, target.Count());

            var actual = (from l in target select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);
            Assert.Equal(expected.FirstOrDefault().HeightInCm, actual.HeightInCm);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        private List<WeightForHeight> GetAllWFH_Female()
        {
            var testWeightForHeight = new List<WeightForHeight>();
            testWeightForHeight.Add(new WeightForHeight
            {
                Sex = 2,
                HeightInCm = 65.0M,
                L = -0.3833M,
                M = 7.2402M,
                S = 0.09113M,
                Sd3neg = 5.583M,
                Sd2neg = 6.071M,
                Sd1neg = 6.620M,
                Sd0 = 7.240M,
                Sd1 = 7.944M,
                Sd2 = 8.746M,
                Sd3 = 9.664M,
                P3 = 6.133M,
                P15 = 6.599M,
                P50 = 7.240M,
                P85 = 7.971M,
                P97 = 8.645M
            });

            return testWeightForHeight;
        }

        [Fact]
        public void GetAllWFL_ShouldReturnAllMale()
        {
            List<WeightForLength> expected = GetAllWFL_Male();

            var controller = new ChartController();
            var target = controller.GetAllWFL(1) as List<WeightForLength>;

            Assert.Equal(651, target.Count());

            var actual = (from l in target select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);
            Assert.Equal(expected.FirstOrDefault().LengthInCm, actual.LengthInCm);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        private List<WeightForLength> GetAllWFL_Male()
        {
            var testWeightForLength = new List<WeightForLength>();
            testWeightForLength.Add(new WeightForLength
            {
                LengthInCm = 45.0M,
                Sex = 1,
                L = -0.3521M,
                M = 2.4410M,
                S = 0.09182M,
                Sd3neg = 1.877M,
                Sd2neg = 2.043M,
                Sd1neg = 2.230M,
                Sd0 = 2.441M,
                Sd1 = 2.680M,
                Sd2 = 2.951M,
                Sd3 = 3.261M,
                P3 = 2.064M,
                P15 = 2.223M,
                P50 = 2.441M,
                P85 = 2.689M,
                P97 = 2.917M
            });

            return testWeightForLength;
        }

        [Fact]
        public void GetAllWFL_ShouldReturnAllFemale()
        {
            List<WeightForLength> expected = GetAllWFL_Female();

            var controller = new ChartController();
            var target = controller.GetAllWFL(2) as List<WeightForLength>;

            Assert.Equal(651, target.Count());

            var actual = (from l in target select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);
            Assert.Equal(expected.FirstOrDefault().LengthInCm, actual.LengthInCm);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        private List<WeightForLength> GetAllWFL_Female()
        {
            var testWeightForLength = new List<WeightForLength>();
            testWeightForLength.Add(new WeightForLength
            {
                LengthInCm = 45.0M,
                Sex = 2,
                L = -0.3833M,
                M = 2.4607M,
                S = 0.09029M,
                Sd3neg = 1.902M,
                Sd2neg = 2.066M,
                Sd1neg = 2.252M,
                Sd0 = 2.461M,
                Sd1 = 2.698M,
                Sd2 = 2.967M,
                Sd3 = 3.275M,
                P3 = 2.087M,
                P15 = 2.245M,
                P50 = 2.461M,
                P85 = 2.707M,
                P97 = 2.933M
            });

            return testWeightForLength;
        }
    }
}