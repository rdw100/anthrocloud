using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnthroCloud.Business
{
    /// <summary>
    /// Calculates the BMI as body mass divided by the square of the body height 
    /// and is universally expressed in units of kg/m2, resulting from the mass 
    /// in kilograms and height in meters.
    /// </summary>
    public class BMI
    {
        /// <summary>
        /// Body weight in kilograms (kg)
        /// </summary>
        public double Weight { get; private set; }

        /// <summary>
        /// Height in centimeters (cm)
        /// </summary>
        public double Height { get; private set; }

        /// <summary>
        /// Body mass divided by the square of the body height
        /// </summary>
        public double Bmi { get; set; }

        public BMI() { }

        /// <summary>
        /// Creates a BMI object with calculated body mass index.
        /// </summary>
        /// <param name="weight">Body weight</param>
        /// <param name="height">Body height</param>
        public BMI(double weight, double height)
        {
            Weight = weight;
            Height = height;
            _ = Calculate(weight, height);
        }

        /// <summary>
        /// Gets and sets the calculated BMI property. 
        /// </summary>
        /// <param name="weight">Body weight</param>
        /// <param name="height">Body height</param>
        public async Task<double> Calculate(double weight, double height)
        {
            Bmi = await Task.FromResult(CalculateBMI(weight, height));
            return Bmi;
        }

        /// <summary>
        /// Calculates body mass index.
        /// </summary>
        /// <param name="weight">The weight.</param>
        /// <param name="height">The height.</param>
        /// <returns>Return BMI.</returns>
        private static double CalculateBMI(double weight, double height)
        {
            double bmi = (weight / Math.Pow(height / 100.0, 2));
            return bmi;
        }

        /// <summary>
        /// Rounds the calculated BMI.
        /// </summary>
        /// <returns>Returns BMI rounded to tenths.</returns>
        public double ToReadableDouble()
        {
            double bmi = Math.Round(Bmi, 1);//Bmi;
            return bmi;
        }
    }
}
