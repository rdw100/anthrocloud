using System;
using System.Collections.Generic;
using System.Text;
using AnthroCloud.Data.Models;

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
        public List<WeightForAge> ListWeightForAge(byte sex);

        /// <summary>
        /// Defines method to filter and return WFL data.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of WFL objects.</returns>
        public List<WeightForLength> ListWeightForLength(byte sex);

        /// <summary>
        /// Defines method to filter and return WFH data.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of WFH objects.</returns>
        public List<WeightForHeight> ListWeightForHeight(byte sex);

        /// <summary>
        /// Defines method to filter and return BFA data.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of BFA objects.</returns>
        public List<BmiforAge> ListBmiforAge(byte sex);

        /// <summary>
        /// Defines method to filter and return HCFA data.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of HCFA objects.</returns>
        public List<HcforAge> ListHcforAge(byte sex);

        /// <summary>
        /// Defines method to filter and return LHFA data.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of LHFA objects.</returns>
        public List<LengthHeightForAge> ListLengthHeightForAge(byte sex);

        /// <summary>
        /// Defines method to filter and return Muac data.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of Muac objects.</returns>
        public List<MuacforAge> ListMuacforAge(byte sex);

        /// <summary>
        /// Defines method to filter and return SSF data.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of SSF objects.</returns>
        public List<SsfforAge> ListSsfforAge(byte sex);

        /// <summary>
        /// Defines method to filter and return TSF data.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of TSF objects.</returns>
        public List<TsfforAge> ListTsfforAge(byte sex);
    }
}
