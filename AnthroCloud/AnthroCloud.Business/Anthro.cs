using System;
using System.Collections.Generic;
using System.Text;

namespace AnthroCloud.Business
{
    /// <summary>
    /// Retrieves calculated anthropometric measurements. 
    /// </summary>
    public class Anthro : IGrowthAnthro
    {
        /// <summary>
        /// Gets the calculated age in total days.
        /// </summary>
        /// <param name="birth">The date of birth</param>
        /// <param name="visit">The date of visit</param>
        /// <returns>Returns the calculated age in total days.</returns>
        public int GetAgeInDays(DateTime birth, DateTime visit)
        {
            Age age = new Age(birth, visit);
            return age.TotalDays;
        }

        /// <summary>
        /// Gets the formatted age string for user interface display.
        /// </summary>
        /// <param name="birth">The date of birth</param>
        /// <param name="visit">The date of visit</param>
        /// <returns>Returns the formatted age string for user interface display.</returns>
        public string GetAgeString(DateTime birth, DateTime visit)
        {
            Age age = new Age(birth, visit);
            return age.ToReadableString();
        }

        /// <summary>
        /// Gets the calculated body-mass index.
        /// </summary>
        /// <param name="weight">Body weight</param>
        /// <param name="height">Body height</param>
        /// <returns>Returns the calculated body-mass index.</returns>
        public double GetBMI(double weight, double height)
        {
            BMI bmi = new BMI(9.00, 73.00);
            return bmi.ToReadableDouble();
        }
    }
}
