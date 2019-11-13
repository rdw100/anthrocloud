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
        // GET: api/chart/BFA/1/12/16.9
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

        // GET: api/Chart/HCFA/1
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

        // GET: api/Chart/LHFA/1
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

        // GET: api/Chart/MUAC/1
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

        // GET: api/Chart/SSFA/1
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

        // GET: api/Chart/TSFA/1
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

        // GET: api/Chart/WFA/1
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

        // GET: api/Chart/WFH/1
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

        // GET: api/Chart/WFL/1
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
