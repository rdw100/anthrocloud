using AnthroCloud.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnthroCloud.Data
{
    /// <summary>
    /// Defines the standard operations to be performed by the Chart data access object.
    /// </summary>
    /// <remarks>This data access component accesses WHO Child Growth Table data.
    /// BFA  - Body mass index-for-age (BMI-for-age)
    /// HCA  - Head circumference-for-age
    /// LHFA - Length Height for Age
    /// MUAC - Mid-Upper Arm Circumference
    /// SSF  - Subscapular skinfold-for-age
    /// TSF  - Triceps skinfold-for-age
    /// WFA  - Weight-for-age
    /// WFH  - Weight-for-height
    /// WFL  - Weight-for-length
    /// </remarks>
    public interface IChartDAC
    {
        /// <summary>
        /// Defines method to filter and return WFA data.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of WFA objects.</returns>
        public Task<List<WeightForAge>> ListWeightForAge(Sexes sex);

        /// <summary>
        /// Defines method to filter and return WFL data.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of WFL objects.</returns>
        public Task<List<WeightForLength>> ListWeightForLength(Sexes sex);

        /// <summary>
        /// Defines method to filter and return WFH data.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of WFH objects.</returns>
        public Task<List<WeightForHeight>> ListWeightForHeight(Sexes sex);

        /// <summary>
        /// Defines method to filter and return BFA data.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of BFA objects.</returns>
        public Task<List<BmiforAge>> ListBmiforAge(Sexes sex);

        /// <summary>
        /// Defines method to filter and return HCFA data.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of HCFA objects.</returns>
        public Task<List<HcForAge>> ListHcforAge(Sexes sex);

        /// <summary>
        /// Defines method to filter and return LHFA data.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of LHFA objects.</returns>
        public Task<List<LengthHeightForAge>> ListLengthHeightForAge(Sexes sex);

        /// <summary>
        /// Defines method to filter and return Muac data.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of Muac objects.</returns>
        public Task<List<MuacforAge>> ListMuacforAge(Sexes sex);

        /// <summary>
        /// Defines method to filter and return SSF data.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of SSF objects.</returns>
        public Task<List<SsfforAge>> ListSsfforAge(Sexes sex);

        /// <summary>
        /// Defines method to filter and return TSF data.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of TSF objects.</returns>
        public Task<List<TsfforAge>> ListTsfforAge(Sexes sex);
    }
}
