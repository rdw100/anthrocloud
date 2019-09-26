using System;
using System.Collections.Generic;
using System.Linq;
using AnthroCloud.Data.Models;

namespace AnthroCloud.Data
{
    public class ChartDAC : IChartDAC
    {
        /// <summary>
        /// Gets a strongly typed typed list of WFA objects.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of WFA objects.</returns>
        public List<WeightForAge> ListWeightForAge(byte sex)
        {
            using var db = new AnthroCloudContext();

            IQueryable<WeightForAge> query = db.Set<WeightForAge>();

            query = query.Where(c => c.Sex == sex);

            return query.ToList();
        }

        /// <summary>
        /// Gets a strongly typed typed list of BFA objects.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of BFA objects.</returns>
        public List<BmiforAge> ListBmiforAge(byte sex)
        {
            using var db = new AnthroCloudContext();

            IQueryable<BmiforAge> query = db.Set<BmiforAge>();

            query = query.Where(c => c.Sex == sex);

            return query.ToList();
        }

        /// <summary>
        /// Gets a strongly typed typed list of WFL objects.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of WFL objects.</returns>
        public List<WeightForLength> ListWeightForLength(byte sex)
        {
            using var db = new AnthroCloudContext();

            IQueryable<WeightForLength> query = db.Set<WeightForLength>();

            query = query.Where(c => c.Sex == sex);

            return query.ToList();
        }

        /// <summary>
        /// Gets a strongly typed typed list of WFH objects.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of WFH objects.</returns>
        public List<WeightForHeight> ListWeightForHeight(byte sex)
        {
            using var db = new AnthroCloudContext();

            IQueryable<WeightForHeight> query = db.Set<WeightForHeight>();

            query = query.Where(c => c.Sex == sex);

            return query.ToList();
        }

        /// <summary>
        /// Gets a strongly typed typed list of HCFA objects.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of HCFA objects.</returns>
        public List<HcforAge> ListHcforAge(byte sex)
        {
            using var db = new AnthroCloudContext();

            IQueryable<HcforAge> query = db.Set<HcforAge>();

            query = query.Where(c => c.Sex == sex);

            return query.ToList();
        }

        /// <summary>
        /// Gets a strongly typed typed list of LHFA objects.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of LHFA objects.</returns>
        public List<LengthHeightForAge> ListLengthHeightForAge(byte sex)
        {
            using var db = new AnthroCloudContext();

            IQueryable<LengthHeightForAge> query = db.Set<LengthHeightForAge>();

            query = query.Where(c => c.Sex == sex);

            return query.ToList();
        }

        /// <summary>
        /// Gets a strongly typed typed list of MUAC objects.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of MUAC objects.</returns>
        public List<MuacforAge> ListMuacforAge(byte sex)
        {
            using var db = new AnthroCloudContext();

            IQueryable<MuacforAge> query = db.Set<MuacforAge>();

            query = query.Where(c => c.Sex == sex);

            return query.ToList();
        }

        /// <summary>
        /// Gets a strongly typed typed list of SSF objects.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of SSF objects.</returns>
        public List<SsfforAge> ListSsfforAge(byte sex)
        {
            using var db = new AnthroCloudContext();

            IQueryable<SsfforAge> query = db.Set<SsfforAge>();

            query = query.Where(c => c.Sex == sex);

            return query.ToList();
        }

        /// <summary>
        /// Gets a strongly typed typed list of TSF objects.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of TSF objects.</returns>
        public List<TsfforAge> ListTsfforAge(byte sex)
        {
            using var db = new AnthroCloudContext();

            IQueryable<TsfforAge> query = db.Set<TsfforAge>();

            query = query.Where(c => c.Sex == sex);

            return query.ToList();
        }
    }
}
