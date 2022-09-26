﻿using AnthroCloud.Business;
using Microsoft.AspNetCore.Mvc;

namespace AnthroCloud.API.Controllers
{
    /// <summary>
    /// Provides anthropometric calculations for display individual measurements.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AnthroController : ControllerBase
    {
        /// <summary>
        /// Gets a human readable string in either Months or Year-Month (TotalMonths) format.
        /// </summary>
        /// <param name="birth">Birth date</param>
        /// <param name="visit">Visit date</param>
        /// <returns>Returns a human readable string in either Months or Year-Month (TotalMonths) format.</returns>
        /// <example>GET: api/anthro/age/2016-12-01T00:00:00/2019-12-31T23:59:59</example>
        [Route("AGE/{birth}/{visit}")]
        [HttpGet]
        public string GetAge(DateTime birth, DateTime visit)
        {
            Age age = new Age(birth, visit);
            return age.ToReadableString();
        }

        /// <summary>
        /// Gets string of age in total days.
        /// </summary>
        /// <param name="birth">Birth date</param>
        /// <param name="visit">Visit date</param>
        /// <returns>Returns string of age in total days.</returns>
        /// <example>GET: api/anthro/age/days/2016-12-01T00:00:00/2019-12-31T23:59:59</example>
        [Route("AGE/DAYS/{birth}/{visit}")]
        [HttpGet]
        public string GetAgeInDays(DateTime birth, DateTime visit)
        {
            Age age = new Age(birth, visit);
            return age.ToDaysString();
        }

        /// <summary>
        /// Gets string of age in total months.
        /// </summary>
        /// <param name="birth">Birth date</param>
        /// <param name="visit">Visit date</param>
        /// <returns>Returns string of age in total months.</returns>
        /// <example>GET: api/anthro/age/months/2016-12-01T00:00:00/2019-12-31T23:59:59</example>
        [Route("AGE/MONTHS/{birth}/{visit}")]
        [HttpGet]
        public string GetAgeInMonths(DateTime birth, DateTime visit)
        {
            Age age = new Age(birth, visit);
            return age.ToMonthsString();
        }

        /// <summary>
        /// Gets string of age in years.
        /// </summary>
        /// <param name="birth">Birth date</param>
        /// <param name="visit">Visit date</param>
        /// <returns>Returns string of age in years.</returns>
        /// <example>GET: api/anthro/age/years/2016-12-01T00:00:00/2019-12-31T23:59:59</example>
        [Route("AGE/YEARS/{birth}/{visit}")]
        [HttpGet]
        public string GetAgeInYears(DateTime birth, DateTime visit)
        {
            Age age = new Age(birth, visit);
            return age.ToYearsString();
        }

        /// <summary>
        /// Gets body mass divided by the square of the body height
        /// </summary>
        /// <param name="weight">Body weight</param>
        /// <param name="height">Body height</param>
        /// <returns>Returns body mass divided by the square of the body height</returns>
        /// <example>GET: api/anthro/bmi/9.00/73.00</example>
        [Route("BMI/{weight}/{height}")]
        [HttpGet]
        public double GetBMI(double weight, double height)
        {
            BMI bmi = new BMI(weight, height);
            return bmi.Bmi;
        }

        /// <summary>
        /// Gets a human readable string in either Months or Year-Month (TotalMonths) format asynchronously.
        /// </summary>
        /// <param name="birth">Birth date</param>
        /// <param name="visit">Visit date</param>
        /// <returns>Returns a human readable string in either Months or Year-Month (TotalMonths) format.</returns>
        /// <example>GET: api/anthro/age/2016-12-01T00:00:00/2019-12-31T23:59:59</example>
        [Route("AgeObjectAsync/{birth}/{visit}")]
        [HttpGet]
        public async Task<Age> GetAgeObjectAsync(DateTime birth, DateTime visit)
        {
            Age age = new Age(birth, visit);
            _ = await age.Calculate(birth, visit);
            return age;
        }

        /// <summary>
        /// Gets body mass divided by the square of the body height asynchronously.
        /// </summary>
        /// <param name="weight">Body weight</param>
        /// <param name="height">Body height</param>
        /// <returns>Returns body mass divided by the square of the body height</returns>
        /// <example>GET: api/anthro/bmi/9.00/73.00</example>
        [Route("BMIAsync/{weight}/{height}")]
        [HttpGet]
        public async Task<double> GetBMIAsync(double weight, double height)
        {
            BMI bmi = new BMI();
            _ = await bmi.Calculate(weight, height);
            return bmi.Bmi;
        }
    }
}
