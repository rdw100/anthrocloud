using System;
using System.Collections.Generic;
using System.Linq;
using AnthroCloud.Entities;

namespace AnthroCloud.Data
{
    /// <summary>
    /// Represents the standard operations to be performed by the Chart data access object.
    /// </summary>
    public class ChartDAC : IChartDAC
    {
        /// <summary>
        /// Gets a strongly typed typed list of WFA objects.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of WFA objects.</returns>
        public List<WeightForAge> ListWeightForAge(Sexes sex)
        {
            using var db = new AnthroCloudContextMySql();

            IQueryable<WeightForAge> query = db.Set<WeightForAge>();

            query = query.Where(c => c.Sex == (byte)sex);

            return query.ToList();
        }

        /// <summary>
        /// Gets a strongly typed typed list of BFA objects.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of BFA objects.</returns>
        public List<BmiforAge> ListBmiforAge(Sexes sex)
        {
            using var db = new AnthroCloudContextMySql();

            IQueryable<BmiforAge> query = db.Set<BmiforAge>();

            query = query.Where(c => c.Sex == (byte)sex);

            return query.ToList();
        }

        /// <summary>
        /// Gets a strongly typed typed list of WFL objects.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of WFL objects.</returns>
        public List<WeightForLength> ListWeightForLength(Sexes sex)
        {
            using var db = new AnthroCloudContextMySql();

            IQueryable<WeightForLength> query = db.Set<WeightForLength>();

            query = query.Where(c => c.Sex == (byte)sex);

            return query.ToList();
        }

        /// <summary>
        /// Gets a strongly typed typed list of WFH objects.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of WFH objects.</returns>
        public List<WeightForHeight> ListWeightForHeight(Sexes sex)
        {
            using var db = new AnthroCloudContextMySql();

            IQueryable<WeightForHeight> query = db.Set<WeightForHeight>();

            query = query.Where(c => c.Sex == (byte)sex);

            return query.ToList();
        }

        /// <summary>
        /// Gets a strongly typed typed list of HCFA objects.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of HCFA objects.</returns>
        public List<HcForAge> ListHcforAge(Sexes sex)
        {
            using var db = new AnthroCloudContextMySql();

            IQueryable<HcForAge> query = db.Set<HcForAge>();

            query = query.Where(c => c.Sex == (byte)sex);

            return query.ToList();
        }

        /// <summary>
        /// Gets a strongly typed typed list of LHFA objects.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of LHFA objects.</returns>
        public List<LengthHeightForAge> ListLengthHeightForAge(Sexes sex)
        {
            using var db = new AnthroCloudContextMySql();

            IQueryable<LengthHeightForAge> query = db.Set<LengthHeightForAge>();

            query = query.Where(c => c.Sex == (byte)sex);

            return query.ToList();
        }

        /// <summary>
        /// Gets a strongly typed typed list of MUAC objects.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of MUAC objects.</returns>
        public List<MuacforAge> ListMuacforAge(Sexes sex)
        {
            using var db = new AnthroCloudContextMySql();

            IQueryable<MuacforAge> query = db.Set<MuacforAge>();

            query = query.Where(c => c.Sex == (byte)sex);

            return query.ToList();
        }

        /// <summary>
        /// Gets a strongly typed typed list of SSF objects.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of SSF objects.</returns>
        public List<SsfforAge> ListSsfforAge(Sexes sex)
        {
            using var db = new AnthroCloudContextMySql();

            IQueryable<SsfforAge> query = db.Set<SsfforAge>();

            query = query.Where(c => c.Sex == (byte)sex);

            return query.ToList();
        }

        /// <summary>
        /// Gets a strongly typed typed list of TSF objects.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of TSF objects.</returns>
        public List<TsfforAge> ListTsfforAge(Sexes sex)
        {
            using var db = new AnthroCloudContextMySql();

            IQueryable<TsfforAge> query = db.Set<TsfforAge>();

            query = query.Where(c => c.Sex == (byte)sex);

            return query.ToList();
        }
    }
}
