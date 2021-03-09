using AnthroCloud.API.Controllers;
using AnthroCloud.Entities;
using AnthroCloud.Tests;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AnthroCloud.Integration.Tests
{
    /// <summary>
    /// Integration tests controller logic for chart data.
    /// </summary>
    public class ChartControllerTests
    {
        private AnthroCloudContextMySql _context = new TestAnthroCloudContext().Context;
        
        /// <summary>
        /// Tests chart controller logic for BMI chart data given new data point (x,y) when male.
        /// </summary>
        [Fact]
        public async Task GetBMI_MaleNewXNewY_ShouldReturnAllMaleAsync()
        {
            List<BmiforAge> expected = GetTestBmiforAge_Male();

            var controller = new ChartController(_context);
            var target = await controller.GetAllBFA(1,12,17.5M) as List<BmiforAge>;

            Assert.Equal(62, target.Count);
            
            var actual = (from l in target select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);            
            Assert.Equal(expected.FirstOrDefault().Month, actual.Month);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        /// <summary>
        /// Gets sample BMI data for a male.
        /// </summary>
        /// <returns>Returns sample BMI data for a male.</returns>
        private static List<BmiforAge> GetTestBmiforAge_Male()
        {
            var testBmiforAge = new List<BmiforAge>();
            testBmiforAge.Add(new BmiforAge
            {
                Month = 0,
                Sex = 1,
                L = -0.3053M,
                M = 13.4069M,
                S = 0.09560M,
                Sd3neg = 10.200M,
                Sd2neg = 11.100M,
                Sd1neg = 12.200M,
                Sd0 = 13.400M,
                Sd1 = 14.800M,
                Sd2 = 16.300M,
                Sd3 = 18.100M,
                P3 = 11.300M,
                P15 = 12.200M,
                P50 = 13.400M,
                P85 = 14.800M,
                P97 = 16.100M
            });

            return testBmiforAge;
        }

        /// <summary>
        /// Tests chart controller logic for BMI chart data given new data point (x,y) when female.
        /// </summary>
        [Fact]
        public async Task GetBMI_FemaleNewXNewY_ShouldReturnAllFemaleAsync()
        {
            List<BmiforAge> expected = GetTestBmiforAge_Female();

            var controller = new ChartController(_context);
            var target = await controller.GetAllBFA(2, 12, 17) as List<BmiforAge>;

            Assert.Equal(62, target.Count);

            var actual = (from l in target select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);
            Assert.Equal(expected.FirstOrDefault().Month, actual.Month);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        /// <summary>
        /// Gets sample BMI data for a female.
        /// </summary>
        /// <returns>Returns sample BMI data for a female.</returns>
        private static List<BmiforAge> GetTestBmiforAge_Female()
        {
            var testBmiforAge = new List<BmiforAge>();
            testBmiforAge.Add(new BmiforAge
            {
                Month = 0,
                Sex = 2,
                L = -0.0631M,
                M = 13.3363M,
                S = 0.09272M,
                Sd3neg = 10.100M,
                Sd2neg = 11.100M,
                Sd1neg = 12.200M,
                Sd0 = 13.300M,
                Sd1 = 14.600M,
                Sd2 = 16.100M,
                Sd3 = 17.700M,
                P3 = 11.200M,
                P15 = 12.100M,
                P50 = 13.300M,
                P85 = 14.700M,
                P97 = 15.900M
            });

            return testBmiforAge;
        }

        /// <summary>
        /// Tests chart controller logic for HCFA chart data given new data point (x,y) when male.
        /// </summary>
        [Fact]
        public async Task GetHCFA_MaleNewXNewY_ShouldReturnAllMale()
        {
            List<HcForAge> expected = GetAllHCFA_Male();

            var controller = new ChartController(_context);
            var target = await controller.GetAllHCFA(1, 12, 73.00M) as List<HcForAge>;

            Assert.Equal(61, target.Count);

            var actual = (from l in target select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);
            Assert.Equal(expected.FirstOrDefault().Month, actual.Month);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        /// <summary>
        /// Gets sample HCFA data for a male.
        /// </summary>
        /// <returns>Returns sample HCFA data for a male.</returns>
        private static List<HcForAge> GetAllHCFA_Male()
        {
            var testHcforAge = new List<HcForAge>();
            testHcforAge.Add(new HcForAge
            {
                Month = 0,
                Sex = 1,
                L = 1,
                M = 34.4618M,
                S = 0.03686M,
                Sd3neg = 30.700M,
                Sd2neg = 31.900M,
                Sd1neg = 33.200M,
                Sd0 = 34.500M,
                Sd1 = 35.700M,
                Sd2 = 37.000M,
                Sd3 = 38.300M,
                P3 = 32.100M,
                P15 = 33.100M,
                P50 = 34.500M,
                P85 = 35.800M,
                P97 = 36.900M
            });

            return testHcforAge;
        }

        /// <summary>
        /// Tests chart controller logic for HCFA chart data given new data point (x,y) when female.
        /// </summary>
        [Fact]
        public async Task GetHCFA_FemaleNewXNewY_ShouldReturnAllFemale()
        {
            List<HcForAge> expected = GetAllHCFA_Female();

            var controller = new ChartController(_context);
            var target = await controller.GetAllHCFA(2, 12, 73.00M) as List<HcForAge>;

            Assert.Equal(61, target.Count);

            var actual = (from l in target select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);
            Assert.Equal(expected.FirstOrDefault().Month, actual.Month);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        /// <summary>
        /// Gets sample HCFA data for a female.
        /// </summary>
        /// <returns>Returns sample HCFA data for a female.</returns>
        private static List<HcForAge> GetAllHCFA_Female()
        {
            var testHcforAge = new List<HcForAge>();
            testHcforAge.Add(new HcForAge
            {
                Month = 0,
                Sex = 2,
                L = 1,
                M = 33.8787M,
                S = 0.03496M,
                Sd3neg = 30.300M,
                Sd2neg = 31.500M,
                Sd1neg = 32.700M,
                Sd0 = 33.900M,
                Sd1 = 35.100M,
                Sd2 = 36.200M,
                Sd3 = 37.400M,
                P3 = 31.700M,
                P15 = 32.700M,
                P50 = 33.900M,
                P85 = 35.100M,
                P97 = 36.100M
            });

            return testHcforAge;
        }

        /// <summary>
        /// Tests chart controller logic for LHFA chart data given new data point (x,y) when male.
        /// </summary>
        [Fact]
        public async Task GetLHFA_MaleNewXNewY_ShouldReturnAllMale()
        {
            List<LengthHeightForAge> expected = GetAllLHFA_Male();

            var controller = new ChartController(_context);
            var target = await controller.GetAllLHFA(1, 12, 73) as List<LengthHeightForAge>;

            Assert.Equal(62, target.Count);

            var actual = (from l in target select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);
            Assert.Equal(expected.FirstOrDefault().Month, actual.Month);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        /// <summary>
        /// Gets sample LHFA data for a male.
        /// </summary>
        /// <returns>Returns sample LHFA data for a male.</returns>
        private static List<LengthHeightForAge> GetAllLHFA_Male()
        {
            var testLhfaforAge = new List<LengthHeightForAge>();
            testLhfaforAge.Add(new LengthHeightForAge
            {
                Month = 0,
                Sex = 1,
                L = 1,
                M = 49.8842M,
                S = 0.03795M,
                Sd3neg = 44.200M,
                Sd2neg = 46.100M,
                Sd0 = 49.900M,
                Sd2 = 53.700M,
                Sd3 = 55.600M,
                P3 = 46.300M,
                P15 = 47.900M,
                P50 = 49.900M,
                P85 = 51.800M,
                P97 = 53.400M
            });

            return testLhfaforAge;
        }

        /// <summary>
        /// Tests chart controller logic for LHFA chart data given new data point (x,y) when female.
        /// </summary>
        [Fact]
        public async Task GetLHFA_FemaleNewXNewY_ShouldReturnAllFemale()
        {
            List<LengthHeightForAge> expected = GetAllLHFA_Female();

            var controller = new ChartController(_context);
            var target = await controller.GetAllLHFA(2, 12, 73) as List<LengthHeightForAge>;

            Assert.Equal(62, target.Count);

            var actual = (from l in target select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);
            Assert.Equal(expected.FirstOrDefault().Month, actual.Month);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        /// <summary>
        /// Gets sample LHFA data for a female.
        /// </summary>
        /// <returns>Returns sample LHFA data for a female.</returns>
        private static List<LengthHeightForAge> GetAllLHFA_Female()
        {
            var testLhfaforAge = new List<LengthHeightForAge>();
            testLhfaforAge.Add(new LengthHeightForAge
            {
                Month = 0,
                Sex = 2,
                L = 1,
                M = 49.1477M,
                S = 0.03790M,
                Sd3neg = 43.600M,
                Sd2neg = 45.400M,
                Sd0 = 49.100M,
                Sd2 = 52.900M,
                Sd3 = 54.700M,
                P3 = 45.600M,
                P15 = 47.200M,
                P50 = 49.100M,
                P85 = 51.100M,
                P97 = 52.700M
            });

            return testLhfaforAge;
        }

        /// <summary>
        /// Tests chart controller logic for MUAC chart data given new data point (x,y) when male.
        /// </summary>
        [Fact]
        public async Task GetMUAC_MaleNewXNewY_ShouldReturnAllMale()
        {
            List<MuacforAge> expected = GetAllMUAC_Male();

            var controller = new ChartController(_context);
            var target = await controller.GetAllMUAC(1, 12, 15) as List<MuacforAge>;

            Assert.Equal(58, target.Count);

            var actual = (from l in target select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);
            Assert.Equal(expected.FirstOrDefault().Month, actual.Month);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        /// <summary>
        /// Gets sample MUAC data for a male.
        /// </summary>
        /// <returns>Returns sample MUAC data for a male.</returns>
        private static List<MuacforAge> GetAllMUAC_Male()
        {
            var testMuacforAge = new List<MuacforAge>();
            testMuacforAge.Add(new MuacforAge
            {
                Month = 3,
                Sex = 1,
                L = 0.3928M,
                M = 13.4817M,
                S = 0.07475M,
                Sd3neg = 10.700M,
                Sd2neg = 11.600M,
                Sd1neg = 12.500M,
                Sd0 = 13.500M,
                Sd1 = 14.500M,
                Sd2 = 15.600M,
                Sd3 = 16.700M,
                P3 = 11.700M,
                P15 = 12.500M,
                P50 = 13.500M,
                P85 = 14.600M,
                P97 = 15.500M
            });

            return testMuacforAge;
        }

        /// <summary>
        /// Tests chart controller logic for MUAC chart data given new data point (x,y) when female.
        /// </summary>
        [Fact]
        public async Task GetMUAC_FemaleNewXNewY_ShouldReturnAllFemale()
        {
            List<MuacforAge> expected = GetAllMUAC_Female();

            var controller = new ChartController(_context);
            var target = await controller.GetAllMUAC(2, 12, 15) as List<MuacforAge>;

            Assert.Equal(58, target.Count);

            var actual = (from l in target select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);
            Assert.Equal(expected.FirstOrDefault().Month, actual.Month);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        /// <summary>
        /// Gets sample MUAC data for a female.
        /// </summary>
        /// <returns>Returns sample MUAC data for a female.</returns>
        private static List<MuacforAge> GetAllMUAC_Female()
        {
            var testMuacforAge = new List<MuacforAge>();
            testMuacforAge.Add(new MuacforAge
            {
                Month = 3,
                Sex = 2,
                L = -0.1733M,
                M = 13.0284M,
                S = 0.08263M,
                Sd3neg = 10.200M,
                Sd2neg = 11.100M,
                Sd1neg = 12.000M,
                Sd0 = 13.000M,
                Sd1 = 14.200M,
                Sd2 = 15.400M,
                Sd3 = 16.800M,
                P3 = 11.200M,
                P15 = 12.000M,
                P50 = 13.000M,
                P85 = 14.200M,
                P97 = 15.300M
            });

            return testMuacforAge;
        }

        /// <summary>
        /// Tests chart controller logic for SSFA chart data given new data point (x,y) when male.
        /// </summary>
        [Fact]
        public async Task GetSSFA_MaleNewXNewY_ShouldReturnAllMale()
        {
            List<SsfforAge> expected = GetAllSSFA_Male();

            var controller = new ChartController(_context);
            var target = await controller.GetAllSSFA(1, 12, 7) as List<SsfforAge>;

            Assert.Equal(58, target.Count);

            var actual = (from l in target select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);
            Assert.Equal(expected.FirstOrDefault().Month, actual.Month);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        /// <summary>
        /// Gets sample SSFA data for a male.
        /// </summary>
        /// <returns>Returns sample SSFA data for a male.</returns>
        private static List<SsfforAge> GetAllSSFA_Male()
        {
            var testSSFforAge = new List<SsfforAge>();
            testSSFforAge.Add(new SsfforAge
            {
                Month = 3,
                Sex = 1,
                L = -0.3033M,
                M = 7.6899M,
                S = 0.17020M,
                Sd3neg = 4.800M,
                Sd2neg = 5.600M,
                Sd1neg = 6.500M,
                Sd0 = 7.700M,
                Sd1 = 9.200M,
                Sd2 = 11.000M,
                Sd3 = 13.400M,
                P3 = 5.700M,
                P15 = 6.500M,
                P50 = 7.700M,
                P85 = 9.200M,
                P97 = 10.800M
            });

            return testSSFforAge;
        }

        /// <summary>
        /// Tests chart controller logic for SSFA chart data given new data point (x,y) when female.
        /// </summary>
        [Fact]
        public async Task GetSSFA_FemaleNewXNewY_ShouldReturnAllFemale()
        {
            List<SsfforAge> expected = GetAllSSFA_Female();

            var controller = new ChartController(_context);
            var target = await controller.GetAllSSFA(2, 12, 7) as List<SsfforAge>;

            Assert.Equal(58, target.Count);

            var actual = (from l in target select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);
            Assert.Equal(expected.FirstOrDefault().Month, actual.Month);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        /// <summary>
        /// Gets sample SSFA data for a female.
        /// </summary>
        /// <returns>Returns sample SSFA data for a female.</returns>
        private static List<SsfforAge> GetAllSSFA_Female()
        {
            var testSSFforAge = new List<SsfforAge>();
            testSSFforAge.Add(new SsfforAge
            {
                Month = 3,
                Sex = 2,
                L = -0.2026M,
                M = 7.7846M,
                S = 0.18428M,
                Sd3neg = 4.600M,
                Sd2neg = 5.500M,
                Sd1neg = 6.500M,
                Sd0 = 7.800M,
                Sd1 = 9.400M,
                Sd2 = 11.400M,
                Sd3 = 14.000M,
                P3 = 5.600M,
                P15 = 6.500M,
                P50 = 7.800M,
                P85 = 9.500M,
                P97 = 11.200M
            });

            return testSSFforAge;
        }

        /// <summary>
        /// Tests chart controller logic for TSFA chart data given new data point (x,y) when male.
        /// </summary>
        [Fact]
        public async Task GetTSFA_MaleNewXNewY_ShouldReturnAllMale()
        {
            List<TsfforAge> expected = GetAllTSFA_Male();

            var controller = new ChartController(_context);
            var target = await controller.GetAllTSFA(1, 12, 8) as List<TsfforAge>;

            Assert.Equal(58, target.Count);

            var actual = (from l in target select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);
            Assert.Equal(expected.FirstOrDefault().Month, actual.Month);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        /// <summary>
        /// Gets sample TSFA data for a male.
        /// </summary>
        /// <returns>Returns sample TSFA data for a male.</returns>
        private static List<TsfforAge> GetAllTSFA_Male()
        {
            var testTsfforAge = new List<TsfforAge>();
            testTsfforAge.Add(new TsfforAge
            {
                Month = 3,
                Sex = 1,
                L = 0.0027M,
                M = 9.7639M,
                S = 0.16618M,
                Sd3neg = 5.900M,
                Sd2neg = 7.000M,
                Sd1neg = 8.300M,
                Sd0 = 9.800M,
                Sd1 = 11.500M,
                Sd2 = 13.600M,
                Sd3 = 16.100M,
                P3 = 7.100M,
                P15 = 8.200M,
                P50 = 9.800M,
                P85 = 11.600M,
                P97 = 13.300M
            });

            return testTsfforAge;
        }

        /// <summary>
        /// Tests chart controller logic for TSFA chart data given new data point (x,y) when female.
        /// </summary>
        [Fact]
        public async Task GetTSFA_FemaleNewXNewY_ShouldReturnAllFemale()
        {
            List<TsfforAge> expected = GetAllTSFA_Female();

            var controller = new ChartController(_context);
            var target = await controller.GetAllTSFA(2, 12, 8) as List<TsfforAge>;

            Assert.Equal(58, target.Count);

            var actual = (from l in target select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);
            Assert.Equal(expected.FirstOrDefault().Month, actual.Month);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        /// <summary>
        /// Gets sample TSFA data for a female.
        /// </summary>
        /// <returns>Returns sample TSFA data for a female.</returns>
        private static List<TsfforAge> GetAllTSFA_Female()
        {
            var testTsfforAge = new List<TsfforAge>();
            testTsfforAge.Add(new TsfforAge
            {
                Month = 3,
                Sex = 2,
                L = 0.1875M,
                M = 9.7516M,
                S = 0.17535M,
                Sd3neg = 5.600M,
                Sd2neg = 6.800M,
                Sd1neg = 8.200M,
                Sd0 = 9.800M,
                Sd1 = 11.600M,
                Sd2 = 13.700M,
                Sd3 = 16.100M,
                P3 = 6.900M,
                P15 = 8.100M,
                P50 = 9.800M,
                P85 = 11.700M,
                P97 = 13.400M
            });

            return testTsfforAge;
        }

        /// <summary>
        /// Tests chart controller logic for WFA chart data given new data point (x,y) when male.
        /// </summary>
        [Fact]
        public async Task GetWFA_MaleNewXNewY_ShouldReturnAllMale()
        {
            List<WeightForAge> expected = GetAllWFA_Male();

            var controller = new ChartController(_context);
            var target = await controller.GetAllWFA(1, 12, 9) as List<WeightForAge>;

            Assert.Equal(61, target.Count);

            var actual = (from l in target select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);
            Assert.Equal(expected.FirstOrDefault().Month, actual.Month);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        /// <summary>
        /// Gets sample WFA data for a male.
        /// </summary>
        /// <returns>Returns sample WFA data for a male.</returns>
        private static List<WeightForAge> GetAllWFA_Male()
        {
            var testWeightForAge = new List<WeightForAge>();
            testWeightForAge.Add(new WeightForAge
            {
                Month = 0,
                Sex = 1,
                L = 0.3487M,
                M = 3.3464M,
                S = 0.14602M,
                Sd3neg = 2.100M,
                Sd2neg = 2.500M,
                Sd0 = 3.300M,
                Sd2 = 4.400M,
                Sd3 = 5.000M,
                P3 = 2.500M,
                P15 = 2.900M,
                P50 = 3.300M,
                P85 = 3.900M,
                P97 = 4.300M
            });

            return testWeightForAge;
        }

        /// <summary>
        /// Tests chart controller logic for WFA chart data given new data point (x,y) when female.
        /// </summary>
        [Fact]
        public async Task GetWFA_FemaleNewXNewY_ShouldReturnAllFemale()
        {
            List<WeightForAge> expected = GetAllWFA_Female();

            var controller = new ChartController(_context);
            var target = await controller.GetAllWFA(2, 12, 9) as List<WeightForAge>;

            Assert.Equal(61, target.Count);

            var actual = (from l in target select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);
            Assert.Equal(expected.FirstOrDefault().Month, actual.Month);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        /// <summary>
        /// Gets sample WFA data for a female.
        /// </summary>
        /// <returns>Returns sample WFA data for a female.</returns>
        private static List<WeightForAge> GetAllWFA_Female()
        {
            var testWeightForAge = new List<WeightForAge>();
            testWeightForAge.Add(new WeightForAge
            {
                Month = 0,
                Sex = 2,
                L = 0.3809M,
                M = 3.2322M,
                S = 0.14171M,
                Sd3neg = 2.000M,
                Sd2neg = 2.400M,
                Sd0 = 3.200M,
                Sd2 = 4.200M,
                Sd3 = 4.800M,
                P3 = 2.400M,
                P15 = 2.800M,
                P50 = 3.200M,
                P85 = 3.700M,
                P97 = 4.200M
            });

            return testWeightForAge;
        }

        /// <summary>
        /// Tests chart controller logic for WFH chart data given new data point (x,y) when male.
        /// </summary>
        [Fact]
        public async Task GetWFH_MaleNewXNewY_ShouldReturnAllMale()
        {
            List<WeightForHeight> expected = GetAllWFH_Male();

            var controller = new ChartController(_context);
            var target = await controller.GetAllWFH(1, 73, 9) as List<WeightForHeight>;

            Assert.Equal(111, target.Count);

            var actual = (from l in target select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);
            Assert.Equal(expected.FirstOrDefault().Heightincm, actual.Heightincm);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        /// <summary>
        /// Gets sample WFH data for a male.
        /// </summary>
        /// <returns>Returns sample WFH data for a male.</returns>
        private static List<WeightForHeight> GetAllWFH_Male()
        {
            var testWeightForHeight = new List<WeightForHeight>();
            testWeightForHeight.Add(new WeightForHeight
            {
                Sex = 1,
                Heightincm = 65.0M,
                L = -0.3521M,
                M = 7.4327M,
                S = 0.08217M,
                Sd3neg = 5.900M,
                Sd2neg = 6.300M,
                Sd1neg = 6.900M,
                Sd0 = 7.400M,
                Sd1 = 8.100M,
                Sd2 = 8.800M,
                Sd3 = 9.600M,
                P3 = 6.400M,
                P15 = 6.800M,
                P50 = 7.400M,
                P85 = 8.100M,
                P97 = 8.700M
            });

            return testWeightForHeight;
        }

        /// <summary>
        /// Tests chart controller logic for WFH chart data given new interpolated data point (x,y) when male.
        /// </summary>
        [Fact]
        public async Task GetWFH_MaleNewXNewY_ShouldReturnInterpolated()
        {
            List<WeightForHeight> expected = GetWFH_Male_Interpolated_Row();

            var controller = new ChartController(_context);
            var target = await controller.GetAllWFH(1, 87.70M, 12.35M) as List<WeightForHeight>;

            Assert.Equal(111 + 1, target.Count);

            var actual = (from l in target where l.Score == 12.35M select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);
            Assert.Equal(expected.FirstOrDefault().Heightincm, actual.Heightincm);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.Equal(expected.FirstOrDefault().Score, actual.Score);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        /// <summary>
        /// Gets sample interpolated WFH data for a male.
        /// </summary>
        /// <returns>Returns sample interpolated WFH data for a male.</returns>
        private static List<WeightForHeight> GetWFH_Male_Interpolated_Row()
        {
            var testWeightForHeight = new List<WeightForHeight>();
            testWeightForHeight.Add(new WeightForHeight
            {
                Sex = 1,
                Heightincm = 87.70M,
                Score = 12.35M,
                L = null,
                M = null,
                S = null,
                Sd3neg = 9.750M,
                Sd2neg = 10.550M,
                Sd1neg = 11.400M,
                Sd0 = 12.350M,
                Sd1 = 13.400M,
                Sd2 = 14.600M,
                Sd3 = 15.900M,
                P3 = 10.650M,
                P15 = 11.350M,
                P50 = 12.350M,
                P85 = 13.450M,
                P97 = 14.450M
            });

            return testWeightForHeight;
        }

        /// <summary>
        /// Tests chart controller logic for WFH chart data given new data point (x,y) when female.
        /// </summary>
        [Fact]
        public async Task GetWFH_FemaleNewXNewY_ShouldReturnAllFemale()
        {
            List<WeightForHeight> expected = GetAllWFH_Female();

            var controller = new ChartController(_context);
            var target = await controller.GetAllWFH(2, 73, 9) as List<WeightForHeight>;

            Assert.Equal(111, target.Count);

            var actual = (from l in target select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);
            Assert.Equal(expected.FirstOrDefault().Heightincm, actual.Heightincm);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.Equal(expected.FirstOrDefault().Score, actual.Score);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        /// <summary>
        /// Gets sample WFH data for a female.
        /// </summary>
        /// <returns>Returns sample WFH data for a female.</returns>
        private static List<WeightForHeight> GetAllWFH_Female()
        {
            var testWeightForHeight = new List<WeightForHeight>();
            testWeightForHeight.Add(new WeightForHeight
            {
                Sex = 2,
                Heightincm = 65.0M,
                L = -0.3833M,
                M = 7.2402M,
                S = 0.09113M,
                Sd3neg = 5.600M,
                Sd2neg = 6.100M,
                Sd1neg = 6.600M,
                Sd0 = 7.200M,
                Sd1 = 7.900M,
                Sd2 = 8.700M,
                Sd3 = 9.700M,
                P3 = 6.100M,
                P15 = 6.600M,
                P50 = 7.200M,
                P85 = 8.000M,
                P97 = 8.600M
            });

            return testWeightForHeight;
        }

        /// <summary>
        /// Tests chart controller logic for WFH chart data given new interpolated data point (x,y) when male.
        /// </summary>
        [Fact]
        public async Task GetWFH_FemaleNewXNewY_ShouldReturnInterpolated()
        {
            List<WeightForHeight> expected = GetWFH_Female_Interpolated_Row();

            var controller = new ChartController(_context);
            var target = await controller.GetAllWFH(1, 87.70M, 12.35M) as List<WeightForHeight>;

            Assert.Equal(111 + 1, target.Count);

            var actual = (from l in target where l.Score == 12.35M select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);
            Assert.Equal(expected.FirstOrDefault().Heightincm, actual.Heightincm);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.Equal(expected.FirstOrDefault().Score, actual.Score);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        /// <summary>
        /// Gets sample interpolated WFH data for a female.
        /// </summary>
        /// <returns>Gets sample interpolated WFH data for a female.</returns>
        private static List<WeightForHeight> GetWFH_Female_Interpolated_Row()
        {
            var testWeightForHeight = new List<WeightForHeight>();
            testWeightForHeight.Add(new WeightForHeight
            {
                Sex = 1,
                Heightincm = 87.70M,
                Score = 12.35M,
                L = null,
                M = null,
                S = null,
                Sd3neg = 9.750M,
                Sd2neg = 10.550M,
                Sd1neg = 11.400M,
                Sd0 = 12.350M,
                Sd1 = 13.400M,
                Sd2 = 14.600M,
                Sd3 = 15.900M,
                P3 = 10.650M,
                P15 = 11.350M,
                P50 = 12.350M,
                P85 = 13.450M,
                P97 = 14.450M
            });

            return testWeightForHeight;
        }

        /// <summary>
        /// Tests chart controller logic for WFL chart data given new data point (x,y) when male.
        /// </summary>
        [Fact]
        public async Task GetWFL_MaleNewXNewY_ShouldReturnAllMale()
        {
            List<WeightForLength> expected = GetAllWFL_Male();

            var controller = new ChartController(_context);
            var target = await controller.GetAllWFL(1, 73.00M, 9.00M) as List<WeightForLength>;

            // + 1 represents added interpolated data row for scored line chart
            Assert.Equal(131, target.Count);

            var actual = (from l in target select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);
            Assert.Equal(expected.FirstOrDefault().Lengthincm, actual.Lengthincm);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        /// <summary>
        /// Gets sample WFL data for a male.
        /// </summary>
        /// <returns>Returns sample WFL data for a male.</returns>
        private static List<WeightForLength> GetAllWFL_Male()
        {
            var testWeightForLength = new List<WeightForLength>();
            testWeightForLength.Add(new WeightForLength
            {
                Lengthincm = 45.0M,
                Sex = 1,
                L = -0.3521M,
                M = 2.4410M,
                S = 0.09182M,
                Sd3neg = 1.900M,
                Sd2neg = 2.000M,
                Sd1neg = 2.400M,
                Sd0 = 2.400M,
                Sd1 = 2.700M,
                Sd2 = 3.000M,
                Sd3 = 3.300M,
                P3 = 2.100M,
                P15 = 2.200M,
                P50 = 2.400M,
                P85 = 2.700M,
                P97 = 2.900M
            });

            return testWeightForLength;
        }
        /// <summary>
        /// Tests chart controller logic for WFL chart data given new interpolated data point (x,y) when male.
        /// </summary>
        [Fact]
        public async Task GetWFL_MaleNewXNewY_ShouldReturnInterpolated()
        {
            List<WeightForLength> expected = GetWFL_Male_Interpolated_Row();

            var controller = new ChartController(_context);
            var target = await controller.GetAllWFL(1, 73.25M, 9.25M) as List<WeightForLength>;

            // + 1 represents added interpolated data row for scored line chart
            Assert.Equal(131 + 1, target.Count);

            var actual = (from l in target where l.Score == 9.25M select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);
            Assert.Equal(expected.FirstOrDefault().Lengthincm, actual.Lengthincm);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.Equal(expected.FirstOrDefault().Score, actual.Score);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        /// <summary>
        /// Gets sample intepolated WFL data for a male.
        /// </summary>
        /// <returns>Returns sample intepolated WFL data for a male.</returns>
        private static List<WeightForLength> GetWFL_Male_Interpolated_Row()
        {
            var testWeightForLength = new List<WeightForLength>();
            testWeightForLength.Add(new WeightForLength
            {
                Lengthincm = 73.25M,
                Score = 9.25M, 
                Sex = 1,
                L = null,
                M = null,
                S = null,
                Sd3neg = 7.200M,
                Sd2neg = 7.750M,
                Sd1neg = 8.450M,
                Sd0 = 9.150M,
                Sd1 = 9.950M,
                Sd2 = 10.850M,
                Sd3 = 16.850M,
                P3 = 7.850M,
                P15 = 8.400M,
                P50 = 9.150M,
                P85 = 9.950M,
                P97 = 10.750M
            });

            return testWeightForLength;
        }

        /// <summary>
        /// Tests chart controller logic for WFL chart data given new data point (x,y) when female.
        /// </summary>
        [Fact]
        public async Task GetWFL_FemaleNewXNewY_ShouldReturnAllFemale()
        {
            List<WeightForLength> expected = GetAllWFL_Female();

            var controller = new ChartController(_context);
            var target = await controller.GetAllWFL(2, 73.00M, 9.00M) as List<WeightForLength>;

            Assert.Equal(131, target.Count);

            var actual = (from l in target select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);
            Assert.Equal(expected.FirstOrDefault().Lengthincm, actual.Lengthincm);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        /// <summary>
        /// Gets sample WFL data for a female.
        /// </summary>
        /// <returns>Returns sample WFL data for a female.</returns>
        private static List<WeightForLength> GetAllWFL_Female()
        {
            var testWeightForLength = new List<WeightForLength>();
            testWeightForLength.Add(new WeightForLength
            {
                Lengthincm = 45.0M,
                Sex = 2,
                L = -0.3833M,
                M = 2.4607M,
                S = 0.09029M,
                Sd3neg = 1.900M,
                Sd2neg = 2.100M,
                Sd1neg = 2.300M,
                Sd0 = 2.500M,
                Sd1 = 2.700M,
                Sd2 = 3.000M,
                Sd3 = 3.300M,
                P3 = 2.100M,
                P15 = 2.200M,
                P50 = 2.500M,
                P85 = 2.700M,
                P97 = 2.900M
            });

            return testWeightForLength;
        }

        /// <summary>
        /// Tests chart controller logic for WFL chart data given new interpolated data point (x,y) when female.
        /// </summary>
        [Fact]
        public async Task GetWFL_FemaleNewXNewY_ShouldReturnInterpolated()
        {
            List<WeightForLength> expected = GetWFL_Female_Interpolated_Row();

            var controller = new ChartController(_context);
            var target = await controller.GetAllWFL(2, 73.25M, 9.25M) as List<WeightForLength>;

            Assert.Equal(131 + 1, target.Count);

            var actual = (from l in target where l.Score == 9.25M select l).FirstOrDefault();

            Assert.Equal((Sexes)expected.FirstOrDefault().Sex, (Sexes)actual.Sex);
            Assert.Equal(expected.FirstOrDefault().Lengthincm, actual.Lengthincm);
            Assert.Equal(expected.FirstOrDefault().M, actual.M);
            Assert.Equal(expected.FirstOrDefault().Sd0, actual.Sd0);
            Assert.Equal(expected.FirstOrDefault().P50, actual.P50);
            Assert.Equal(expected.FirstOrDefault().Score, actual.Score);
            Assert.InRange((decimal)actual.P97, 0, 100);
        }

        /// <summary>
        /// Gets sample interpolated WFL data for a female.
        /// </summary>
        /// <returns>Returns sample interpolated WFL data for a female.</returns>
        private static List<WeightForLength> GetWFL_Female_Interpolated_Row()
        {
            var testWeightForLength = new List<WeightForLength>();
            testWeightForLength.Add(new WeightForLength
            {
                Lengthincm = 73.25M,
                Sex = 2,
                Score = 9.25M,
                L = null,
                M = null,
                S = null,
                Sd3neg = 6.850M,
                Sd2neg = 7.400M,
                Sd1neg = 8.050M,
                Sd0 = 8.850M,
                Sd1 = 9.650M,
                Sd2 = 10.650M,
                Sd3 = 11.750M,
                P3 = 7.450M,
                P15 = 8.050M,
                P50 = 8.850M,
                P85 = 9.650M,
                P97 = 10.500M
            });

            return testWeightForLength;
        }
    }
}