using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AnthroCloud.Business;
using AnthroCloud.Entities;

namespace AnthroCloud.API.Controllers
{
    /// <summary>
    /// Provides chart data for display individual measurements.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {

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
        public List<BmiforAge> GetAllBFA(byte id, byte x, decimal y)
        {
            List<BmiforAge> result = null;

            Chart chart = new Chart();
            result = chart.ListBmiforAge((Sexes)id, x, y);

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
        public List<HcForAge> GetAllHCFA(byte id, byte x, decimal y)
        {
            List<HcForAge> result = null;

            Chart chart = new Chart();
            result = chart.ListHcforAge((Sexes)id, x, y);

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
        public List<LengthHeightForAge> GetAllLHFA(byte id, byte x, decimal y)
        {
            List<LengthHeightForAge> result = null;

            Chart chart = new Chart();
            result = chart.ListLengthHeightForAge((Sexes)id, x, y);

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
        public List<MuacforAge> GetAllMUAC(byte id, byte x, decimal y)
        {
            List<MuacforAge> result = null;

            Chart chart = new Chart();
            result = chart.ListMuacforAge((Sexes)id, x, y);

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
        public List<SsfforAge> GetAllSSFA(byte id, byte x, decimal y)
        {
            List<SsfforAge> result = null;

            Chart chart = new Chart();
            result = chart.ListSsfforAge((Sexes)id, x, y);

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
        public List<TsfforAge> GetAllTSFA(byte id, byte x, decimal y)
        {
            List<TsfforAge> result = null;

            Chart chart = new Chart();
            result = chart.ListTsfforAge((Sexes)id, x, y );

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
        public List<WeightForAge> GetAllWFA(byte id, byte x, decimal y)
        {
            List<WeightForAge> result = null;

            Chart chart = new Chart();
            result = chart.ListWeightForAge((Sexes)id, x, y);

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
        public List<WeightForHeight> GetAllWFH(byte id, decimal x, decimal y)
        {
            List<WeightForHeight> result = null;

            Chart chart = new Chart();
            result = chart.ListWeightForHeight((Sexes)id, x, y);

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
        public List<WeightForLength> GetAllWFL(byte id, decimal x, decimal y)
        {
            List<WeightForLength> result = null;

            Chart chart = new Chart();
            result = chart.ListWeightForLength((Sexes)id, x, y);

            return result;
        }
    }
}