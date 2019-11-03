using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AnthroCloud.Business;

namespace AnthroCloud.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnthroController : ControllerBase
    {
        // GET: api/anthro/age/2016-12-01T00:00:00/2019-12-31T23:59:59
        [Route("AGE/{birth}/{visit}")]
        public string GetAge(DateTime birth, DateTime visit)
        {
            Age age = new Age(birth, visit);
            return age.ToReadableString();
        }

        // GET: api/anthro/age/days/2016-12-01T00:00:00/2019-12-31T23:59:59
        [Route("AGE/DAYS/{birth}/{visit}")]
        public string GetAgeInDays(DateTime birth, DateTime visit)
        {
            Age age = new Age(birth, visit);
            return age.ToDaysString();
        }

        // GET: api/anthro/age/days/2016-12-01T00:00:00/2019-12-31T23:59:59
        [Route("AGE/YEARS/{birth}/{visit}")]
        public string GetAgeInYears(DateTime birth, DateTime visit)
        {
            Age age = new Age(birth, visit);
            return age.ToYearsString();
        }

        // GET: api/anthro/bmi/9.00/73.00
        [Route("BMI/{weight}/{height}")]
        public double GetBMI(double weight, double height)
        {
            BMI bmi = new BMI(weight, height);
            return bmi.ToReadableDouble();
        }

        // POST: api/Anthro
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Anthro/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
