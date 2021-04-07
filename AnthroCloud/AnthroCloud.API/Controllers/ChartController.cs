using AnthroCloud.Business;
using AnthroCloud.Entities;
using AnthroCloud.Entities.Charts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace AnthroCloud.API.Controllers
{
    /// <summary>
    /// Provides chart data for displaying individual measurements.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private AnthroCloudContextMsSql _context;

        /// <summary>
        /// Solely constructs controller with database context.
        /// </summary>
        /// <param name="ctx">The database context</param>
        public ChartController(AnthroCloudContextMsSql context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets chart data for the Body mass index (BMI) for age indicator.
        /// </summary>
        /// <param name="id">Sex</param>
        /// <param name="x">X-axis data point</param>
        /// <param name="y">Y-axis data point</param>
        /// <returns>Returns chart data for the Body mass index (BMI) for age indicator.</returns>
        /// <example>
        /// GET: api/Chart/BFA/1
        /// GET: api/chart/BFA/1/12/16.9
        /// </example>
        [HttpGet("{id}")]
        [Route("BFA/{id}")]
        [Route("BFA/{id}/{x}/{y}")]
        public async Task<List<BmiforAge>> GetAllBFA(byte id, byte x, decimal y)
        {
            Chart chart = new Chart(_context);
            List<BmiforAge> result = await chart.ListBmiforAgeAsync((Sexes)id, x, y);
            return result;
        }

        /// <summary>
        /// Gets chart data for the Head circumference-for-age indicator.
        /// </summary>
        /// <param name="id">Sex</param>
        /// <param name="x">X-axis data point</param>
        /// <param name="y">Y-axis data point</param>
        /// <returns>Returns chart data for the Head circumference-for-age indicator.</returns>
        /// <example>GET: api/Chart/HCFA/1</example>
        [HttpGet("{id}")]
        [Route("HCFA/{id}")]
        [Route("HCFA/{id}/{x}/{y}")]
        public async Task<List<HcForAge>> GetAllHCFA(byte id, byte x, decimal y)
        {
            Chart chart = new Chart(_context);
            List<HcForAge> result = await chart.ListHcforAge((Sexes)id, x, y);
            return result;
        }

        /// <summary>
        /// Gets chart data for the Length/height-for-age indicator.
        /// </summary>
        /// <param name="id">Sex</param>
        /// <param name="x">X-axis data point</param>
        /// <param name="y">Y-axis data point</param>
        /// <returns>Returns chart data for the Length/height-for-age indicator.</returns>
        /// <example>GET: api/Chart/LHFA/1</example>
        [HttpGet("{id}")]
        [Route("LHFA/{id}")]
        [Route("LHFA/{id}/{x}/{y}")]
        public async Task<List<LengthHeightForAge>> GetAllLHFA(byte id, byte x, decimal y)
        {
            Chart chart = new Chart(_context);
            List<LengthHeightForAge> result = await chart.ListLengthHeightForAge((Sexes)id, x, y);
            return result;
        }

        /// <summary>
        /// Gets chart data for the Arm circumference-for-age indicator.
        /// </summary>
        /// <param name="id">Sex</param>
        /// <param name="x">X-axis data point</param>
        /// <param name="y">Y-axis data point</param>
        /// <returns>Returns chart data for the Arm circumference-for-age indicator.</returns>
        /// <example>GET: api/Chart/MUAC/1</example>
        [HttpGet("{id}")]
        [Route("MUAC/{id}")]
        [Route("MUAC/{id}/{x}/{y}")]
        public async Task<List<MuacforAge>> GetAllMUAC(byte id, byte x, decimal y)
        {
            Chart chart = new Chart(_context);
            List<MuacforAge> result = await chart.ListMuacforAge((Sexes)id, x, y);
            return result;
        }

        /// <summary>
        /// Gets chart data for the Subscapular skinfold-for-age indicator.
        /// </summary>
        /// <param name="id">Sex</param>
        /// <param name="x">X-axis data point</param>
        /// <param name="y">Y-axis data point</param>
        /// <returns>Returns chart data for the Subscapular skinfold-for-age indicator.</returns>
        /// <example>GET: api/Chart/SSFA/1</example>
        [HttpGet("{id}")]
        [Route("SSFA/{id}")]
        [Route("SSFA/{id}/{x}/{y}")]
        public async Task<List<SsfforAge>> GetAllSSFA(byte id, byte x, decimal y)
        {
            Chart chart = new Chart(_context);
            List<SsfforAge> result = await chart.ListSsfforAge((Sexes)id, x, y);
            return result;
        }

        /// <summary>
        /// Gets chart data for the Triceps skinfold-for-age indicator.
        /// </summary>
        /// <param name="id">Sex</param>
        /// <param name="x">X-axis data point</param>
        /// <param name="y">Y-axis data point</param>
        /// <returns>Retrieve chart data for the Triceps skinfold-for-age indicator.</returns>
        /// <example>GET: api/Chart/TSFA/1</example>
        [HttpGet("{id}")]
        [Route("TSFA/{id}")]
        [Route("TSFA/{id}/{x}/{y}")]
        public async Task<List<TsfforAge>> GetAllTSFA(byte id, byte x, decimal y)
        {
            Chart chart = new Chart(_context);
            List<TsfforAge> result = await chart.ListTsfforAge((Sexes)id, x, y);
            return result;
        }

        /// <summary>
        /// Gets chart data for the Weight-for-age indicator.
        /// </summary>
        /// <param name="id">Sex</param>
        /// <param name="x">X-axis data point</param>
        /// <param name="y">Y-axis data point</param>
        /// <returns>Returns chart data for the Weight-for-age indicator.</returns>
        /// <example>GET: api/Chart/WFA/1</example>
        [HttpGet("{id}")]
        [Route("WFA/{id}")]
        [Route("WFA/{id}/{x}/{y}")]
        public async Task<List<WeightForAge>> GetAllWFA(byte id, byte x, decimal y)
        {
            Chart chart = new Chart(_context);
            List<WeightForAge> result = await chart.ListWeightForAge((Sexes)id, x, y);
            return result;
        }

        /// <summary>
        /// Gets chart data for the Weight-for-height indicator.
        /// </summary>
        /// <param name="id">Sex</param>
        /// <param name="x">X-axis data point</param>
        /// <param name="y">Y-axis data point</param>
        /// <returns>Returns chart data for the Weight-for-height indicator.</returns>
        /// <example>GET: api/Chart/WFH/1</example>
        [HttpGet("{id}")]
        [Route("WFH/{id}")]
        [Route("WFH/{id}/{x}/{y}")]
        public async Task<List<WeightForHeight>> GetAllWFH(byte id, decimal x, decimal y)
        {
            Chart chart = new Chart(_context);
            List<WeightForHeight> result = await chart.ListWeightForHeight((Sexes)id, x, y);
            return result;
        }

        /// <summary>
        /// Gets chart data for the Weight-for-length indicator.
        /// </summary>
        /// <param name="id">Sex</param>
        /// <param name="x">X-axis data point</param>
        /// <param name="y">Y-axis data point</param>
        /// <returns>Returns chart data for the Weight-for-length indicator.</returns>
        /// <example>GET: api/Chart/WFL/1</example>
        [HttpGet("{id}")]
        [Route("WFL/{id}")]
        [Route("WFL/{id}/{x}/{y}")]
        public async Task<List<WeightForLength>> GetAllWFL(byte id, decimal x, decimal y)
        {
            Chart chart = new Chart(_context);
            List<WeightForLength> result = await chart.ListWeightForLength((Sexes)id, x, y);
            return result;
        }

        /// <summary>
        /// Gets Body mass index (BMI) for age indicator chart data as a JSON 
        /// serialized DataTable structure to pass into Chart.js DataTable 
        /// constructor.
        /// </summary>
        /// <param name="id">Sex</param>
        /// <param name="x">X-axis data point</param>
        /// <param name="y">Y-axis data point</param>
        /// <param name="z">Graph Type</param>
        /// <returns>Returns Body mass index (BMI) for age indicator chart data
        /// as a JSON serialized DataTable structure to pass into Chart.js 
        /// DataTable constructor.</returns>
        /// <example>GET: api/chart/BFA/2/12/17.5/PValue</example>
        [Route("BFA/{id}/{x}/{y}/{z}")]
        public async Task<string> GetAllBFAJson(byte id, byte x, decimal y, GraphTypes z)
        {
            Chart chart = new Chart(_context);
            List<BmiforAge> result = await chart.ListBmiforAgeAsync((Sexes)id, x, y);

            ChartDataTable gChart = new();
            gChart.cols = gChart.GetCols(z, GrowthTypes.BFA);
            gChart.rows = gChart.GetBfaRows(z, GrowthTypes.BFA, result);

            string sJson = JsonSerializer.Serialize(gChart);
            return sJson;
        }

        /// <summary>
        /// Gets Head circumference-for-age indicator chart data as a JSON 
        /// serialized DataTable structure to pass into Chart.js DataTable 
        /// constructor.
        /// </summary>
        /// <param name="id">Sex</param>
        /// <param name="x">X-axis data point</param>
        /// <param name="y">Y-axis data point</param>
        /// <param name="z">Graph Type</param>
        /// <returns>Returns Head circumference-for-age indicator chart data as
        /// a JSON serialized DataTable structure to pass into Chart.js 
        /// DataTable constructor.</returns>
        /// <example>GET: api/Chart/HCFA/1/12/73/ZScore</example>
        [Route("HCFA/{id}/{x}/{y}/{z}")]
        public async Task<string> GetAllHCFAJson(byte id, byte x, decimal y, GraphTypes z)
        {
            Chart chart = new Chart(_context);
            List<HcForAge> result = await chart.ListHcforAge((Sexes)id, x, y);

            ChartDataTable gChart = new();
            gChart.cols = gChart.GetCols(z, GrowthTypes.HCA);
            gChart.rows = gChart.GetHcaRows(z, GrowthTypes.HCA, result);

            string sJson = JsonSerializer.Serialize(gChart);
            return sJson;
        }

        /// <summary>
        /// Gets Length/height-for-age indicator chart data as a JSON 
        /// serialized DataTable structure to pass into Chart.js DataTable 
        /// constructor.
        /// </summary>
        /// <param name="id">Sex</param>
        /// <param name="x">X-axis data point</param>
        /// <param name="y">Y-axis data point</param>
        /// <param name="z">Graph Type</param>
        /// <returns>Returns Length/height-for-age indicator chart data as a 
        /// JSON serialized DataTable structure to pass into Chart.js DataTable
        /// constructor.</returns>
        /// <example>GET: api/Chart/LHFA/2/12/73/PValue</example>
        [Route("LHFA/{id}/{x}/{y}/{z}")]
        public async Task<string> GetAllLHFAJson(byte id, byte x, decimal y, GraphTypes z)
        {
            Chart chart = new Chart(_context);
            List<LengthHeightForAge> result = await chart.ListLengthHeightForAge((Sexes)id, x, y);
           
            ChartDataTable gChart = new();
            gChart.cols = gChart.GetCols(z, GrowthTypes.LHFA);
            gChart.rows = gChart.GetLhfaRows(z, GrowthTypes.LHFA, result);

            string sJson = JsonSerializer.Serialize(gChart);
            return sJson;
        }

        /// <summary>
        /// Gets Arm circumference-for-age indicator chart data as a JSON
        /// serialized DataTable structure to pass into Chart.js DataTable 
        /// constructor.
        /// </summary>
        /// <param name="id">Sex</param>
        /// <param name="x">X-axis data point</param>
        /// <param name="y">Y-axis data point</param>
        /// <param name="z">Graph Type</param>
        /// <returns>Returns Arm circumference-for-age indicator chart data as 
        /// a JSON serialized DataTable structure to pass into Chart.js 
        /// DataTable constructor.</returns>
        /// <example>GET: api/Chart/MUAC/1/12/15/ZScore</example>
        [Route("MUAC/{id}/{x}/{y}/{z}")]
        public async Task<string> GetAllMUACJson(byte id, byte x, decimal y, GraphTypes z)
        {
            Chart chart = new Chart(_context);
            List<MuacforAge> result = await chart.ListMuacforAge((Sexes)id, x, y);

            ChartDataTable gChart = new();
            gChart.cols = gChart.GetCols(z, GrowthTypes.MUAC);
            gChart.rows = gChart.GetMuacRows(z, GrowthTypes.MUAC, result);

            string sJson = JsonSerializer.Serialize(gChart);
            return sJson;
        }

        /// <summary>
        /// Gets Subscapular skinfold-for-age indicator chart data as a JSON
        /// serialized DataTable structure to pass into Chart.js DataTable 
        /// constructor.
        /// </summary>
        /// <param name="id">Sex</param>
        /// <param name="x">X-axis data point</param>
        /// <param name="y">Y-axis data point</param>
        /// <param name="z">Graph Type</param>
        /// <returns>Returns Subscapular skinfold-for-age indicator chart data 
        /// as a JSON serialized DataTable structure to pass into Chart.js 
        /// DataTable constructor.</returns>
        /// <example>GET: api/Chart/SSFA/1/12/7/PValue</example>
        [Route("SSFA/{id}/{x}/{y}/{z}")]
        public async Task<string> GetAllSSFAJson(byte id, byte x, decimal y, GraphTypes z)
        {
            Chart chart = new Chart(_context);
            List<SsfforAge> result = await chart.ListSsfforAge((Sexes)id, x, y);
            
            ChartDataTable gChart = new();
            gChart.cols = gChart.GetCols(z, GrowthTypes.SSF);
            gChart.rows = gChart.GetSsfRows(z, GrowthTypes.SSF, result);

            string sJson = JsonSerializer.Serialize(gChart);
            return sJson;
        }

        /// <summary>
        /// Gets Triceps skinfold-for-age indicator chart data as a JSON 
        /// serialized DataTable structure to pass into Chart.js DataTable 
        /// constructor.
        /// </summary>
        /// <param name="id">Sex</param>
        /// <param name="x">X-axis data point</param>
        /// <param name="y">Y-axis data point</param>
        /// <param name="z">Graph Type</param>
        /// <returns>Returns Triceps skinfold-for-age indicator chart data as a
        /// JSON serialized DataTable structure to pass into Chart.js DataTable 
        /// constructor.</returns>
        /// <example>GET: api/Chart/TSFA/2/12/8/ZScore</example>
        [Route("TSFA/{id}/{x}/{y}/{z}")]
        public async Task<string> GetAllTSFAJson(byte id, byte x, decimal y, GraphTypes z)
        {
            Chart chart = new Chart(_context);
            List<TsfforAge> result = await chart.ListTsfforAge((Sexes)id, x, y);

            ChartDataTable gChart = new();
            gChart.cols = gChart.GetCols(z, GrowthTypes.TSF);
            gChart.rows = gChart.GetTsfRows(z, GrowthTypes.TSF, result);

            string sJson = JsonSerializer.Serialize(gChart);
            return sJson;
        }

        /// <summary>
        /// Gets Weight-for-age indicator chart data as a JSON serialized
        /// DataTable structure to pass into Chart.js DataTable constructor.
        /// </summary>
        /// <param name="id">Sex</param>
        /// <param name="x">X-axis data point</param>
        /// <param name="y">Y-axis data point</param>
        /// <param name="z">Graph Type</param>
        /// <returns>Returns Gets Weight-for-age indicator chart data as a 
        /// JSON serialized DataTable structure to pass into Chart.js DataTable
        /// constructor.</returns>
        /// <example>GET: api/Chart/WFA/1/12/9/PValue</example>
        [Route("WFA/{id}/{x}/{y}/{z}")]
        public async Task<string> GetAllWFAJson(byte id, byte x, decimal y, GraphTypes z)
        {
            Chart chart = new Chart(_context);
            List<WeightForAge> result = await chart.ListWeightForAge((Sexes)id, x, y);

            ChartDataTable gChart = new();
            gChart.cols = gChart.GetCols(z, GrowthTypes.WFA);
            gChart.rows = gChart.GetWfaRows(z, GrowthTypes.WFA, result);

            string sJson = JsonSerializer.Serialize(gChart);
            return sJson;
        }

        /// <summary>
        /// Gets Weight-for-height indicator chart data as a JSON serialized
        /// DataTable structure to pass into Chart.js DataTable constructor.
        /// </summary>
        /// <param name="id">Sex</param>
        /// <param name="x">X-axis data point</param>
        /// <param name="y">Y-axis data point</param>
        /// <param name="z">Graph Type</param>
        /// <returns>Returns Gets Weight-for-height indicator chart data as a 
        /// JSON serialized DataTable structure to pass into Chart.js DataTable
        /// constructor.</returns>
        /// <example>GET: api/Chart/WFH/1/73/9/PValue</example>
        [Route("WFH/{id}/{x}/{y}/{z}")]
        public async Task<string> GetAllWFHJson(byte id, decimal x, decimal y, GraphTypes z)
        {
            Chart chart = new Chart(_context);
            List<WeightForHeight> result = await chart.ListWeightForHeight((Sexes)id, x, y);

            ChartDataTable gChart = new();
            gChart.cols = gChart.GetCols(z, GrowthTypes.WFH);
            gChart.rows = gChart.GetWfhRows(z, GrowthTypes.WFH, result);

            string sJson = JsonSerializer.Serialize(gChart);
            return sJson;
        }

        /// <summary>
        /// Gets Weight-for-length indicator chart data as a JSON serialized
        /// DataTable structure to pass into Chart.js DataTable constructor.
        /// </summary>
        /// <param name="id">Sex</param>
        /// <param name="x">X-axis data point</param>
        /// <param name="y">Y-axis data point</param>
        /// <param name="z">Graph Type</param>
        /// <returns>Returns Gets Weight-for-height indicator chart data as a 
        /// JSON serialized DataTable structure to pass into Chart.js DataTable
        /// constructor.</returns>
        /// <example>GET: api/Chart/WFL/1/73/9/PValue</example>
        [Route("WFL/{id}/{x}/{y}/{z}")]
        public async Task<string> GetAllWFLJson(byte id, decimal x, decimal y, GraphTypes z)
        {
            Chart chart = new(_context);
            List<WeightForLength> result = await chart.ListWeightForLength((Sexes)id, x, y);

            ChartDataTable gChart = new();
            gChart.cols = gChart.GetCols(z, GrowthTypes.WFL);
            gChart.rows = gChart.GetWflRows(z, GrowthTypes.WFL, result);

            string sJson = JsonSerializer.Serialize(gChart);
            return sJson;
        }
    }
}