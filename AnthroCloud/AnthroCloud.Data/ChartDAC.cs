using AnthroCloud.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnthroCloud.Data
{
    /// <summary>
    /// Represents the standard operations to be performed by the Chart data access object.
    /// </summary>
    public class ChartDAC : IChartDAC
    {
        private readonly AnthroCloudContextMySql _context;
        
        public ChartDAC() { }

        /// <summary>
        /// Constructs controller with database context.
        /// </summary>
        /// <param name="context">The database context</param>
        public ChartDAC(AnthroCloudContextMySql context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
            _context.ChangeTracker.LazyLoadingEnabled = false;
        }

        /// <summary>
        /// Gets a strongly typed typed list of WFA objects.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of WFA objects.</returns>
        public async Task<List<WeightForAge>> ListWeightForAge(Sexes sex)
        {
            byte paramSex = (byte)sex;

            IQueryable<WeightForAge> query = _context.Set<WeightForAge>().AsNoTracking();

            query = query.Where(c => c.Sex == paramSex);

            return await query.ToListAsync();
        }

        /// <summary>
        /// Gets a strongly typed typed list of BFA objects.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of BFA objects.</returns>
        public async Task<List<BmiforAge>> ListBmiforAge(Sexes sex)
        {
            byte paramSex = (byte)sex;

            IQueryable<BmiforAge> query = _context.Set<BmiforAge>().AsNoTracking();

            query = query.Where(c => c.Sex == paramSex);

            return await query.ToListAsync(); //.ToList();
        }

        /// <summary>
        /// Gets a strongly typed typed list of WFL objects.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of WFL objects.</returns>
        public async Task<List<WeightForLength>> ListWeightForLength(Sexes sex)
        {
            byte paramSex = (byte)sex;

            IQueryable<WeightForLength> query = _context.Set<WeightForLength>().AsNoTracking();

            query = query.Where(c => c.Sex == paramSex);

            return await query.ToListAsync();
        }

        /// <summary>
        /// Gets a strongly typed typed list of WFH objects.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of WFH objects.</returns>
        public async Task<List<WeightForHeight>> ListWeightForHeight(Sexes sex)
        {
            byte paramSex = (byte)sex;

            IQueryable<WeightForHeight> query = _context.Set<WeightForHeight>().AsNoTracking();

            query = query.Where(c => c.Sex == paramSex);

            return await query.ToListAsync();
        }

        /// <summary>
        /// Gets a strongly typed typed list of HCFA objects.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of HCFA objects.</returns>
        public async Task<List<HcForAge>> ListHcforAge(Sexes sex)
        {
            byte paramSex = (byte)sex;

            IQueryable<HcForAge> query = _context.Set<HcForAge>().AsNoTracking();

            query = query.Where(c => c.Sex == paramSex);

            return await query.ToListAsync();
        }

        /// <summary>
        /// Gets a strongly typed typed list of LHFA objects.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of LHFA objects.</returns>
        public async Task<List<LengthHeightForAge>> ListLengthHeightForAge(Sexes sex)
        {
            byte paramSex = (byte)sex;

            IQueryable<LengthHeightForAge> query = _context.Set<LengthHeightForAge>().AsNoTracking();

            query = query.Where(c => c.Sex == paramSex);

            return await query.ToListAsync();
        }

        /// <summary>
        /// Gets a strongly typed typed list of MUAC objects.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of MUAC objects.</returns>
        public async Task<List<MuacforAge>> ListMuacforAge(Sexes sex)
        {
            byte paramSex = (byte)sex;

            IQueryable<MuacforAge> query = _context.Set<MuacforAge>().AsNoTracking();

            query = query.Where(c => c.Sex == paramSex);

            return await query.ToListAsync();
        }

        /// <summary>
        /// Gets a strongly typed typed list of SSF objects.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of SSF objects.</returns>
        public async Task<List<SsfforAge>> ListSsfforAge(Sexes sex)
        {
            byte paramSex = (byte)sex;

            IQueryable<SsfforAge> query = _context.Set<SsfforAge>().AsNoTracking();

            query = query.Where(c => c.Sex == paramSex);

            return await query.ToListAsync();
        }

        /// <summary>
        /// Gets a strongly typed typed list of TSF objects.
        /// </summary>
        /// <param name="sex">Filters by ISO/IEC 5218 standard (1 = male, 2 = female)</param>
        /// <returns>Returns a strongly typed list of TSF objects.</returns>
        public async Task<List<TsfforAge>> ListTsfforAge(Sexes sex)
        {
            byte paramSex = (byte)sex;
            
            IQueryable<TsfforAge> query = _context.Set<TsfforAge>().AsNoTracking();
            
            query = query.Where(c => c.Sex == paramSex);

            return await query.ToListAsync();
        }
    }
}
