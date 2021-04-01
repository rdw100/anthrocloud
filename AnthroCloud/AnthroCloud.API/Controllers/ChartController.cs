using AnthroCloud.Business;
using AnthroCloud.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
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
        /// Gets a JSON serialized JavaScript string literal object. 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Returns a JSON representation of the DataTable that can be passed into the DataTable constructor.</returns>
        [HttpGet("{id}")]
        [Route("WFLJson/{id}")]
        [Route("WFLJson/{id}/{x}/{y}")]
        public async Task<string> GetAllWFLJson(byte id, decimal x, decimal y)
        {
            Chart chart = new Chart(_context);
            List<WeightForLength> result = await chart.ListWeightForLength((Sexes)id, x, y);
            
            // Select P Columns
            List<WFL_P> wfl = result.Select(x => new WFL_P(x.Lengthincm, x.P3, x.P15, x.P50, x.P85, x.P97, x.Score)).ToList();

            List<Col> cols = new List<Col>()
            {
                    //new Col { id = "sex", label = "Sex", type = "string" },
                    new Col { id = "lengthincm", label = "Lengthincm", type = "number" },
                    //new Col { id = "l", label = "L", type = "number" },
                    //new Col { id = "m", label = "M", type = "number" },
                    //new Col { id = "s", label = "S", type = "number" },
                    //new Col { id = "sd3neg", label = "Sd3neg", type = "number" },
                    //new Col { id = "sd2neg", label = "Sd2neg", type = "number" },
                    //new Col { id = "sd1neg", label = "Sd1neg", type = "number" },
                    //new Col { id = "sd0", label = "Sd0", type = "number" },
                    //new Col { id = "sd1", label = "Sd1", type = "number" },
                    //new Col { id = "sd2", label = "Sd2", type = "number" },
                    //new Col { id = "sd3", label = "Sd3", type = "number" },
                    new Col { id = "p3", label = "P3", type = "number" },
                    new Col { id = "p15", label = "P15", type = "number" },
                    new Col { id = "p50", label = "P50", type = "number" },
                    new Col { id = "p85", label = "P85", type = "number" },
                    new Col { id = "p97", label = "P97", type = "number" },
                    new Col { id = "score", label = "Score", type = "number" },
            };

            List<Row> rows = new List<Row>();
            foreach (var item in wfl)
            {
                rows.Add(new Row
                {
                    c = new List<Cell>()
                    {
                        new Cell { v = item.Lengthincm },
                        new Cell { v = item.P3 },
                        new Cell { v = item.P15 },
                        new Cell { v = item.P50 },
                        new Cell { v = item.P85 },
                        new Cell { v = item.P97 },
                        new Cell { v = item.Score }
                    }
                });
            }

            // Datatable
            DataTable gChart = new DataTable();
            gChart.cols = cols;
            gChart.rows = rows;

            string sJson = JsonSerializer.Serialize(gChart);
            return sJson;
        }
    }
    public class DataTable
    {
        public List<Col> cols { get; set; }
        public List<Row> rows { get; set; }
    }

    public class Col
    {
        public string id { get; set; }
        public string label { get; set; }
        public string type { get; set; }
    }

    public class Cell
    {
        public dynamic v { get; set; }
        //public object f { get; set; }
    }

    public class Row
    {
        public List<Cell> c { get; set; }
    }

    public class WFL_P
    {
        public decimal Lengthincm { get; }
        public decimal P3 { get; }
        public decimal P15 { get; }
        public decimal P50 { get; }
        public decimal P85 { get; }
        public decimal P97 { get; }
        public decimal? Score { get; }

        public WFL_P(decimal lengthincm, decimal p3, decimal p15, decimal p50, decimal p85, decimal p97, decimal? score)
        {
            Lengthincm = lengthincm;
            P3 = p3;
            P15 = p15;
            P50 = p50;
            P85 = p85;
            P97 = p97;
            Score = score;
        }
    }

    //public class Row
    //{
    //    //public int Sex { get; set; }
    //    public double LengthInCm { get; set; }
    //    //public double L { get; set; }
    //    //public double M { get; set; }
    //    //public double S { get; set; }
    //    //public double Sd3neg { get; set; }
    //    //public double Sd2neg { get; set; }
    //    //public double Sd1neg { get; set; }
    //    //public double Sd0 { get; set; }
    //    //public double Sd1 { get; set; }
    //    //public double Sd2 { get; set; }
    //    //public double Sd3 { get; set; }
    //    public double P3 { get; set; }
    //    public double P15 { get; set; }
    //    public double P50 { get; set; }
    //    public double P85 { get; set; }
    //    public double P97 { get; set; }
    //    public double Score { get; set; }
    //}
}