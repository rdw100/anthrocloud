using System;
using System.Collections.Generic;
using System.Text;

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
        public double Bmi { get; private set; }

        /// <summary>
        /// Creates a BMI object with calculated body mass index.
        /// </summary>
        /// <param name="weight">Body weight</param>
        /// <param name="height">Body height</param>
        public BMI(double weight, double height)
        {
            Weight = weight;
            Height = height;
            Calculate(weight, height);
        }

        /// <summary>
        /// Caclulates body mass index.
        /// </summary>
        /// <param name="weight">Body weight</param>
        /// <param name="height">Body height</param>
        private void Calculate(double weight, double height)
        {
            Bmi = weight / Math.Pow(height / 100.0, 2);
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
