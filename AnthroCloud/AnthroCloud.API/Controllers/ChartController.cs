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
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        // GET: api/Chart/BFA/1
        [HttpGet("{id}")]
        [Route("BFA/{id}")]
        public List<BmiforAge> GetAllBFA(byte id)
        {
            List<BmiforAge> result = null;

            Chart chart = new Chart();
            result = chart.ListBmiforAge((Sexes)id);

            return result;
        }

        // GET: api/Chart/HCFA/1
        [HttpGet("{id}")]
        [Route("HCFA/{id}")]
        public List<HcForAge> GetAllHCFA(byte id)
        {
            List<HcForAge> result = null;

            Chart chart = new Chart();
            result = chart.ListHcforAge((Sexes)id);

            return result;
        }

        // GET: api/Chart/LHFA/1
        [HttpGet("{id}")]
        [Route("LHFA/{id}")]
        public List<LengthHeightForAge> GetAllLHFA(byte id)
        {
            List<LengthHeightForAge> result = null;

            Chart chart = new Chart();
            result = chart.ListLengthHeightForAge((Sexes)id);

            return result;
        }

        // GET: api/Chart/MUAC/1
        [HttpGet("{id}")]
        [Route("MUAC/{id}")]
        public List<MuacforAge> GetAllMUAC(byte id)
        {
            List<MuacforAge> result = null;

            Chart chart = new Chart();
            result = chart.ListMuacforAge((Sexes)id);

            return result;
        }

        // GET: api/Chart/SSFA/1
        [HttpGet("{id}")]
        [Route("SSFA/{id}")]
        public List<SsfforAge> GetAllSSFA(byte id)
        {
            List<SsfforAge> result = null;

            Chart chart = new Chart();
            result = chart.ListSsfforAge((Sexes)id);

            return result;
        }

        // GET: api/Chart/TSFA/1
        [HttpGet("{id}")]
        [Route("TSFA/{id}")]
        public List<TsfforAge> GetAllTSFA(byte id)
        {
            List<TsfforAge> result = null;

            Chart chart = new Chart();
            result = chart.ListTsfforAge((Sexes)id);

            return result;
        }

        // GET: api/Chart/WFA/1
        [HttpGet("{id}")]
        [Route("WFA/{id}")]
        public List<WeightForAge> GetAllWFA(byte id)
        {
            List<WeightForAge> result = null;

            Chart chart = new Chart();
            result = chart.ListWeightForAge((Sexes)id);

            return result;
        }

        // GET: api/Chart/WFH/1
        [HttpGet("{id}")]
        [Route("WFH/{id}")]
        public List<WeightForHeight> GetAllWFH(byte id)
        {
            List<WeightForHeight> result = null;

            Chart chart = new Chart();
            result = chart.ListWeightForHeight((Sexes)id);

            return result;
        }

        // GET: api/Chart/WFL/1
        [HttpGet("{id}")]
        [Route("WFL/{id}")]
        public List<WeightForLength> GetAllWFL(byte id)
        {
            List<WeightForLength> result = null;

            Chart chart = new Chart();
            result = chart.ListWeightForLength((Sexes)id);

            return result;
        }

        ////// GET: api/Chart
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Chart/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Chart
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Chart/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
